using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScintillaNET;

namespace SCDint
{
    public partial class FRM_SCD_EDIT : Form
    {

        public bool Suggestion;

        public FRM_SCD_EDIT()
        {
            InitializeComponent();

            numberedRTB1.RichTextBox.BackColor = Color.Black;
            numberedRTB1.RichTextBox.ForeColor = Color.PaleGoldenrod;
            numberedRTB1.RichTextBox.Font = numberedRTB1.Font;

            //            numberedRTB1.RichTextBox.AppendText("\n" + LIB_RDT.Current_SCD_Lines);
            LB_OP_SUGGEST.Hide();

            Suggestion = false;
            scintilla1.Margins[0].Width = 16;
            
        
         

        }

        private void numberedRTB1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Alt)
            {
                MessageBox.Show("alt pressed");
            }
        }

        private void FRM_SCD_EDIT_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < LIB_RDT.Current_SCD_Lines.Length; i++)
            {
                numberedRTB1.RichTextBox.AppendText("\n" + LIB_RDT.Current_SCD_Lines[i]);
            }

           

        }

        private void numberedRTB1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'f')
            {
                Suggestion = true;
                LB_OP_SUGGEST.Show();
                MessageBox.Show("t");
            }
        }

        private void numberedRTB1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                LB_OP_SUGGEST.Show();
            }
        }

        private void scintilla1_TextChanged(object sender, EventArgs e)
        {
            int maxLines = scintilla1.Lines.Count;

            if (maxLines >= 100)
            {
                
            }

        }
    }
}
