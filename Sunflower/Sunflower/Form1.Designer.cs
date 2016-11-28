namespace Sunflower
{
    partial class SunflowerForm
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
            this.widthLabel = new System.Windows.Forms.Label();
            this.widthTxt = new System.Windows.Forms.TextBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.lengthTxt = new System.Windows.Forms.TextBox();
            this.materialLabel = new System.Windows.Forms.Label();
            this.materialComboBox = new System.Windows.Forms.ComboBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.amountTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(47, 39);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 0;
            this.widthLabel.Text = "Width";
            // 
            // widthTxt
            // 
            this.widthTxt.Location = new System.Drawing.Point(100, 35);
            this.widthTxt.Name = "widthTxt";
            this.widthTxt.Size = new System.Drawing.Size(121, 20);
            this.widthTxt.TabIndex = 1;
            this.widthTxt.TextChanged += new System.EventHandler(this.widthTxt_TextChanged);
            this.widthTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.widthTxt_KeyPress);
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(44, 75);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(40, 13);
            this.lengthLabel.TabIndex = 2;
            this.lengthLabel.Text = "Length";
            // 
            // lengthTxt
            // 
            this.lengthTxt.Location = new System.Drawing.Point(100, 71);
            this.lengthTxt.Name = "lengthTxt";
            this.lengthTxt.Size = new System.Drawing.Size(121, 20);
            this.lengthTxt.TabIndex = 3;
            this.lengthTxt.TextChanged += new System.EventHandler(this.widthTxt_TextChanged);
            this.lengthTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lengthTxt_KeyPress);
            // 
            // materialLabel
            // 
            this.materialLabel.AutoSize = true;
            this.materialLabel.Location = new System.Drawing.Point(42, 111);
            this.materialLabel.Name = "materialLabel";
            this.materialLabel.Size = new System.Drawing.Size(44, 13);
            this.materialLabel.TabIndex = 4;
            this.materialLabel.Text = "Material";
            // 
            // materialComboBox
            // 
            this.materialComboBox.DisplayMember = "Cotton";
            this.materialComboBox.FormattingEnabled = true;
            this.materialComboBox.Items.AddRange(new object[] {
            "Cotton",
            "Nylon",
            "Silk"});
            this.materialComboBox.Location = new System.Drawing.Point(100, 108);
            this.materialComboBox.MaxDropDownItems = 20;
            this.materialComboBox.Name = "materialComboBox";
            this.materialComboBox.Size = new System.Drawing.Size(121, 21);
            this.materialComboBox.TabIndex = 5;
            this.materialComboBox.ValueMember = "0;1;2;";
            this.materialComboBox.SelectedIndexChanged += new System.EventHandler(this.widthTxt_TextChanged);
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(43, 152);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(43, 13);
            this.amountLabel.TabIndex = 6;
            this.amountLabel.Text = "Amount";
            // 
            // amountTxt
            // 
            this.amountTxt.Location = new System.Drawing.Point(100, 149);
            this.amountTxt.Name = "amountTxt";
            this.amountTxt.ReadOnly = true;
            this.amountTxt.Size = new System.Drawing.Size(121, 20);
            this.amountTxt.TabIndex = 7;
            this.amountTxt.Text = "0.0";
            this.amountTxt.TextChanged += new System.EventHandler(this.widthTxt_TextChanged);
            // 
            // SunflowerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 203);
            this.Controls.Add(this.amountTxt);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.materialComboBox);
            this.Controls.Add(this.materialLabel);
            this.Controls.Add(this.lengthTxt);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.widthTxt);
            this.Controls.Add(this.widthLabel);
            this.Name = "SunflowerForm";
            this.Text = "Sunflower";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.TextBox widthTxt;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.TextBox lengthTxt;
        private System.Windows.Forms.Label materialLabel;
        private System.Windows.Forms.ComboBox materialComboBox;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.TextBox amountTxt;
    }
}

