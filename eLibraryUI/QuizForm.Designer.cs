namespace eLibraryUI
{
    partial class QuizForm
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
            this.questionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.firstAnswerButton = new System.Windows.Forms.RadioButton();
            this.secondAnswerButton = new System.Windows.Forms.RadioButton();
            this.thirdAnswerButton = new System.Windows.Forms.RadioButton();
            this.fourthAnswerButton = new System.Windows.Forms.RadioButton();
            this.nextQuestionButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.finalBookPanel = new System.Windows.Forms.Panel();
            this.bookBasicLabel = new System.Windows.Forms.Label();
            this.authorBasicLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleBasicLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.genreBasicLabel = new System.Windows.Forms.Label();
            this.backSecondButton = new System.Windows.Forms.Button();
            this.toReadButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.finalBookPanel.SuspendLayout();
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
            // questionLabel
            // 
            this.questionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.questionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.questionLabel.Location = new System.Drawing.Point(12, 9);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(376, 159);
            this.questionLabel.TabIndex = 12;
            this.questionLabel.Text = "Question";
            this.questionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.label1.Location = new System.Drawing.Point(14, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------------";
            // 
            // firstAnswerButton
            // 
            this.firstAnswerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.firstAnswerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.firstAnswerButton.Location = new System.Drawing.Point(13, 185);
            this.firstAnswerButton.Name = "firstAnswerButton";
            this.firstAnswerButton.Size = new System.Drawing.Size(371, 101);
            this.firstAnswerButton.TabIndex = 14;
            this.firstAnswerButton.TabStop = true;
            this.firstAnswerButton.Text = "Answer1";
            this.firstAnswerButton.UseVisualStyleBackColor = true;
            // 
            // secondAnswerButton
            // 
            this.secondAnswerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.secondAnswerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.secondAnswerButton.Location = new System.Drawing.Point(13, 292);
            this.secondAnswerButton.Name = "secondAnswerButton";
            this.secondAnswerButton.Size = new System.Drawing.Size(371, 101);
            this.secondAnswerButton.TabIndex = 15;
            this.secondAnswerButton.TabStop = true;
            this.secondAnswerButton.Text = "Answer2";
            this.secondAnswerButton.UseVisualStyleBackColor = true;
            // 
            // thirdAnswerButton
            // 
            this.thirdAnswerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.thirdAnswerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.thirdAnswerButton.Location = new System.Drawing.Point(13, 399);
            this.thirdAnswerButton.Name = "thirdAnswerButton";
            this.thirdAnswerButton.Size = new System.Drawing.Size(371, 101);
            this.thirdAnswerButton.TabIndex = 16;
            this.thirdAnswerButton.TabStop = true;
            this.thirdAnswerButton.Text = "Answer3";
            this.thirdAnswerButton.UseVisualStyleBackColor = true;
            // 
            // fourthAnswerButton
            // 
            this.fourthAnswerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fourthAnswerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.fourthAnswerButton.Location = new System.Drawing.Point(13, 506);
            this.fourthAnswerButton.Name = "fourthAnswerButton";
            this.fourthAnswerButton.Size = new System.Drawing.Size(371, 101);
            this.fourthAnswerButton.TabIndex = 17;
            this.fourthAnswerButton.TabStop = true;
            this.fourthAnswerButton.Text = "Answer4";
            this.fourthAnswerButton.UseVisualStyleBackColor = true;
            // 
            // nextQuestionButton
            // 
            this.nextQuestionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.nextQuestionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nextQuestionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nextQuestionButton.Location = new System.Drawing.Point(262, 634);
            this.nextQuestionButton.Name = "nextQuestionButton";
            this.nextQuestionButton.Size = new System.Drawing.Size(126, 54);
            this.nextQuestionButton.TabIndex = 18;
            this.nextQuestionButton.Text = "Następne";
            this.nextQuestionButton.UseVisualStyleBackColor = false;
            this.nextQuestionButton.Visible = false;
            this.nextQuestionButton.Click += new System.EventHandler(this.nextQuestionButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.finalBookPanel);
            this.mainPanel.Controls.Add(this.questionLabel);
            this.mainPanel.Controls.Add(this.nextQuestionButton);
            this.mainPanel.Controls.Add(this.backButton);
            this.mainPanel.Controls.Add(this.fourthAnswerButton);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.thirdAnswerButton);
            this.mainPanel.Controls.Add(this.firstAnswerButton);
            this.mainPanel.Controls.Add(this.secondAnswerButton);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(400, 700);
            this.mainPanel.TabIndex = 19;
            this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
            // 
            // finalBookPanel
            // 
            this.finalBookPanel.Controls.Add(this.toReadButton);
            this.finalBookPanel.Controls.Add(this.backSecondButton);
            this.finalBookPanel.Controls.Add(this.genreLabel);
            this.finalBookPanel.Controls.Add(this.genreBasicLabel);
            this.finalBookPanel.Controls.Add(this.titleLabel);
            this.finalBookPanel.Controls.Add(this.titleBasicLabel);
            this.finalBookPanel.Controls.Add(this.authorLabel);
            this.finalBookPanel.Controls.Add(this.authorBasicLabel);
            this.finalBookPanel.Controls.Add(this.bookBasicLabel);
            this.finalBookPanel.Location = new System.Drawing.Point(0, 0);
            this.finalBookPanel.Name = "finalBookPanel";
            this.finalBookPanel.Size = new System.Drawing.Size(400, 700);
            this.finalBookPanel.TabIndex = 19;
            this.finalBookPanel.Visible = false;
            // 
            // bookBasicLabel
            // 
            this.bookBasicLabel.AutoSize = true;
            this.bookBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bookBasicLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.bookBasicLabel.Location = new System.Drawing.Point(78, 9);
            this.bookBasicLabel.Name = "bookBasicLabel";
            this.bookBasicLabel.Size = new System.Drawing.Size(244, 31);
            this.bookBasicLabel.TabIndex = 22;
            this.bookBasicLabel.Text = "Twoją ksiązką jest:";
            this.bookBasicLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // authorBasicLabel
            // 
            this.authorBasicLabel.AutoSize = true;
            this.authorBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.authorBasicLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.authorBasicLabel.Location = new System.Drawing.Point(160, 106);
            this.authorBasicLabel.Name = "authorBasicLabel";
            this.authorBasicLabel.Size = new System.Drawing.Size(79, 31);
            this.authorBasicLabel.TabIndex = 23;
            this.authorBasicLabel.Text = "Autor";
            this.authorBasicLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // authorLabel
            // 
            this.authorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.authorLabel.ForeColor = System.Drawing.Color.LightCoral;
            this.authorLabel.Location = new System.Drawing.Point(17, 137);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(367, 79);
            this.authorLabel.TabIndex = 24;
            this.authorLabel.Text = "author";
            this.authorLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleLabel.ForeColor = System.Drawing.Color.LightCoral;
            this.titleLabel.Location = new System.Drawing.Point(13, 247);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(371, 115);
            this.titleLabel.TabIndex = 26;
            this.titleLabel.Text = "title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // titleBasicLabel
            // 
            this.titleBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleBasicLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.titleBasicLabel.Location = new System.Drawing.Point(17, 216);
            this.titleBasicLabel.Name = "titleBasicLabel";
            this.titleBasicLabel.Size = new System.Drawing.Size(367, 31);
            this.titleBasicLabel.TabIndex = 25;
            this.titleBasicLabel.Text = "Tytuł";
            this.titleBasicLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // genreLabel
            // 
            this.genreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.genreLabel.ForeColor = System.Drawing.Color.LightCoral;
            this.genreLabel.Location = new System.Drawing.Point(13, 409);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(371, 31);
            this.genreLabel.TabIndex = 28;
            this.genreLabel.Text = "genre";
            this.genreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // genreBasicLabel
            // 
            this.genreBasicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.genreBasicLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.genreBasicLabel.Location = new System.Drawing.Point(78, 362);
            this.genreBasicLabel.Name = "genreBasicLabel";
            this.genreBasicLabel.Size = new System.Drawing.Size(244, 31);
            this.genreBasicLabel.TabIndex = 27;
            this.genreBasicLabel.Text = "Gatunek";
            this.genreBasicLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backSecondButton
            // 
            this.backSecondButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.backSecondButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backSecondButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.backSecondButton.Location = new System.Drawing.Point(17, 634);
            this.backSecondButton.Name = "backSecondButton";
            this.backSecondButton.Size = new System.Drawing.Size(72, 54);
            this.backSecondButton.TabIndex = 29;
            this.backSecondButton.Text = "Wróć";
            this.backSecondButton.UseVisualStyleBackColor = false;
            this.backSecondButton.Click += new System.EventHandler(this.backSecondButton_Click);
            // 
            // toReadButton
            // 
            this.toReadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(185)))), ((int)(((byte)(22)))));
            this.toReadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.toReadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toReadButton.Location = new System.Drawing.Point(84, 506);
            this.toReadButton.Name = "toReadButton";
            this.toReadButton.Size = new System.Drawing.Size(238, 54);
            this.toReadButton.TabIndex = 30;
            this.toReadButton.Text = "Do przeczytania!";
            this.toReadButton.UseVisualStyleBackColor = false;
            this.toReadButton.Click += new System.EventHandler(this.toReadButton_Click);
            // 
            // QuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(400, 700);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuizForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "s";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.finalBookPanel.ResumeLayout(false);
            this.finalBookPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton firstAnswerButton;
        private System.Windows.Forms.RadioButton secondAnswerButton;
        private System.Windows.Forms.RadioButton thirdAnswerButton;
        private System.Windows.Forms.RadioButton fourthAnswerButton;
        private System.Windows.Forms.Button nextQuestionButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel finalBookPanel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.Label genreBasicLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label titleBasicLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label authorBasicLabel;
        private System.Windows.Forms.Label bookBasicLabel;
        private System.Windows.Forms.Button toReadButton;
        private System.Windows.Forms.Button backSecondButton;
    }
}