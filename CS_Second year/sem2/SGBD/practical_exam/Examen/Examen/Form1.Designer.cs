
namespace Examen
{
    partial class Form1
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
            this.dataGridCofetarii = new System.Windows.Forms.DataGridView();
            this.dataGridBriose = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCofetarii)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBriose)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridCofetarii
            // 
            this.dataGridCofetarii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCofetarii.Location = new System.Drawing.Point(41, 21);
            this.dataGridCofetarii.Name = "dataGridCofetarii";
            this.dataGridCofetarii.RowHeadersWidth = 62;
            this.dataGridCofetarii.RowTemplate.Height = 28;
            this.dataGridCofetarii.Size = new System.Drawing.Size(790, 487);
            this.dataGridCofetarii.TabIndex = 0;
            this.dataGridCofetarii.SelectionChanged += new System.EventHandler(this.dataGridCofetarii_SelectionChanged);
            // 
            // dataGridBriose
            // 
            this.dataGridBriose.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBriose.Location = new System.Drawing.Point(876, 21);
            this.dataGridBriose.Name = "dataGridBriose";
            this.dataGridBriose.RowHeadersWidth = 62;
            this.dataGridBriose.RowTemplate.Height = 28;
            this.dataGridBriose.Size = new System.Drawing.Size(826, 487);
            this.dataGridBriose.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(782, 558);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(164, 68);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1734, 650);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dataGridBriose);
            this.Controls.Add(this.dataGridCofetarii);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCofetarii)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBriose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridCofetarii;
        private System.Windows.Forms.DataGridView dataGridBriose;
        private System.Windows.Forms.Button saveButton;
    }
}

