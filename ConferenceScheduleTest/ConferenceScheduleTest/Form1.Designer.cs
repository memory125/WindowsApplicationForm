namespace ConferenceScheduleTest
{
    partial class Conference
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
            this.fileLabel = new System.Windows.Forms.Label();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.fileButton = new System.Windows.Forms.Button();
            this.resultListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(38, 35);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(26, 13);
            this.fileLabel.TabIndex = 0;
            this.fileLabel.Text = "File:";
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(82, 32);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(286, 20);
            this.fileTextBox.TabIndex = 1;
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(374, 30);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(59, 23);
            this.fileButton.TabIndex = 2;
            this.fileButton.Text = "Browser";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // resultListBox
            // 
            this.resultListBox.FormattingEnabled = true;
            this.resultListBox.Location = new System.Drawing.Point(44, 73);
            this.resultListBox.Name = "resultListBox";
            this.resultListBox.Size = new System.Drawing.Size(389, 238);
            this.resultListBox.TabIndex = 3;
            // 
            // Conference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 355);
            this.Controls.Add(this.resultListBox);
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.fileLabel);
            this.Name = "Conference";
            this.Text = "Conference Schedule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.ListBox resultListBox;
    }
}

