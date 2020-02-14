namespace eLibraryUI
{
    partial class SearchBookForm
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
            this.searchTypeLabel = new System.Windows.Forms.Label();
            this.searchTypeDropDown = new System.Windows.Forms.ComboBox();
            this.searchValueLabel = new System.Windows.Forms.Label();
            this.titleValue = new System.Windows.Forms.TextBox();
            this.foundBooksListBox = new System.Windows.Forms.ListBox();
            this.bookDescriptionPanel = new System.Windows.Forms.Panel();
            this.bookDescriptionLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.bookDescriptionBasicLabel = new System.Windows.Forms.Label();
            this.genreBasicLabel = new System.Windows.Forms.Label();
            this.titleBasicLabel = new System.Windows.Forms.Label();
            this.authorBasicLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.toReadButton = new System.Windows.Forms.Button();
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
            this.backButton.TabIndex = 11;
            this.backButton.Text = "Wróć";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // searchTypeLabel
            // 
            this.searchTypeLabel.AutoSize = true;
            this.searchTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.searchTypeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.searchTypeLabel.Location = new System.Drawing.Point(100, 9);
            this.searchTypeLabel.Name = "searchTypeLabel";
            this.searchTypeLabel.Size = new System.Drawing.Size(197, 31);
            this.searchTypeLabel.TabIndex = 12;
            this.searchTypeLabel.Text = "Szukaj według:";
            // 
            // searchTypeDropDown
            // 
            this.searchTypeDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.searchTypeDropDown.ForeColor = System.Drawing.Color.Black;
            this.searchTypeDropDown.FormattingEnabled = true;
            this.searchTypeDropDown.Location = new System.Drawing.Point(12, 43);
            this.searchTypeDropDown.Name = "searchTypeDropDown";
            this.searchTypeDropDown.Size = new System.Drawing.Size(376, 39);
            this.searchTypeDropDown.TabIndex = 21;
            // 
            // searchValueLabel
            // 
            this.searchValueLabel.AutoSize = true;
            this.searchValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.searchValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.searchValueLabel.Location = new System.Drawing.Point(100, 95);
            this.searchValueLabel.Name = "searchValueLabel";
            this.searchValueLabel.Size = new System.Drawing.Size(188, 31);
            this.searchValueLabel.TabIndex = 22;
            this.searchValueLabel.Text = "Szukana fraza";
            // 
            // titleValue
            // 
            this.titleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleValue.Location = new System.Drawing.Point(12, 129);
            this.titleValue.Name = "titleValue";
            this.titleValue.Size = new System.Drawing.Size(376, 38);
            this.titleValue.TabIndex = 23;
            // 
            // foundBooksListBox
            // 
            this.foundBooksListBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.foundBooksListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.foundBooksListBox.ForeColor = System.Drawing.Color.Black;
            this.foundBooksListBox.FormattingEnabled = true;
            this.foundBooksListBox.ItemHeight = 20;
            this.foundBooksListBox.Location = new System.Drawing.Point(12, 255);
            this.foundBooksListBox.Name = "foundBooksListBox";
            this.foundBooksListBox.Size = new System.Drawing.Size(140, 344);
            this.foundBooksListBox.TabIndex = 24;
            this.foundBooksListBox.SelectedIndexChanged += new System.EventHandler(this.foundBooksListBox_SelectedIndexChanged);
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
            this.bookDescriptionPanel.Location = new System.Drawing.Point(159, 255);
            this.bookDescriptionPanel.Name = "bookDescriptionPanel";
            this.bookDescriptionPanel.Size = new System.Drawing.Size(229, 344);
            this.bookDescriptionPanel.TabIndex = 25;
            // 
            // bookDescriptionLabel
            // 
            this.bookDescriptionLabel.AutoEllipsis = true;
            this.bookDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bookDescriptionLabel.ForeColor = System.Drawing.Color.Black;
            this.bookDescriptionLabel.Location = new System.Drawing.Point(4, 195);
            this.bookDescriptionLabel.Name = "bookDescriptionLabel";
            this.bookDescriptionLabel.Size = new System.Drawing.Size(215, 149);
            this.bookDescriptionLabel.TabIndex = 7;
            this.bookDescriptionLabel.Text = "Nie znaleziono opisu";
            this.bookDescriptionLabel.Click += new System.EventHandler(this.bookDescriptionLabel_Click);
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
            this.titleLabel.Size = new System.Drawing.Size(136, 77);
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
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.searchButton.Location = new System.Drawing.Point(92, 187);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(216, 39);
            this.searchButton.TabIndex = 26;
            this.searchButton.Text = "Szukaj";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // toReadButton
            // 
            this.toReadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.toReadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.toReadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toReadButton.Location = new System.Drawing.Point(159, 605);
            this.toReadButton.Name = "toReadButton";
            this.toReadButton.Size = new System.Drawing.Size(229, 39);
            this.toReadButton.TabIndex = 27;
            this.toReadButton.Text = "Do przeczytania";
            this.toReadButton.UseVisualStyleBackColor = false;
            this.toReadButton.Click += new System.EventHandler(this.toReadButton_Click);
            // 
            // SearchBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(400, 700);
            this.Controls.Add(this.toReadButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.bookDescriptionPanel);
            this.Controls.Add(this.foundBooksListBox);
            this.Controls.Add(this.titleValue);
            this.Controls.Add(this.searchValueLabel);
            this.Controls.Add(this.searchTypeDropDown);
            this.Controls.Add(this.searchTypeLabel);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchBookForm";
            this.bookDescriptionPanel.ResumeLayout(false);
            this.bookDescriptionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label searchTypeLabel;
        private System.Windows.Forms.ComboBox searchTypeDropDown;
        private System.Windows.Forms.Label searchValueLabel;
        private System.Windows.Forms.TextBox titleValue;
        private System.Windows.Forms.ListBox foundBooksListBox;
        private System.Windows.Forms.Panel bookDescriptionPanel;
        private System.Windows.Forms.Label bookDescriptionLabel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label bookDescriptionBasicLabel;
        private System.Windows.Forms.Label genreBasicLabel;
        private System.Windows.Forms.Label titleBasicLabel;
        private System.Windows.Forms.Label authorBasicLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button toReadButton;
    }
}