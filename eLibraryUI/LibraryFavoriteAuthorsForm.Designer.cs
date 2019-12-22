namespace eLibraryUI
{
    partial class LibraryFavoriteAuthorsForm
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
            this.favoriteAuthorsDropDown = new System.Windows.Forms.ComboBox();
            this.favoriteAuthorsLabel = new System.Windows.Forms.Label();
            this.addFavoriteAuthorLabel = new System.Windows.Forms.Label();
            this.addFavoriteAuthorDropDown = new System.Windows.Forms.ComboBox();
            this.subsciptionLabel = new System.Windows.Forms.Label();
            this.subscriptionCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // favoriteAuthorsDropDown
            // 
            this.favoriteAuthorsDropDown.ForeColor = System.Drawing.Color.Black;
            this.favoriteAuthorsDropDown.FormattingEnabled = true;
            this.favoriteAuthorsDropDown.Location = new System.Drawing.Point(6, 52);
            this.favoriteAuthorsDropDown.Name = "favoriteAuthorsDropDown";
            this.favoriteAuthorsDropDown.Size = new System.Drawing.Size(382, 21);
            this.favoriteAuthorsDropDown.TabIndex = 19;
            // 
            // favoriteAuthorsLabel
            // 
            this.favoriteAuthorsLabel.AutoSize = true;
            this.favoriteAuthorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.favoriteAuthorsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.favoriteAuthorsLabel.Location = new System.Drawing.Point(95, 9);
            this.favoriteAuthorsLabel.Name = "favoriteAuthorsLabel";
            this.favoriteAuthorsLabel.Size = new System.Drawing.Size(209, 31);
            this.favoriteAuthorsLabel.TabIndex = 20;
            this.favoriteAuthorsLabel.Text = "Ulubieni autorzy";
            this.favoriteAuthorsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addFavoriteAuthorLabel
            // 
            this.addFavoriteAuthorLabel.AutoSize = true;
            this.addFavoriteAuthorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addFavoriteAuthorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.addFavoriteAuthorLabel.Location = new System.Drawing.Point(69, 89);
            this.addFavoriteAuthorLabel.Name = "addFavoriteAuthorLabel";
            this.addFavoriteAuthorLabel.Size = new System.Drawing.Size(261, 31);
            this.addFavoriteAuthorLabel.TabIndex = 21;
            this.addFavoriteAuthorLabel.Text = "Dodaj autora do listy";
            this.addFavoriteAuthorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addFavoriteAuthorDropDown
            // 
            this.addFavoriteAuthorDropDown.ForeColor = System.Drawing.Color.Black;
            this.addFavoriteAuthorDropDown.FormattingEnabled = true;
            this.addFavoriteAuthorDropDown.Location = new System.Drawing.Point(6, 133);
            this.addFavoriteAuthorDropDown.Name = "addFavoriteAuthorDropDown";
            this.addFavoriteAuthorDropDown.Size = new System.Drawing.Size(382, 21);
            this.addFavoriteAuthorDropDown.TabIndex = 22;
            // 
            // subsciptionLabel
            // 
            this.subsciptionLabel.AutoSize = true;
            this.subsciptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.subsciptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.subsciptionLabel.Location = new System.Drawing.Point(1, 191);
            this.subsciptionLabel.Name = "subsciptionLabel";
            this.subsciptionLabel.Size = new System.Drawing.Size(283, 25);
            this.subsciptionLabel.TabIndex = 23;
            this.subsciptionLabel.Text = "Włączyć subskrypcję email?";
            this.subsciptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subscriptionCheckBox
            // 
            this.subscriptionCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.subscriptionCheckBox.Location = new System.Drawing.Point(353, 191);
            this.subscriptionCheckBox.Name = "subscriptionCheckBox";
            this.subscriptionCheckBox.Size = new System.Drawing.Size(35, 26);
            this.subscriptionCheckBox.TabIndex = 24;
            this.subscriptionCheckBox.UseVisualStyleBackColor = true;
            // 
            // LibraryFavoriteAuthorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(400, 260);
            this.Controls.Add(this.subscriptionCheckBox);
            this.Controls.Add(this.subsciptionLabel);
            this.Controls.Add(this.addFavoriteAuthorDropDown);
            this.Controls.Add(this.addFavoriteAuthorLabel);
            this.Controls.Add(this.favoriteAuthorsLabel);
            this.Controls.Add(this.favoriteAuthorsDropDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "LibraryFavoriteAuthorsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ulubieni autorzy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox favoriteAuthorsDropDown;
        private System.Windows.Forms.Label favoriteAuthorsLabel;
        private System.Windows.Forms.Label addFavoriteAuthorLabel;
        private System.Windows.Forms.ComboBox addFavoriteAuthorDropDown;
        private System.Windows.Forms.Label subsciptionLabel;
        private System.Windows.Forms.CheckBox subscriptionCheckBox;
    }
}