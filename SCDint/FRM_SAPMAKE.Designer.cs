namespace SCDint
{
    partial class FRM_SAPMAKE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_SAPMAKE));
            this.driveListBox2 = new Microsoft.VisualBasic.Compatibility.VB6.DriveListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileListBox1 = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
            this.dirListBox1 = new Microsoft.VisualBasic.Compatibility.VB6.DirListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fileListBox2 = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
            this.dirListBox2 = new Microsoft.VisualBasic.Compatibility.VB6.DirListBox();
            this.driveListBox1 = new Microsoft.VisualBasic.Compatibility.VB6.DriveListBox();
            this.BTN_MAKESAP = new System.Windows.Forms.Button();
            this.SAP_PROGRESS = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // driveListBox2
            // 
            this.driveListBox2.FormattingEnabled = true;
            this.driveListBox2.Location = new System.Drawing.Point(6, 19);
            this.driveListBox2.Name = "driveListBox2";
            this.driveListBox2.Size = new System.Drawing.Size(296, 21);
            this.driveListBox2.TabIndex = 1;
            this.driveListBox2.SelectedIndexChanged += new System.EventHandler(this.driveListBox2_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.fileListBox1);
            this.groupBox1.Controls.Add(this.dirListBox1);
            this.groupBox1.Controls.Add(this.driveListBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 323);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Original .SAP";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(6, 329);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 67);
            this.panel1.TabIndex = 5;
            // 
            // fileListBox1
            // 
            this.fileListBox1.FormattingEnabled = true;
            this.fileListBox1.Location = new System.Drawing.Point(163, 62);
            this.fileListBox1.Name = "fileListBox1";
            this.fileListBox1.Pattern = "*.*";
            this.fileListBox1.Size = new System.Drawing.Size(120, 251);
            this.fileListBox1.TabIndex = 4;
            // 
            // dirListBox1
            // 
            this.dirListBox1.FormattingEnabled = true;
            this.dirListBox1.IntegralHeight = false;
            this.dirListBox1.Location = new System.Drawing.Point(6, 62);
            this.dirListBox1.Name = "dirListBox1";
            this.dirListBox1.Size = new System.Drawing.Size(151, 251);
            this.dirListBox1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fileListBox2);
            this.groupBox2.Controls.Add(this.dirListBox2);
            this.groupBox2.Controls.Add(this.driveListBox1);
            this.groupBox2.Location = new System.Drawing.Point(345, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 323);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wav Directory";
            // 
            // fileListBox2
            // 
            this.fileListBox2.FormattingEnabled = true;
            this.fileListBox2.Location = new System.Drawing.Point(163, 62);
            this.fileListBox2.Name = "fileListBox2";
            this.fileListBox2.Pattern = "*.*";
            this.fileListBox2.Size = new System.Drawing.Size(120, 251);
            this.fileListBox2.TabIndex = 4;
            // 
            // dirListBox2
            // 
            this.dirListBox2.FormattingEnabled = true;
            this.dirListBox2.IntegralHeight = false;
            this.dirListBox2.Location = new System.Drawing.Point(6, 62);
            this.dirListBox2.Name = "dirListBox2";
            this.dirListBox2.Size = new System.Drawing.Size(151, 251);
            this.dirListBox2.TabIndex = 3;
            // 
            // driveListBox1
            // 
            this.driveListBox1.FormattingEnabled = true;
            this.driveListBox1.Location = new System.Drawing.Point(6, 19);
            this.driveListBox1.Name = "driveListBox1";
            this.driveListBox1.Size = new System.Drawing.Size(296, 21);
            this.driveListBox1.TabIndex = 1;
            // 
            // BTN_MAKESAP
            // 
            this.BTN_MAKESAP.Location = new System.Drawing.Point(265, 343);
            this.BTN_MAKESAP.Name = "BTN_MAKESAP";
            this.BTN_MAKESAP.Size = new System.Drawing.Size(152, 23);
            this.BTN_MAKESAP.TabIndex = 4;
            this.BTN_MAKESAP.Text = "Make .SAP";
            this.BTN_MAKESAP.UseVisualStyleBackColor = true;
            this.BTN_MAKESAP.Click += new System.EventHandler(this.BTN_MAKESAP_Click);
            // 
            // SAP_PROGRESS
            // 
            this.SAP_PROGRESS.Location = new System.Drawing.Point(41, 372);
            this.SAP_PROGRESS.Name = "SAP_PROGRESS";
            this.SAP_PROGRESS.Size = new System.Drawing.Size(587, 23);
            this.SAP_PROGRESS.TabIndex = 5;
            // 
            // FRM_SAPMAKE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 407);
            this.Controls.Add(this.SAP_PROGRESS);
            this.Controls.Add(this.BTN_MAKESAP);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_SAPMAKE";
            this.Text = "FRM_SAPMAKE";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.VisualBasic.Compatibility.VB6.DriveListBox driveListBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.VisualBasic.Compatibility.VB6.FileListBox fileListBox1;
        private Microsoft.VisualBasic.Compatibility.VB6.DirListBox dirListBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.VisualBasic.Compatibility.VB6.FileListBox fileListBox2;
        private Microsoft.VisualBasic.Compatibility.VB6.DirListBox dirListBox2;
        private Microsoft.VisualBasic.Compatibility.VB6.DriveListBox driveListBox1;
        private System.Windows.Forms.Button BTN_MAKESAP;
        private System.Windows.Forms.ProgressBar SAP_PROGRESS;
    }
}