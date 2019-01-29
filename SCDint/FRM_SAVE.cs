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
    public partial class FRM_SAVE : Form
    {
        public FRM_SAVE()
        {
            InitializeComponent();
        }

        private void BTN_SAVEGAME_Click(object sender, EventArgs e)
        {
            string fname = "PL" + LIB_MEMORY.MEM_SAVE.PLD.ToString() + "_" + "ROOM" + (LIB_MEMORY.MEM_SAVE.Stage + 1).ToString() + LIB_MEMORY.MEM_SAVE.Room.ToString("X").PadLeft(2, '0') + LIB_MEMORY.MEM_SAVE.Player.ToString() + ".BIOHAZARD2";

            LIB_MEMORY.BIO2_EXE_SAVE_ANYWHERE(LIB_MEMORY.DATA_HOOK.Hooked_Process, "C:\\Users\\Dchaps\\Desktop\\" + fname);
        }
    }
}
