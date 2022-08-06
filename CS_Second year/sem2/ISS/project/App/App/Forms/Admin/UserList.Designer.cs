
namespace App
{
    partial class UserList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserList));
            this.viewEntities = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            this.labelUsersList = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.viewEntities)).BeginInit();
            this.SuspendLayout();
            // 
            // viewEntities
            // 
            this.viewEntities.BackgroundColor = System.Drawing.Color.DarkMagenta;
            this.viewEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewEntities.Location = new System.Drawing.Point(100, 125);
            this.viewEntities.Name = "viewEntities";
            this.viewEntities.RowHeadersVisible = false;
            this.viewEntities.RowHeadersWidth = 62;
            this.viewEntities.RowTemplate.Height = 28;
            this.viewEntities.Size = new System.Drawing.Size(1206, 724);
            this.viewEntities.TabIndex = 0;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(47, 37);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(122, 51);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // labelUsersList
            // 
            this.labelUsersList.AutoSize = true;
            this.labelUsersList.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsersList.Location = new System.Drawing.Point(707, 42);
            this.labelUsersList.Name = "labelUsersList";
            this.labelUsersList.Size = new System.Drawing.Size(124, 46);
            this.labelUsersList.TabIndex = 2;
            this.labelUsersList.Text = "Users";
            this.labelUsersList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.ClientSize = new System.Drawing.Size(1924, 944);
            this.Controls.Add(this.labelUsersList);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.viewEntities);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserList";
            this.Text = "Users List";
            this.Load += new System.EventHandler(this.UserList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewEntities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView viewEntities;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label labelUsersList;
    }
}