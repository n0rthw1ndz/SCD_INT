namespace SCDint
{
    partial class FRM_SCD_EDIT
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCompileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LB_OP_SUGGEST = new System.Windows.Forms.ListBox();
            this.scintilla1 = new ScintillaNET.Scintilla();
            this.numberedRTB1 = new AboControls.UserControls.NumberedRTB();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem,
            this.configToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1403, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveCompileToolStripMenuItem});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveCompileToolStripMenuItem
            // 
            this.saveCompileToolStripMenuItem.Name = "saveCompileToolStripMenuItem";
            this.saveCompileToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveCompileToolStripMenuItem.Text = "Save/Compile";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // LB_OP_SUGGEST
            // 
            this.LB_OP_SUGGEST.FormattingEnabled = true;
            this.LB_OP_SUGGEST.Location = new System.Drawing.Point(139, 76);
            this.LB_OP_SUGGEST.Name = "LB_OP_SUGGEST";
            this.LB_OP_SUGGEST.Size = new System.Drawing.Size(256, 147);
            this.LB_OP_SUGGEST.TabIndex = 3;
            // 
            // scintilla1
            // 
            this.scintilla1.Location = new System.Drawing.Point(32, 30);
            this.scintilla1.Name = "scintilla1";
            this.scintilla1.Size = new System.Drawing.Size(1337, 732);
            this.scintilla1.TabIndex = 4;
            this.scintilla1.Text = "scintilla1";
            this.scintilla1.TextChanged += new System.EventHandler(this.scintilla1_TextChanged);
            // 
            // numberedRTB1
            // 
            this.numberedRTB1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.numberedRTB1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.numberedRTB1.Font = new System.Drawing.Font("Wasco Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberedRTB1.Location = new System.Drawing.Point(16, 30);
            this.numberedRTB1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.numberedRTB1.Name = "numberedRTB1";
            this.numberedRTB1.Size = new System.Drawing.Size(1371, 744);
            this.numberedRTB1.TabIndex = 2;
            this.numberedRTB1.Visible = false;
            this.numberedRTB1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numberedRTB1_KeyDown);
            this.numberedRTB1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberedRTB1_KeyPress);
            this.numberedRTB1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numberedRTB1_MouseClick);
            // 
            // FRM_SCD_EDIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 860);
            this.Controls.Add(this.scintilla1);
            this.Controls.Add(this.LB_OP_SUGGEST);
            this.Controls.Add(this.numberedRTB1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FRM_SCD_EDIT";
            this.Text = "FRM_SCD_EDIT";
            this.Load += new System.EventHandler(this.FRM_SCD_EDIT_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCompileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private AboControls.UserControls.NumberedRTB numberedRTB1;
        private System.Windows.Forms.ListBox LB_OP_SUGGEST;
        private ScintillaNET.Scintilla scintilla1;
    }
}