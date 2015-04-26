namespace VbeComponents.Business.Controls
{
    partial class SelectionPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAll = new System.Windows.Forms.Label();
            this.lblModules = new System.Windows.Forms.Label();
            this.lblForms = new System.Windows.Forms.Label();
            this.lblClasses = new System.Windows.Forms.Label();
            this.lblDocs = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblAll, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblModules, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblForms, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblClasses, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDocs, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 18);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblAll
            // 
            this.lblAll.AutoSize = true;
            this.lblAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAll.Location = new System.Drawing.Point(3, 0);
            this.lblAll.Name = "lblAll";
            this.lblAll.Padding = new System.Windows.Forms.Padding(1, 2, 0, 0);
            this.lblAll.Size = new System.Drawing.Size(22, 15);
            this.lblAll.TabIndex = 0;
            this.lblAll.Text = "All";
            this.lblAll.Click += new System.EventHandler(this.lblAll_Click);
            this.lblAll.DoubleClick += new System.EventHandler(this.lblAll_Click);
            // 
            // lblModules
            // 
            this.lblModules.AutoSize = true;
            this.lblModules.Location = new System.Drawing.Point(31, 0);
            this.lblModules.Name = "lblModules";
            this.lblModules.Padding = new System.Windows.Forms.Padding(1, 2, 0, 0);
            this.lblModules.Size = new System.Drawing.Size(48, 15);
            this.lblModules.TabIndex = 1;
            this.lblModules.Text = "Modules";
            this.lblModules.Click += new System.EventHandler(this.lblModules_Click);
            this.lblModules.DoubleClick += new System.EventHandler(this.lblModules_Click);
            // 
            // lblForms
            // 
            this.lblForms.AutoSize = true;
            this.lblForms.Location = new System.Drawing.Point(85, 0);
            this.lblForms.Name = "lblForms";
            this.lblForms.Padding = new System.Windows.Forms.Padding(1, 2, 0, 0);
            this.lblForms.Size = new System.Drawing.Size(36, 15);
            this.lblForms.TabIndex = 2;
            this.lblForms.Text = "Forms";
            this.lblForms.Click += new System.EventHandler(this.lblForms_Click);
            this.lblForms.DoubleClick += new System.EventHandler(this.lblForms_Click);
            // 
            // lblClasses
            // 
            this.lblClasses.AutoSize = true;
            this.lblClasses.Location = new System.Drawing.Point(127, 0);
            this.lblClasses.Name = "lblClasses";
            this.lblClasses.Padding = new System.Windows.Forms.Padding(1, 2, 0, 0);
            this.lblClasses.Size = new System.Drawing.Size(44, 15);
            this.lblClasses.TabIndex = 3;
            this.lblClasses.Text = "Classes";
            this.lblClasses.Click += new System.EventHandler(this.lblClasses_Click);
            this.lblClasses.DoubleClick += new System.EventHandler(this.lblClasses_Click);
            // 
            // lblDocs
            // 
            this.lblDocs.AutoSize = true;
            this.lblDocs.Location = new System.Drawing.Point(177, 0);
            this.lblDocs.Name = "lblDocs";
            this.lblDocs.Padding = new System.Windows.Forms.Padding(1, 2, 0, 0);
            this.lblDocs.Size = new System.Drawing.Size(62, 15);
            this.lblDocs.TabIndex = 4;
            this.lblDocs.Text = "Documents";
            this.lblDocs.Click += new System.EventHandler(this.lblDocs_Click);
            this.lblDocs.DoubleClick += new System.EventHandler(this.lblDocs_Click);
            // 
            // SelectionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SelectionPanel";
            this.Size = new System.Drawing.Size(250, 18);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblAll;
        private System.Windows.Forms.Label lblModules;
        private System.Windows.Forms.Label lblForms;
        private System.Windows.Forms.Label lblClasses;
        private System.Windows.Forms.Label lblDocs;
    }
}
