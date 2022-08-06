
namespace Laborator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gridParents = new System.Windows.Forms.DataGridView();
            this.titluParinti = new System.Windows.Forms.Label();
            this.gridChildren = new System.Windows.Forms.DataGridView();
            this.titluCopii = new System.Windows.Forms.Label();
            this.refreshAll = new System.Windows.Forms.Button();
            this.deleteChild = new System.Windows.Forms.Button();
            this.modChild = new System.Windows.Forms.Button();
            this.labelModMarca = new System.Windows.Forms.Label();
            this.labelModModel = new System.Windows.Forms.Label();
            this.labelModNumar = new System.Windows.Forms.Label();
            this.inputModMarca = new System.Windows.Forms.TextBox();
            this.inputModModel = new System.Windows.Forms.TextBox();
            this.inputModNumar = new System.Windows.Forms.TextBox();
            this.acceptModChild = new System.Windows.Forms.Button();
            this.addChild = new System.Windows.Forms.Button();
            this.labelAddMarca = new System.Windows.Forms.Label();
            this.labelAddModel = new System.Windows.Forms.Label();
            this.labelAddNumar = new System.Windows.Forms.Label();
            this.inputAddMarca = new System.Windows.Forms.TextBox();
            this.inputAddModel = new System.Windows.Forms.TextBox();
            this.inputAddNumar = new System.Windows.Forms.TextBox();
            this.acceptAddChild = new System.Windows.Forms.Button();
            this.labelModSofer = new System.Windows.Forms.Label();
            this.inputModSofer = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridParents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChildren)).BeginInit();
            this.SuspendLayout();
            // 
            // gridParents
            // 
            this.gridParents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridParents.Location = new System.Drawing.Point(12, 106);
            this.gridParents.Name = "gridParents";
            this.gridParents.RowHeadersWidth = 30;
            this.gridParents.RowTemplate.Height = 28;
            this.gridParents.Size = new System.Drawing.Size(747, 489);
            this.gridParents.TabIndex = 0;
            this.gridParents.SelectionChanged += new System.EventHandler(this.gridParinti_SelectionChanged);
            // 
            // titluParinti
            // 
            this.titluParinti.AutoSize = true;
            this.titluParinti.Font = new System.Drawing.Font("SimSun", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titluParinti.Location = new System.Drawing.Point(148, 36);
            this.titluParinti.Name = "titluParinti";
            this.titluParinti.Size = new System.Drawing.Size(396, 56);
            this.titluParinti.TabIndex = 1;
            this.titluParinti.Text = "Tabel-Părinte";
            // 
            // gridChildren
            // 
            this.gridChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridChildren.Location = new System.Drawing.Point(947, 106);
            this.gridChildren.Name = "gridChildren";
            this.gridChildren.RowHeadersWidth = 62;
            this.gridChildren.RowTemplate.Height = 28;
            this.gridChildren.Size = new System.Drawing.Size(747, 489);
            this.gridChildren.TabIndex = 2;
            this.gridChildren.SelectionChanged += new System.EventHandler(this.gridCopii_SelectionChanged);
            // 
            // titluCopii
            // 
            this.titluCopii.AutoSize = true;
            this.titluCopii.Font = new System.Drawing.Font("SimSun", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titluCopii.Location = new System.Drawing.Point(1136, 36);
            this.titluCopii.Name = "titluCopii";
            this.titluCopii.Size = new System.Drawing.Size(343, 56);
            this.titluCopii.TabIndex = 3;
            this.titluCopii.Text = "Tabel-Copii";
            // 
            // refreshAll
            // 
            this.refreshAll.BackColor = System.Drawing.Color.Transparent;
            this.refreshAll.Font = new System.Drawing.Font("SimSun", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshAll.Image = ((System.Drawing.Image)(resources.GetObject("refreshAll.Image")));
            this.refreshAll.Location = new System.Drawing.Point(796, 251);
            this.refreshAll.Name = "refreshAll";
            this.refreshAll.Size = new System.Drawing.Size(134, 131);
            this.refreshAll.TabIndex = 4;
            this.refreshAll.UseVisualStyleBackColor = false;
            this.refreshAll.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteChild
            // 
            this.deleteChild.Font = new System.Drawing.Font("SimSun", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteChild.Location = new System.Drawing.Point(759, 720);
            this.deleteChild.Name = "deleteChild";
            this.deleteChild.Size = new System.Drawing.Size(171, 47);
            this.deleteChild.TabIndex = 5;
            this.deleteChild.Text = "Sterge fiu";
            this.deleteChild.UseVisualStyleBackColor = true;
            this.deleteChild.Visible = false;
            this.deleteChild.Click += new System.EventHandler(this.deleteChild_Click);
            // 
            // modChild
            // 
            this.modChild.Font = new System.Drawing.Font("SimSun", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modChild.Location = new System.Drawing.Point(759, 667);
            this.modChild.Name = "modChild";
            this.modChild.Size = new System.Drawing.Size(171, 47);
            this.modChild.TabIndex = 6;
            this.modChild.Text = "Modifica";
            this.modChild.UseVisualStyleBackColor = true;
            this.modChild.Visible = false;
            this.modChild.Click += new System.EventHandler(this.modifyChild_Click);
            // 
            // labelModMarca
            // 
            this.labelModMarca.AutoSize = true;
            this.labelModMarca.Font = new System.Drawing.Font("SimSun", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModMarca.Location = new System.Drawing.Point(1140, 664);
            this.labelModMarca.Name = "labelModMarca";
            this.labelModMarca.Size = new System.Drawing.Size(117, 33);
            this.labelModMarca.TabIndex = 7;
            this.labelModMarca.Text = "Marca:";
            this.labelModMarca.Visible = false;
            // 
            // labelModModel
            // 
            this.labelModModel.AutoSize = true;
            this.labelModModel.Font = new System.Drawing.Font("SimSun", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModModel.Location = new System.Drawing.Point(1140, 747);
            this.labelModModel.Name = "labelModModel";
            this.labelModModel.Size = new System.Drawing.Size(117, 33);
            this.labelModModel.TabIndex = 8;
            this.labelModModel.Text = "Model:";
            this.labelModModel.Visible = false;
            // 
            // labelModNumar
            // 
            this.labelModNumar.AutoSize = true;
            this.labelModNumar.Font = new System.Drawing.Font("SimSun", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModNumar.Location = new System.Drawing.Point(1140, 829);
            this.labelModNumar.Name = "labelModNumar";
            this.labelModNumar.Size = new System.Drawing.Size(117, 33);
            this.labelModNumar.TabIndex = 9;
            this.labelModNumar.Text = "Numar:";
            this.labelModNumar.Visible = false;
            // 
            // inputModMarca
            // 
            this.inputModMarca.Font = new System.Drawing.Font("SimSun", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputModMarca.Location = new System.Drawing.Point(1307, 644);
            this.inputModMarca.Name = "inputModMarca";
            this.inputModMarca.Size = new System.Drawing.Size(260, 53);
            this.inputModMarca.TabIndex = 10;
            this.inputModMarca.Visible = false;
            // 
            // inputModModel
            // 
            this.inputModModel.Font = new System.Drawing.Font("SimSun", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputModModel.Location = new System.Drawing.Point(1307, 734);
            this.inputModModel.Name = "inputModModel";
            this.inputModModel.Size = new System.Drawing.Size(260, 53);
            this.inputModModel.TabIndex = 11;
            this.inputModModel.Visible = false;
            // 
            // inputModNumar
            // 
            this.inputModNumar.Font = new System.Drawing.Font("SimSun", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputModNumar.Location = new System.Drawing.Point(1307, 809);
            this.inputModNumar.Name = "inputModNumar";
            this.inputModNumar.Size = new System.Drawing.Size(260, 53);
            this.inputModNumar.TabIndex = 12;
            this.inputModNumar.Visible = false;
            // 
            // acceptModChild
            // 
            this.acceptModChild.BackColor = System.Drawing.Color.Transparent;
            this.acceptModChild.Font = new System.Drawing.Font("SimSun", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptModChild.Location = new System.Drawing.Point(1321, 977);
            this.acceptModChild.Name = "acceptModChild";
            this.acceptModChild.Size = new System.Drawing.Size(171, 47);
            this.acceptModChild.TabIndex = 13;
            this.acceptModChild.Text = "Modifica";
            this.acceptModChild.UseVisualStyleBackColor = false;
            this.acceptModChild.Visible = false;
            this.acceptModChild.Click += new System.EventHandler(this.acceptChild_Click);
            // 
            // addChild
            // 
            this.addChild.Font = new System.Drawing.Font("SimSun", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addChild.Location = new System.Drawing.Point(759, 614);
            this.addChild.Name = "addChild";
            this.addChild.Size = new System.Drawing.Size(171, 47);
            this.addChild.TabIndex = 16;
            this.addChild.Text = "Adauga";
            this.addChild.UseVisualStyleBackColor = true;
            this.addChild.Visible = false;
            this.addChild.Click += new System.EventHandler(this.addChild_Click);
            // 
            // labelAddMarca
            // 
            this.labelAddMarca.AutoSize = true;
            this.labelAddMarca.Font = new System.Drawing.Font("SimSun", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddMarca.Location = new System.Drawing.Point(72, 734);
            this.labelAddMarca.Name = "labelAddMarca";
            this.labelAddMarca.Size = new System.Drawing.Size(117, 33);
            this.labelAddMarca.TabIndex = 17;
            this.labelAddMarca.Text = "Marca:";
            this.labelAddMarca.Visible = false;
            // 
            // labelAddModel
            // 
            this.labelAddModel.AutoSize = true;
            this.labelAddModel.Font = new System.Drawing.Font("SimSun", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddModel.Location = new System.Drawing.Point(72, 829);
            this.labelAddModel.Name = "labelAddModel";
            this.labelAddModel.Size = new System.Drawing.Size(117, 33);
            this.labelAddModel.TabIndex = 18;
            this.labelAddModel.Text = "Model:";
            this.labelAddModel.Visible = false;
            // 
            // labelAddNumar
            // 
            this.labelAddNumar.AutoSize = true;
            this.labelAddNumar.Font = new System.Drawing.Font("SimSun", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddNumar.Location = new System.Drawing.Point(72, 907);
            this.labelAddNumar.Name = "labelAddNumar";
            this.labelAddNumar.Size = new System.Drawing.Size(117, 33);
            this.labelAddNumar.TabIndex = 19;
            this.labelAddNumar.Text = "Numar:";
            this.labelAddNumar.Visible = false;
            // 
            // inputAddMarca
            // 
            this.inputAddMarca.Font = new System.Drawing.Font("SimSun", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputAddMarca.Location = new System.Drawing.Point(230, 727);
            this.inputAddMarca.Name = "inputAddMarca";
            this.inputAddMarca.Size = new System.Drawing.Size(260, 53);
            this.inputAddMarca.TabIndex = 20;
            this.inputAddMarca.Visible = false;
            // 
            // inputAddModel
            // 
            this.inputAddModel.Font = new System.Drawing.Font("SimSun", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputAddModel.Location = new System.Drawing.Point(230, 820);
            this.inputAddModel.Name = "inputAddModel";
            this.inputAddModel.Size = new System.Drawing.Size(260, 53);
            this.inputAddModel.TabIndex = 21;
            this.inputAddModel.Visible = false;
            // 
            // inputAddNumar
            // 
            this.inputAddNumar.Font = new System.Drawing.Font("SimSun", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputAddNumar.Location = new System.Drawing.Point(230, 896);
            this.inputAddNumar.Name = "inputAddNumar";
            this.inputAddNumar.Size = new System.Drawing.Size(260, 53);
            this.inputAddNumar.TabIndex = 22;
            this.inputAddNumar.Visible = false;
            // 
            // acceptAddChild
            // 
            this.acceptAddChild.Font = new System.Drawing.Font("SimSun", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptAddChild.Location = new System.Drawing.Point(254, 991);
            this.acceptAddChild.Name = "acceptAddChild";
            this.acceptAddChild.Size = new System.Drawing.Size(171, 47);
            this.acceptAddChild.TabIndex = 23;
            this.acceptAddChild.Text = "Adauga";
            this.acceptAddChild.UseVisualStyleBackColor = true;
            this.acceptAddChild.Visible = false;
            this.acceptAddChild.Click += new System.EventHandler(this.acceptAddChild_Click);
            // 
            // labelModSofer
            // 
            this.labelModSofer.AutoSize = true;
            this.labelModSofer.Font = new System.Drawing.Font("SimSun", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModSofer.Location = new System.Drawing.Point(1140, 907);
            this.labelModSofer.Name = "labelModSofer";
            this.labelModSofer.Size = new System.Drawing.Size(117, 33);
            this.labelModSofer.TabIndex = 24;
            this.labelModSofer.Text = "Sofer:";
            this.labelModSofer.Visible = false;
            // 
            // inputModSofer
            // 
            this.inputModSofer.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputModSofer.FormattingEnabled = true;
            this.inputModSofer.Location = new System.Drawing.Point(1307, 907);
            this.inputModSofer.Name = "inputModSofer";
            this.inputModSofer.Size = new System.Drawing.Size(260, 36);
            this.inputModSofer.Sorted = true;
            this.inputModSofer.TabIndex = 25;
            this.inputModSofer.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(1778, 1050);
            this.Controls.Add(this.inputModSofer);
            this.Controls.Add(this.labelModSofer);
            this.Controls.Add(this.acceptAddChild);
            this.Controls.Add(this.inputAddNumar);
            this.Controls.Add(this.inputAddModel);
            this.Controls.Add(this.inputAddMarca);
            this.Controls.Add(this.labelAddNumar);
            this.Controls.Add(this.labelAddModel);
            this.Controls.Add(this.labelAddMarca);
            this.Controls.Add(this.addChild);
            this.Controls.Add(this.acceptModChild);
            this.Controls.Add(this.inputModNumar);
            this.Controls.Add(this.inputModModel);
            this.Controls.Add(this.inputModMarca);
            this.Controls.Add(this.labelModNumar);
            this.Controls.Add(this.labelModModel);
            this.Controls.Add(this.labelModMarca);
            this.Controls.Add(this.modChild);
            this.Controls.Add(this.deleteChild);
            this.Controls.Add(this.refreshAll);
            this.Controls.Add(this.titluCopii);
            this.Controls.Add(this.gridChildren);
            this.Controls.Add(this.titluParinti);
            this.Controls.Add(this.gridParents);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridParents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChildren)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridParents;
        private System.Windows.Forms.Label titluParinti;
        private System.Windows.Forms.DataGridView gridChildren;
        private System.Windows.Forms.Label titluCopii;
        private System.Windows.Forms.Button refreshAll;
        private System.Windows.Forms.Button deleteChild;
        private System.Windows.Forms.Button modChild;
        private System.Windows.Forms.Label labelModMarca;
        private System.Windows.Forms.Label labelModModel;
        private System.Windows.Forms.Label labelModNumar;
        private System.Windows.Forms.TextBox inputModMarca;
        private System.Windows.Forms.TextBox inputModModel;
        private System.Windows.Forms.TextBox inputModNumar;
        private System.Windows.Forms.Button acceptModChild;
        private System.Windows.Forms.Button addChild;
        private System.Windows.Forms.Label labelAddMarca;
        private System.Windows.Forms.Label labelAddModel;
        private System.Windows.Forms.Label labelAddNumar;
        private System.Windows.Forms.TextBox inputAddMarca;
        private System.Windows.Forms.TextBox inputAddModel;
        private System.Windows.Forms.TextBox inputAddNumar;
        private System.Windows.Forms.Button acceptAddChild;
        private System.Windows.Forms.Label labelModSofer;
        private System.Windows.Forms.ComboBox inputModSofer;
    }
}

