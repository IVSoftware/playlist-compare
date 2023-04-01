namespace playlist_compare
{
    partial class MainForm
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
            dataGridViewMusic = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMusic).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMusic
            // 
            dataGridViewMusic.AllowUserToAddRows = false;
            dataGridViewMusic.AllowUserToDeleteRows = false;
            dataGridViewMusic.AllowUserToResizeColumns = false;
            dataGridViewMusic.AllowUserToResizeRows = false;
            dataGridViewMusic.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewMusic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMusic.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewMusic.Location = new System.Drawing.Point(10, 10);
            dataGridViewMusic.Name = "dataGridViewMusic";
            dataGridViewMusic.RowHeadersVisible = false;
            dataGridViewMusic.RowHeadersWidth = 62;
            dataGridViewMusic.RowTemplate.Height = 33;
            dataGridViewMusic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMusic.Size = new System.Drawing.Size(458, 224);
            dataGridViewMusic.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(478, 244);
            Controls.Add(dataGridViewMusic);
            Name = "MainForm";
            Padding = new System.Windows.Forms.Padding(10);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)dataGridViewMusic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMusic;
    }
}
