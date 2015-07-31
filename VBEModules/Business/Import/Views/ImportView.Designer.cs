namespace VbeComponents.Business.Import.Views
{
    partial class ImportView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportView));
            this.lblTopBanner = new System.Windows.Forms.Label();
            this.tw = new System.Windows.Forms.TreeView();
            this.lblItems = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSelectedProjectPath = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cboProjects = new System.Windows.Forms.ComboBox();
            this.lblProjectImportFrom = new System.Windows.Forms.Label();
            this.txtActiveProject = new System.Windows.Forms.TextBox();
            this.lblSelectedProject = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chbOverride = new System.Windows.Forms.CheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.selectionPanel1 = new VbeComponents.Controls.SelectionPanel();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTopBanner
            // 
            this.lblTopBanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopBanner.BackColor = System.Drawing.Color.DarkGray;
            this.lblTopBanner.Location = new System.Drawing.Point(-1, -1);
            this.lblTopBanner.Name = "lblTopBanner";
            this.lblTopBanner.Size = new System.Drawing.Size(668, 10);
            this.lblTopBanner.TabIndex = 0;
            // 
            // tw
            // 
            this.tw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tw.CheckBoxes = true;
            this.tw.Location = new System.Drawing.Point(12, 30);
            this.tw.Name = "tw";
            this.tw.Size = new System.Drawing.Size(258, 398);
            this.tw.TabIndex = 1;
            this.tw.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tw_AfterCheck);
            this.tw.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tw_AfterSelect);
            // 
            // lblItems
            // 
            this.lblItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(13, 433);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(0, 13);
            this.lblItems.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblSelectedProjectPath);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.cboProjects);
            this.groupBox1.Controls.Add(this.lblProjectImportFrom);
            this.groupBox1.Controls.Add(this.txtActiveProject);
            this.groupBox1.Controls.Add(this.lblSelectedProject);
            this.groupBox1.Location = new System.Drawing.Point(283, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 148);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // lblSelectedProjectPath
            // 
            this.lblSelectedProjectPath.AutoSize = true;
            this.lblSelectedProjectPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedProjectPath.ForeColor = System.Drawing.Color.Gray;
            this.lblSelectedProjectPath.Location = new System.Drawing.Point(75, 64);
            this.lblSelectedProjectPath.MaximumSize = new System.Drawing.Size(300, 14);
            this.lblSelectedProjectPath.Name = "lblSelectedProjectPath";
            this.lblSelectedProjectPath.Size = new System.Drawing.Size(0, 13);
            this.lblSelectedProjectPath.TabIndex = 12;
            this.lblSelectedProjectPath.MouseHover += new System.EventHandler(this.lblSelectedProjectPath_MouseHover);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.BackColor = System.Drawing.Color.DimGray;
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.btnBrowse.FlatAppearance.BorderSize = 2;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(280, 108);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(95, 28);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Text = "&Browse…";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cboProjects
            // 
            this.cboProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProjects.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProjects.FormattingEnabled = true;
            this.cboProjects.Location = new System.Drawing.Point(13, 81);
            this.cboProjects.Name = "cboProjects";
            this.cboProjects.Size = new System.Drawing.Size(362, 21);
            this.cboProjects.TabIndex = 3;
            this.cboProjects.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cboProjects_DrawItem);
            this.cboProjects.SelectedIndexChanged += new System.EventHandler(this.cboProjects_SelectedIndexChanged);
            // 
            // lblProjectImportFrom
            // 
            this.lblProjectImportFrom.AutoSize = true;
            this.lblProjectImportFrom.Location = new System.Drawing.Point(10, 64);
            this.lblProjectImportFrom.Name = "lblProjectImportFrom";
            this.lblProjectImportFrom.Size = new System.Drawing.Size(59, 13);
            this.lblProjectImportFrom.TabIndex = 2;
            this.lblProjectImportFrom.Text = "Import from";
            // 
            // txtActiveProject
            // 
            this.txtActiveProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActiveProject.Location = new System.Drawing.Point(10, 37);
            this.txtActiveProject.Name = "txtActiveProject";
            this.txtActiveProject.ReadOnly = true;
            this.txtActiveProject.Size = new System.Drawing.Size(365, 20);
            this.txtActiveProject.TabIndex = 1;
            // 
            // lblSelectedProject
            // 
            this.lblSelectedProject.AutoSize = true;
            this.lblSelectedProject.Location = new System.Drawing.Point(7, 20);
            this.lblSelectedProject.Name = "lblSelectedProject";
            this.lblSelectedProject.Size = new System.Drawing.Size(139, 13);
            this.lblSelectedProject.TabIndex = 0;
            this.lblSelectedProject.Text = "Selected project ( import to )";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.BackColor = System.Drawing.Color.DimGray;
            this.btnImport.Enabled = false;
            this.btnImport.FlatAppearance.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.btnImport.FlatAppearance.BorderSize = 2;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(410, 390);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(116, 38);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "&Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.DimGray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(542, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 38);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chbOverride
            // 
            this.chbOverride.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbOverride.AutoSize = true;
            this.chbOverride.Checked = true;
            this.chbOverride.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOverride.Location = new System.Drawing.Point(412, 433);
            this.chbOverride.Name = "chbOverride";
            this.chbOverride.Size = new System.Drawing.Size(103, 17);
            this.chbOverride.TabIndex = 10;
            this.chbOverride.Text = "Override if exists";
            this.chbOverride.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // selectionPanel1
            // 
            this.selectionPanel1.Location = new System.Drawing.Point(12, 12);
            this.selectionPanel1.Name = "selectionPanel1";
            this.selectionPanel1.Nodes = null;
            this.selectionPanel1.Size = new System.Drawing.Size(274, 18);
            this.selectionPanel1.TabIndex = 2;
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(283, 185);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(375, 188);
            this.txtContent.TabIndex = 11;
            // 
            // ImportView
            // 
            this.AcceptButton = this.btnImport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(670, 453);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.chbOverride);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.selectionPanel1);
            this.Controls.Add(this.tw);
            this.Controls.Add(this.lblTopBanner);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(686, 491);
            this.Name = "ImportView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Components";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTopBanner;
        private System.Windows.Forms.TreeView tw;
        private Controls.SelectionPanel selectionPanel1;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboProjects;
        private System.Windows.Forms.Label lblProjectImportFrom;
        private System.Windows.Forms.TextBox txtActiveProject;
        private System.Windows.Forms.Label lblSelectedProject;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chbOverride;
        private System.Windows.Forms.Label lblSelectedProjectPath;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtContent;
    }
}