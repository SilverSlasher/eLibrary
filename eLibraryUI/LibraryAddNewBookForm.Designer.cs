namespace eLibraryUI
{
    partial class LibraryAddNewBookForm
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
            this.bookDescriptionBasicLabel = new System.Windows.Forms.Label();
            this.genreBasicLabel = new System.Windows.Forms.Label();
            this.titleBasicLabel = new System.Windows.Forms.Label();
            this.authorBasicLabel = new System.Windows.Forms.Label();
            this.authorValue = new System.Windows.Forms.TextBox();
            this.titleValue = new System.Windows.Forms.TextBox();
            this.descriptionValue = new System.Windows.Forms.TextBox();
            this.addBookButton = new System.Windows.Forms.Button();
            this.genreDropDown = new System.Windows.Forms.ComboBox();
            this.pagesLabel = new System.Windows.Forms.Label();
            this.pagesValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bookDescriptionBasicLabel
            // 
            this.bookDescriptionBasicLabel.AutoSize = true;
            this.bookDescriptionBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bookDescriptionBasicLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.bookDescriptionBasicLabel.Location = new System.Drawing.Point(12, 191);
            this.bookDescriptionBasicLabel.Name = "bookDescriptionBasicLabel";
            this.bookDescriptionBasicLabel.Size = new System.Drawing.Size(78, 31);
            this.bookDescriptionBasicLabel.TabIndex = 3;
            this.bookDescriptionBasicLabel.Text = "Opis:";
            // 
            // genreBasicLabel
            // 
            this.genreBasicLabel.AutoSize = true;
            this.genreBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.genreBasicLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.genreBasicLabel.Location = new System.Drawing.Point(14, 106);
            this.genreBasicLabel.Name = "genreBasicLabel";
            this.genreBasicLabel.Size = new System.Drawing.Size(125, 31);
            this.genreBasicLabel.TabIndex = 2;
            this.genreBasicLabel.Text = "Gatunek:";
            // 
            // titleBasicLabel
            // 
            this.titleBasicLabel.AutoSize = true;
            this.titleBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleBasicLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.titleBasicLabel.Location = new System.Drawing.Point(14, 62);
            this.titleBasicLabel.Name = "titleBasicLabel";
            this.titleBasicLabel.Size = new System.Drawing.Size(82, 31);
            this.titleBasicLabel.TabIndex = 1;
            this.titleBasicLabel.Text = "Tytuł:";
            // 
            // authorBasicLabel
            // 
            this.authorBasicLabel.AutoSize = true;
            this.authorBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.authorBasicLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.authorBasicLabel.Location = new System.Drawing.Point(14, 18);
            this.authorBasicLabel.Name = "authorBasicLabel";
            this.authorBasicLabel.Size = new System.Drawing.Size(87, 31);
            this.authorBasicLabel.TabIndex = 0;
            this.authorBasicLabel.Text = "Autor:";
            // 
            // authorValue
            // 
            this.authorValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.authorValue.Location = new System.Drawing.Point(185, 15);
            this.authorValue.Name = "authorValue";
            this.authorValue.Size = new System.Drawing.Size(207, 38);
            this.authorValue.TabIndex = 4;
            // 
            // titleValue
            // 
            this.titleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleValue.Location = new System.Drawing.Point(185, 59);
            this.titleValue.Name = "titleValue";
            this.titleValue.Size = new System.Drawing.Size(207, 38);
            this.titleValue.TabIndex = 5;
            // 
            // descriptionValue
            // 
            this.descriptionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.descriptionValue.Location = new System.Drawing.Point(18, 225);
            this.descriptionValue.Multiline = true;
            this.descriptionValue.Name = "descriptionValue";
            this.descriptionValue.Size = new System.Drawing.Size(372, 113);
            this.descriptionValue.TabIndex = 7;
            // 
            // addBookButton
            // 
            this.addBookButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.addBookButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addBookButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addBookButton.Location = new System.Drawing.Point(115, 344);
            this.addBookButton.Name = "addBookButton";
            this.addBookButton.Size = new System.Drawing.Size(169, 48);
            this.addBookButton.TabIndex = 11;
            this.addBookButton.Text = "Dodaj do bazy";
            this.addBookButton.UseVisualStyleBackColor = false;
            // 
            // genreDropDown
            // 
            this.genreDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.genreDropDown.ForeColor = System.Drawing.Color.Black;
            this.genreDropDown.FormattingEnabled = true;
            this.genreDropDown.Location = new System.Drawing.Point(185, 103);
            this.genreDropDown.Name = "genreDropDown";
            this.genreDropDown.Size = new System.Drawing.Size(207, 39);
            this.genreDropDown.TabIndex = 20;
            // 
            // pagesLabel
            // 
            this.pagesLabel.AutoSize = true;
            this.pagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pagesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.pagesLabel.Location = new System.Drawing.Point(14, 151);
            this.pagesLabel.Name = "pagesLabel";
            this.pagesLabel.Size = new System.Drawing.Size(169, 31);
            this.pagesLabel.TabIndex = 21;
            this.pagesLabel.Text = "Liczba stron:";
            // 
            // pagesValue
            // 
            this.pagesValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pagesValue.Location = new System.Drawing.Point(185, 148);
            this.pagesValue.Name = "pagesValue";
            this.pagesValue.Size = new System.Drawing.Size(207, 38);
            this.pagesValue.TabIndex = 22;
            // 
            // LibraryAddNewBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(404, 404);
            this.Controls.Add(this.pagesValue);
            this.Controls.Add(this.pagesLabel);
            this.Controls.Add(this.genreDropDown);
            this.Controls.Add(this.addBookButton);
            this.Controls.Add(this.descriptionValue);
            this.Controls.Add(this.titleValue);
            this.Controls.Add(this.authorValue);
            this.Controls.Add(this.bookDescriptionBasicLabel);
            this.Controls.Add(this.authorBasicLabel);
            this.Controls.Add(this.titleBasicLabel);
            this.Controls.Add(this.genreBasicLabel);
            this.Name = "LibraryAddNewBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodawanie książki do bazy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label bookDescriptionBasicLabel;
        private System.Windows.Forms.Label genreBasicLabel;
        private System.Windows.Forms.Label titleBasicLabel;
        private System.Windows.Forms.Label authorBasicLabel;
        private System.Windows.Forms.TextBox authorValue;
        private System.Windows.Forms.TextBox titleValue;
        private System.Windows.Forms.TextBox descriptionValue;
        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.ComboBox genreDropDown;
        private System.Windows.Forms.Label pagesLabel;
        private System.Windows.Forms.TextBox pagesValue;
    }
}