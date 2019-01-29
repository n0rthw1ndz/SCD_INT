namespace SCDint
{
    partial class FRM_CALC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_CALC));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LBL_HEX = new System.Windows.Forms.Label();
            this.Dec_input = new System.Windows.Forms.TextBox();
            this.Hex_Input = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LBL_HEX);
            this.groupBox1.Controls.Add(this.Dec_input);
            this.groupBox1.Controls.Add(this.Hex_Input);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hex <> Decimal Conversion";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(319, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 43);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "DEC:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LBL_HEX
            // 
            this.LBL_HEX.Location = new System.Drawing.Point(6, 22);
            this.LBL_HEX.Name = "LBL_HEX";
            this.LBL_HEX.Size = new System.Drawing.Size(48, 23);
            this.LBL_HEX.TabIndex = 2;
            this.LBL_HEX.Text = "HEX:";
            // 
            // Dec_input
            // 
            this.Dec_input.Location = new System.Drawing.Point(60, 54);
            this.Dec_input.Name = "Dec_input";
            this.Dec_input.Size = new System.Drawing.Size(237, 20);
            this.Dec_input.TabIndex = 1;
            this.Dec_input.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Hex_Input
            // 
            this.Hex_Input.Location = new System.Drawing.Point(60, 19);
            this.Hex_Input.Name = "Hex_Input";
            this.Hex_Input.Size = new System.Drawing.Size(237, 20);
            this.Hex_Input.TabIndex = 0;
            this.Hex_Input.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FRM_CALC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(408, 115);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_CALC";
            this.Text = "Quick Calculator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBL_HEX;
        private System.Windows.Forms.TextBox Dec_input;
        private System.Windows.Forms.TextBox Hex_Input;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}