
namespace App.Tester
{
    partial class AddBug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBug));
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelAddBug = new System.Windows.Forms.Label();
            this.labelCodeId = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelSeverity = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxSeverity = new System.Windows.Forms.ComboBox();
            this.comboBoxCodeId = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(32, 33);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(115, 55);
            this.buttonBack.TabIndex = 15;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelAddBug
            // 
            this.labelAddBug.AutoSize = true;
            this.labelAddBug.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddBug.Location = new System.Drawing.Point(246, 33);
            this.labelAddBug.Name = "labelAddBug";
            this.labelAddBug.Size = new System.Drawing.Size(217, 55);
            this.labelAddBug.TabIndex = 16;
            this.labelAddBug.Text = "Add bug:";
            // 
            // labelCodeId
            // 
            this.labelCodeId.AutoSize = true;
            this.labelCodeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodeId.Location = new System.Drawing.Point(57, 169);
            this.labelCodeId.Name = "labelCodeId";
            this.labelCodeId.Size = new System.Drawing.Size(125, 32);
            this.labelCodeId.TabIndex = 17;
            this.labelCodeId.Text = "Code ID:";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(259, 258);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(166, 32);
            this.labelDescription.TabIndex = 18;
            this.labelDescription.Text = "Description:";
            // 
            // labelSeverity
            // 
            this.labelSeverity.AutoSize = true;
            this.labelSeverity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSeverity.Location = new System.Drawing.Point(57, 649);
            this.labelSeverity.Name = "labelSeverity";
            this.labelSeverity.Size = new System.Drawing.Size(126, 32);
            this.labelSeverity.TabIndex = 19;
            this.labelSeverity.Text = "Severity:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(63, 305);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(542, 304);
            this.textBoxDescription.TabIndex = 21;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(256, 753);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(169, 50);
            this.buttonAdd.TabIndex = 23;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // comboBoxSeverity
            // 
            this.comboBoxSeverity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSeverity.FormattingEnabled = true;
            this.comboBoxSeverity.Location = new System.Drawing.Point(208, 644);
            this.comboBoxSeverity.Name = "comboBoxSeverity";
            this.comboBoxSeverity.Size = new System.Drawing.Size(302, 37);
            this.comboBoxSeverity.TabIndex = 24;
            // 
            // comboBoxCodeId
            // 
            this.comboBoxCodeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCodeId.FormattingEnabled = true;
            this.comboBoxCodeId.Location = new System.Drawing.Point(208, 164);
            this.comboBoxCodeId.Name = "comboBoxCodeId";
            this.comboBoxCodeId.Size = new System.Drawing.Size(302, 37);
            this.comboBoxCodeId.TabIndex = 25;
            // 
            // AddBug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.ClientSize = new System.Drawing.Size(728, 894);
            this.Controls.Add(this.comboBoxCodeId);
            this.Controls.Add(this.comboBoxSeverity);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelSeverity);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelCodeId);
            this.Controls.Add(this.labelAddBug);
            this.Controls.Add(this.buttonBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddBug";
            this.Text = "Add Bug";
            this.Load += new System.EventHandler(this.AddBug_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelAddBug;
        private System.Windows.Forms.Label labelCodeId;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelSeverity;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ComboBox comboBoxSeverity;
        private System.Windows.Forms.ComboBox comboBoxCodeId;
    }
}