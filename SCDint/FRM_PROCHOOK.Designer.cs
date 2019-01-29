namespace SCDint
{
    partial class FRM_PROCHOOK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_PROCHOOK));
            this.LB_PROCLIST = new System.Windows.Forms.ListBox();
            this.BTN_HOOKGAME = new System.Windows.Forms.Button();
            this.Group_MemFunctions = new System.Windows.Forms.GroupBox();
            this.TIMER_PROC = new System.Windows.Forms.Timer(this.components);
            this.BTN_UNHOOK = new System.Windows.Forms.Button();
            this.Group_MemFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB_PROCLIST
            // 
            this.LB_PROCLIST.BackColor = System.Drawing.SystemColors.WindowText;
            this.LB_PROCLIST.Font = new System.Drawing.Font("DejaVu Serif Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_PROCLIST.ForeColor = System.Drawing.SystemColors.Window;
            this.LB_PROCLIST.FormattingEnabled = true;
            this.LB_PROCLIST.ItemHeight = 31;
            this.LB_PROCLIST.Location = new System.Drawing.Point(2, 8);
            this.LB_PROCLIST.Name = "LB_PROCLIST";
            this.LB_PROCLIST.Size = new System.Drawing.Size(204, 35);
            this.LB_PROCLIST.TabIndex = 0;
            // 
            // BTN_HOOKGAME
            // 
            this.BTN_HOOKGAME.BackColor = System.Drawing.SystemColors.Desktop;
            this.BTN_HOOKGAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_HOOKGAME.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTN_HOOKGAME.Image = ((System.Drawing.Image)(resources.GetObject("BTN_HOOKGAME.Image")));
            this.BTN_HOOKGAME.Location = new System.Drawing.Point(69, 19);
            this.BTN_HOOKGAME.Name = "BTN_HOOKGAME";
            this.BTN_HOOKGAME.Size = new System.Drawing.Size(58, 64);
            this.BTN_HOOKGAME.TabIndex = 1;
            this.BTN_HOOKGAME.Text = "Hook";
            this.BTN_HOOKGAME.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTN_HOOKGAME.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTN_HOOKGAME.UseVisualStyleBackColor = false;
            this.BTN_HOOKGAME.Click += new System.EventHandler(this.BTN_HOOKGAME_Click);
            // 
            // Group_MemFunctions
            // 
            this.Group_MemFunctions.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Group_MemFunctions.Controls.Add(this.BTN_UNHOOK);
            this.Group_MemFunctions.Controls.Add(this.BTN_HOOKGAME);
            this.Group_MemFunctions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Group_MemFunctions.Location = new System.Drawing.Point(2, 49);
            this.Group_MemFunctions.Name = "Group_MemFunctions";
            this.Group_MemFunctions.Size = new System.Drawing.Size(204, 148);
            this.Group_MemFunctions.TabIndex = 2;
            this.Group_MemFunctions.TabStop = false;
            // 
            // TIMER_PROC
            // 
            this.TIMER_PROC.Interval = 1;
            // 
            // BTN_UNHOOK
            // 
            this.BTN_UNHOOK.Location = new System.Drawing.Point(45, 122);
            this.BTN_UNHOOK.Name = "BTN_UNHOOK";
            this.BTN_UNHOOK.Size = new System.Drawing.Size(107, 23);
            this.BTN_UNHOOK.TabIndex = 3;
            this.BTN_UNHOOK.Text = "UNHOOK";
            this.BTN_UNHOOK.UseVisualStyleBackColor = true;
            this.BTN_UNHOOK.Click += new System.EventHandler(this.BTN_UNHOOK_Click);
            // 
            // FRM_PROCHOOK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 206);
            this.Controls.Add(this.Group_MemFunctions);
            this.Controls.Add(this.LB_PROCLIST);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_PROCHOOK";
            this.Text = "FRM_PROCHOOK";
            this.Load += new System.EventHandler(this.FRM_PROCHOOK_Load);
            this.Group_MemFunctions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LB_PROCLIST;
        private System.Windows.Forms.Button BTN_HOOKGAME;
        private System.Windows.Forms.GroupBox Group_MemFunctions;
        public System.Windows.Forms.Timer TIMER_PROC;
        private System.Windows.Forms.Button BTN_UNHOOK;
    }
}