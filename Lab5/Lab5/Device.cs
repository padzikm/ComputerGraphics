using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using System.Drawing;
using System.Windows.Forms;

namespace Lab5
{    
    
        public class Device
        {
            private byte[] backBuffer;
            private Bitmap bmp;
            private PictureBox pictureBox;
            private Vector2[] list;

            public Device(Bitmap bmp, PictureBox pictureBox)
            {
                this.bmp = bmp;
                this.pictureBox = pictureBox;
                list = new Vector2[8];
                backBuffer = new byte[bmp.Width * bmp.Height * 4];
            }
            
            public void Clear(byte r, byte g, byte b, byte a)
            {                
                for (int i = 0; i < bmp.Width; ++i)
                    for (int j = 0; j < bmp.Height; ++j)
                        bmp.SetPixel(i, j, System.Drawing.Color.FromArgb(a, r, g, b));
            }
            
            public void PutPixel(int x, int y, Color4 color)
            {                
                System.Drawing.Color c = System.Drawing.Color.FromArgb((int)color.Alpha, (int)color.Red, (int)color.Green, (int)color.Blue);
                bmp.SetPixel(x, y, c);
            }
            
            public Vector2 Project(Vector3 coord, Matrix transMat)
            {                
                var point = Vector3.TransformCoordinate(coord, transMat);                
                var x = point.X * bmp.Width + bmp.Width / 2.0f;
                var y = -point.Y * bmp.Height + bmp.Height / 2.0f;
                return (new Vector2(x, y));
            }
            
            public void DrawPoint(Vector2 point)
            {                
                if (point.X >= 0 && point.Y >= 0 && point.X < bmp.Width && point.Y < bmp.Height)
                {                    
                    PutPixel((int)point.X, (int)point.Y, new Color4(1.0f, 1.0f, 0.0f, 1.0f));
                }
            }
            
            public void Render(Camera camera, params Mesh[] meshes)
            {                
                var viewMatrix = Matrix.LookAtLH(camera.Position, camera.Target, Vector3.UnitY);
                var projectionMatrix = Matrix.PerspectiveFovRH(0.78f,
                                                               (float)bmp.Width / bmp.Height,
                                                               0.01f, 1.0f);

                foreach (Mesh mesh in meshes)
                {                    
                    var worldMatrix = Matrix.RotationYawPitchRoll(mesh.Rotation.Y, mesh.Rotation.X, mesh.Rotation.Z) *
                                      Matrix.Translation(mesh.Position);

                    var transformMatrix = worldMatrix * viewMatrix * projectionMatrix;

                    int i = 0;                    
                    
                    foreach (var vertex in mesh.Vertices)
                    {                        
                        var point = Project(vertex, transformMatrix);
                        list[i] = point;
                        ++i;
                        DrawPoint(point);
                        //++odd;
                        //if (odd == 1)
                        //{
                        //    Pen blackPen = new Pen(System.Drawing.Color.Yellow, 3);
                        //    using (var graphics = Graphics.FromImage(bmp))
                        //    {
                        //        graphics.DrawLine(blackPen, p.X, p.Y, point.X, point.Y);
                        //    }
                        //    odd = 0;
                        //}
                        //++odd;
                        //p = point;
                    }
                    Pen blackPen = new Pen(System.Drawing.Color.Yellow, 3);
                    using (var graphics = Graphics.FromImage(bmp))
                            {
                                graphics.DrawLine(blackPen, list[0].X, list[0].Y, list[1].X, list[1].Y);
                                graphics.DrawLine(blackPen, list[0].X, list[0].Y, list[2].X, list[2].Y);
                                graphics.DrawLine(blackPen, list[0].X, list[0].Y, list[4].X, list[4].Y);
                                graphics.DrawLine(blackPen, list[1].X, list[1].Y, list[5].X, list[5].Y);
                                graphics.DrawLine(blackPen, list[1].X, list[1].Y, list[6].X, list[6].Y);
                                graphics.DrawLine(blackPen, list[2].X, list[2].Y, list[3].X, list[3].Y);
                                graphics.DrawLine(blackPen, list[2].X, list[2].Y, list[6].X, list[6].Y);
                                graphics.DrawLine(blackPen, list[3].X, list[3].Y, list[4].X, list[4].Y);
                                graphics.DrawLine(blackPen, list[3].X, list[3].Y, list[7].X, list[7].Y);
                                graphics.DrawLine(blackPen, list[4].X, list[4].Y, list[5].X, list[5].Y);
                                graphics.DrawLine(blackPen, list[5].X, list[5].Y, list[7].X, list[7].Y);
                                graphics.DrawLine(blackPen, list[6].X, list[6].Y, list[7].X, list[7].Y);
                            }
                }
            }        
    }
}
