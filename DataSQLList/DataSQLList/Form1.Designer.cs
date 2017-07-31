namespace DataSQLList
{
    partial class DataSQLList
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
            this._listView = new System.Windows.Forms.ListView();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._queryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _listView
            // 
            this._listView.GridLines = true;
            this._listView.Location = new System.Drawing.Point(12, 168);
            this._listView.Name = "_listView";
            this._listView.Size = new System.Drawing.Size(365, 131);
            this._listView.TabIndex = 0;
            this._listView.UseCompatibleStateImageBehavior = false;
            this._listView.View = System.Windows.Forms.View.Details;
            // 
            // _dataGridView
            // 
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Location = new System.Drawing.Point(12, 12);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.Size = new System.Drawing.Size(366, 150);
            this._dataGridView.TabIndex = 1;
            // 
            // _queryButton
            // 
            this._queryButton.Location = new System.Drawing.Point(151, 307);
            this._queryButton.Name = "_queryButton";
            this._queryButton.Size = new System.Drawing.Size(75, 23);
            this._queryButton.TabIndex = 2;
            this._queryButton.Text = "Query";
            this._queryButton.UseVisualStyleBackColor = true;
            this._queryButton.Click += new System.EventHandler(this._queryButton_Click);
            // 
            // DataSQLList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 346);
            this.Controls.Add(this._queryButton);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this._listView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataSQLList";
            this.Text = "DataSQLList";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.ResumeLayout(false);

        }    
        #endregion

        private System.Windows.Forms.ListView _listView;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.Button _queryButton;
    }
}

