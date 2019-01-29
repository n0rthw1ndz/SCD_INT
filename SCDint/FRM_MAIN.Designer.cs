namespace SCDint
{
    partial class FRM_MAIN
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_MAIN));
            this.LST_CODE = new System.Windows.Forms.ListView();
            this.CLM_LINE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CLM_CODE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CLM_CODE_COMMENT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BAR_TOOL = new System.Windows.Forms.ToolStrip();
            this.BTN_OPEN = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SCD_BUTTON_REPACK = new System.Windows.Forms.ToolStripButton();
            this.BTN_DISPLAY_TOGGLE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BTN_AOT_MONITOR = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BTN_FLAG_MONITOR = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.BTN_HOME = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.SCD_BTN_CLIPBOARD = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MNU_TOP = new System.Windows.Forms.MenuStrip();
            this.M_FILE = new System.Windows.Forms.ToolStripMenuItem();
            this.M_FILE_OPEN = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.M_FILE_EXIT = new System.Windows.Forms.ToolStripMenuItem();
            this.M_VIEW = new System.Windows.Forms.ToolStripMenuItem();
            this.M_VIEW_TOGGLE = new System.Windows.Forms.ToolStripMenuItem();
            this.bIO2RE2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bIO2RE3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sCDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.M_HELP = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LST_BYTE = new System.Windows.Forms.ListView();
            this.CLM_OFFSET = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CLM_BYTECODE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CLM_BYTE_COMMENT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LST_PROP = new System.Windows.Forms.PropertyGrid();
            this.DLG_OPEN_FILE = new System.Windows.Forms.OpenFileDialog();
            this.STATUS_STRIP = new System.Windows.Forms.StatusStrip();
            this.LBL_PROC_STATUS = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_IGT = new System.Windows.Forms.ToolStripStatusLabel();
            this.DIR_LISTBOX = new Microsoft.VisualBasic.Compatibility.VB6.DirListBox();
            this.DRIVE_LISTBOX = new Microsoft.VisualBasic.Compatibility.VB6.DriveListBox();
            this.F_LISTBOX = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
            this.panel_scd = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IMAGE_BG_RENDER_RDT = new System.Windows.Forms.PictureBox();
            this.MAIN_TOOLBAR = new System.Windows.Forms.ToolBar();
            this.tsep00 = new System.Windows.Forms.ToolBarButton();
            this.TBTN_EXE = new System.Windows.Forms.ToolBarButton();
            this.TBTN_BIO3EXE = new System.Windows.Forms.ToolBarButton();
            this.tsep02 = new System.Windows.Forms.ToolBarButton();
            this.TBTN_DEBUG = new System.Windows.Forms.ToolBarButton();
            this.TBTN_SCD = new System.Windows.Forms.ToolBarButton();
            this.tsep_01 = new System.Windows.Forms.ToolBarButton();
            this.TBTN_SAP = new System.Windows.Forms.ToolBarButton();
            this.TBTN_FX = new System.Windows.Forms.ToolBarButton();
            this.TBTN_SAVE = new System.Windows.Forms.ToolBarButton();
            this.TBTN_CONV = new System.Windows.Forms.ToolBarButton();
            this.TBTN_CONFIG = new System.Windows.Forms.ToolBarButton();
            this.TBTN_HEX = new System.Windows.Forms.ToolBarButton();
            this.TBTN_MSG = new System.Windows.Forms.ToolBarButton();
            this.IconList = new System.Windows.Forms.ImageList(this.components);
            this.STATUS_SELECTOR = new System.Windows.Forms.ComboBox();
            this.LBL_SEL_CONDITION = new System.Windows.Forms.Label();
            this.LBL_PLDSELECT = new System.Windows.Forms.Label();
            this.PLD_SELECTOR = new System.Windows.Forms.ComboBox();
            this.LBL_CAMERAS = new System.Windows.Forms.Label();
            this.LBL_PLAYER_COORDS = new System.Windows.Forms.Label();
            this.LBL_ROOMDESC = new System.Windows.Forms.Label();
            this.LBL_CAMID00 = new System.Windows.Forms.Label();
            this.LBL_RID00 = new System.Windows.Forms.Label();
            this.LBL_RID01 = new System.Windows.Forms.Label();
            this.LBL_CAMID01 = new System.Windows.Forms.Label();
            this.LBL_POSR = new System.Windows.Forms.Label();
            this.LBL_POSY = new System.Windows.Forms.Label();
            this.LBL_POSX = new System.Windows.Forms.Label();
            this.LBL_POSZ = new System.Windows.Forms.Label();
            this.TIMER_HOOK = new System.Windows.Forms.Timer(this.components);
            this.STATUS_IMAGE = new System.Windows.Forms.PictureBox();
            this.BTN_HOOK = new System.Windows.Forms.Button();
            this.WPN_IMAGE = new System.Windows.Forms.PictureBox();
            this.PLAYER_IMAGE = new System.Windows.Forms.PictureBox();
            this.MemoryGroup00 = new System.Windows.Forms.GroupBox();
            this.IMAGE_BG_RENDER = new System.Windows.Forms.PictureBox();
            this.BTN_ROOM_DEBUG = new System.Windows.Forms.Button();
            this.LBL_WPNEQUIP = new System.Windows.Forms.Label();
            this.LBL_HP = new System.Windows.Forms.Label();
            this.BTN_INVO = new System.Windows.Forms.Button();
            this.LBL_AMMO = new System.Windows.Forms.Label();
            this.TIMER_ECG = new System.Windows.Forms.Timer(this.components);
            this.DefaultImage = new System.Windows.Forms.PictureBox();
            this.OPCODE_MENU = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertOpcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BAR_TOOL.SuspendLayout();
            this.MNU_TOP.SuspendLayout();
            this.STATUS_STRIP.SuspendLayout();
            this.panel_scd.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IMAGE_BG_RENDER_RDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STATUS_IMAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WPN_IMAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLAYER_IMAGE)).BeginInit();
            this.MemoryGroup00.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IMAGE_BG_RENDER)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultImage)).BeginInit();
            this.OPCODE_MENU.SuspendLayout();
            this.SuspendLayout();
            // 
            // LST_CODE
            // 
            this.LST_CODE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.LST_CODE.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CLM_LINE,
            this.CLM_CODE,
            this.CLM_CODE_COMMENT});
            this.LST_CODE.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LST_CODE.ForeColor = System.Drawing.Color.Gainsboro;
            this.LST_CODE.FullRowSelect = true;
            this.LST_CODE.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LST_CODE.HideSelection = false;
            this.LST_CODE.Location = new System.Drawing.Point(153, 50);
            this.LST_CODE.MultiSelect = false;
            this.LST_CODE.Name = "LST_CODE";
            this.LST_CODE.Size = new System.Drawing.Size(1531, 714);
            this.LST_CODE.TabIndex = 0;
            this.LST_CODE.UseCompatibleStateImageBehavior = false;
            this.LST_CODE.View = System.Windows.Forms.View.Details;
            this.LST_CODE.SelectedIndexChanged += new System.EventHandler(this.LST_CODE_SelectedIndexChanged);
            this.LST_CODE.Click += new System.EventHandler(this.LST_CODE_Click);
            this.LST_CODE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LST_CODE_KeyDown);
            this.LST_CODE.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LST_CODE_MouseClick);
            this.LST_CODE.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LST_CODE_MouseDown);
            // 
            // CLM_LINE
            // 
            this.CLM_LINE.Text = "LINE";
            this.CLM_LINE.Width = 97;
            // 
            // CLM_CODE
            // 
            this.CLM_CODE.Text = "INTERPRETED CODE";
            this.CLM_CODE.Width = 351;
            // 
            // CLM_CODE_COMMENT
            // 
            this.CLM_CODE_COMMENT.Text = "COMMENT";
            this.CLM_CODE_COMMENT.Width = 1024;
            // 
            // BAR_TOOL
            // 
            this.BAR_TOOL.AutoSize = false;
            this.BAR_TOOL.BackColor = System.Drawing.Color.Gainsboro;
            this.BAR_TOOL.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.BAR_TOOL.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.BAR_TOOL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTN_OPEN,
            this.toolStripSeparator1,
            this.SCD_BUTTON_REPACK,
            this.BTN_DISPLAY_TOGGLE,
            this.toolStripSeparator4,
            this.BTN_AOT_MONITOR,
            this.toolStripSeparator5,
            this.BTN_FLAG_MONITOR,
            this.toolStripSeparator6,
            this.BTN_HOME,
            this.toolStripSeparator8,
            this.SCD_BTN_CLIPBOARD,
            this.toolStripSeparator2});
            this.BAR_TOOL.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.BAR_TOOL.Location = new System.Drawing.Point(0, 0);
            this.BAR_TOOL.Name = "BAR_TOOL";
            this.BAR_TOOL.Size = new System.Drawing.Size(1900, 47);
            this.BAR_TOOL.Stretch = true;
            this.BAR_TOOL.TabIndex = 1;
            this.BAR_TOOL.Text = "toolStrip1";
            this.BAR_TOOL.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.BAR_TOOL_ItemClicked);
            // 
            // BTN_OPEN
            // 
            this.BTN_OPEN.AutoSize = false;
            this.BTN_OPEN.BackColor = System.Drawing.Color.Gainsboro;
            this.BTN_OPEN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_OPEN.ForeColor = System.Drawing.Color.Crimson;
            this.BTN_OPEN.Image = ((System.Drawing.Image)(resources.GetObject("BTN_OPEN.Image")));
            this.BTN_OPEN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_OPEN.Name = "BTN_OPEN";
            this.BTN_OPEN.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.BTN_OPEN.Size = new System.Drawing.Size(48, 45);
            this.BTN_OPEN.Text = "toolStripButton1";
            this.BTN_OPEN.Click += new System.EventHandler(this.BTN_OPEN_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // SCD_BUTTON_REPACK
            // 
            this.SCD_BUTTON_REPACK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SCD_BUTTON_REPACK.Image = ((System.Drawing.Image)(resources.GetObject("SCD_BUTTON_REPACK.Image")));
            this.SCD_BUTTON_REPACK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SCD_BUTTON_REPACK.Name = "SCD_BUTTON_REPACK";
            this.SCD_BUTTON_REPACK.Size = new System.Drawing.Size(34, 44);
            this.SCD_BUTTON_REPACK.Text = "toolStripButton1";
            this.SCD_BUTTON_REPACK.Click += new System.EventHandler(this.SCD_BUTTON_REPACK_Click);
            // 
            // BTN_DISPLAY_TOGGLE
            // 
            this.BTN_DISPLAY_TOGGLE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_DISPLAY_TOGGLE.Image = ((System.Drawing.Image)(resources.GetObject("BTN_DISPLAY_TOGGLE.Image")));
            this.BTN_DISPLAY_TOGGLE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_DISPLAY_TOGGLE.Name = "BTN_DISPLAY_TOGGLE";
            this.BTN_DISPLAY_TOGGLE.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.BTN_DISPLAY_TOGGLE.Size = new System.Drawing.Size(54, 44);
            this.BTN_DISPLAY_TOGGLE.Text = "Toggle between bytecode/interpreted code display mode";
            this.BTN_DISPLAY_TOGGLE.Click += new System.EventHandler(this.BTN_DISPLAY_TOGGLE_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 47);
            // 
            // BTN_AOT_MONITOR
            // 
            this.BTN_AOT_MONITOR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_AOT_MONITOR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_AOT_MONITOR.Image")));
            this.BTN_AOT_MONITOR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_AOT_MONITOR.Name = "BTN_AOT_MONITOR";
            this.BTN_AOT_MONITOR.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.BTN_AOT_MONITOR.Size = new System.Drawing.Size(54, 44);
            this.BTN_AOT_MONITOR.Text = "Display a list of all AOT objects used";
            this.BTN_AOT_MONITOR.Click += new System.EventHandler(this.BTN_AOT_MONITOR_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 47);
            // 
            // BTN_FLAG_MONITOR
            // 
            this.BTN_FLAG_MONITOR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_FLAG_MONITOR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_FLAG_MONITOR.Image")));
            this.BTN_FLAG_MONITOR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_FLAG_MONITOR.Name = "BTN_FLAG_MONITOR";
            this.BTN_FLAG_MONITOR.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.BTN_FLAG_MONITOR.Size = new System.Drawing.Size(54, 44);
            this.BTN_FLAG_MONITOR.Text = "Display a list of all flags used";
            this.BTN_FLAG_MONITOR.Click += new System.EventHandler(this.BTN_FLAG_MONITOR_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 47);
            // 
            // BTN_HOME
            // 
            this.BTN_HOME.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_HOME.Image = ((System.Drawing.Image)(resources.GetObject("BTN_HOME.Image")));
            this.BTN_HOME.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_HOME.Name = "BTN_HOME";
            this.BTN_HOME.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.BTN_HOME.Size = new System.Drawing.Size(54, 44);
            this.BTN_HOME.Text = "toolStripButton1";
            this.BTN_HOME.Click += new System.EventHandler(this.BTN_HOME_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 47);
            // 
            // SCD_BTN_CLIPBOARD
            // 
            this.SCD_BTN_CLIPBOARD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SCD_BTN_CLIPBOARD.Image = ((System.Drawing.Image)(resources.GetObject("SCD_BTN_CLIPBOARD.Image")));
            this.SCD_BTN_CLIPBOARD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SCD_BTN_CLIPBOARD.Name = "SCD_BTN_CLIPBOARD";
            this.SCD_BTN_CLIPBOARD.Size = new System.Drawing.Size(34, 44);
            this.SCD_BTN_CLIPBOARD.Text = "toolStripButton1";
            this.SCD_BTN_CLIPBOARD.ToolTipText = "Notes/Clipboard";
            this.SCD_BTN_CLIPBOARD.Click += new System.EventHandler(this.SCD_BTN_CLIPBOARD_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 47);
            // 
            // MNU_TOP
            // 
            this.MNU_TOP.BackColor = System.Drawing.Color.DarkGray;
            this.MNU_TOP.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MNU_TOP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.M_FILE,
            this.M_VIEW,
            this.M_HELP});
            this.MNU_TOP.Location = new System.Drawing.Point(0, 0);
            this.MNU_TOP.Name = "MNU_TOP";
            this.MNU_TOP.Size = new System.Drawing.Size(1424, 24);
            this.MNU_TOP.TabIndex = 2;
            this.MNU_TOP.Text = "menuStrip1";
            // 
            // M_FILE
            // 
            this.M_FILE.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.M_FILE_OPEN,
            this.toolStripMenuItem1,
            this.configToolStripMenuItem,
            this.toolStripMenuItem2,
            this.M_FILE_EXIT});
            this.M_FILE.Name = "M_FILE";
            this.M_FILE.Size = new System.Drawing.Size(37, 20);
            this.M_FILE.Text = "File";
            // 
            // M_FILE_OPEN
            // 
            this.M_FILE_OPEN.Name = "M_FILE_OPEN";
            this.M_FILE_OPEN.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.M_FILE_OPEN.Size = new System.Drawing.Size(155, 22);
            this.M_FILE_OPEN.Text = "Open...";
            this.M_FILE_OPEN.Click += new System.EventHandler(this.M_FILE_OPEN_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.configToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 6);
            // 
            // M_FILE_EXIT
            // 
            this.M_FILE_EXIT.Name = "M_FILE_EXIT";
            this.M_FILE_EXIT.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.M_FILE_EXIT.Size = new System.Drawing.Size(155, 22);
            this.M_FILE_EXIT.Text = "Quit";
            this.M_FILE_EXIT.Click += new System.EventHandler(this.M_FILE_EXIT_Click);
            // 
            // M_VIEW
            // 
            this.M_VIEW.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.M_VIEW_TOGGLE,
            this.sCDToolStripMenuItem});
            this.M_VIEW.Name = "M_VIEW";
            this.M_VIEW.Size = new System.Drawing.Size(44, 20);
            this.M_VIEW.Text = "View";
            // 
            // M_VIEW_TOGGLE
            // 
            this.M_VIEW_TOGGLE.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bIO2RE2ToolStripMenuItem,
            this.bIO2RE3ToolStripMenuItem});
            this.M_VIEW_TOGGLE.Name = "M_VIEW_TOGGLE";
            this.M_VIEW_TOGGLE.Size = new System.Drawing.Size(188, 22);
            this.M_VIEW_TOGGLE.Text = "Toggle display mode";
            this.M_VIEW_TOGGLE.Click += new System.EventHandler(this.M_VIEW_TOGGLE_Click);
            // 
            // bIO2RE2ToolStripMenuItem
            // 
            this.bIO2RE2ToolStripMenuItem.CheckOnClick = true;
            this.bIO2RE2ToolStripMenuItem.Name = "bIO2RE2ToolStripMenuItem";
            this.bIO2RE2ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.bIO2RE2ToolStripMenuItem.Text = "BIO2/RE2";
            this.bIO2RE2ToolStripMenuItem.Click += new System.EventHandler(this.bIO2RE2ToolStripMenuItem_Click);
            // 
            // bIO2RE3ToolStripMenuItem
            // 
            this.bIO2RE3ToolStripMenuItem.CheckOnClick = true;
            this.bIO2RE3ToolStripMenuItem.Name = "bIO2RE3ToolStripMenuItem";
            this.bIO2RE3ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.bIO2RE3ToolStripMenuItem.Text = "BIO3/RE3";
            this.bIO2RE3ToolStripMenuItem.Click += new System.EventHandler(this.bIO2RE3ToolStripMenuItem_Click);
            // 
            // sCDToolStripMenuItem
            // 
            this.sCDToolStripMenuItem.Name = "sCDToolStripMenuItem";
            this.sCDToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.sCDToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.sCDToolStripMenuItem.Text = "Byte > Interpreted";
            // 
            // M_HELP
            // 
            this.M_HELP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.M_HELP.Name = "M_HELP";
            this.M_HELP.Size = new System.Drawing.Size(44, 20);
            this.M_HELP.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // LST_BYTE
            // 
            this.LST_BYTE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LST_BYTE.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CLM_OFFSET,
            this.CLM_BYTECODE,
            this.CLM_BYTE_COMMENT});
            this.LST_BYTE.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LST_BYTE.ForeColor = System.Drawing.Color.Gainsboro;
            this.LST_BYTE.FullRowSelect = true;
            this.LST_BYTE.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LST_BYTE.HideSelection = false;
            this.LST_BYTE.Location = new System.Drawing.Point(153, 50);
            this.LST_BYTE.MultiSelect = false;
            this.LST_BYTE.Name = "LST_BYTE";
            this.LST_BYTE.Size = new System.Drawing.Size(1531, 714);
            this.LST_BYTE.TabIndex = 5;
            this.LST_BYTE.UseCompatibleStateImageBehavior = false;
            this.LST_BYTE.View = System.Windows.Forms.View.Details;
            this.LST_BYTE.SelectedIndexChanged += new System.EventHandler(this.LST_BYTE_SelectedIndexChanged);
            this.LST_BYTE.Click += new System.EventHandler(this.LST_BYTE_Click);
            this.LST_BYTE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LST_BYTE_KeyDown);
            // 
            // CLM_OFFSET
            // 
            this.CLM_OFFSET.Text = "OFFSET";
            // 
            // CLM_BYTECODE
            // 
            this.CLM_BYTECODE.Text = "BYTECODE";
            this.CLM_BYTECODE.Width = 600;
            // 
            // CLM_BYTE_COMMENT
            // 
            this.CLM_BYTE_COMMENT.Text = "COMMENT";
            this.CLM_BYTE_COMMENT.Width = 1024;
            // 
            // LST_PROP
            // 
            this.LST_PROP.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.LST_PROP.CommandsForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LST_PROP.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LST_PROP.HelpVisible = false;
            this.LST_PROP.LineColor = System.Drawing.SystemColors.ControlDark;
            this.LST_PROP.Location = new System.Drawing.Point(1690, 50);
            this.LST_PROP.Name = "LST_PROP";
            this.LST_PROP.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.LST_PROP.Size = new System.Drawing.Size(202, 559);
            this.LST_PROP.TabIndex = 8;
            this.LST_PROP.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.LST_PROP_PropertyValueChanged);
            // 
            // DLG_OPEN_FILE
            // 
            this.DLG_OPEN_FILE.Filter = "SCD files|*.SCD|RDT files|*.RDT";
            // 
            // STATUS_STRIP
            // 
            this.STATUS_STRIP.AutoSize = false;
            this.STATUS_STRIP.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.STATUS_STRIP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LBL_PROC_STATUS,
            this.toolStripStatusLabel1,
            this.LBL_IGT});
            this.STATUS_STRIP.Location = new System.Drawing.Point(0, 831);
            this.STATUS_STRIP.Name = "STATUS_STRIP";
            this.STATUS_STRIP.Size = new System.Drawing.Size(1424, 28);
            this.STATUS_STRIP.SizingGrip = false;
            this.STATUS_STRIP.TabIndex = 10;
            this.STATUS_STRIP.Text = "statusStrip1";
            // 
            // LBL_PROC_STATUS
            // 
            this.LBL_PROC_STATUS.Name = "LBL_PROC_STATUS";
            this.LBL_PROC_STATUS.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.LBL_PROC_STATUS.Size = new System.Drawing.Size(100, 23);
            this.LBL_PROC_STATUS.Text = "Process:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 23);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // LBL_IGT
            // 
            this.LBL_IGT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_IGT.Name = "LBL_IGT";
            this.LBL_IGT.Size = new System.Drawing.Size(49, 23);
            this.LBL_IGT.Text = "IGT:";
            // 
            // DIR_LISTBOX
            // 
            this.DIR_LISTBOX.BackColor = System.Drawing.SystemColors.WindowText;
            this.DIR_LISTBOX.ForeColor = System.Drawing.Color.Beige;
            this.DIR_LISTBOX.FormattingEnabled = true;
            this.DIR_LISTBOX.IntegralHeight = false;
            this.DIR_LISTBOX.Location = new System.Drawing.Point(0, 77);
            this.DIR_LISTBOX.Name = "DIR_LISTBOX";
            this.DIR_LISTBOX.Size = new System.Drawing.Size(147, 305);
            this.DIR_LISTBOX.TabIndex = 13;
            this.DIR_LISTBOX.SelectedIndexChanged += new System.EventHandler(this.DIR_LISTBOX_SelectedIndexChanged);
            this.DIR_LISTBOX.SelectedValueChanged += new System.EventHandler(this.DIR_LISTBOX_SelectedValueChanged);
            // 
            // DRIVE_LISTBOX
            // 
            this.DRIVE_LISTBOX.FormattingEnabled = true;
            this.DRIVE_LISTBOX.Location = new System.Drawing.Point(3, 50);
            this.DRIVE_LISTBOX.Name = "DRIVE_LISTBOX";
            this.DRIVE_LISTBOX.Size = new System.Drawing.Size(144, 21);
            this.DRIVE_LISTBOX.TabIndex = 14;
            this.DRIVE_LISTBOX.SelectionChangeCommitted += new System.EventHandler(this.DRIVE_LISTBOX_SelectionChangeCommitted);
            // 
            // F_LISTBOX
            // 
            this.F_LISTBOX.BackColor = System.Drawing.SystemColors.WindowText;
            this.F_LISTBOX.ForeColor = System.Drawing.SystemColors.Window;
            this.F_LISTBOX.FormattingEnabled = true;
            this.F_LISTBOX.Location = new System.Drawing.Point(3, 388);
            this.F_LISTBOX.Name = "F_LISTBOX";
            this.F_LISTBOX.Normal = false;
            this.F_LISTBOX.Pattern = "*.*";
            this.F_LISTBOX.Size = new System.Drawing.Size(144, 381);
            this.F_LISTBOX.TabIndex = 15;
            this.F_LISTBOX.SelectedIndexChanged += new System.EventHandler(this.F_LISTBOX_SelectedIndexChanged);
            // 
            // panel_scd
            // 
            this.panel_scd.BackColor = System.Drawing.Color.Gainsboro;
            this.panel_scd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_scd.Controls.Add(this.groupBox1);
            this.panel_scd.Controls.Add(this.DRIVE_LISTBOX);
            this.panel_scd.Controls.Add(this.F_LISTBOX);
            this.panel_scd.Controls.Add(this.BAR_TOOL);
            this.panel_scd.Controls.Add(this.LST_PROP);
            this.panel_scd.Controls.Add(this.DIR_LISTBOX);
            this.panel_scd.Controls.Add(this.LST_CODE);
            this.panel_scd.Controls.Add(this.LST_BYTE);
            this.panel_scd.Location = new System.Drawing.Point(0, 76);
            this.panel_scd.Name = "panel_scd";
            this.panel_scd.Size = new System.Drawing.Size(1904, 778);
            this.panel_scd.TabIndex = 16;
            this.panel_scd.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IMAGE_BG_RENDER_RDT);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1692, 625);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 130);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CURRENT ROOM";
            // 
            // IMAGE_BG_RENDER_RDT
            // 
            this.IMAGE_BG_RENDER_RDT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.IMAGE_BG_RENDER_RDT.ErrorImage = ((System.Drawing.Image)(resources.GetObject("IMAGE_BG_RENDER_RDT.ErrorImage")));
            this.IMAGE_BG_RENDER_RDT.Image = ((System.Drawing.Image)(resources.GetObject("IMAGE_BG_RENDER_RDT.Image")));
            this.IMAGE_BG_RENDER_RDT.Location = new System.Drawing.Point(29, 30);
            this.IMAGE_BG_RENDER_RDT.Name = "IMAGE_BG_RENDER_RDT";
            this.IMAGE_BG_RENDER_RDT.Size = new System.Drawing.Size(140, 87);
            this.IMAGE_BG_RENDER_RDT.TabIndex = 27;
            this.IMAGE_BG_RENDER_RDT.TabStop = false;
            // 
            // MAIN_TOOLBAR
            // 
            this.MAIN_TOOLBAR.AutoSize = false;
            this.MAIN_TOOLBAR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MAIN_TOOLBAR.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tsep00,
            this.TBTN_EXE,
            this.TBTN_BIO3EXE,
            this.tsep02,
            this.TBTN_DEBUG,
            this.TBTN_SCD,
            this.tsep_01,
            this.TBTN_SAP,
            this.TBTN_FX,
            this.TBTN_SAVE,
            this.TBTN_CONV,
            this.TBTN_CONFIG,
            this.TBTN_HEX,
            this.TBTN_MSG});
            this.MAIN_TOOLBAR.ButtonSize = new System.Drawing.Size(25, 25);
            this.MAIN_TOOLBAR.DropDownArrows = true;
            this.MAIN_TOOLBAR.ImageList = this.IconList;
            this.MAIN_TOOLBAR.Location = new System.Drawing.Point(0, 24);
            this.MAIN_TOOLBAR.Name = "MAIN_TOOLBAR";
            this.MAIN_TOOLBAR.ShowToolTips = true;
            this.MAIN_TOOLBAR.Size = new System.Drawing.Size(1424, 46);
            this.MAIN_TOOLBAR.TabIndex = 17;
            this.MAIN_TOOLBAR.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.MAIN_TOOLBAR_ButtonClick);
            this.MAIN_TOOLBAR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MAIN_TOOLBAR_MouseUp);
            // 
            // tsep00
            // 
            this.tsep00.Name = "tsep00";
            this.tsep00.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // TBTN_EXE
            // 
            this.TBTN_EXE.ImageIndex = 21;
            this.TBTN_EXE.Name = "TBTN_EXE";
            // 
            // TBTN_BIO3EXE
            // 
            this.TBTN_BIO3EXE.ImageIndex = 20;
            this.TBTN_BIO3EXE.Name = "TBTN_BIO3EXE";
            // 
            // tsep02
            // 
            this.tsep02.Name = "tsep02";
            this.tsep02.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // TBTN_DEBUG
            // 
            this.TBTN_DEBUG.ImageIndex = 2;
            this.TBTN_DEBUG.Name = "TBTN_DEBUG";
            // 
            // TBTN_SCD
            // 
            this.TBTN_SCD.ImageIndex = 6;
            this.TBTN_SCD.Name = "TBTN_SCD";
            // 
            // tsep_01
            // 
            this.tsep_01.Name = "tsep_01";
            this.tsep_01.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // TBTN_SAP
            // 
            this.TBTN_SAP.ImageIndex = 13;
            this.TBTN_SAP.Name = "TBTN_SAP";
            // 
            // TBTN_FX
            // 
            this.TBTN_FX.ImageIndex = 10;
            this.TBTN_FX.Name = "TBTN_FX";
            // 
            // TBTN_SAVE
            // 
            this.TBTN_SAVE.ImageIndex = 14;
            this.TBTN_SAVE.Name = "TBTN_SAVE";
            // 
            // TBTN_CONV
            // 
            this.TBTN_CONV.ImageIndex = 15;
            this.TBTN_CONV.Name = "TBTN_CONV";
            // 
            // TBTN_CONFIG
            // 
            this.TBTN_CONFIG.ImageIndex = 16;
            this.TBTN_CONFIG.Name = "TBTN_CONFIG";
            // 
            // TBTN_HEX
            // 
            this.TBTN_HEX.ImageIndex = 22;
            this.TBTN_HEX.Name = "TBTN_HEX";
            // 
            // TBTN_MSG
            // 
            this.TBTN_MSG.ImageIndex = 11;
            this.TBTN_MSG.Name = "TBTN_MSG";
            // 
            // IconList
            // 
            this.IconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconList.ImageStream")));
            this.IconList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconList.Images.SetKeyName(0, "Open.png");
            this.IconList.Images.SetKeyName(1, "Hex2Dec.png");
            this.IconList.Images.SetKeyName(2, "Lyle-Zapato-Arthropodicons-Japanese-Beetle.ico");
            this.IconList.Images.SetKeyName(3, "Exe.png");
            this.IconList.Images.SetKeyName(4, "Danrabbit-Elementary-Folder-home.ico");
            this.IconList.Images.SetKeyName(5, "ICON16.ico");
            this.IconList.Images.SetKeyName(6, "ICO_APP.ico");
            this.IconList.Images.SetKeyName(7, "byte2Tex.png");
            this.IconList.Images.SetKeyName(8, "claire.png");
            this.IconList.Images.SetKeyName(9, "leon.png");
            this.IconList.Images.SetKeyName(10, "EFX.png");
            this.IconList.Images.SetKeyName(11, "Clipboard-icon.png");
            this.IconList.Images.SetKeyName(12, "Exe00.png");
            this.IconList.Images.SetKeyName(13, "sapmake.png");
            this.IconList.Images.SetKeyName(14, "saveico.png");
            this.IconList.Images.SetKeyName(15, "convert_ico.png");
            this.IconList.Images.SetKeyName(16, "config_ico.png");
            this.IconList.Images.SetKeyName(17, "ITEM_Menu.png");
            this.IconList.Images.SetKeyName(18, "RE3ICO.ico");
            this.IconList.Images.SetKeyName(19, "Nem00_Ico.ico");
            this.IconList.Images.SetKeyName(20, "re3_exeico00.png");
            this.IconList.Images.SetKeyName(21, "BIO2_ICO.ico");
            this.IconList.Images.SetKeyName(22, "Hex-Workshop-Hex-Editor.png");
            // 
            // STATUS_SELECTOR
            // 
            this.STATUS_SELECTOR.FormattingEnabled = true;
            this.STATUS_SELECTOR.Items.AddRange(new object[] {
            "FINE",
            "CAUTION0",
            "CAUTION1",
            "DANGER",
            "POISON"});
            this.STATUS_SELECTOR.Location = new System.Drawing.Point(153, 122);
            this.STATUS_SELECTOR.Name = "STATUS_SELECTOR";
            this.STATUS_SELECTOR.Size = new System.Drawing.Size(94, 21);
            this.STATUS_SELECTOR.TabIndex = 2;
            this.STATUS_SELECTOR.Text = "FINE";
            this.STATUS_SELECTOR.SelectedIndexChanged += new System.EventHandler(this.STATUS_SELECTOR_SelectedIndexChanged);
            // 
            // LBL_SEL_CONDITION
            // 
            this.LBL_SEL_CONDITION.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.LBL_SEL_CONDITION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_SEL_CONDITION.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LBL_SEL_CONDITION.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_SEL_CONDITION.Location = new System.Drawing.Point(165, 21);
            this.LBL_SEL_CONDITION.Name = "LBL_SEL_CONDITION";
            this.LBL_SEL_CONDITION.Size = new System.Drawing.Size(148, 17);
            this.LBL_SEL_CONDITION.TabIndex = 3;
            this.LBL_SEL_CONDITION.Text = "CONDITION SELECT";
            this.LBL_SEL_CONDITION.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_PLDSELECT
            // 
            this.LBL_PLDSELECT.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.LBL_PLDSELECT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_PLDSELECT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LBL_PLDSELECT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_PLDSELECT.Location = new System.Drawing.Point(319, 22);
            this.LBL_PLDSELECT.Name = "LBL_PLDSELECT";
            this.LBL_PLDSELECT.Size = new System.Drawing.Size(155, 17);
            this.LBL_PLDSELECT.TabIndex = 6;
            this.LBL_PLDSELECT.Text = "PLD_SELECT";
            this.LBL_PLDSELECT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PLD_SELECTOR
            // 
            this.PLD_SELECTOR.FormattingEnabled = true;
            this.PLD_SELECTOR.Items.AddRange(new object[] {
            "00 - LEON - RPD DEFAULT",
            "08 - LEON - RPD ALTERNATE",
            "0A - LEON - BIKER"});
            this.PLD_SELECTOR.Location = new System.Drawing.Point(320, 110);
            this.PLD_SELECTOR.Name = "PLD_SELECTOR";
            this.PLD_SELECTOR.Size = new System.Drawing.Size(132, 21);
            this.PLD_SELECTOR.TabIndex = 5;
            this.PLD_SELECTOR.Text = "00 - LEON - RPD ARMOR";
            // 
            // LBL_CAMERAS
            // 
            this.LBL_CAMERAS.BackColor = System.Drawing.SystemColors.Control;
            this.LBL_CAMERAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_CAMERAS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LBL_CAMERAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_CAMERAS.Location = new System.Drawing.Point(490, 15);
            this.LBL_CAMERAS.Name = "LBL_CAMERAS";
            this.LBL_CAMERAS.Size = new System.Drawing.Size(114, 23);
            this.LBL_CAMERAS.TabIndex = 8;
            this.LBL_CAMERAS.Text = "CAMERA";
            this.LBL_CAMERAS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_PLAYER_COORDS
            // 
            this.LBL_PLAYER_COORDS.BackColor = System.Drawing.SystemColors.Control;
            this.LBL_PLAYER_COORDS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_PLAYER_COORDS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LBL_PLAYER_COORDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_PLAYER_COORDS.Location = new System.Drawing.Point(610, 15);
            this.LBL_PLAYER_COORDS.Name = "LBL_PLAYER_COORDS";
            this.LBL_PLAYER_COORDS.Size = new System.Drawing.Size(434, 24);
            this.LBL_PLAYER_COORDS.TabIndex = 9;
            this.LBL_PLAYER_COORDS.Text = "PLAYER COORDINATES";
            this.LBL_PLAYER_COORDS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_ROOMDESC
            // 
            this.LBL_ROOMDESC.BackColor = System.Drawing.SystemColors.Control;
            this.LBL_ROOMDESC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_ROOMDESC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LBL_ROOMDESC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_ROOMDESC.Location = new System.Drawing.Point(1050, 15);
            this.LBL_ROOMDESC.Name = "LBL_ROOMDESC";
            this.LBL_ROOMDESC.Size = new System.Drawing.Size(140, 23);
            this.LBL_ROOMDESC.TabIndex = 10;
            this.LBL_ROOMDESC.Text = "ROOMXXXX.RDT";
            this.LBL_ROOMDESC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_CAMID00
            // 
            this.LBL_CAMID00.BackColor = System.Drawing.SystemColors.ControlText;
            this.LBL_CAMID00.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LBL_CAMID00.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LBL_CAMID00.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_CAMID00.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LBL_CAMID00.Location = new System.Drawing.Point(490, 38);
            this.LBL_CAMID00.Name = "LBL_CAMID00";
            this.LBL_CAMID00.Size = new System.Drawing.Size(60, 23);
            this.LBL_CAMID00.TabIndex = 11;
            this.LBL_CAMID00.Text = "05";
            this.LBL_CAMID00.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_RID00
            // 
            this.LBL_RID00.BackColor = System.Drawing.SystemColors.ControlText;
            this.LBL_RID00.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LBL_RID00.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LBL_RID00.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_RID00.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LBL_RID00.Location = new System.Drawing.Point(1050, 38);
            this.LBL_RID00.Name = "LBL_RID00";
            this.LBL_RID00.Size = new System.Drawing.Size(71, 23);
            this.LBL_RID00.TabIndex = 12;
            this.LBL_RID00.Text = "01";
            this.LBL_RID00.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_RID01
            // 
            this.LBL_RID01.BackColor = System.Drawing.SystemColors.ControlText;
            this.LBL_RID01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LBL_RID01.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LBL_RID01.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_RID01.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LBL_RID01.Location = new System.Drawing.Point(1118, 38);
            this.LBL_RID01.Name = "LBL_RID01";
            this.LBL_RID01.Size = new System.Drawing.Size(72, 23);
            this.LBL_RID01.TabIndex = 13;
            this.LBL_RID01.Text = "00";
            this.LBL_RID01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_CAMID01
            // 
            this.LBL_CAMID01.BackColor = System.Drawing.SystemColors.ControlText;
            this.LBL_CAMID01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LBL_CAMID01.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LBL_CAMID01.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_CAMID01.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LBL_CAMID01.Location = new System.Drawing.Point(550, 38);
            this.LBL_CAMID01.Name = "LBL_CAMID01";
            this.LBL_CAMID01.Size = new System.Drawing.Size(54, 23);
            this.LBL_CAMID01.TabIndex = 14;
            this.LBL_CAMID01.Text = "0";
            this.LBL_CAMID01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_POSR
            // 
            this.LBL_POSR.BackColor = System.Drawing.SystemColors.ControlText;
            this.LBL_POSR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LBL_POSR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LBL_POSR.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_POSR.ForeColor = System.Drawing.Color.BlueViolet;
            this.LBL_POSR.Location = new System.Drawing.Point(949, 38);
            this.LBL_POSR.Name = "LBL_POSR";
            this.LBL_POSR.Size = new System.Drawing.Size(95, 23);
            this.LBL_POSR.TabIndex = 18;
            this.LBL_POSR.Text = "0";
            this.LBL_POSR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_POSY
            // 
            this.LBL_POSY.BackColor = System.Drawing.SystemColors.ControlText;
            this.LBL_POSY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LBL_POSY.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LBL_POSY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_POSY.ForeColor = System.Drawing.Color.SpringGreen;
            this.LBL_POSY.Location = new System.Drawing.Point(722, 38);
            this.LBL_POSY.Name = "LBL_POSY";
            this.LBL_POSY.Size = new System.Drawing.Size(106, 23);
            this.LBL_POSY.TabIndex = 17;
            this.LBL_POSY.Text = "00";
            this.LBL_POSY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBL_POSY.Click += new System.EventHandler(this.LBL_POSY_Click);
            // 
            // LBL_POSX
            // 
            this.LBL_POSX.BackColor = System.Drawing.SystemColors.ControlText;
            this.LBL_POSX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LBL_POSX.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LBL_POSX.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_POSX.ForeColor = System.Drawing.Color.Crimson;
            this.LBL_POSX.Location = new System.Drawing.Point(610, 38);
            this.LBL_POSX.Name = "LBL_POSX";
            this.LBL_POSX.Size = new System.Drawing.Size(106, 23);
            this.LBL_POSX.TabIndex = 16;
            this.LBL_POSX.Text = "01";
            this.LBL_POSX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_POSZ
            // 
            this.LBL_POSZ.BackColor = System.Drawing.SystemColors.ControlText;
            this.LBL_POSZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LBL_POSZ.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LBL_POSZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_POSZ.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.LBL_POSZ.Location = new System.Drawing.Point(837, 38);
            this.LBL_POSZ.Name = "LBL_POSZ";
            this.LBL_POSZ.Size = new System.Drawing.Size(106, 23);
            this.LBL_POSZ.TabIndex = 15;
            this.LBL_POSZ.Text = "05";
            this.LBL_POSZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TIMER_HOOK
            // 
            this.TIMER_HOOK.Enabled = true;
            this.TIMER_HOOK.Interval = 10;
            this.TIMER_HOOK.Tick += new System.EventHandler(this.TIMER_HOOK_Tick);
            // 
            // STATUS_IMAGE
            // 
            this.STATUS_IMAGE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.STATUS_IMAGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.STATUS_IMAGE.Image = ((System.Drawing.Image)(resources.GetObject("STATUS_IMAGE.Image")));
            this.STATUS_IMAGE.Location = new System.Drawing.Point(165, 42);
            this.STATUS_IMAGE.Name = "STATUS_IMAGE";
            this.STATUS_IMAGE.Size = new System.Drawing.Size(149, 60);
            this.STATUS_IMAGE.TabIndex = 1;
            this.STATUS_IMAGE.TabStop = false;
            // 
            // BTN_HOOK
            // 
            this.BTN_HOOK.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_HOOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTN_HOOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_HOOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_HOOK.Image = ((System.Drawing.Image)(resources.GetObject("BTN_HOOK.Image")));
            this.BTN_HOOK.Location = new System.Drawing.Point(8, 20);
            this.BTN_HOOK.Name = "BTN_HOOK";
            this.BTN_HOOK.Size = new System.Drawing.Size(58, 81);
            this.BTN_HOOK.TabIndex = 19;
            this.BTN_HOOK.Text = "Hook";
            this.BTN_HOOK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTN_HOOK.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BTN_HOOK.UseVisualStyleBackColor = false;
            this.BTN_HOOK.Click += new System.EventHandler(this.BTN_HOOK_Click);
            // 
            // WPN_IMAGE
            // 
            this.WPN_IMAGE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WPN_IMAGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.WPN_IMAGE.Image = ((System.Drawing.Image)(resources.GetObject("WPN_IMAGE.Image")));
            this.WPN_IMAGE.Location = new System.Drawing.Point(72, 42);
            this.WPN_IMAGE.Name = "WPN_IMAGE";
            this.WPN_IMAGE.Size = new System.Drawing.Size(64, 60);
            this.WPN_IMAGE.TabIndex = 4;
            this.WPN_IMAGE.TabStop = false;
            // 
            // PLAYER_IMAGE
            // 
            this.PLAYER_IMAGE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PLAYER_IMAGE.Image = ((System.Drawing.Image)(resources.GetObject("PLAYER_IMAGE.Image")));
            this.PLAYER_IMAGE.Location = new System.Drawing.Point(320, 42);
            this.PLAYER_IMAGE.Name = "PLAYER_IMAGE";
            this.PLAYER_IMAGE.Size = new System.Drawing.Size(84, 55);
            this.PLAYER_IMAGE.TabIndex = 0;
            this.PLAYER_IMAGE.TabStop = false;
            // 
            // MemoryGroup00
            // 
            this.MemoryGroup00.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MemoryGroup00.Controls.Add(this.PLAYER_IMAGE);
            this.MemoryGroup00.Controls.Add(this.STATUS_IMAGE);
            this.MemoryGroup00.Controls.Add(this.IMAGE_BG_RENDER);
            this.MemoryGroup00.Controls.Add(this.WPN_IMAGE);
            this.MemoryGroup00.Controls.Add(this.BTN_HOOK);
            this.MemoryGroup00.Controls.Add(this.BTN_ROOM_DEBUG);
            this.MemoryGroup00.Controls.Add(this.LBL_WPNEQUIP);
            this.MemoryGroup00.Controls.Add(this.LBL_HP);
            this.MemoryGroup00.Controls.Add(this.LBL_PLDSELECT);
            this.MemoryGroup00.Controls.Add(this.PLD_SELECTOR);
            this.MemoryGroup00.Controls.Add(this.BTN_INVO);
            this.MemoryGroup00.Controls.Add(this.LBL_AMMO);
            this.MemoryGroup00.Controls.Add(this.LBL_SEL_CONDITION);
            this.MemoryGroup00.Controls.Add(this.LBL_POSR);
            this.MemoryGroup00.Controls.Add(this.STATUS_SELECTOR);
            this.MemoryGroup00.Controls.Add(this.LBL_POSY);
            this.MemoryGroup00.Controls.Add(this.LBL_POSX);
            this.MemoryGroup00.Controls.Add(this.LBL_CAMID01);
            this.MemoryGroup00.Controls.Add(this.LBL_CAMERAS);
            this.MemoryGroup00.Controls.Add(this.LBL_POSZ);
            this.MemoryGroup00.Controls.Add(this.LBL_PLAYER_COORDS);
            this.MemoryGroup00.Controls.Add(this.LBL_ROOMDESC);
            this.MemoryGroup00.Controls.Add(this.LBL_CAMID00);
            this.MemoryGroup00.Controls.Add(this.LBL_RID00);
            this.MemoryGroup00.Controls.Add(this.LBL_RID01);
            this.MemoryGroup00.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MemoryGroup00.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemoryGroup00.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MemoryGroup00.Location = new System.Drawing.Point(5, 860);
            this.MemoryGroup00.Name = "MemoryGroup00";
            this.MemoryGroup00.Size = new System.Drawing.Size(1897, 156);
            this.MemoryGroup00.TabIndex = 21;
            this.MemoryGroup00.TabStop = false;
            this.MemoryGroup00.Text = "Memory";
            // 
            // IMAGE_BG_RENDER
            // 
            this.IMAGE_BG_RENDER.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.IMAGE_BG_RENDER.ErrorImage = ((System.Drawing.Image)(resources.GetObject("IMAGE_BG_RENDER.ErrorImage")));
            this.IMAGE_BG_RENDER.Image = ((System.Drawing.Image)(resources.GetObject("IMAGE_BG_RENDER.Image")));
            this.IMAGE_BG_RENDER.Location = new System.Drawing.Point(1050, 64);
            this.IMAGE_BG_RENDER.Name = "IMAGE_BG_RENDER";
            this.IMAGE_BG_RENDER.Size = new System.Drawing.Size(140, 87);
            this.IMAGE_BG_RENDER.TabIndex = 26;
            this.IMAGE_BG_RENDER.TabStop = false;
            this.IMAGE_BG_RENDER.Click += new System.EventHandler(this.IMAGE_BG_RENDER_Click);
            // 
            // BTN_ROOM_DEBUG
            // 
            this.BTN_ROOM_DEBUG.BackColor = System.Drawing.Color.Crimson;
            this.BTN_ROOM_DEBUG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_ROOM_DEBUG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ROOM_DEBUG.ImageIndex = 2;
            this.BTN_ROOM_DEBUG.ImageList = this.IconList;
            this.BTN_ROOM_DEBUG.Location = new System.Drawing.Point(1196, 15);
            this.BTN_ROOM_DEBUG.Name = "BTN_ROOM_DEBUG";
            this.BTN_ROOM_DEBUG.Size = new System.Drawing.Size(38, 43);
            this.BTN_ROOM_DEBUG.TabIndex = 25;
            this.BTN_ROOM_DEBUG.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTN_ROOM_DEBUG.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BTN_ROOM_DEBUG.UseVisualStyleBackColor = false;
            // 
            // LBL_WPNEQUIP
            // 
            this.LBL_WPNEQUIP.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.LBL_WPNEQUIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_WPNEQUIP.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LBL_WPNEQUIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_WPNEQUIP.Location = new System.Drawing.Point(72, 22);
            this.LBL_WPNEQUIP.Name = "LBL_WPNEQUIP";
            this.LBL_WPNEQUIP.Size = new System.Drawing.Size(72, 17);
            this.LBL_WPNEQUIP.TabIndex = 24;
            this.LBL_WPNEQUIP.Text = "WPN_EQUIP";
            this.LBL_WPNEQUIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_HP
            // 
            this.LBL_HP.BackColor = System.Drawing.Color.Cornsilk;
            this.LBL_HP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_HP.ForeColor = System.Drawing.Color.Coral;
            this.LBL_HP.Location = new System.Drawing.Point(265, 110);
            this.LBL_HP.Name = "LBL_HP";
            this.LBL_HP.Size = new System.Drawing.Size(49, 14);
            this.LBL_HP.TabIndex = 21;
            this.LBL_HP.Text = "LBL_HP";
            // 
            // BTN_INVO
            // 
            this.BTN_INVO.BackColor = System.Drawing.Color.Crimson;
            this.BTN_INVO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_INVO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTN_INVO.ImageIndex = 17;
            this.BTN_INVO.ImageList = this.IconList;
            this.BTN_INVO.Location = new System.Drawing.Point(17, 110);
            this.BTN_INVO.Name = "BTN_INVO";
            this.BTN_INVO.Size = new System.Drawing.Size(37, 35);
            this.BTN_INVO.TabIndex = 23;
            this.BTN_INVO.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTN_INVO.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BTN_INVO.UseVisualStyleBackColor = false;
            this.BTN_INVO.Click += new System.EventHandler(this.BTN_INVO_Click);
            // 
            // LBL_AMMO
            // 
            this.LBL_AMMO.BackColor = System.Drawing.Color.Cornsilk;
            this.LBL_AMMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_AMMO.ForeColor = System.Drawing.Color.Crimson;
            this.LBL_AMMO.Location = new System.Drawing.Point(69, 123);
            this.LBL_AMMO.Name = "LBL_AMMO";
            this.LBL_AMMO.Size = new System.Drawing.Size(74, 20);
            this.LBL_AMMO.TabIndex = 22;
            this.LBL_AMMO.Text = "label3";
            // 
            // TIMER_ECG
            // 
            this.TIMER_ECG.Enabled = true;
            this.TIMER_ECG.Interval = 2500;
            this.TIMER_ECG.Tick += new System.EventHandler(this.TIMER_ECG_Tick);
            // 
            // DefaultImage
            // 
            this.DefaultImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DefaultImage.Image = ((System.Drawing.Image)(resources.GetObject("DefaultImage.Image")));
            this.DefaultImage.Location = new System.Drawing.Point(0, 0);
            this.DefaultImage.Name = "DefaultImage";
            this.DefaultImage.Size = new System.Drawing.Size(1904, 854);
            this.DefaultImage.TabIndex = 22;
            this.DefaultImage.TabStop = false;
            // 
            // OPCODE_MENU
            // 
            this.OPCODE_MENU.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.OPCODE_MENU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertOpcodeToolStripMenuItem});
            this.OPCODE_MENU.Name = "OPCODE_MENU";
            this.OPCODE_MENU.Size = new System.Drawing.Size(149, 26);
            // 
            // insertOpcodeToolStripMenuItem
            // 
            this.insertOpcodeToolStripMenuItem.Name = "insertOpcodeToolStripMenuItem";
            this.insertOpcodeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.insertOpcodeToolStripMenuItem.Text = "Insert Opcode";
            // 
            // FRM_MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1424, 859);
            this.Controls.Add(this.MemoryGroup00);
            this.Controls.Add(this.MAIN_TOOLBAR);
            this.Controls.Add(this.STATUS_STRIP);
            this.Controls.Add(this.MNU_TOP);
            this.Controls.Add(this.panel_scd);
            this.Controls.Add(this.DefaultImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MNU_TOP;
            this.MinimumSize = new System.Drawing.Size(799, 599);
            this.Name = "FRM_MAIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCD INT ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_MAIN_Load);
            this.Resize += new System.EventHandler(this.FRM_MAIN_Resize);
            this.BAR_TOOL.ResumeLayout(false);
            this.BAR_TOOL.PerformLayout();
            this.MNU_TOP.ResumeLayout(false);
            this.MNU_TOP.PerformLayout();
            this.STATUS_STRIP.ResumeLayout(false);
            this.STATUS_STRIP.PerformLayout();
            this.panel_scd.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IMAGE_BG_RENDER_RDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STATUS_IMAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WPN_IMAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLAYER_IMAGE)).EndInit();
            this.MemoryGroup00.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IMAGE_BG_RENDER)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultImage)).EndInit();
            this.OPCODE_MENU.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LST_CODE;
        private System.Windows.Forms.ToolStrip BAR_TOOL;
        private System.Windows.Forms.MenuStrip MNU_TOP;
        private System.Windows.Forms.ColumnHeader CLM_LINE;
		private System.Windows.Forms.ColumnHeader CLM_CODE;
        private System.Windows.Forms.ListView LST_BYTE;
        private System.Windows.Forms.ColumnHeader CLM_OFFSET;
        private System.Windows.Forms.ColumnHeader CLM_BYTECODE;
        private System.Windows.Forms.ToolStripButton BTN_DISPLAY_TOGGLE;
        private System.Windows.Forms.ToolStripMenuItem M_FILE;
        private System.Windows.Forms.ToolStripMenuItem M_FILE_OPEN;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem M_FILE_EXIT;
        private System.Windows.Forms.ToolStripMenuItem M_VIEW;
        private System.Windows.Forms.ToolStripMenuItem M_HELP;
        private System.Windows.Forms.ToolStripMenuItem M_VIEW_TOGGLE;
        private System.Windows.Forms.ColumnHeader CLM_CODE_COMMENT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTN_AOT_MONITOR;
        private System.Windows.Forms.ToolStripButton BTN_FLAG_MONITOR;
        private System.Windows.Forms.ColumnHeader CLM_BYTE_COMMENT;
        private System.Windows.Forms.PropertyGrid LST_PROP;
        private System.Windows.Forms.OpenFileDialog DLG_OPEN_FILE;
        private System.Windows.Forms.ToolStripButton BTN_OPEN;
        private System.Windows.Forms.StatusStrip STATUS_STRIP;
        private System.Windows.Forms.ToolStripStatusLabel LBL_PROC_STATUS;
        private Microsoft.VisualBasic.Compatibility.VB6.DirListBox DIR_LISTBOX;
        private Microsoft.VisualBasic.Compatibility.VB6.DriveListBox DRIVE_LISTBOX;
        private Microsoft.VisualBasic.Compatibility.VB6.FileListBox F_LISTBOX;
        private System.Windows.Forms.ToolStripButton BTN_HOME;
        private System.Windows.Forms.Panel panel_scd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolBar MAIN_TOOLBAR;
        private System.Windows.Forms.ImageList IconList;
        private System.Windows.Forms.ToolBarButton TBTN_BIO2EXE;
        private System.Windows.Forms.ToolBarButton TBTN_DEBUG;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolBarButton tsep00;
        private System.Windows.Forms.ToolBarButton tsep02;
        private System.Windows.Forms.ToolBarButton tsep_01;
        private System.Windows.Forms.ToolBarButton TBTN_SCD;
        private System.Windows.Forms.ToolBarButton TBTN_SAP;
        private System.Windows.Forms.ToolBarButton TBTN_FX;
        private System.Windows.Forms.ToolBarButton TBTN_SAVE;
        private System.Windows.Forms.ToolBarButton TBTN_CONV;
        private System.Windows.Forms.ToolStripButton SCD_BTN_CLIPBOARD;
        private System.Windows.Forms.ToolBarButton TBTN_CONFIG;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bIO2RE2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bIO2RE3ToolStripMenuItem;
        private System.Windows.Forms.ComboBox STATUS_SELECTOR;
        private System.Windows.Forms.Label LBL_SEL_CONDITION;
        private System.Windows.Forms.Label LBL_CAMID00;
        private System.Windows.Forms.Label LBL_ROOMDESC;
        private System.Windows.Forms.Label LBL_PLAYER_COORDS;
        private System.Windows.Forms.Label LBL_CAMERAS;
        private System.Windows.Forms.Label LBL_PLDSELECT;
        private System.Windows.Forms.ComboBox PLD_SELECTOR;
        private System.Windows.Forms.Label LBL_RID01;
        private System.Windows.Forms.Label LBL_RID00;
        private System.Windows.Forms.Label LBL_POSR;
        private System.Windows.Forms.Label LBL_POSY;
        private System.Windows.Forms.Label LBL_POSX;
        private System.Windows.Forms.Label LBL_POSZ;
        private System.Windows.Forms.Label LBL_CAMID01;
        private System.Windows.Forms.GroupBox MemoryGroup00;
        private System.Windows.Forms.Button BTN_HOOK;
        private System.Windows.Forms.PictureBox STATUS_IMAGE;
        private System.Windows.Forms.PictureBox PLAYER_IMAGE;
        private System.Windows.Forms.PictureBox WPN_IMAGE;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel LBL_IGT;
        private System.Windows.Forms.Label LBL_HP;
        public System.Windows.Forms.Timer TIMER_HOOK;
        public System.Windows.Forms.Timer TIMER_ECG;
        private System.Windows.Forms.Label LBL_AMMO;
        private System.Windows.Forms.Button BTN_INVO;
        private System.Windows.Forms.Label LBL_WPNEQUIP;
        private System.Windows.Forms.Button BTN_ROOM_DEBUG;
        private System.Windows.Forms.ToolStripMenuItem sCDToolStripMenuItem;
        private System.Windows.Forms.ToolBarButton TBTN_BIO3EXE;
        private System.Windows.Forms.ToolBarButton TBTN_BIO2_EXE;
        private System.Windows.Forms.PictureBox DefaultImage;
        private System.Windows.Forms.ToolBarButton TBTN_EXE;
        private System.Windows.Forms.ToolBarButton TBTN_HEX;
        private System.Windows.Forms.PictureBox IMAGE_BG_RENDER;
        private System.Windows.Forms.ToolStripButton SCD_BUTTON_REPACK;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip OPCODE_MENU;
        private System.Windows.Forms.ToolStripMenuItem insertOpcodeToolStripMenuItem;
        private System.Windows.Forms.PictureBox IMAGE_BG_RENDER_RDT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolBarButton TBTN_MSG;
    }
}

