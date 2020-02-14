namespace eLibraryUI
{
    partial class RemindAccountForm
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
            this.emailAddressLabel = new System.Windows.Forms.Label();
            this.emailAddressValue = new System.Windows.Forms.TextBox();
            this.remindEmailButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // emailAddressLabel
            // 
            this.emailAddressLabel.AutoSize = true;
            this.emailAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailAddressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.emailAddressLabel.Location = new System.Drawing.Point(92, 9);
            this.emailAddressLabel.Name = "emailAddressLabel";
            this.emailAddressLabel.Size = new System.Drawing.Size(237, 31);
            this.emailAddressLabel.TabIndex = 21;
            this.emailAddressLabel.Text = "Podaj adres email:";
            this.emailAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emailAddressValue
            // 
            this.emailAddressValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailAddressValue.Location = new System.Drawing.Point(54, 69);
            this.emailAddressValue.Name = "emailAddressValue";
            this.emailAddressValue.Size = new System.Drawing.Size(311, 38);
            this.emailAddressValue.TabIndex = 22;
            // 
            // remindEmailButton
            // 
            this.remindEmailButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.remindEmailButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.remindEmailButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.remindEmailButton.Location = new System.Drawing.Point(125, 135);
            this.remindEmailButton.Name = "remindEmailButton";
            this.remindEmailButton.Size = new System.Drawing.Size(169, 48);
            this.remindEmailButton.TabIndex = 23;
            this.remindEmailButton.Text = "Wyślij";
            this.remindEmailButton.UseVisualStyleBackColor = false;
            this.remindEmailButton.Click += new System.EventHandler(this.remindEmailButton_Click);
            // 
            // RemindAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(404, 264);
            this.Controls.Add(this.remindEmailButton);
            this.Controls.Add(this.emailAddressValue);
            this.Controls.Add(this.emailAddressLabel);
            this.Name = "RemindAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemindAccountForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label emailAddressLabel;
        private System.Windows.Forms.TextBox emailAddressValue;
        private System.Windows.Forms.Button remindEmailButton;
    }
}