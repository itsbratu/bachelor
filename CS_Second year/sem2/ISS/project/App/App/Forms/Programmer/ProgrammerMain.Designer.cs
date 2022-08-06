
namespace App.Forms.Programmer
{
    partial class ProgrammerMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgrammerMain));
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonViewBugs = new System.Windows.Forms.Button();
            this.buttonFixBug = new System.Windows.Forms.Button();
            this.buttonViewReviews = new System.Windows.Forms.Button();
            this.buttonAddReview = new System.Windows.Forms.Button();
            this.label_jobTitle = new System.Windows.Forms.Label();
            this.label_userName = new System.Windows.Forms.Label();
            this.buttonChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(42, 36);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(98, 43);
            this.buttonLogout.TabIndex = 5;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonViewBugs
            // 
            this.buttonViewBugs.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonViewBugs.Location = new System.Drawing.Point(169, 135);
            this.buttonViewBugs.Name = "buttonViewBugs";
            this.buttonViewBugs.Size = new System.Drawing.Size(212, 63);
            this.buttonViewBugs.TabIndex = 6;
            this.buttonViewBugs.Text = "View Bugs";
            this.buttonViewBugs.UseVisualStyleBackColor = false;
            this.buttonViewBugs.Click += new System.EventHandler(this.buttonViewBugs_Click);
            // 
            // buttonFixBug
            // 
            this.buttonFixBug.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonFixBug.Location = new System.Drawing.Point(169, 261);
            this.buttonFixBug.Name = "buttonFixBug";
            this.buttonFixBug.Size = new System.Drawing.Size(212, 63);
            this.buttonFixBug.TabIndex = 7;
            this.buttonFixBug.Text = "Fix Bug";
            this.buttonFixBug.UseVisualStyleBackColor = false;
            this.buttonFixBug.Click += new System.EventHandler(this.buttonFixBug_Click);
            // 
            // buttonViewReviews
            // 
            this.buttonViewReviews.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonViewReviews.Location = new System.Drawing.Point(169, 548);
            this.buttonViewReviews.Name = "buttonViewReviews";
            this.buttonViewReviews.Size = new System.Drawing.Size(212, 63);
            this.buttonViewReviews.TabIndex = 10;
            this.buttonViewReviews.Text = "View Reviews";
            this.buttonViewReviews.UseVisualStyleBackColor = false;
            this.buttonViewReviews.Click += new System.EventHandler(this.buttonViewReviews_Click);
            // 
            // buttonAddReview
            // 
            this.buttonAddReview.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonAddReview.Location = new System.Drawing.Point(169, 406);
            this.buttonAddReview.Name = "buttonAddReview";
            this.buttonAddReview.Size = new System.Drawing.Size(212, 63);
            this.buttonAddReview.TabIndex = 11;
            this.buttonAddReview.Text = "Add Review";
            this.buttonAddReview.UseVisualStyleBackColor = false;
            this.buttonAddReview.Click += new System.EventHandler(this.buttonAddReview_Click);
            // 
            // label_jobTitle
            // 
            this.label_jobTitle.AutoSize = true;
            this.label_jobTitle.Font = new System.Drawing.Font("MS PGothic", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_jobTitle.ForeColor = System.Drawing.Color.White;
            this.label_jobTitle.Location = new System.Drawing.Point(48, 906);
            this.label_jobTitle.Name = "label_jobTitle";
            this.label_jobTitle.Size = new System.Drawing.Size(92, 33);
            this.label_jobTitle.TabIndex = 12;
            this.label_jobTitle.Text = "label2";
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.ForeColor = System.Drawing.Color.White;
            this.label_userName.Location = new System.Drawing.Point(383, 919);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(51, 20);
            this.label_userName.TabIndex = 13;
            this.label_userName.Text = "label1";
            // 
            // buttonChat
            // 
            this.buttonChat.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonChat.Location = new System.Drawing.Point(169, 689);
            this.buttonChat.Name = "buttonChat";
            this.buttonChat.Size = new System.Drawing.Size(212, 63);
            this.buttonChat.TabIndex = 14;
            this.buttonChat.Text = "Chat";
            this.buttonChat.UseVisualStyleBackColor = false;
            this.buttonChat.Click += new System.EventHandler(this.buttonChat_Click);
            // 
            // ProgrammerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.ClientSize = new System.Drawing.Size(534, 1050);
            this.Controls.Add(this.buttonChat);
            this.Controls.Add(this.label_userName);
            this.Controls.Add(this.label_jobTitle);
            this.Controls.Add(this.buttonAddReview);
            this.Controls.Add(this.buttonViewReviews);
            this.Controls.Add(this.buttonFixBug);
            this.Controls.Add(this.buttonViewBugs);
            this.Controls.Add(this.buttonLogout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProgrammerMain";
            this.Text = "Programmer Main";
            this.Load += new System.EventHandler(this.ProgrammerMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonViewBugs;
        private System.Windows.Forms.Button buttonFixBug;
        private System.Windows.Forms.Button buttonViewReviews;
        private System.Windows.Forms.Button buttonAddReview;
        private System.Windows.Forms.Label label_jobTitle;
        private System.Windows.Forms.Label label_userName;
        private System.Windows.Forms.Button buttonChat;
    }
}