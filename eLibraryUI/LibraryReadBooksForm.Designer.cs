﻿namespace eLibraryUI
{
    partial class LibraryReadBooksForm
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
            this.readBooksListBox = new System.Windows.Forms.ListBox();
            this.bookDescriptionPanel = new System.Windows.Forms.Panel();
            this.authorBasicLabel = new System.Windows.Forms.Label();
            this.titleBasicLabel = new System.Windows.Forms.Label();
            this.genreBasicLabel = new System.Windows.Forms.Label();
            this.bookDescriptionBasicLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.bookDescriptionLabel = new System.Windows.Forms.Label();
            this.favoriteAuthorsButton = new System.Windows.Forms.Button();
            this.booksToReadButton = new System.Windows.Forms.Button();
            this.quotationLabel = new System.Windows.Forms.Label();
            this.bookDescriptionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // readBooksListBox
            // 
            this.readBooksListBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.readBooksListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.readBooksListBox.ForeColor = System.Drawing.Color.Black;
            this.readBooksListBox.FormattingEnabled = true;
            this.readBooksListBox.ItemHeight = 20;
            this.readBooksListBox.Location = new System.Drawing.Point(12, 12);
            this.readBooksListBox.Name = "readBooksListBox";
            this.readBooksListBox.Size = new System.Drawing.Size(140, 344);
            this.readBooksListBox.TabIndex = 0;
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
            this.bookDescriptionPanel.Location = new System.Drawing.Point(159, 12);
            this.bookDescriptionPanel.Name = "bookDescriptionPanel";
            this.bookDescriptionPanel.Size = new System.Drawing.Size(229, 344);
            this.bookDescriptionPanel.TabIndex = 1;
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
            // genreBasicLabel
            // 
            this.genreBasicLabel.AutoSize = true;
            this.genreBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.genreBasicLabel.ForeColor = System.Drawing.Color.Black;
            this.genreBasicLabel.Location = new System.Drawing.Point(4, 64);
            this.genreBasicLabel.Name = "genreBasicLabel";
            this.genreBasicLabel.Size = new System.Drawing.Size(85, 24);
            this.genreBasicLabel.TabIndex = 2;
            this.genreBasicLabel.Text = "Gatunek:";
            // 
            // bookDescriptionBasicLabel
            // 
            this.bookDescriptionBasicLabel.AutoSize = true;
            this.bookDescriptionBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bookDescriptionBasicLabel.ForeColor = System.Drawing.Color.Black;
            this.bookDescriptionBasicLabel.Location = new System.Drawing.Point(4, 94);
            this.bookDescriptionBasicLabel.Name = "bookDescriptionBasicLabel";
            this.bookDescriptionBasicLabel.Size = new System.Drawing.Size(54, 24);
            this.bookDescriptionBasicLabel.TabIndex = 3;
            this.bookDescriptionBasicLabel.Text = "Opis:";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.authorLabel.ForeColor = System.Drawing.Color.Black;
            this.authorLabel.Location = new System.Drawing.Point(97, 4);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(114, 24);
            this.authorLabel.TabIndex = 4;
            this.authorLabel.Text = "authorName";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleLabel.ForeColor = System.Drawing.Color.Black;
            this.titleLabel.Location = new System.Drawing.Point(97, 34);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(87, 24);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "bookTitle";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.genreLabel.ForeColor = System.Drawing.Color.Black;
            this.genreLabel.Location = new System.Drawing.Point(95, 64);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(105, 24);
            this.genreLabel.TabIndex = 6;
            this.genreLabel.Text = "bookGenre";
            // 
            // bookDescriptionLabel
            // 
            this.bookDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bookDescriptionLabel.ForeColor = System.Drawing.Color.Black;
            this.bookDescriptionLabel.Location = new System.Drawing.Point(4, 124);
            this.bookDescriptionLabel.Name = "bookDescriptionLabel";
            this.bookDescriptionLabel.Size = new System.Drawing.Size(215, 209);
            this.bookDescriptionLabel.TabIndex = 7;
            this.bookDescriptionLabel.Text = "Nie znaleziono opisu";
            // 
            // favoriteAuthorsButton
            // 
            this.favoriteAuthorsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.favoriteAuthorsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.favoriteAuthorsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.favoriteAuthorsButton.Location = new System.Drawing.Point(70, 384);
            this.favoriteAuthorsButton.Name = "favoriteAuthorsButton";
            this.favoriteAuthorsButton.Size = new System.Drawing.Size(261, 48);
            this.favoriteAuthorsButton.TabIndex = 7;
            this.favoriteAuthorsButton.Text = "Ulubieni autorzy";
            this.favoriteAuthorsButton.UseVisualStyleBackColor = false;
            // 
            // booksToReadButton
            // 
            this.booksToReadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.booksToReadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.booksToReadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.booksToReadButton.Location = new System.Drawing.Point(70, 463);
            this.booksToReadButton.Name = "booksToReadButton";
            this.booksToReadButton.Size = new System.Drawing.Size(261, 48);
            this.booksToReadButton.TabIndex = 8;
            this.booksToReadButton.Text = "Do przeczytania";
            this.booksToReadButton.UseVisualStyleBackColor = false;
            // 
            // quotationLabel
            // 
            this.quotationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.quotationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.quotationLabel.Location = new System.Drawing.Point(35, 565);
            this.quotationLabel.Name = "quotationLabel";
            this.quotationLabel.Size = new System.Drawing.Size(330, 126);
            this.quotationLabel.TabIndex = 8;
            this.quotationLabel.Text = "\"Smart quote about power and wisdom\"";
            this.quotationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LibraryReadBooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(400, 700);
            this.Controls.Add(this.quotationLabel);
            this.Controls.Add(this.booksToReadButton);
            this.Controls.Add(this.favoriteAuthorsButton);
            this.Controls.Add(this.bookDescriptionPanel);
            this.Controls.Add(this.readBooksListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LibraryReadBooksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LibraryReadBooksForm";
            this.bookDescriptionPanel.ResumeLayout(false);
            this.bookDescriptionPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox readBooksListBox;
        private System.Windows.Forms.Panel bookDescriptionPanel;
        private System.Windows.Forms.Label bookDescriptionLabel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label bookDescriptionBasicLabel;
        private System.Windows.Forms.Label genreBasicLabel;
        private System.Windows.Forms.Label titleBasicLabel;
        private System.Windows.Forms.Label authorBasicLabel;
        private System.Windows.Forms.Button favoriteAuthorsButton;
        private System.Windows.Forms.Button booksToReadButton;
        private System.Windows.Forms.Label quotationLabel;
    }
}