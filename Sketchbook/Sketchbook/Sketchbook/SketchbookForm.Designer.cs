namespace Sketchbook
{
    partial class SketchbookForm
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
            this.sketchbookArea = new System.Windows.Forms.PictureBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.clearAllButton = new System.Windows.Forms.Button();
            this.selectedFigureComboBox = new System.Windows.Forms.ComboBox();
            this.selectedActionComboBox = new System.Windows.Forms.ComboBox();
            this.selectedColorComboBox = new System.Windows.Forms.ComboBox();
            this.lineThicknessTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sketchbookArea)).BeginInit();
            this.SuspendLayout();
            // 
            // sketchbookArea
            // 
            this.sketchbookArea.BackColor = System.Drawing.Color.White;
            this.sketchbookArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sketchbookArea.Location = new System.Drawing.Point(12, 50);
            this.sketchbookArea.Name = "sketchbookArea";
            this.sketchbookArea.Size = new System.Drawing.Size(1330, 530);
            this.sketchbookArea.TabIndex = 0;
            this.sketchbookArea.TabStop = false;
            this.sketchbookArea.Paint += new System.Windows.Forms.PaintEventHandler(this.sketchbookArea_Paint);
            this.sketchbookArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sketchbookArea_MouseClick);
            this.sketchbookArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sketchbookArea_MouseDown);
            this.sketchbookArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sketchbookArea_MouseUp);
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(12, 12);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(75, 23);
            this.drawButton.TabIndex = 1;
            this.drawButton.Text = "Draw";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // clearAllButton
            // 
            this.clearAllButton.Location = new System.Drawing.Point(122, 12);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(75, 23);
            this.clearAllButton.TabIndex = 2;
            this.clearAllButton.Text = "Clear all";
            this.clearAllButton.UseVisualStyleBackColor = true;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // selectedFigureComboBox
            // 
            this.selectedFigureComboBox.FormattingEnabled = true;
            this.selectedFigureComboBox.Items.AddRange(new object[] {
            "New figure",
            "All"});
            this.selectedFigureComboBox.Location = new System.Drawing.Point(373, 13);
            this.selectedFigureComboBox.Name = "selectedFigureComboBox";
            this.selectedFigureComboBox.Size = new System.Drawing.Size(121, 21);
            this.selectedFigureComboBox.TabIndex = 3;
            this.selectedFigureComboBox.SelectedIndexChanged += new System.EventHandler(this.selectedFigureComboBox_SelectedIndexChanged);
            // 
            // selectedActionComboBox
            // 
            this.selectedActionComboBox.FormattingEnabled = true;
            this.selectedActionComboBox.Items.AddRange(new object[] {
            "AddVertex",
            "MoveVertex",
            "RemoveVertex"});
            this.selectedActionComboBox.Location = new System.Drawing.Point(568, 13);
            this.selectedActionComboBox.Name = "selectedActionComboBox";
            this.selectedActionComboBox.Size = new System.Drawing.Size(121, 21);
            this.selectedActionComboBox.TabIndex = 4;
            this.selectedActionComboBox.SelectedIndexChanged += new System.EventHandler(this.selectedActionComboBox_SelectedIndexChanged);
            // 
            // selectedColorComboBox
            // 
            this.selectedColorComboBox.FormattingEnabled = true;
            this.selectedColorComboBox.Items.AddRange(new object[] {
            "Black",
            "Red",
            "Green",
            "Blue"});
            this.selectedColorComboBox.Location = new System.Drawing.Point(753, 11);
            this.selectedColorComboBox.Name = "selectedColorComboBox";
            this.selectedColorComboBox.Size = new System.Drawing.Size(121, 21);
            this.selectedColorComboBox.TabIndex = 5;
            this.selectedColorComboBox.SelectedIndexChanged += new System.EventHandler(this.selectedColorComboBox_SelectedIndexChanged);
            // 
            // lineThicknessTextBox
            // 
            this.lineThicknessTextBox.Location = new System.Drawing.Point(949, 11);
            this.lineThicknessTextBox.Name = "lineThicknessTextBox";
            this.lineThicknessTextBox.Size = new System.Drawing.Size(100, 20);
            this.lineThicknessTextBox.TabIndex = 6;
            this.lineThicknessTextBox.Text = "1";
            this.lineThicknessTextBox.TextChanged += new System.EventHandler(this.lineThicknessTextBox_TextChanged);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(235, 11);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // SketchbookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 592);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.lineThicknessTextBox);
            this.Controls.Add(this.selectedColorComboBox);
            this.Controls.Add(this.selectedActionComboBox);
            this.Controls.Add(this.selectedFigureComboBox);
            this.Controls.Add(this.clearAllButton);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.sketchbookArea);
            this.Name = "SketchbookForm";
            this.Text = "SketchbookForm";
            ((System.ComponentModel.ISupportInitialize)(this.sketchbookArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sketchbookArea;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.ComboBox selectedFigureComboBox;
        private System.Windows.Forms.ComboBox selectedActionComboBox;
        private System.Windows.Forms.ComboBox selectedColorComboBox;
        private System.Windows.Forms.TextBox lineThicknessTextBox;
        private System.Windows.Forms.Button clearButton;
    }
}