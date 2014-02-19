using SharpDX;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Padzikm5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Device device;
        Mesh[] meshes;
        Camera mera = new Camera();
        DateTime previousDate;
        private Collection<double> lastFPSValues = new Collection<double>();
        private bool dragging = false;
        private PointerPoint pointClicked;
        private float X = 0.0f;
        private float Y = 0.0f;
        public static float zoom = 2.0f;

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Choose the back buffer resolution here
            WriteableBitmap bmp = new WriteableBitmap((int)ActualWidth, (int)ActualHeight);

            // Our Image XAML control
            frontBuffer.Source = bmp;

            device = new Device(bmp);
            meshes = await device.LoadJSONFileAsync("robot.babylon");
            mera.Position = new Vector3(0, 0, 10.0f);
            mera.Target = Vector3.Zero;

            // Registering to the XAML rendering loop
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        // Rendering loop handler
        void CompositionTarget_Rendering(object sender, object e)
        {
            device.Clear(0, 0, 0, 255);

            foreach (var mesh in meshes)
            {
                mesh.Rotation = new Vector3(mesh.Rotation.X + X, mesh.Rotation.Y + Y, mesh.Rotation.Z);
                if (mesh.Rotation.X >= 360.0f)
                    mesh.Rotation = new Vector3(0f, mesh.Rotation.Y, mesh.Rotation.Z);
                if (mesh.Rotation.X <= -360.0f)
                    mesh.Rotation = new Vector3(0f, mesh.Rotation.Y, mesh.Rotation.Z);
                if (mesh.Rotation.Y >= 360.0f)
                    mesh.Rotation = new Vector3(mesh.Rotation.X, 0f, mesh.Rotation.Z);
                if (mesh.Rotation.Y <= -360.0f)
                    mesh.Rotation = new Vector3(mesh.Rotation.X, 0f, mesh.Rotation.Z);
            }

            device.Render(mera, meshes);
            device.Present();
        }

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void frontBuffer_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            dragging = true;
            pointClicked = e.GetCurrentPoint(frontBuffer);
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void frontBuffer_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint pointMove = e.GetCurrentPoint(frontBuffer);
            if (dragging)
            {
                if (pointClicked.Position.X - pointMove.Position.X > 0)
                    X = X - 0.001f;
                else if (pointClicked.Position.X - pointMove.Position.X < 0)
                    X = X + 0.001f;

                if (pointClicked.Position.Y - pointMove.Position.Y > 0)
                    Y = Y - 0.001f;
                else if (pointClicked.Position.Y - pointMove.Position.Y < 0)
                    Y = Y + 0.001f;
            }
        }

        private void frontBuffer_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            dragging = false;
            X = 0.0f;
            Y = 0.0f;
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 0);
        }

        private void frontBuffer_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            if (e.GetCurrentPoint(frontBuffer).Properties.MouseWheelDelta < 0)
                zoom = zoom + 0.1f;
            else
                zoom = zoom - 0.1f;
        }
    }
}
