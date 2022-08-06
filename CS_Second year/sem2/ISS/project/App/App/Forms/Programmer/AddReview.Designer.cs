
namespace App.Programmer
{
    partial class AddReview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddReview));
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelAddReview = new System.Windows.Forms.Label();
            this.labelCodeId = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelFeedback = new System.Windows.Forms.Label();
            this.comboBoxFeedback = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxCodeId = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.DarkMagenta;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonBack.Location = new System.Drawing.Point(45, 37);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(115, 55);
            this.buttonBack.TabIndex = 16;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelAddReview
            // 
            this.labelAddReview.AutoSize = true;
            this.labelAddReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddReview.Location = new System.Drawing.Point(237, 96);
            this.labelAddReview.Name = "labelAddReview";
            this.labelAddReview.Size = new System.Drawing.Size(275, 55);
            this.labelAddReview.TabIndex = 17;
            this.labelAddReview.Text = "Add review:";
            // 
            // labelCodeId
            // 
            this.labelCodeId.AutoSize = true;
            this.labelCodeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodeId.Location = new System.Drawing.Point(132, 196);
            this.labelCodeId.Name = "labelCodeId";
            this.labelCodeId.Size = new System.Drawing.Size(125, 32);
            this.labelCodeId.TabIndex = 18;
            this.labelCodeId.Text = "Code ID:";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(293, 285);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(166, 32);
            this.labelDescription.TabIndex = 19;
            this.labelDescription.Text = "Description:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.White;
            this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDescription.Location = new System.Drawing.Point(187, 358);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(437, 304);
            this.textBoxDescription.TabIndex = 22;
            // 
            // labelFeedback
            // 
            this.labelFeedback.AutoSize = true;
            this.labelFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFeedback.Location = new System.Drawing.Point(89, 733);
            this.labelFeedback.Name = "labelFeedback";
            this.labelFeedback.Size = new System.Drawing.Size(148, 32);
            this.labelFeedback.TabIndex = 23;
            this.labelFeedback.Text = "Feedback:";
            // 
            // comboBoxFeedback
            // 
            this.comboBoxFeedback.BackColor = System.Drawing.Color.White;
            this.comboBoxFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFeedback.FormattingEnabled = true;
            this.comboBoxFeedback.Location = new System.Drawing.Point(265, 733);
            this.comboBoxFeedback.Name = "comboBoxFeedback";
            this.comboBoxFeedback.Size = new System.Drawing.Size(323, 37);
            this.comboBoxFeedback.TabIndex = 24;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.White;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(299, 824);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(115, 55);
            this.buttonAdd.TabIndex = 25;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // comboBoxCodeId
            // 
            this.comboBoxCodeId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxCodeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCodeId.FormattingEnabled = true;
            this.comboBoxCodeId.Location = new System.Drawing.Point(299, 196);
            this.comboBoxCodeId.Name = "comboBoxCodeId";
            this.comboBoxCodeId.Size = new System.Drawing.Size(160, 37);
            this.comboBoxCodeId.TabIndex = 26;
            // 
            // AddReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.ClientSize = new System.Drawing.Size(700, 914);
            this.Controls.Add(this.comboBoxCodeId);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.comboBoxFeedback);
            this.Controls.Add(this.labelFeedback);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelCodeId);
            this.Controls.Add(this.labelAddReview);
            this.Controls.Add(this.buttonBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddReview";
            this.Text = "Add Review";
            this.Load += new System.EventHandler(this.AddReview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelAddReview;
        private System.Windows.Forms.Label labelCodeId;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelFeedback;
        private System.Windows.Forms.ComboBox comboBoxFeedback;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ComboBox comboBoxCodeId;
    }
}