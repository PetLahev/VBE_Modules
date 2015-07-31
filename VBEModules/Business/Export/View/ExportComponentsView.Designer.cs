namespace VbeComponents.Business.Export.View
{
    partial class ExportComponentsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportComponentsView));
            this.tw = new System.Windows.Forms.TreeView();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblProjectCaption = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.txtExportPath = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPathCaption = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lblTopBanner = new System.Windows.Forms.Label();
            this.selectionPanel1 = new VbeComponents.Controls.SelectionPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtContent = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tw
            // 
            this.tw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tw.CheckBoxes = true;
            this.tw.Location = new System.Drawing.Point(12, 30);
            this.tw.Name = "tw";
            this.tw.Size = new System.Drawing.Size(258, 398);
            this.tw.TabIndex = 0;
            this.tw.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tw_AfterCheck);
            this.tw.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tw_AfterSelect);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.DimGray;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.btnExport.FlatAppearance.BorderSize = 2;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(410, 390);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(116, 38);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "&Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblProjectCaption
            // 
            this.lblProjectCaption.AutoSize = true;
            this.lblProjectCaption.Location = new System.Drawing.Point(10, 22);
            this.lblProjectCaption.Name = "lblProjectCaption";
            this.lblProjectCaption.Size = new System.Drawing.Size(84, 13);
            this.lblProjectCaption.TabIndex = 4;
            this.lblProjectCaption.Text = "Selected project";
            // 
            // lblItems
            // 
            this.lblItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(13, 433);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(74, 13);
            this.lblItems.TabIndex = 6;
            this.lblItems.Text = "0 components";
            // 
            // txtExportPath
            // 
            this.txtExportPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExportPath.ForeColor = System.Drawing.Color.Silver;
            this.txtExportPath.Location = new System.Drawing.Point(10, 81);
            this.txtExportPath.Name = "txtExportPath";
            this.txtExportPath.ReadOnly = true;
            this.txtExportPath.Size = new System.Drawing.Size(352, 20);
            this.txtExportPath.TabIndex = 7;
            this.txtExportPath.Text = "Specify  path to export";
            this.txtExportPath.MouseHover += new System.EventHandler(this.txtExportPath_MouseHover);
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
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPathCaption
            // 
            this.lblPathCaption.AutoSize = true;
            this.lblPathCaption.Location = new System.Drawing.Point(10, 65);
            this.lblPathCaption.Name = "lblPathCaption";
            this.lblPathCaption.Size = new System.Drawing.Size(134, 13);
            this.lblPathCaption.TabIndex = 9;
            this.lblPathCaption.Text = "Path to export components";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.BackColor = System.Drawing.Color.DimGray;
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.btnBrowse.FlatAppearance.BorderSize = 2;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(267, 107);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(95, 28);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "&Browse…";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtProjectName);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.lblProjectCaption);
            this.groupBox1.Controls.Add(this.txtExportPath);
            this.groupBox1.Controls.Add(this.lblPathCaption);
            this.groupBox1.Location = new System.Drawing.Point(283, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 145);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectName.ForeColor = System.Drawing.Color.Black;
            this.txtProjectName.Location = new System.Drawing.Point(10, 38);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.ReadOnly = true;
            this.txtProjectName.Size = new System.Drawing.Size(352, 20);
            this.txtProjectName.TabIndex = 11;
            this.txtProjectName.Text = "<project name>";
            // 
            // lblTopBanner
            // 
            this.lblTopBanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopBanner.BackColor = System.Drawing.Color.DarkGray;
            this.lblTopBanner.Location = new System.Drawing.Point(-1, -1);
            this.lblTopBanner.Name = "lblTopBanner";
            this.lblTopBanner.Size = new System.Drawing.Size(670, 11);
            this.lblTopBanner.TabIndex = 13;
            // 
            // selectionPanel1
            // 
            this.selectionPanel1.Location = new System.Drawing.Point(12, 12);
            this.selectionPanel1.Name = "selectionPanel1";
            this.selectionPanel1.Nodes = null;
            this.selectionPanel1.Size = new System.Drawing.Size(258, 18);
            this.selectionPanel1.TabIndex = 1;
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(283, 180);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(375, 192);
            this.txtContent.TabIndex = 14;
            // 
            // ExportComponentsView
            // 
            this.AcceptButton = this.btnExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(670, 451);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lblTopBanner);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.selectionPanel1);
            this.Controls.Add(this.tw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(686, 489);
            this.Name = "ExportComponentsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Components";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tw;
        private Controls.SelectionPanel selectionPanel1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblProjectCaption;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.TextBox txtExportPath;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPathCaption;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label lblTopBanner;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtContent;
    }
}