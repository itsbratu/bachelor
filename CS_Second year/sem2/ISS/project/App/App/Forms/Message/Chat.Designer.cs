
namespace App.Forms.Message
{
    partial class Chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            this.label_idBug = new System.Windows.Forms.Label();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.comboBoxIdBug = new System.Windows.Forms.ComboBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_idBug
            // 
            this.label_idBug.AutoSize = true;
            this.label_idBug.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label_idBug.Location = new System.Drawing.Point(476, 40);
            this.label_idBug.Name = "label_idBug";
            this.label_idBug.Size = new System.Drawing.Size(115, 37);
            this.label_idBug.TabIndex = 0;
            this.label_idBug.Text = "Id bug:";
            // 
            // textBoxContent
            // 
            this.textBoxContent.BackColor = System.Drawing.Color.DarkMagenta;
            this.textBoxContent.Location = new System.Drawing.Point(61, 186);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(991, 587);
            this.textBoxContent.TabIndex = 8;
            // 
            // comboBoxIdBug
            // 
            this.comboBoxIdBug.BackColor = System.Drawing.Color.DarkMagenta;
            this.comboBoxIdBug.FormattingEnabled = true;
            this.comboBoxIdBug.Location = new System.Drawing.Point(441, 111);
            this.comboBoxIdBug.Name = "comboBoxIdBug";
            this.comboBoxIdBug.Size = new System.Drawing.Size(193, 28);
            this.comboBoxIdBug.TabIndex = 10;
            this.comboBoxIdBug.SelectionChangeCommitted += new System.EventHandler(this.comboBoxIdBug_SelectionChangeCommitted);
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.SkyBlue;
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.Location = new System.Drawing.Point(937, 847);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(115, 44);
            this.sendButton.TabIndex = 26;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(61, 40);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(122, 51);
            this.backButton.TabIndex = 27;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.BackColor = System.Drawing.Color.DarkMagenta;
            this.textBoxMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMsg.Location = new System.Drawing.Point(61, 853);
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.Size = new System.Drawing.Size(850, 35);
            this.textBoxMsg.TabIndex = 28;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.ClientSize = new System.Drawing.Size(1112, 960);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.comboBoxIdBug);
            this.Controls.Add(this.textBoxContent);
            this.Controls.Add(this.label_idBug);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chat";
            this.Text = "Send Message";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_idBug;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.ComboBox comboBoxIdBug;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox textBoxMsg;
    }
}