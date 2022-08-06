
namespace App.Programmer
{
    partial class FixBug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FixBug));
            this.backButton = new System.Windows.Forms.Button();
            this.labelFix = new System.Windows.Forms.Label();
            this.labelBugId = new System.Windows.Forms.Label();
            this.buttonFix = new System.Windows.Forms.Button();
            this.comboBoxIds = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(31, 27);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(122, 51);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // labelFix
            // 
            this.labelFix.AutoSize = true;
            this.labelFix.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFix.Location = new System.Drawing.Point(163, 108);
            this.labelFix.Name = "labelFix";
            this.labelFix.Size = new System.Drawing.Size(156, 46);
            this.labelFix.TabIndex = 5;
            this.labelFix.Text = "Bug Fix";
            // 
            // labelBugId
            // 
            this.labelBugId.AutoSize = true;
            this.labelBugId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBugId.Location = new System.Drawing.Point(26, 209);
            this.labelBugId.Name = "labelBugId";
            this.labelBugId.Size = new System.Drawing.Size(91, 29);
            this.labelBugId.TabIndex = 6;
            this.labelBugId.Text = "Bug ID:";
            // 
            // buttonFix
            // 
            this.buttonFix.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonFix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFix.Location = new System.Drawing.Point(171, 295);
            this.buttonFix.Name = "buttonFix";
            this.buttonFix.Size = new System.Drawing.Size(122, 51);
            this.buttonFix.TabIndex = 7;
            this.buttonFix.Text = "Fix";
            this.buttonFix.UseVisualStyleBackColor = false;
            this.buttonFix.Click += new System.EventHandler(this.buttonFix_Click);
            // 
            // comboBoxIds
            // 
            this.comboBoxIds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxIds.FormattingEnabled = true;
            this.comboBoxIds.Location = new System.Drawing.Point(136, 205);
            this.comboBoxIds.Name = "comboBoxIds";
            this.comboBoxIds.Size = new System.Drawing.Size(228, 33);
            this.comboBoxIds.TabIndex = 8;
            // 
            // FixBug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.ClientSize = new System.Drawing.Size(444, 409);
            this.Controls.Add(this.comboBoxIds);
            this.Controls.Add(this.buttonFix);
            this.Controls.Add(this.labelBugId);
            this.Controls.Add(this.labelFix);
            this.Controls.Add(this.backButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FixBug";
            this.Text = "Fix Bug";
            this.Load += new System.EventHandler(this.FixBug_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label labelFix;
        private System.Windows.Forms.Label labelBugId;
        private System.Windows.Forms.Button buttonFix;
        private System.Windows.Forms.ComboBox comboBoxIds;
    }
}