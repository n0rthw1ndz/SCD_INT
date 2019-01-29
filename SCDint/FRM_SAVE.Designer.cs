namespace SCDint
{
    partial class FRM_SAVE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_SAVE));
            this.SAVE_CONTROL = new System.Windows.Forms.TabControl();
            this.TAB_BIO2_SV = new System.Windows.Forms.TabPage();
            this.TAB_BIO3_SV = new System.Windows.Forms.TabPage();
            this.Icon_List = new System.Windows.Forms.ImageList(this.components);
            this.BTN_SAVEGAME = new System.Windows.Forms.Button();
            this.SAVE_CONTROL.SuspendLayout();
            this.TAB_BIO2_SV.SuspendLayout();
            this.SuspendLayout();
            // 
            // SAVE_CONTROL
            // 
            this.SAVE_CONTROL.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.SAVE_CONTROL.Controls.Add(this.TAB_BIO2_SV);
            this.SAVE_CONTROL.Controls.Add(this.TAB_BIO3_SV);
            this.SAVE_CONTROL.Location = new System.Drawing.Point(0, 0);
            this.SAVE_CONTROL.Name = "SAVE_CONTROL";
            this.SAVE_CONTROL.SelectedIndex = 0;
            this.SAVE_CONTROL.Size = new System.Drawing.Size(283, 260);
            this.SAVE_CONTROL.TabIndex = 0;
            // 
            // TAB_BIO2_SV
            // 
            this.TAB_BIO2_SV.Controls.Add(this.BTN_SAVEGAME);
            this.TAB_BIO2_SV.Location = new System.Drawing.Point(4, 4);
            this.TAB_BIO2_SV.Name = "TAB_BIO2_SV";
            this.TAB_BIO2_SV.Padding = new System.Windows.Forms.Padding(3);
            this.TAB_BIO2_SV.Size = new System.Drawing.Size(275, 234);
            this.TAB_BIO2_SV.TabIndex = 0;
            this.TAB_BIO2_SV.Text = "BIO2 SAVE DATA";
            this.TAB_BIO2_SV.UseVisualStyleBackColor = true;
            // 
            // TAB_BIO3_SV
            // 
            this.TAB_BIO3_SV.Location = new System.Drawing.Point(4, 4);
            this.TAB_BIO3_SV.Name = "TAB_BIO3_SV";
            this.TAB_BIO3_SV.Padding = new System.Windows.Forms.Padding(3);
            this.TAB_BIO3_SV.Size = new System.Drawing.Size(275, 234);
            this.TAB_BIO3_SV.TabIndex = 1;
            this.TAB_BIO3_SV.Text = "BIO3 SAVE DATA";
            this.TAB_BIO3_SV.UseVisualStyleBackColor = true;
            // 
            // Icon_List
            // 
            this.Icon_List.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.Icon_List.ImageSize = new System.Drawing.Size(16, 16);
            this.Icon_List.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // BTN_SAVEGAME
            // 
            this.BTN_SAVEGAME.Font = new System.Drawing.Font("Wasco Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_SAVEGAME.Location = new System.Drawing.Point(46, 154);
            this.BTN_SAVEGAME.Name = "BTN_SAVEGAME";
            this.BTN_SAVEGAME.Size = new System.Drawing.Size(167, 63);
            this.BTN_SAVEGAME.TabIndex = 1;
            this.BTN_SAVEGAME.Text = "SAVE ANYWHERE";
            this.BTN_SAVEGAME.UseVisualStyleBackColor = true;
            this.BTN_SAVEGAME.Click += new System.EventHandler(this.BTN_SAVEGAME_Click);
            // 
            // FRM_SAVE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.SAVE_CONTROL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_SAVE";
            this.Text = "SAVE EDIT";
            this.SAVE_CONTROL.ResumeLayout(false);
            this.TAB_BIO2_SV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl SAVE_CONTROL;
        private System.Windows.Forms.TabPage TAB_BIO2_SV;
        private System.Windows.Forms.TabPage TAB_BIO3_SV;
        private System.Windows.Forms.ImageList Icon_List;
        private System.Windows.Forms.Button BTN_SAVEGAME;
    }
}