namespace eLibraryUI
{
    partial class LibraryWelcomeForm
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
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.readBooksButton = new System.Windows.Forms.Button();
            this.chooseBookButton = new System.Windows.Forms.Button();
            this.addNewBookButton = new System.Windows.Forms.Button();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.welcomeLabel.Location = new System.Drawing.Point(32, 67);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(110, 46);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Witaj";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.firstNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.firstNameLabel.Location = new System.Drawing.Point(138, 67);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(210, 46);
            this.firstNameLabel.TabIndex = 1;
            this.firstNameLabel.Text = "UserName";
            // 
            // readBooksButton
            // 
            this.readBooksButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.readBooksButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.readBooksButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.readBooksButton.Location = new System.Drawing.Point(70, 160);
            this.readBooksButton.Name = "readBooksButton";
            this.readBooksButton.Size = new System.Drawing.Size(261, 48);
            this.readBooksButton.TabIndex = 6;
            this.readBooksButton.Text = "Przeczytane";
            this.readBooksButton.UseVisualStyleBackColor = false;
            this.readBooksButton.Click += new System.EventHandler(this.readBooksButton_Click);
            // 
            // chooseBookButton
            // 
            this.chooseBookButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.chooseBookButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chooseBookButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chooseBookButton.Location = new System.Drawing.Point(70, 250);
            this.chooseBookButton.Name = "chooseBookButton";
            this.chooseBookButton.Size = new System.Drawing.Size(261, 48);
            this.chooseBookButton.TabIndex = 7;
            this.chooseBookButton.Text = "Wybierz książkę";
            this.chooseBookButton.UseVisualStyleBackColor = false;
            this.chooseBookButton.Click += new System.EventHandler(this.chooseBookButton_Click);
            // 
            // addNewBookButton
            // 
            this.addNewBookButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.addNewBookButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addNewBookButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addNewBookButton.Location = new System.Drawing.Point(70, 340);
            this.addNewBookButton.Name = "addNewBookButton";
            this.addNewBookButton.Size = new System.Drawing.Size(261, 48);
            this.addNewBookButton.TabIndex = 8;
            this.addNewBookButton.Text = "Dodaj książkę";
            this.addNewBookButton.UseVisualStyleBackColor = false;
            this.addNewBookButton.Click += new System.EventHandler(this.addNewBookButton_Click);
            // 
            // statisticsButton
            // 
            this.statisticsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.statisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.statisticsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statisticsButton.Location = new System.Drawing.Point(70, 430);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(261, 48);
            this.statisticsButton.TabIndex = 9;
            this.statisticsButton.Text = "Statystyki";
            this.statisticsButton.UseVisualStyleBackColor = false;
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.logoutButton.Location = new System.Drawing.Point(115, 560);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(169, 48);
            this.logoutButton.TabIndex = 10;
            this.logoutButton.Text = "Wyłącz";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // LibraryWelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(400, 700);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.statisticsButton);
            this.Controls.Add(this.addNewBookButton);
            this.Controls.Add(this.chooseBookButton);
            this.Controls.Add(this.readBooksButton);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.welcomeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LibraryWelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LibraryWelcomeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Button readBooksButton;
        private System.Windows.Forms.Button chooseBookButton;
        private System.Windows.Forms.Button addNewBookButton;
        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.Button logoutButton;
    }
}