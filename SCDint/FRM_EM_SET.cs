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
    public partial class FRM_EM_SET : Form
    {
        public FRM_EM_SET()
        {
            InitializeComponent();
           
         
        }

        private void FRM_EM_SET_Load(object sender, EventArgs e)
        {
            TB_BYTESTR.Text = LIB_RDT.Selected_ByteStr.ToString();
        }
    }
}
