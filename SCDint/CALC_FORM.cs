using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCDint
{
    public partial class CalcTest : Form
    {
        public CalcTest()
        {
            InitializeComponent();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is my fucking calculator you fucking bitch! ", "lol", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
