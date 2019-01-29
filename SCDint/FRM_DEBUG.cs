using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace SCDint
{
    public partial class FRM_DEBUG : Form
    {

        public static string cur_file = string.Empty;

        public FRM_DEBUG()
        {
            InitializeComponent();
        }

        private void unpackSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
            int sel_idx = LV_RDT.FocusedItem.Index;
            int sel_off = int.Parse(LV_RDT.Items[sel_idx].SubItems[2].Text);
            string sel_ex = LV_RDT.Items[sel_idx].SubItems[1].Text.Substring(LV_RDT.Items[sel_idx].SubItems[1].Text.Length - 4, 3);
            string sel_str = LV_RDT.Items[sel_idx].SubItems[1].Text;
            string cur_file_no_ext = cur_file.Substring(cur_file.Length - 8, 4);

            int[] LV_OFFS = new int[LV_RDT.Items.Count];
            byte[] barray = new byte[0];

            for (int i = 0; i < LV_OFFS.Length; i++)
            {
                LV_OFFS[i] = int.Parse(LV_RDT.Items[i].SubItems[2].Text);
            }

            Array.Sort(LV_OFFS);

           int next_off = Array.BinarySearch(LV_OFFS, sel_off);

            if (next_off >= 0)
            {
                Array.Resize(ref barray, LV_OFFS[next_off + 1] - sel_off);

                MessageBox.Show(LV_OFFS[next_off + 1].ToString());

                if (cur_file != string.Empty)
                {
                    using (var fs2 = new FileStream(cur_file, FileMode.Open))
                    {
                        using (BinaryReader br = new BinaryReader(fs2))
                        {
                            fs2.Seek(sel_off, SeekOrigin.Begin);

                            for (int i = 0; i < barray.Length; i++)
                            {
                                barray[i] = br.ReadByte();
                            }
                        }
                    }

              


                }


                MessageBox.Show(cur_file_no_ext.ToString());

                string outstr = AppDomain.CurrentDomain.BaseDirectory + "\\DUMPED\\R" + cur_file_no_ext + "_" + next_off + "_." + sel_ex; 
                   

                using (var ws = new FileStream(outstr, FileMode.Create))
                {
                    using (var bw = new BinaryWriter(ws))
                    {
                        ws.Seek(0, SeekOrigin.Begin);
                        bw.Write(barray, 0, barray.Length);
                    }


                }

            }



       




        }
    }
}
