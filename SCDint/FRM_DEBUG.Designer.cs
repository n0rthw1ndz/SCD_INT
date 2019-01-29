namespace SCDint
{
    partial class FRM_DEBUG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_DEBUG));
            this.Debug_Log = new System.Windows.Forms.RichTextBox();
            this.LV_RDT = new System.Windows.Forms.ListView();
            this.lv_rdtclm_idx = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_rdtclm_desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_rdtclm_offset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RDT_IO_MENU = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.unpackAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unpackSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RDT_IO_MENU.SuspendLayout();
            this.SuspendLayout();
            // 
            // Debug_Log
            // 
            this.Debug_Log.BackColor = System.Drawing.SystemColors.WindowText;
            this.Debug_Log.Font = new System.Drawing.Font("DejaVu Sans Mono", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Debug_Log.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Debug_Log.Location = new System.Drawing.Point(250, 12);
            this.Debug_Log.Name = "Debug_Log";
            this.Debug_Log.Size = new System.Drawing.Size(549, 449);
            this.Debug_Log.TabIndex = 0;
            this.Debug_Log.Text = "";
            // 
            // LV_RDT
            // 
            this.LV_RDT.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv_rdtclm_idx,
            this.lv_rdtclm_desc,
            this.lv_rdtclm_offset});
            this.LV_RDT.ContextMenuStrip = this.RDT_IO_MENU;
            this.LV_RDT.FullRowSelect = true;
            this.LV_RDT.GridLines = true;
            this.LV_RDT.Location = new System.Drawing.Point(12, 12);
            this.LV_RDT.Name = "LV_RDT";
            this.LV_RDT.Size = new System.Drawing.Size(232, 449);
            this.LV_RDT.TabIndex = 1;
            this.LV_RDT.UseCompatibleStateImageBehavior = false;
            this.LV_RDT.View = System.Windows.Forms.View.Details;
            // 
            // lv_rdtclm_idx
            // 
            this.lv_rdtclm_idx.Text = "Index";
            // 
            // lv_rdtclm_desc
            // 
            this.lv_rdtclm_desc.Text = "Description";
            this.lv_rdtclm_desc.Width = 98;
            // 
            // lv_rdtclm_offset
            // 
            this.lv_rdtclm_offset.Text = "Offset";
            // 
            // RDT_IO_MENU
            // 
            this.RDT_IO_MENU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unpackAllToolStripMenuItem,
            this.unpackSelectedToolStripMenuItem,
            this.repackToolStripMenuItem});
            this.RDT_IO_MENU.Name = "RDT_IO_MENU";
            this.RDT_IO_MENU.Size = new System.Drawing.Size(162, 70);
            // 
            // unpackAllToolStripMenuItem
            // 
            this.unpackAllToolStripMenuItem.Name = "unpackAllToolStripMenuItem";
            this.unpackAllToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.unpackAllToolStripMenuItem.Text = "Unpack All";
            // 
            // unpackSelectedToolStripMenuItem
            // 
            this.unpackSelectedToolStripMenuItem.Name = "unpackSelectedToolStripMenuItem";
            this.unpackSelectedToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.unpackSelectedToolStripMenuItem.Text = "Unpack Selected";
            this.unpackSelectedToolStripMenuItem.Click += new System.EventHandler(this.unpackSelectedToolStripMenuItem_Click);
            // 
            // repackToolStripMenuItem
            // 
            this.repackToolStripMenuItem.Name = "repackToolStripMenuItem";
            this.repackToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.repackToolStripMenuItem.Text = "Repack";
            // 
            // FRM_DEBUG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 473);
            this.Controls.Add(this.LV_RDT);
            this.Controls.Add(this.Debug_Log);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_DEBUG";
            this.Text = "FRM_DEBUG";
            this.RDT_IO_MENU.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox Debug_Log;
        public System.Windows.Forms.ListView LV_RDT;
        private System.Windows.Forms.ColumnHeader lv_rdtclm_idx;
        private System.Windows.Forms.ColumnHeader lv_rdtclm_desc;
        private System.Windows.Forms.ColumnHeader lv_rdtclm_offset;
        private System.Windows.Forms.ContextMenuStrip RDT_IO_MENU;
        private System.Windows.Forms.ToolStripMenuItem unpackAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unpackSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repackToolStripMenuItem;
    }
}