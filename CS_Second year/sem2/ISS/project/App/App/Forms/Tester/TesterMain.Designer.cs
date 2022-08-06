
namespace App.Tester
{
    partial class TesterMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TesterMain));
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonAddBug = new System.Windows.Forms.Button();
            this.label_userName = new System.Windows.Forms.Label();
            this.label_jobTitle = new System.Windows.Forms.Label();
            this.buttonChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.DarkMagenta;
            this.buttonLogout.Location = new System.Drawing.Point(12, 12);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(98, 43);
            this.buttonLogout.TabIndex = 5;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonAddBug
            // 
            this.buttonAddBug.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonAddBug.Location = new System.Drawing.Point(102, 137);
            this.buttonAddBug.Name = "buttonAddBug";
            this.buttonAddBug.Size = new System.Drawing.Size(212, 63);
            this.buttonAddBug.TabIndex = 6;
            this.buttonAddBug.Text = "Add bug";
            this.buttonAddBug.UseVisualStyleBackColor = false;
            this.buttonAddBug.Click += new System.EventHandler(this.buttonAddBug_Click);
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.ForeColor = System.Drawing.Color.White;
            this.label_userName.Location = new System.Drawing.Point(241, 494);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(51, 20);
            this.label_userName.TabIndex = 9;
            this.label_userName.Text = "label1";
            // 
            // label_jobTitle
            // 
            this.label_jobTitle.AutoSize = true;
            this.label_jobTitle.Font = new System.Drawing.Font("MS PGothic", 16F, System.Drawing.FontStyle.Italic);
            this.label_jobTitle.ForeColor = System.Drawing.Color.White;
            this.label_jobTitle.Location = new System.Drawing.Point(27, 481);
            this.label_jobTitle.Name = "label_jobTitle";
            this.label_jobTitle.Size = new System.Drawing.Size(92, 33);
            this.label_jobTitle.TabIndex = 10;
            this.label_jobTitle.Text = "label2";
            // 
            // buttonChat
            // 
            this.buttonChat.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonChat.Location = new System.Drawing.Point(102, 280);
            this.buttonChat.Name = "buttonChat";
            this.buttonChat.Size = new System.Drawing.Size(212, 63);
            this.buttonChat.TabIndex = 11;
            this.buttonChat.Text = "Chat";
            this.buttonChat.UseVisualStyleBackColor = false;
            this.buttonChat.Click += new System.EventHandler(this.buttonChat_Click);
            // 
            // TesterMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.ClientSize = new System.Drawing.Size(405, 541);
            this.Controls.Add(this.buttonChat);
            this.Controls.Add(this.label_jobTitle);
            this.Controls.Add(this.label_userName);
            this.Controls.Add(this.buttonAddBug);
            this.Controls.Add(this.buttonLogout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TesterMain";
            this.Text = "Tester Main";
            this.Load += new System.EventHandler(this.TesterMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonAddBug;
        private System.Windows.Forms.Label label_userName;
        private System.Windows.Forms.Label label_jobTitle;
        private System.Windows.Forms.Button buttonChat;
    }
}