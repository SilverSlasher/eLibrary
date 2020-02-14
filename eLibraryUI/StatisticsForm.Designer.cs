namespace eLibraryUI
{
    partial class StatisticsForm
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
            this.backButton = new System.Windows.Forms.Button();
            this.readPagesBasicLabel = new System.Windows.Forms.Label();
            this.toReadPagesBasicLabel = new System.Windows.Forms.Label();
            this.favoriteAuthorsBasicLabel = new System.Windows.Forms.Label();
            this.favoriteGenreBasicLabel = new System.Windows.Forms.Label();
            this.readPagesLabel = new System.Windows.Forms.Label();
            this.toReadPagesLabel = new System.Windows.Forms.Label();
            this.favoriteAuthorsLabel = new System.Windows.Forms.Label();
            this.favoriteGenreLabel = new System.Windows.Forms.Label();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.backButton.Location = new System.Drawing.Point(12, 634);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(72, 54);
            this.backButton.TabIndex = 10;
            this.backButton.Text = "Wróć";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // readPagesBasicLabel
            // 
            this.readPagesBasicLabel.AutoSize = true;
            this.readPagesBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.readPagesBasicLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.readPagesBasicLabel.Location = new System.Drawing.Point(7, 40);
            this.readPagesBasicLabel.Name = "readPagesBasicLabel";
            this.readPagesBasicLabel.Size = new System.Drawing.Size(213, 25);
            this.readPagesBasicLabel.TabIndex = 11;
            this.readPagesBasicLabel.Text = "Przeczytanych stron:";
            // 
            // toReadPagesBasicLabel
            // 
            this.toReadPagesBasicLabel.AutoSize = true;
            this.toReadPagesBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toReadPagesBasicLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.toReadPagesBasicLabel.Location = new System.Drawing.Point(7, 105);
            this.toReadPagesBasicLabel.Name = "toReadPagesBasicLabel";
            this.toReadPagesBasicLabel.Size = new System.Drawing.Size(241, 25);
            this.toReadPagesBasicLabel.TabIndex = 12;
            this.toReadPagesBasicLabel.Text = "Stron \"do przeczytania\":";
            // 
            // favoriteAuthorsBasicLabel
            // 
            this.favoriteAuthorsBasicLabel.AutoSize = true;
            this.favoriteAuthorsBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.favoriteAuthorsBasicLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.favoriteAuthorsBasicLabel.Location = new System.Drawing.Point(7, 170);
            this.favoriteAuthorsBasicLabel.Name = "favoriteAuthorsBasicLabel";
            this.favoriteAuthorsBasicLabel.Size = new System.Drawing.Size(207, 25);
            this.favoriteAuthorsBasicLabel.TabIndex = 13;
            this.favoriteAuthorsBasicLabel.Text = "Ulubionych autorów:";
            // 
            // favoriteGenreBasicLabel
            // 
            this.favoriteGenreBasicLabel.AutoSize = true;
            this.favoriteGenreBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.favoriteGenreBasicLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.favoriteGenreBasicLabel.Location = new System.Drawing.Point(7, 235);
            this.favoriteGenreBasicLabel.Name = "favoriteGenreBasicLabel";
            this.favoriteGenreBasicLabel.Size = new System.Drawing.Size(185, 25);
            this.favoriteGenreBasicLabel.TabIndex = 14;
            this.favoriteGenreBasicLabel.Text = "Ulubiony gatunek:";
            // 
            // readPagesLabel
            // 
            this.readPagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.readPagesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.readPagesLabel.Location = new System.Drawing.Point(253, 40);
            this.readPagesLabel.Name = "readPagesLabel";
            this.readPagesLabel.Size = new System.Drawing.Size(135, 25);
            this.readPagesLabel.TabIndex = 16;
            this.readPagesLabel.Text = "XXXX";
            this.readPagesLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // toReadPagesLabel
            // 
            this.toReadPagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toReadPagesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.toReadPagesLabel.Location = new System.Drawing.Point(253, 105);
            this.toReadPagesLabel.Name = "toReadPagesLabel";
            this.toReadPagesLabel.Size = new System.Drawing.Size(135, 25);
            this.toReadPagesLabel.TabIndex = 17;
            this.toReadPagesLabel.Text = "XXXX";
            this.toReadPagesLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // favoriteAuthorsLabel
            // 
            this.favoriteAuthorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.favoriteAuthorsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.favoriteAuthorsLabel.Location = new System.Drawing.Point(253, 170);
            this.favoriteAuthorsLabel.Name = "favoriteAuthorsLabel";
            this.favoriteAuthorsLabel.Size = new System.Drawing.Size(135, 25);
            this.favoriteAuthorsLabel.TabIndex = 18;
            this.favoriteAuthorsLabel.Text = "XXXX";
            this.favoriteAuthorsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // favoriteGenreLabel
            // 
            this.favoriteGenreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.favoriteGenreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.favoriteGenreLabel.Location = new System.Drawing.Point(253, 235);
            this.favoriteGenreLabel.Name = "favoriteGenreLabel";
            this.favoriteGenreLabel.Size = new System.Drawing.Size(135, 25);
            this.favoriteGenreLabel.TabIndex = 19;
            this.favoriteGenreLabel.Text = "XXXX";
            this.favoriteGenreLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // monthCalendar
            // 
            this.monthCalendar.BackColor = System.Drawing.SystemColors.Window;
            this.monthCalendar.Enabled = false;
            this.monthCalendar.Location = new System.Drawing.Point(55, 383);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowWeekNumbers = true;
            this.monthCalendar.TabIndex = 21;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(400, 700);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.favoriteGenreLabel);
            this.Controls.Add(this.favoriteAuthorsLabel);
            this.Controls.Add(this.toReadPagesLabel);
            this.Controls.Add(this.readPagesLabel);
            this.Controls.Add(this.favoriteGenreBasicLabel);
            this.Controls.Add(this.favoriteAuthorsBasicLabel);
            this.Controls.Add(this.toReadPagesBasicLabel);
            this.Controls.Add(this.readPagesBasicLabel);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatisticsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label readPagesBasicLabel;
        private System.Windows.Forms.Label toReadPagesBasicLabel;
        private System.Windows.Forms.Label favoriteAuthorsBasicLabel;
        private System.Windows.Forms.Label favoriteGenreBasicLabel;
        private System.Windows.Forms.Label readPagesLabel;
        private System.Windows.Forms.Label toReadPagesLabel;
        private System.Windows.Forms.Label favoriteAuthorsLabel;
        private System.Windows.Forms.Label favoriteGenreLabel;
        private System.Windows.Forms.MonthCalendar monthCalendar;
    }
}