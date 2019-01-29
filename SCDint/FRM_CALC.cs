using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCDint
{
    public partial class FRM_CALC : Form
    {

        public Int32 hexval;
        public Int32 decval;

        public FRM_CALC()
        {
            InitializeComponent();
        }


        //dec input
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decval = int.Parse(Dec_input.Text);
                string hexval = decval.ToString("X");
                Hex_Input.Text = hexval;
            }
            catch
            {

            }

        }


        //hex input
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string hexval = Hex_Input.Text;
                decval = int.Parse(hexval, System.Globalization.NumberStyles.HexNumber);
                Dec_input.Text = decval.ToString();

            }

            catch
            {

            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
