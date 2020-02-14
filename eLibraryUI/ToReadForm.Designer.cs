namespace eLibraryUI
{
    partial class ToReadForm
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
            this.toReadListBox = new System.Windows.Forms.ListBox();
            this.ToReadMainLabel = new System.Windows.Forms.Label();
            this.bookDescriptionPanel = new System.Windows.Forms.Panel();
            this.bookDescriptionLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.bookDescriptionBasicLabel = new System.Windows.Forms.Label();
            this.genreBasicLabel = new System.Windows.Forms.Label();
            this.titleBasicLabel = new System.Windows.Forms.Label();
            this.authorBasicLabel = new System.Windows.Forms.Label();
            this.readBookButton = new System.Windows.Forms.Button();
            this.bookDescriptionPanel.SuspendLayout();
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
            this.backButton.TabIndex = 12;
            this.backButton.Text = "Wróć";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // toReadListBox
            // 
            this.toReadListBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toReadListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toReadListBox.ForeColor = System.Drawing.Color.Black;
            this.toReadListBox.FormattingEnabled = true;
            this.toReadListBox.ItemHeight = 20;
            this.toReadListBox.Location = new System.Drawing.Point(12, 68);
            this.toReadListBox.Name = "toReadListBox";
            this.toReadListBox.Size = new System.Drawing.Size(376, 104);
            this.toReadListBox.TabIndex = 25;
            this.toReadListBox.SelectedIndexChanged += new System.EventHandler(this.toReadListBox_SelectedIndexChanged);
            // 
            // ToReadMainLabel
            // 
            this.ToReadMainLabel.AutoSize = true;
            this.ToReadMainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ToReadMainLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.ToReadMainLabel.Location = new System.Drawing.Point(51, 9);
            this.ToReadMainLabel.Name = "ToReadMainLabel";
            this.ToReadMainLabel.Size = new System.Drawing.Size(307, 31);
            this.ToReadMainLabel.TabIndex = 26;
            this.ToReadMainLabel.Text = "Książki do przeczytania:";
            // 
            // bookDescriptionPanel
            // 
            this.bookDescriptionPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bookDescriptionPanel.Controls.Add(this.bookDescriptionLabel);
            this.bookDescriptionPanel.Controls.Add(this.genreLabel);
            this.bookDescriptionPanel.Controls.Add(this.titleLabel);
            this.bookDescriptionPanel.Controls.Add(this.authorLabel);
            this.bookDescriptionPanel.Controls.Add(this.bookDescriptionBasicLabel);
            this.bookDescriptionPanel.Controls.Add(this.genreBasicLabel);
            this.bookDescriptionPanel.Controls.Add(this.titleBasicLabel);
            this.bookDescriptionPanel.Controls.Add(this.authorBasicLabel);
            this.bookDescriptionPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.bookDescriptionPanel.Location = new System.Drawing.Point(12, 187);
            this.bookDescriptionPanel.Name = "bookDescriptionPanel";
            this.bookDescriptionPanel.Size = new System.Drawing.Size(376, 321);
            this.bookDescriptionPanel.TabIndex = 27;
            // 
            // bookDescriptionLabel
            // 
            this.bookDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bookDescriptionLabel.ForeColor = System.Drawing.Color.Black;
            this.bookDescriptionLabel.Location = new System.Drawing.Point(4, 195);
            this.bookDescriptionLabel.Name = "bookDescriptionLabel";
            this.bookDescriptionLabel.Size = new System.Drawing.Size(342, 126);
            this.bookDescriptionLabel.TabIndex = 7;
            this.bookDescriptionLabel.Text = "Nie znaleziono opisu";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.genreLabel.ForeColor = System.Drawing.Color.Black;
            this.genreLabel.Location = new System.Drawing.Point(83, 111);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(46, 24);
            this.genreLabel.TabIndex = 6;
            this.genreLabel.Text = "brak";
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleLabel.ForeColor = System.Drawing.Color.Black;
            this.titleLabel.Location = new System.Drawing.Point(83, 34);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(263, 77);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "brak";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.authorLabel.ForeColor = System.Drawing.Color.Black;
            this.authorLabel.Location = new System.Drawing.Point(83, 4);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(46, 24);
            this.authorLabel.TabIndex = 4;
            this.authorLabel.Text = "brak";
            // 
            // bookDescriptionBasicLabel
            // 
            this.bookDescriptionBasicLabel.AutoSize = true;
            this.bookDescriptionBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bookDescriptionBasicLabel.ForeColor = System.Drawing.Color.Black;
            this.bookDescriptionBasicLabel.Location = new System.Drawing.Point(4, 171);
            this.bookDescriptionBasicLabel.Name = "bookDescriptionBasicLabel";
            this.bookDescriptionBasicLabel.Size = new System.Drawing.Size(54, 24);
            this.bookDescriptionBasicLabel.TabIndex = 3;
            this.bookDescriptionBasicLabel.Text = "Opis:";
            // 
            // genreBasicLabel
            // 
            this.genreBasicLabel.AutoSize = true;
            this.genreBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.genreBasicLabel.ForeColor = System.Drawing.Color.Black;
            this.genreBasicLabel.Location = new System.Drawing.Point(4, 111);
            this.genreBasicLabel.Name = "genreBasicLabel";
            this.genreBasicLabel.Size = new System.Drawing.Size(85, 24);
            this.genreBasicLabel.TabIndex = 2;
            this.genreBasicLabel.Text = "Gatunek:";
            // 
            // titleBasicLabel
            // 
            this.titleBasicLabel.AutoSize = true;
            this.titleBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleBasicLabel.ForeColor = System.Drawing.Color.Black;
            this.titleBasicLabel.Location = new System.Drawing.Point(4, 34);
            this.titleBasicLabel.Name = "titleBasicLabel";
            this.titleBasicLabel.Size = new System.Drawing.Size(59, 24);
            this.titleBasicLabel.TabIndex = 1;
            this.titleBasicLabel.Text = "Tytuł:";
            // 
            // authorBasicLabel
            // 
            this.authorBasicLabel.AutoSize = true;
            this.authorBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.authorBasicLabel.ForeColor = System.Drawing.Color.Black;
            this.authorBasicLabel.Location = new System.Drawing.Point(4, 4);
            this.authorBasicLabel.Name = "authorBasicLabel";
            this.authorBasicLabel.Size = new System.Drawing.Size(60, 24);
            this.authorBasicLabel.TabIndex = 0;
            this.authorBasicLabel.Text = "Autor:";
            // 
            // readBookButton
            // 
            this.readBookButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.readBookButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.readBookButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.readBookButton.Location = new System.Drawing.Point(57, 526);
            this.readBookButton.Name = "readBookButton";
            this.readBookButton.Size = new System.Drawing.Size(280, 59);
            this.readBookButton.TabIndex = 28;
            this.readBookButton.Text = "Już przeczytana!";
            this.readBookButton.UseVisualStyleBackColor = false;
            this.readBookButton.Click += new System.EventHandler(this.readBookButton_Click);
            // 
            // ToReadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(400, 700);
            this.Controls.Add(this.readBookButton);
            this.Controls.Add(this.bookDescriptionPanel);
            this.Controls.Add(this.ToReadMainLabel);
            this.Controls.Add(this.toReadListBox);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToReadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ToReadForm";
            this.bookDescriptionPanel.ResumeLayout(false);
            this.bookDescriptionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ListBox toReadListBox;
        private System.Windows.Forms.Label ToReadMainLabel;
        private System.Windows.Forms.Panel bookDescriptionPanel;
        private System.Windows.Forms.Label bookDescriptionLabel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label bookDescriptionBasicLabel;
        private System.Windows.Forms.Label genreBasicLabel;
        private System.Windows.Forms.Label titleBasicLabel;
        private System.Windows.Forms.Label authorBasicLabel;
        private System.Windows.Forms.Button readBookButton;
    }
}