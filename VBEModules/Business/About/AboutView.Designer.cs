namespace VbeComponents.Business.About
{
    partial class AboutView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutView));
            this.lbltTopBanner = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.picGit = new System.Windows.Forms.PictureBox();
            this.picDucky = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.picMZT = new System.Windows.Forms.PictureBox();
            this.lblThanks = new System.Windows.Forms.Label();
            this.lblLine2 = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDucky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMZT)).BeginInit();
            this.SuspendLayout();
            // 
            // lbltTopBanner
            // 
            this.lbltTopBanner.BackColor = System.Drawing.Color.DarkGray;
            this.lbltTopBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbltTopBanner.Location = new System.Drawing.Point(0, 0);
            this.lbltTopBanner.Name = "lbltTopBanner";
            this.lbltTopBanner.Size = new System.Drawing.Size(391, 11);
            this.lbltTopBanner.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DimGray;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(243, 280);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 85);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Build version:";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.DimGray;
            this.lblVersion.Location = new System.Drawing.Point(125, 23);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(0, 18);
            this.lblVersion.TabIndex = 3;
            // 
            // picGit
            // 
            this.picGit.Image = global::VbeComponents.Properties.Resources.icon_github;
            this.picGit.Location = new System.Drawing.Point(186, 324);
            this.picGit.Name = "picGit";
            this.picGit.Size = new System.Drawing.Size(51, 41);
            this.picGit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGit.TabIndex = 4;
            this.picGit.TabStop = false;
            this.toolTip1.SetToolTip(this.picGit, "https://github.com/PetLahev/VBE_Modules");
            // 
            // picDucky
            // 
            this.picDucky.Image = global::VbeComponents.Properties.Resources.RD_InstallBanner;
            this.picDucky.Location = new System.Drawing.Point(16, 280);
            this.picDucky.Name = "picDucky";
            this.picDucky.Size = new System.Drawing.Size(221, 38);
            this.picDucky.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDucky.TabIndex = 6;
            this.picDucky.TabStop = false;
            this.toolTip1.SetToolTip(this.picDucky, "http://www.rubberduck-vba.com/");
            // 
            // picMZT
            // 
            this.picMZT.Image = global::VbeComponents.Properties.Resources.mztools;
            this.picMZT.Location = new System.Drawing.Point(11, 324);
            this.picMZT.Name = "picMZT";
            this.picMZT.Size = new System.Drawing.Size(169, 41);
            this.picMZT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMZT.TabIndex = 8;
            this.picMZT.TabStop = false;
            this.toolTip1.SetToolTip(this.picMZT, "http://www.mztools.com/index.aspx");
            // 
            // lblThanks
            // 
            this.lblThanks.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanks.Location = new System.Drawing.Point(12, 205);
            this.lblThanks.Name = "lblThanks";
            this.lblThanks.Size = new System.Drawing.Size(371, 74);
            this.lblThanks.TabIndex = 7;
            // 
            // lblLine2
            // 
            this.lblLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine2.BackColor = System.Drawing.Color.DimGray;
            this.lblLine2.Location = new System.Drawing.Point(0, 200);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(391, 3);
            this.lblLine2.TabIndex = 9;
            // 
            // lblDesc
            // 
            this.lblDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDesc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(9, 46);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(374, 147);
            this.lblDesc.TabIndex = 10;
            this.lblDesc.Text = "VBE Components manager is open source  VBE add-in for Microsoft Office applicatio" +
    "n.";
            // 
            // AboutView
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(391, 377);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblLine2);
            this.Controls.Add(this.picMZT);
            this.Controls.Add(this.lblThanks);
            this.Controls.Add(this.picDucky);
            this.Controls.Add(this.picGit);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbltTopBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About VBE Components Manager";
            ((System.ComponentModel.ISupportInitialize)(this.picGit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDucky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMZT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltTopBanner;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.PictureBox picGit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox picDucky;
        private System.Windows.Forms.Label lblThanks;
        private System.Windows.Forms.PictureBox picMZT;
        private System.Windows.Forms.Label lblLine2;
        private System.Windows.Forms.Label lblDesc;
    }
}