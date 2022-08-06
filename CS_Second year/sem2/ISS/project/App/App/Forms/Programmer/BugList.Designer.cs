
namespace App.Forms.Programmer
{
    partial class BugList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BugList));
            this.buttonBack = new System.Windows.Forms.Button();
            this.viewEntities = new System.Windows.Forms.DataGridView();
            this.labelBugList = new System.Windows.Forms.Label();
            this.textBoxBugInfo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.viewEntities)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Transparent;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(47, 47);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(115, 55);
            this.buttonBack.TabIndex = 15;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // viewEntities
            // 
            this.viewEntities.BackgroundColor = System.Drawing.Color.DarkMagenta;
            this.viewEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewEntities.Location = new System.Drawing.Point(47, 127);
            this.viewEntities.Name = "viewEntities";
            this.viewEntities.RowHeadersWidth = 62;
            this.viewEntities.RowTemplate.Height = 28;
            this.viewEntities.Size = new System.Drawing.Size(608, 587);
            this.viewEntities.TabIndex = 16;
            this.viewEntities.SelectionChanged += new System.EventHandler(this.viewEntities_SelectionChanged);
            // 
            // labelBugList
            // 
            this.labelBugList.AutoSize = true;
            this.labelBugList.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBugList.Location = new System.Drawing.Point(615, 47);
            this.labelBugList.Name = "labelBugList";
            this.labelBugList.Size = new System.Drawing.Size(111, 46);
            this.labelBugList.TabIndex = 17;
            this.labelBugList.Text = "Bugs";
            this.labelBugList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxBugInfo
            // 
            this.textBoxBugInfo.Location = new System.Drawing.Point(670, 127);
            this.textBoxBugInfo.Multiline = true;
            this.textBoxBugInfo.Name = "textBoxBugInfo";
            this.textBoxBugInfo.Size = new System.Drawing.Size(538, 525);
            this.textBoxBugInfo.TabIndex = 18;
            // 
            // BugList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.ClientSize = new System.Drawing.Size(1245, 786);
            this.Controls.Add(this.textBoxBugInfo);
            this.Controls.Add(this.labelBugList);
            this.Controls.Add(this.viewEntities);
            this.Controls.Add(this.buttonBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BugList";
            this.Text = "Bug List";
            this.Load += new System.EventHandler(this.BugList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewEntities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.DataGridView viewEntities;
        private System.Windows.Forms.Label labelBugList;
        private System.Windows.Forms.TextBox textBoxBugInfo;
    }
}