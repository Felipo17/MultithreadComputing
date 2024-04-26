namespace ImageProcessingApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PictureBox = new PictureBox();
            PictureBoxThresholded = new PictureBox();
            PictureBoxNegated = new PictureBox();
            PictureBoxBrightened = new PictureBox();
            PictureBoxEdges = new PictureBox();
            LoadImageButton = new Button();
            ApplyFiltersButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxThresholded).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxNegated).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxBrightened).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxEdges).BeginInit();
            SuspendLayout();
            // 
            // PictureBox
            // 
            PictureBox.Location = new Point(12, 12);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(350, 425);
            PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox.TabIndex = 0;
            PictureBox.TabStop = false;
            // 
            // PictureBoxThresholded
            // 
            PictureBoxThresholded.Location = new Point(536, 12);
            PictureBoxThresholded.Name = "PictureBoxThresholded";
            PictureBoxThresholded.Size = new Size(201, 202);
            PictureBoxThresholded.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBoxThresholded.TabIndex = 1;
            PictureBoxThresholded.TabStop = false;
            // 
            // PictureBoxNegated
            // 
            PictureBoxNegated.Location = new Point(743, 12);
            PictureBoxNegated.Name = "PictureBoxNegated";
            PictureBoxNegated.Size = new Size(201, 202);
            PictureBoxNegated.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBoxNegated.TabIndex = 2;
            PictureBoxNegated.TabStop = false;
            // 
            // PictureBoxBrightened
            // 
            PictureBoxBrightened.Location = new Point(536, 235);
            PictureBoxBrightened.Name = "PictureBoxBrightened";
            PictureBoxBrightened.Size = new Size(201, 202);
            PictureBoxBrightened.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBoxBrightened.TabIndex = 3;
            PictureBoxBrightened.TabStop = false;
            // 
            // PictureBoxEdges
            // 
            PictureBoxEdges.Location = new Point(743, 235);
            PictureBoxEdges.Name = "PictureBoxEdges";
            PictureBoxEdges.Size = new Size(201, 202);
            PictureBoxEdges.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBoxEdges.TabIndex = 4;
            PictureBoxEdges.TabStop = false;
            // 
            // LoadImageButton
            // 
            LoadImageButton.Location = new Point(395, 153);
            LoadImageButton.Name = "LoadImageButton";
            LoadImageButton.Size = new Size(108, 61);
            LoadImageButton.TabIndex = 5;
            LoadImageButton.Text = "Load Image";
            LoadImageButton.UseVisualStyleBackColor = true;
            LoadImageButton.Click += LoadImageButton_Click;
            // 
            // ApplyFiltersButton
            // 
            ApplyFiltersButton.Location = new Point(395, 235);
            ApplyFiltersButton.Name = "ApplyFiltersButton";
            ApplyFiltersButton.Size = new Size(108, 61);
            ApplyFiltersButton.TabIndex = 6;
            ApplyFiltersButton.Text = "Apply filters";
            ApplyFiltersButton.UseVisualStyleBackColor = true;
            ApplyFiltersButton.Click += ApplyFiltersButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "\"jpg files (*.jpg)|*.jpg|All files (*.*)|*.*\"";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 449);
            Controls.Add(ApplyFiltersButton);
            Controls.Add(LoadImageButton);
            Controls.Add(PictureBoxEdges);
            Controls.Add(PictureBoxBrightened);
            Controls.Add(PictureBoxNegated);
            Controls.Add(PictureBoxThresholded);
            Controls.Add(PictureBox);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxThresholded).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxNegated).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxBrightened).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxEdges).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PictureBox;
        private PictureBox PictureBoxThresholded;
        private PictureBox PictureBoxNegated;
        private PictureBox PictureBoxBrightened;
        private PictureBox PictureBoxEdges;
        private Button LoadImageButton;
        private Button ApplyFiltersButton;
        private OpenFileDialog openFileDialog1;
    }
}
