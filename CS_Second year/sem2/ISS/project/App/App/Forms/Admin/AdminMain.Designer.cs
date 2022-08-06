
namespace App
{
    partial class AdminMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMain));
            this.buttonViewUsers = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.buttonDeleteUser = new System.Windows.Forms.Button();
            this.buttonModifyUser = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.label_userName = new System.Windows.Forms.Label();
            this.label_jobTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonViewUsers
            // 
            this.buttonViewUsers.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonViewUsers.Location = new System.Drawing.Point(90, 145);
            this.buttonViewUsers.Name = "buttonViewUsers";
            this.buttonViewUsers.Size = new System.Drawing.Size(212, 63);
            this.buttonViewUsers.TabIndex = 0;
            this.buttonViewUsers.Text = "View Users";
            this.buttonViewUsers.UseVisualStyleBackColor = false;
            this.buttonViewUsers.Click += new System.EventHandler(this.buttonViewUsers_Click);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonAddUser.Location = new System.Drawing.Point(90, 253);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(212, 63);
            this.buttonAddUser.TabIndex = 1;
            this.buttonAddUser.Text = "Add User";
            this.buttonAddUser.UseVisualStyleBackColor = false;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // buttonDeleteUser
            // 
            this.buttonDeleteUser.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonDeleteUser.Location = new System.Drawing.Point(90, 366);
            this.buttonDeleteUser.Name = "buttonDeleteUser";
            this.buttonDeleteUser.Size = new System.Drawing.Size(212, 63);
            this.buttonDeleteUser.TabIndex = 2;
            this.buttonDeleteUser.Text = "Delete User";
            this.buttonDeleteUser.UseVisualStyleBackColor = false;
            this.buttonDeleteUser.Click += new System.EventHandler(this.buttonDeleteUser_Click);
            // 
            // buttonModifyUser
            // 
            this.buttonModifyUser.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonModifyUser.Location = new System.Drawing.Point(90, 478);
            this.buttonModifyUser.Name = "buttonModifyUser";
            this.buttonModifyUser.Size = new System.Drawing.Size(212, 63);
            this.buttonModifyUser.TabIndex = 3;
            this.buttonModifyUser.Text = "Modify User";
            this.buttonModifyUser.UseVisualStyleBackColor = false;
            this.buttonModifyUser.Click += new System.EventHandler(this.buttonModifyUser_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(12, 12);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(98, 43);
            this.buttonLogout.TabIndex = 4;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.ForeColor = System.Drawing.Color.White;
            this.label_userName.Location = new System.Drawing.Point(260, 619);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(51, 20);
            this.label_userName.TabIndex = 5;
            this.label_userName.Text = "label1";
            // 
            // label_jobTitle
            // 
            this.label_jobTitle.AutoSize = true;
            this.label_jobTitle.Font = new System.Drawing.Font("MS PGothic", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_jobTitle.ForeColor = System.Drawing.Color.White;
            this.label_jobTitle.Location = new System.Drawing.Point(28, 607);
            this.label_jobTitle.Name = "label_jobTitle";
            this.label_jobTitle.Size = new System.Drawing.Size(92, 33);
            this.label_jobTitle.TabIndex = 6;
            this.label_jobTitle.Text = "label2";
            // 
            // AdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.ClientSize = new System.Drawing.Size(392, 659);
            this.Controls.Add(this.label_jobTitle);
            this.Controls.Add(this.label_userName);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonModifyUser);
            this.Controls.Add(this.buttonDeleteUser);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.buttonViewUsers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminMain";
            this.Text = "Admin Main";
            this.Load += new System.EventHandler(this.AdminMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonViewUsers;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonDeleteUser;
        private System.Windows.Forms.Button buttonModifyUser;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Label label_userName;
        private System.Windows.Forms.Label label_jobTitle;
    }
}