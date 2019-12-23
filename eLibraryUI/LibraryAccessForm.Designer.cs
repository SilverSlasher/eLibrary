namespace eLibraryUI
{
    partial class LibraryAccessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryAccessForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.userNameValue = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.passwordValue = new System.Windows.Forms.TextBox();
            this.createAccountLink = new System.Windows.Forms.LinkLabel();
            this.reminderAccountLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(101, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 267);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // userNameValue
            // 
            this.userNameValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(123)))));
            this.userNameValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userNameValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.userNameValue.Location = new System.Drawing.Point(82, 286);
            this.userNameValue.Name = "userNameValue";
            this.userNameValue.Size = new System.Drawing.Size(239, 31);
            this.userNameValue.TabIndex = 2;
            this.userNameValue.Text = "Nazwa użytkownika";
            this.userNameValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.userNameValue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.userNameValue_MouseClick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.Location = new System.Drawing.Point(12, 351);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 64);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loginButton.Location = new System.Drawing.Point(82, 450);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(223, 48);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Zaloguj";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.panel1.Location = new System.Drawing.Point(13, 333);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 3);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.panel2.Location = new System.Drawing.Point(13, 421);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 3);
            this.panel2.TabIndex = 7;
            // 
            // passwordValue
            // 
            this.passwordValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(123)))));
            this.passwordValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.passwordValue.Location = new System.Drawing.Point(82, 370);
            this.passwordValue.Name = "passwordValue";
            this.passwordValue.Size = new System.Drawing.Size(239, 31);
            this.passwordValue.TabIndex = 3;
            this.passwordValue.Text = "Hasło";
            this.passwordValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordValue.UseSystemPasswordChar = true;
            this.passwordValue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.passwordValue_MouseClick);
            // 
            // createAccountLink
            // 
            this.createAccountLink.AutoSize = true;
            this.createAccountLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.createAccountLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.createAccountLink.Location = new System.Drawing.Point(9, 565);
            this.createAccountLink.Name = "createAccountLink";
            this.createAccountLink.Size = new System.Drawing.Size(137, 25);
            this.createAccountLink.TabIndex = 8;
            this.createAccountLink.TabStop = true;
            this.createAccountLink.Text = "Utwórz konto";
            this.createAccountLink.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.createAccountLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.createAccountLink_LinkClicked);
            // 
            // reminderAccountLink
            // 
            this.reminderAccountLink.AutoSize = true;
            this.reminderAccountLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reminderAccountLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.reminderAccountLink.Location = new System.Drawing.Point(7, 605);
            this.reminderAccountLink.Name = "reminderAccountLink";
            this.reminderAccountLink.Size = new System.Drawing.Size(176, 25);
            this.reminderAccountLink.TabIndex = 9;
            this.reminderAccountLink.TabStop = true;
            this.reminderAccountLink.Text = "Przypomnij hasło";
            this.reminderAccountLink.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.reminderAccountLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.reminderAccountLink_LinkClicked);
            // 
            // LibraryAccessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(400, 700);
            this.Controls.Add(this.reminderAccountLink);
            this.Controls.Add(this.createAccountLink);
            this.Controls.Add(this.passwordValue);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.userNameValue);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LibraryAccessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logowanie";
            this.Load += new System.EventHandler(this.LibraryAccessForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox userNameValue;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox passwordValue;
        private System.Windows.Forms.LinkLabel createAccountLink;
        private System.Windows.Forms.LinkLabel reminderAccountLink;
    }
}

