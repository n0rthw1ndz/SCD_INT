namespace SCDint
{
    partial class FRM_CONFIG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_CONFIG));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("SCD Config");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("EXE Config");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("SAP Config");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("EFX Config");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Executable Path");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("General", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.Picture_Config = new System.Windows.Forms.PictureBox();
            this.GroupConfig = new System.Windows.Forms.GroupBox();
            this.Panel_General = new System.Windows.Forms.GroupBox();
            this.Panel_EXE = new System.Windows.Forms.Panel();
            this.EXEPATH_BIO2_SC = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TV_CONFIG = new System.Windows.Forms.TreeView();
            this.Icon_List = new System.Windows.Forms.ImageList(this.components);
            this.Config_FontDLG = new System.Windows.Forms.FontDialog();
            this.Config_ColorDLG = new System.Windows.Forms.ColorDialog();
            this.Config_FDialog = new System.Windows.Forms.OpenFileDialog();
            this.EXE_LAYOUTPANEL = new System.Windows.Forms.TableLayoutPanel();
            this.EXE_PATH_LEONU = new System.Windows.Forms.TextBox();
            this.EXEPATH_CLAIREU = new System.Windows.Forms.TextBox();
            this.EXEPATH_BIO3MK = new System.Windows.Forms.TextBox();
            this.EXEPATH_BIO3EA = new System.Windows.Forms.TextBox();
            this.BTNPATH_BIO2SC = new System.Windows.Forms.Button();
            this.Config_OpenDLG = new System.Windows.Forms.OpenFileDialog();
            this.BTNPATH_LEONU = new System.Windows.Forms.Button();
            this.BTNPATH_CLAIREU = new System.Windows.Forms.Button();
            this.BTNPATH_BIO3MK = new System.Windows.Forms.Button();
            this.BTNPATH_BIO3EA = new System.Windows.Forms.Button();
            this.BTN_SAVEPATHS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Config)).BeginInit();
            this.GroupConfig.SuspendLayout();
            this.Panel_General.SuspendLayout();
            this.Panel_EXE.SuspendLayout();
            this.EXE_LAYOUTPANEL.SuspendLayout();
            this.SuspendLayout();
            // 
            // Picture_Config
            // 
            this.Picture_Config.Image = ((System.Drawing.Image)(resources.GetObject("Picture_Config.Image")));
            this.Picture_Config.Location = new System.Drawing.Point(34, 453);
            this.Picture_Config.Name = "Picture_Config";
            this.Picture_Config.Size = new System.Drawing.Size(122, 136);
            this.Picture_Config.TabIndex = 0;
            this.Picture_Config.TabStop = false;
            // 
            // GroupConfig
            // 
            this.GroupConfig.Controls.Add(this.Picture_Config);
            this.GroupConfig.Controls.Add(this.Panel_EXE);
            this.GroupConfig.Controls.Add(this.Panel_General);
            this.GroupConfig.Controls.Add(this.TV_CONFIG);
            this.GroupConfig.Location = new System.Drawing.Point(8, 8);
            this.GroupConfig.Name = "GroupConfig";
            this.GroupConfig.Size = new System.Drawing.Size(479, 606);
            this.GroupConfig.TabIndex = 1;
            this.GroupConfig.TabStop = false;
            this.GroupConfig.Text = "Configuration";
            // 
            // Panel_General
            // 
            this.Panel_General.Controls.Add(this.button1);
            this.Panel_General.Controls.Add(this.textBox1);
            this.Panel_General.Location = new System.Drawing.Point(208, 19);
            this.Panel_General.Name = "Panel_General";
            this.Panel_General.Size = new System.Drawing.Size(265, 581);
            this.Panel_General.TabIndex = 2;
            this.Panel_General.TabStop = false;
            this.Panel_General.Text = "General Settings";
            // 
            // Panel_EXE
            // 
            this.Panel_EXE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel_EXE.Controls.Add(this.BTN_SAVEPATHS);
            this.Panel_EXE.Controls.Add(this.BTNPATH_BIO3EA);
            this.Panel_EXE.Controls.Add(this.BTNPATH_BIO3MK);
            this.Panel_EXE.Controls.Add(this.BTNPATH_CLAIREU);
            this.Panel_EXE.Controls.Add(this.BTNPATH_LEONU);
            this.Panel_EXE.Controls.Add(this.BTNPATH_BIO2SC);
            this.Panel_EXE.Controls.Add(this.EXE_LAYOUTPANEL);
            this.Panel_EXE.Location = new System.Drawing.Point(208, 19);
            this.Panel_EXE.Name = "Panel_EXE";
            this.Panel_EXE.Size = new System.Drawing.Size(265, 581);
            this.Panel_EXE.TabIndex = 2;
            // 
            // EXEPATH_BIO2_SC
            // 
            this.EXEPATH_BIO2_SC.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EXEPATH_BIO2_SC.Location = new System.Drawing.Point(6, 15);
            this.EXEPATH_BIO2_SC.Name = "EXEPATH_BIO2_SC";
            this.EXEPATH_BIO2_SC.Size = new System.Drawing.Size(169, 20);
            this.EXEPATH_BIO2_SC.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(63, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 20);
            this.textBox1.TabIndex = 0;
            // 
            // TV_CONFIG
            // 
            this.TV_CONFIG.ImageIndex = 0;
            this.TV_CONFIG.ImageList = this.Icon_List;
            this.TV_CONFIG.Location = new System.Drawing.Point(3, 16);
            this.TV_CONFIG.Name = "TV_CONFIG";
            treeNode1.ImageIndex = 2;
            treeNode1.Name = "Node_SCD";
            treeNode1.Text = "SCD Config";
            treeNode2.Name = "Node_EXE";
            treeNode2.Text = "EXE Config";
            treeNode3.ImageIndex = 3;
            treeNode3.Name = "Node_SAP";
            treeNode3.Text = "SAP Config";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "Node_EFX";
            treeNode4.Text = "EFX Config";
            treeNode5.Name = "Node_General_Path";
            treeNode5.Text = "Executable Path";
            treeNode6.Name = "Node_General";
            treeNode6.Text = "General";
            this.TV_CONFIG.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode6});
            this.TV_CONFIG.SelectedImageIndex = 0;
            this.TV_CONFIG.Size = new System.Drawing.Size(199, 584);
            this.TV_CONFIG.TabIndex = 1;
            this.TV_CONFIG.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_CONFIG_NodeMouseClick);
            // 
            // Icon_List
            // 
            this.Icon_List.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Icon_List.ImageStream")));
            this.Icon_List.TransparentColor = System.Drawing.Color.Transparent;
            this.Icon_List.Images.SetKeyName(0, "Exe00.png");
            this.Icon_List.Images.SetKeyName(1, "EFX.png");
            this.Icon_List.Images.SetKeyName(2, "ICO_APP.ico");
            this.Icon_List.Images.SetKeyName(3, "sapmake.png");
            this.Icon_List.Images.SetKeyName(4, "saveico.png");
            this.Icon_List.Images.SetKeyName(5, "claire.png");
            this.Icon_List.Images.SetKeyName(6, "leon.png");
            this.Icon_List.Images.SetKeyName(7, "BIO2_ICO.ico");
            this.Icon_List.Images.SetKeyName(8, "RE3ICO.ico");
            this.Icon_List.Images.SetKeyName(9, "Nem00_Ico.ico");
            // 
            // Config_FDialog
            // 
            this.Config_FDialog.FileName = "openFileDialog1";
            // 
            // EXE_LAYOUTPANEL
            // 
            this.EXE_LAYOUTPANEL.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.EXE_LAYOUTPANEL.ColumnCount = 1;
            this.EXE_LAYOUTPANEL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.EXE_LAYOUTPANEL.Controls.Add(this.EXEPATH_BIO3EA, 0, 4);
            this.EXE_LAYOUTPANEL.Controls.Add(this.EXEPATH_BIO3MK, 0, 3);
            this.EXE_LAYOUTPANEL.Controls.Add(this.EXEPATH_CLAIREU, 0, 2);
            this.EXE_LAYOUTPANEL.Controls.Add(this.EXE_PATH_LEONU, 0, 1);
            this.EXE_LAYOUTPANEL.Controls.Add(this.EXEPATH_BIO2_SC, 0, 0);
            this.EXE_LAYOUTPANEL.Location = new System.Drawing.Point(64, 3);
            this.EXE_LAYOUTPANEL.Name = "EXE_LAYOUTPANEL";
            this.EXE_LAYOUTPANEL.RowCount = 6;
            this.EXE_LAYOUTPANEL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.EXE_LAYOUTPANEL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.EXE_LAYOUTPANEL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.EXE_LAYOUTPANEL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.EXE_LAYOUTPANEL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.EXE_LAYOUTPANEL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.EXE_LAYOUTPANEL.Size = new System.Drawing.Size(181, 221);
            this.EXE_LAYOUTPANEL.TabIndex = 5;
            // 
            // EXE_PATH_LEONU
            // 
            this.EXE_PATH_LEONU.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EXE_PATH_LEONU.Location = new System.Drawing.Point(6, 55);
            this.EXE_PATH_LEONU.Name = "EXE_PATH_LEONU";
            this.EXE_PATH_LEONU.Size = new System.Drawing.Size(169, 20);
            this.EXE_PATH_LEONU.TabIndex = 5;
            // 
            // EXEPATH_CLAIREU
            // 
            this.EXEPATH_CLAIREU.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EXEPATH_CLAIREU.Location = new System.Drawing.Point(6, 96);
            this.EXEPATH_CLAIREU.Name = "EXEPATH_CLAIREU";
            this.EXEPATH_CLAIREU.Size = new System.Drawing.Size(169, 20);
            this.EXEPATH_CLAIREU.TabIndex = 6;
            // 
            // EXEPATH_BIO3MK
            // 
            this.EXEPATH_BIO3MK.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EXEPATH_BIO3MK.Location = new System.Drawing.Point(6, 141);
            this.EXEPATH_BIO3MK.Name = "EXEPATH_BIO3MK";
            this.EXEPATH_BIO3MK.Size = new System.Drawing.Size(169, 20);
            this.EXEPATH_BIO3MK.TabIndex = 7;
            // 
            // EXEPATH_BIO3EA
            // 
            this.EXEPATH_BIO3EA.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EXEPATH_BIO3EA.Location = new System.Drawing.Point(6, 188);
            this.EXEPATH_BIO3EA.Name = "EXEPATH_BIO3EA";
            this.EXEPATH_BIO3EA.Size = new System.Drawing.Size(169, 20);
            this.EXEPATH_BIO3EA.TabIndex = 8;
            // 
            // BTNPATH_BIO2SC
            // 
            this.BTNPATH_BIO2SC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTNPATH_BIO2SC.ImageIndex = 7;
            this.BTNPATH_BIO2SC.ImageList = this.Icon_List;
            this.BTNPATH_BIO2SC.Location = new System.Drawing.Point(16, 6);
            this.BTNPATH_BIO2SC.Name = "BTNPATH_BIO2SC";
            this.BTNPATH_BIO2SC.Size = new System.Drawing.Size(35, 32);
            this.BTNPATH_BIO2SC.TabIndex = 6;
            this.BTNPATH_BIO2SC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTNPATH_BIO2SC.UseVisualStyleBackColor = true;
            this.BTNPATH_BIO2SC.Click += new System.EventHandler(this.BTNPATH_BIO2SC_Click);
            // 
            // Config_OpenDLG
            // 
            this.Config_OpenDLG.FileName = "openFileDialog1";
            this.Config_OpenDLG.Filter = "Executable|*.exe";
            // 
            // BTNPATH_LEONU
            // 
            this.BTNPATH_LEONU.ImageIndex = 6;
            this.BTNPATH_LEONU.ImageList = this.Icon_List;
            this.BTNPATH_LEONU.Location = new System.Drawing.Point(16, 46);
            this.BTNPATH_LEONU.Name = "BTNPATH_LEONU";
            this.BTNPATH_LEONU.Size = new System.Drawing.Size(35, 32);
            this.BTNPATH_LEONU.TabIndex = 7;
            this.BTNPATH_LEONU.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTNPATH_LEONU.UseVisualStyleBackColor = true;
            this.BTNPATH_LEONU.Click += new System.EventHandler(this.BTNPATH_LEONU_Click);
            // 
            // BTNPATH_CLAIREU
            // 
            this.BTNPATH_CLAIREU.ImageIndex = 5;
            this.BTNPATH_CLAIREU.ImageList = this.Icon_List;
            this.BTNPATH_CLAIREU.Location = new System.Drawing.Point(16, 87);
            this.BTNPATH_CLAIREU.Name = "BTNPATH_CLAIREU";
            this.BTNPATH_CLAIREU.Size = new System.Drawing.Size(35, 32);
            this.BTNPATH_CLAIREU.TabIndex = 8;
            this.BTNPATH_CLAIREU.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTNPATH_CLAIREU.UseVisualStyleBackColor = true;
            this.BTNPATH_CLAIREU.Click += new System.EventHandler(this.BTNPATH_CLAIREU_Click);
            // 
            // BTNPATH_BIO3MK
            // 
            this.BTNPATH_BIO3MK.ImageIndex = 8;
            this.BTNPATH_BIO3MK.ImageList = this.Icon_List;
            this.BTNPATH_BIO3MK.Location = new System.Drawing.Point(16, 132);
            this.BTNPATH_BIO3MK.Name = "BTNPATH_BIO3MK";
            this.BTNPATH_BIO3MK.Size = new System.Drawing.Size(35, 32);
            this.BTNPATH_BIO3MK.TabIndex = 9;
            this.BTNPATH_BIO3MK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTNPATH_BIO3MK.UseVisualStyleBackColor = true;
            this.BTNPATH_BIO3MK.Click += new System.EventHandler(this.BTNPATH_BIO3MK_Click);
            // 
            // BTNPATH_BIO3EA
            // 
            this.BTNPATH_BIO3EA.ImageIndex = 9;
            this.BTNPATH_BIO3EA.ImageList = this.Icon_List;
            this.BTNPATH_BIO3EA.Location = new System.Drawing.Point(16, 179);
            this.BTNPATH_BIO3EA.Name = "BTNPATH_BIO3EA";
            this.BTNPATH_BIO3EA.Size = new System.Drawing.Size(35, 32);
            this.BTNPATH_BIO3EA.TabIndex = 10;
            this.BTNPATH_BIO3EA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTNPATH_BIO3EA.UseVisualStyleBackColor = true;
            this.BTNPATH_BIO3EA.Click += new System.EventHandler(this.BTNPATH_BIO3EA_Click);
            // 
            // BTN_SAVEPATHS
            // 
            this.BTN_SAVEPATHS.Location = new System.Drawing.Point(34, 250);
            this.BTN_SAVEPATHS.Name = "BTN_SAVEPATHS";
            this.BTN_SAVEPATHS.Size = new System.Drawing.Size(205, 46);
            this.BTN_SAVEPATHS.TabIndex = 11;
            this.BTN_SAVEPATHS.Text = "Save Dir Paths";
            this.BTN_SAVEPATHS.UseVisualStyleBackColor = true;
            this.BTN_SAVEPATHS.Click += new System.EventHandler(this.BTN_SAVEPATHS_Click);
            // 
            // FRM_CONFIG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 626);
            this.Controls.Add(this.GroupConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_CONFIG";
            this.Text = "FRM_CONFIG";
            this.Load += new System.EventHandler(this.FRM_CONFIG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Config)).EndInit();
            this.GroupConfig.ResumeLayout(false);
            this.Panel_General.ResumeLayout(false);
            this.Panel_General.PerformLayout();
            this.Panel_EXE.ResumeLayout(false);
            this.EXE_LAYOUTPANEL.ResumeLayout(false);
            this.EXE_LAYOUTPANEL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Picture_Config;
        private System.Windows.Forms.GroupBox GroupConfig;
        private System.Windows.Forms.GroupBox Panel_General;
        private System.Windows.Forms.TreeView TV_CONFIG;
        private System.Windows.Forms.FontDialog Config_FontDLG;
        private System.Windows.Forms.ColorDialog Config_ColorDLG;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog Config_FDialog;
        private System.Windows.Forms.ImageList Icon_List;
        private System.Windows.Forms.Panel Panel_EXE;
        private System.Windows.Forms.TextBox EXEPATH_BIO2_SC;
        private System.Windows.Forms.TableLayoutPanel EXE_LAYOUTPANEL;
        private System.Windows.Forms.TextBox EXEPATH_BIO3EA;
        private System.Windows.Forms.TextBox EXEPATH_BIO3MK;
        private System.Windows.Forms.TextBox EXEPATH_CLAIREU;
        private System.Windows.Forms.TextBox EXE_PATH_LEONU;
        private System.Windows.Forms.Button BTNPATH_BIO2SC;
        private System.Windows.Forms.Button BTNPATH_BIO3EA;
        private System.Windows.Forms.Button BTNPATH_BIO3MK;
        private System.Windows.Forms.Button BTNPATH_CLAIREU;
        private System.Windows.Forms.Button BTNPATH_LEONU;
        private System.Windows.Forms.OpenFileDialog Config_OpenDLG;
        private System.Windows.Forms.Button BTN_SAVEPATHS;
    }
}