
namespace App.Programmer
{
    partial class ViewReviews
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewReviews));
            this.backButton = new System.Windows.Forms.Button();
            this.labelReviews = new System.Windows.Forms.Label();
            this.viewEntities = new System.Windows.Forms.DataGridView();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.viewEntities)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(84, 52);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(122, 51);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // labelReviews
            // 
            this.labelReviews.AutoSize = true;
            this.labelReviews.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReviews.Location = new System.Drawing.Point(611, 57);
            this.labelReviews.Name = "labelReviews";
            this.labelReviews.Size = new System.Drawing.Size(170, 46);
            this.labelReviews.TabIndex = 4;
            this.labelReviews.Text = "Reviews";
            // 
            // viewEntities
            // 
            this.viewEntities.BackgroundColor = System.Drawing.Color.DarkMagenta;
            this.viewEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewEntities.Location = new System.Drawing.Point(84, 135);
            this.viewEntities.Name = "viewEntities";
            this.viewEntities.RowHeadersWidth = 62;
            this.viewEntities.RowTemplate.Height = 28;
            this.viewEntities.Size = new System.Drawing.Size(592, 587);
            this.viewEntities.TabIndex = 5;
            this.viewEntities.SelectionChanged += new System.EventHandler(this.viewEntities_SelectionChanged);
            // 
            // textBoxContent
            // 
            this.textBoxContent.Location = new System.Drawing.Point(697, 135);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(629, 587);
            this.textBoxContent.TabIndex = 7;
            // 
            // ViewReviews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.ClientSize = new System.Drawing.Size(1452, 919);
            this.Controls.Add(this.textBoxContent);
            this.Controls.Add(this.viewEntities);
            this.Controls.Add(this.labelReviews);
            this.Controls.Add(this.backButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewReviews";
            this.Text = "View Reviews";
            this.Load += new System.EventHandler(this.ViewReviews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewEntities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label labelReviews;
        private System.Windows.Forms.DataGridView viewEntities;
        private System.Windows.Forms.TextBox textBoxContent;
    }
}