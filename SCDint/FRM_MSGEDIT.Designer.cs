namespace SCDint
{
    partial class FRM_MSGEDIT
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
            this.LV_MSGDATA = new System.Windows.Forms.ListView();
            this.MSGBOX_INPUT = new System.Windows.Forms.RichTextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSL_MSG_RDT = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MSGBOX_OUTPUT = new System.Windows.Forms.RichTextBox();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LV_MSGBYTE = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LV_MSGDATA
            // 
            this.LV_MSGDATA.BackColor = System.Drawing.Color.AliceBlue;
            this.LV_MSGDATA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3});
            this.LV_MSGDATA.Font = new System.Drawing.Font("Wasco Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LV_MSGDATA.FullRowSelect = true;
            this.LV_MSGDATA.GridLines = true;
            this.LV_MSGDATA.Location = new System.Drawing.Point(3, 3);
            this.LV_MSGDATA.Name = "LV_MSGDATA";
            this.LV_MSGDATA.Size = new System.Drawing.Size(639, 544);
            this.LV_MSGDATA.TabIndex = 0;
            this.LV_MSGDATA.UseCompatibleStateImageBehavior = false;
            this.LV_MSGDATA.View = System.Windows.Forms.View.Details;
            this.LV_MSGDATA.SelectedIndexChanged += new System.EventHandler(this.LV_MSGDATA_SelectedIndexChanged);
            // 
            // MSGBOX_INPUT
            // 
            this.MSGBOX_INPUT.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.MSGBOX_INPUT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MSGBOX_INPUT.Font = new System.Drawing.Font("Wasco Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MSGBOX_INPUT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.MSGBOX_INPUT.Location = new System.Drawing.Point(3, 578);
            this.MSGBOX_INPUT.Name = "MSGBOX_INPUT";
            this.MSGBOX_INPUT.Size = new System.Drawing.Size(647, 129);
            this.MSGBOX_INPUT.TabIndex = 1;
            this.MSGBOX_INPUT.Text = "";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Index";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Offset";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Message";
            this.columnHeader3.Width = 517;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSL_MSG_RDT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 736);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1410, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSL_MSG_RDT
            // 
            this.TSL_MSG_RDT.Name = "TSL_MSG_RDT";
            this.TSL_MSG_RDT.Size = new System.Drawing.Size(86, 22);
            this.TSL_MSG_RDT.Text = "toolStripLabel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.114F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.886F));
            this.tableLayoutPanel1.Controls.Add(this.LV_MSGDATA, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.MSGBOX_OUTPUT, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.MSGBOX_INPUT, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LV_MSGBYTE, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.88732F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.11268F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1386, 710);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // MSGBOX_OUTPUT
            // 
            this.MSGBOX_OUTPUT.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.MSGBOX_OUTPUT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MSGBOX_OUTPUT.Font = new System.Drawing.Font("Wasco Sans", 14.25F, System.Drawing.FontStyle.Bold);
            this.MSGBOX_OUTPUT.Location = new System.Drawing.Point(656, 578);
            this.MSGBOX_OUTPUT.Name = "MSGBOX_OUTPUT";
            this.MSGBOX_OUTPUT.Size = new System.Drawing.Size(727, 129);
            this.MSGBOX_OUTPUT.TabIndex = 2;
            this.MSGBOX_OUTPUT.Text = "";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "R Off";
            this.columnHeader4.Width = 76;
            // 
            // LV_MSGBYTE
            // 
            this.LV_MSGBYTE.BackColor = System.Drawing.Color.AliceBlue;
            this.LV_MSGBYTE.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.LV_MSGBYTE.Font = new System.Drawing.Font("Wasco Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LV_MSGBYTE.FullRowSelect = true;
            this.LV_MSGBYTE.GridLines = true;
            this.LV_MSGBYTE.Location = new System.Drawing.Point(656, 3);
            this.LV_MSGBYTE.Name = "LV_MSGBYTE";
            this.LV_MSGBYTE.Size = new System.Drawing.Size(727, 544);
            this.LV_MSGBYTE.TabIndex = 3;
            this.LV_MSGBYTE.UseCompatibleStateImageBehavior = false;
            this.LV_MSGBYTE.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Index";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Offset";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "R Off";
            this.columnHeader7.Width = 76;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Message";
            this.columnHeader8.Width = 517;
            // 
            // FRM_MSGEDIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 761);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FRM_MSGEDIT";
            this.Text = "FRM_MSGEDIT";
            this.Load += new System.EventHandler(this.FRM_MSGEDIT_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LV_MSGDATA;
        private System.Windows.Forms.RichTextBox MSGBOX_INPUT;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel TSL_MSG_RDT;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox MSGBOX_OUTPUT;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView LV_MSGBYTE;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}