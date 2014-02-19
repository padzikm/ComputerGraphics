namespace Lab2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clipButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fillColorButton = new System.Windows.Forms.Button();
            this.fillTextureButton = new System.Windows.Forms.Button();
            this.drawPolygonButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // clipButton
            // 
            this.clipButton.Location = new System.Drawing.Point(13, 13);
            this.clipButton.Name = "clipButton";
            this.clipButton.Size = new System.Drawing.Size(75, 23);
            this.clipButton.TabIndex = 0;
            this.clipButton.Text = "Clip figure";
            this.clipButton.UseVisualStyleBackColor = true;
            this.clipButton.Click += new System.EventHandler(this.clipButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(128, 12);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(795, 611);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // fillColorButton
            // 
            this.fillColorButton.Location = new System.Drawing.Point(240, 12);
            this.fillColorButton.Name = "fillColorButton";
            this.fillColorButton.Size = new System.Drawing.Size(75, 23);
            this.fillColorButton.TabIndex = 3;
            this.fillColorButton.Text = "Fill color";
            this.fillColorButton.UseVisualStyleBackColor = true;
            this.fillColorButton.Click += new System.EventHandler(this.fillColorButton_Click);
            // 
            // fillTextureButton
            // 
            this.fillTextureButton.Location = new System.Drawing.Point(366, 12);
            this.fillTextureButton.Name = "fillTextureButton";
            this.fillTextureButton.Size = new System.Drawing.Size(75, 23);
            this.fillTextureButton.TabIndex = 4;
            this.fillTextureButton.Text = "Fill texture";
            this.fillTextureButton.UseVisualStyleBackColor = true;
            this.fillTextureButton.Click += new System.EventHandler(this.fillTextureButton_Click);
            // 
            // drawPolygonButton
            // 
            this.drawPolygonButton.Location = new System.Drawing.Point(479, 11);
            this.drawPolygonButton.Name = "drawPolygonButton";
            this.drawPolygonButton.Size = new System.Drawing.Size(75, 23);
            this.drawPolygonButton.TabIndex = 5;
            this.drawPolygonButton.Text = "Draw polygon";
            this.drawPolygonButton.UseVisualStyleBackColor = true;
            this.drawPolygonButton.Click += new System.EventHandler(this.drawPolygonButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 676);
            this.Controls.Add(this.drawPolygonButton);
            this.Controls.Add(this.fillTextureButton);
            this.Controls.Add(this.fillColorButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.clipButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clipButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button fillColorButton;
        private System.Windows.Forms.Button fillTextureButton;
        private System.Windows.Forms.Button drawPolygonButton;
    }
}

