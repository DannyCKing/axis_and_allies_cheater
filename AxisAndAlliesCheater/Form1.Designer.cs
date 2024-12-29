namespace AxisAndAlliesCheater
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ChooseFileButton = new System.Windows.Forms.Button();
            this.UpdateFileButton = new System.Windows.Forms.Button();
            this.ChosenFileTextBox = new System.Windows.Forms.TextBox();
            this.MakeCopyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OriginalFormattedFileTextBox = new System.Windows.Forms.TextBox();
            this.MyNameFileTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StartChangesButton = new System.Windows.Forms.Button();
            this.OverwriteOriginalButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ChooseFileButton
            // 
            this.ChooseFileButton.Location = new System.Drawing.Point(32, 23);
            this.ChooseFileButton.Name = "ChooseFileButton";
            this.ChooseFileButton.Size = new System.Drawing.Size(179, 55);
            this.ChooseFileButton.TabIndex = 0;
            this.ChooseFileButton.Text = "Choose File";
            this.ChooseFileButton.UseVisualStyleBackColor = true;
            this.ChooseFileButton.Click += new System.EventHandler(this.ChooseFileButton_Click);
            // 
            // UpdateFileButton
            // 
            this.UpdateFileButton.Location = new System.Drawing.Point(35, 154);
            this.UpdateFileButton.Name = "UpdateFileButton";
            this.UpdateFileButton.Size = new System.Drawing.Size(176, 55);
            this.UpdateFileButton.TabIndex = 1;
            this.UpdateFileButton.Text = "Read In File";
            this.UpdateFileButton.UseVisualStyleBackColor = true;
            this.UpdateFileButton.Click += new System.EventHandler(this.ReadFileButton_Click);
            // 
            // ChosenFileTextBox
            // 
            this.ChosenFileTextBox.Location = new System.Drawing.Point(404, 34);
            this.ChosenFileTextBox.Name = "ChosenFileTextBox";
            this.ChosenFileTextBox.ReadOnly = true;
            this.ChosenFileTextBox.Size = new System.Drawing.Size(808, 26);
            this.ChosenFileTextBox.TabIndex = 2;
            // 
            // MakeCopyButton
            // 
            this.MakeCopyButton.Location = new System.Drawing.Point(35, 276);
            this.MakeCopyButton.Name = "MakeCopyButton";
            this.MakeCopyButton.Size = new System.Drawing.Size(176, 55);
            this.MakeCopyButton.TabIndex = 3;
            this.MakeCopyButton.Text = "Make Copy";
            this.MakeCopyButton.UseVisualStyleBackColor = true;
            this.MakeCopyButton.Click += new System.EventHandler(this.MakeCopyButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Original File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Original Formatted File";
            // 
            // OriginalFormattedFileTextBox
            // 
            this.OriginalFormattedFileTextBox.Location = new System.Drawing.Point(404, 165);
            this.OriginalFormattedFileTextBox.Name = "OriginalFormattedFileTextBox";
            this.OriginalFormattedFileTextBox.ReadOnly = true;
            this.OriginalFormattedFileTextBox.Size = new System.Drawing.Size(808, 26);
            this.OriginalFormattedFileTextBox.TabIndex = 6;
            // 
            // MyNameFileTextBox
            // 
            this.MyNameFileTextBox.Location = new System.Drawing.Point(404, 287);
            this.MyNameFileTextBox.Name = "MyNameFileTextBox";
            this.MyNameFileTextBox.ReadOnly = true;
            this.MyNameFileTextBox.Size = new System.Drawing.Size(808, 26);
            this.MyNameFileTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "My New File";
            // 
            // StartChangesButton
            // 
            this.StartChangesButton.Location = new System.Drawing.Point(35, 384);
            this.StartChangesButton.Name = "StartChangesButton";
            this.StartChangesButton.Size = new System.Drawing.Size(176, 55);
            this.StartChangesButton.TabIndex = 9;
            this.StartChangesButton.Text = "Start Changes";
            this.StartChangesButton.UseVisualStyleBackColor = true;
            this.StartChangesButton.Click += new System.EventHandler(this.StartChangesButton_Click);
            // 
            // OverwriteOriginalButton
            // 
            this.OverwriteOriginalButton.Location = new System.Drawing.Point(35, 499);
            this.OverwriteOriginalButton.Name = "OverwriteOriginalButton";
            this.OverwriteOriginalButton.Size = new System.Drawing.Size(176, 55);
            this.OverwriteOriginalButton.TabIndex = 10;
            this.OverwriteOriginalButton.Text = "Overwrite Original";
            this.OverwriteOriginalButton.UseVisualStyleBackColor = true;
            this.OverwriteOriginalButton.Click += new System.EventHandler(this.OverwriteOriginalButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 583);
            this.Controls.Add(this.OverwriteOriginalButton);
            this.Controls.Add(this.StartChangesButton);
            this.Controls.Add(this.MyNameFileTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OriginalFormattedFileTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MakeCopyButton);
            this.Controls.Add(this.ChosenFileTextBox);
            this.Controls.Add(this.UpdateFileButton);
            this.Controls.Add(this.ChooseFileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ChooseFileButton;
        private System.Windows.Forms.Button UpdateFileButton;
        private System.Windows.Forms.TextBox ChosenFileTextBox;
        private System.Windows.Forms.Button MakeCopyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OriginalFormattedFileTextBox;
        private System.Windows.Forms.TextBox MyNameFileTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button StartChangesButton;
        private System.Windows.Forms.Button OverwriteOriginalButton;
    }
}

