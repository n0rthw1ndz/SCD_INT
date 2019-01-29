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
    public partial class FRM_MSGEDIT : Form
    {

        LIB_RDT.MSG_BLK_OBJ MSG_BLK = new LIB_RDT.MSG_BLK_OBJ();
        LIB_RDT.MsgAot_Obj[] Msg_Obj = new LIB_RDT.MsgAot_Obj[0];

        public FRM_MSGEDIT()
        {
            InitializeComponent();

          


        }






   




        public void MSG_PARSE(string fp, int offset)
        {
            LV_MSGDATA.Items.Clear();
            string msgstr = string.Empty;

            using (FileStream fs = new FileStream(fp, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    fs.Seek(offset, SeekOrigin.Begin);

                    MSG_BLK.Total = br.ReadInt16();
                    MSG_BLK.Total /= 2;

                    fs.Seek(offset, SeekOrigin.Begin);

                    //resize ptrs to total
                    Array.Resize(ref MSG_BLK.Msg_Ptrs, MSG_BLK.Total);
                    Array.Resize(ref MSG_BLK.Msgs, MSG_BLK.Total);
                    Array.Resize(ref Msg_Obj, MSG_BLK.Total);

                    // loop through total and read ptrs
                    for (int i = 0; i < MSG_BLK.Total; i++)
                    {
                        MSG_BLK.Msg_Ptrs[i] = br.ReadInt16();
                        LV_MSGDATA.Items.Add(i.ToString());
                        LV_MSGBYTE.Items.Add(i.ToString());
                        LV_MSGDATA.Items[i].SubItems.Add("0x" + MSG_BLK.Msg_Ptrs[i].ToString("X"));
                        LV_MSGBYTE.Items[i].SubItems.Add("0x" + MSG_BLK.Msg_Ptrs[i].ToString("X"));

                    }

                    
                    for (int j = 0; j < MSG_BLK.Total; j++)
                    {
                        //  seek to each ptr
                        fs.Seek(offset + MSG_BLK.Msg_Ptrs[j] + 2, SeekOrigin.Begin);

                        int roff = offset + MSG_BLK.Msg_Ptrs[j];

                        LV_MSGDATA.Items[j].SubItems.Add(roff.ToString());
                        LV_MSGBYTE.Items[j].SubItems.Add(roff.ToString());

                        if (j != MSG_BLK.Total - 1)
                        {
                            Msg_Obj[j].msg_sz = MSG_BLK.Msg_Ptrs[j + 1] - MSG_BLK.Msg_Ptrs[j];
                          //  MessageBox.Show(Msg_Obj[j].msg_sz.ToString());
                        }
                        
                        
                     
                        //resize indexed msg byte array to ptr size
                        Array.Resize(ref Msg_Obj[j].Msg_Data, Msg_Obj[j].msg_sz);
                        //   byte[] data = new byte[MSG_BLK.Msg_Ptrs[j]];


                            for (int x = 0; x < Msg_Obj[j].msg_sz; x++)
                            {
                                //data[x] = br.ReadByte();
                                Msg_Obj[j].Msg_Data[x] = br.ReadByte();
                                if (LIB_MSG.LUT_CHARTBL.ContainsKey(Msg_Obj[j].Msg_Data[x]))
                                {
                                    //  msgstr += data[x].ToString("X");
                                    Msg_Obj[j].Msg += LIB_MSG.LUT_CHARTBL[Msg_Obj[j].Msg_Data[x]];
                                    Msg_Obj[j].bytestr += Msg_Obj[j].Msg_Data[x].ToString("X");

                                }
                            }

                        
                     

                    
                        
                        LV_MSGDATA.Items[j].SubItems.Add(Msg_Obj[j].Msg);
                        LV_MSGBYTE.Items[j].SubItems.Add(Msg_Obj[j].bytestr);
                        
                    }


               //     MessageBox.Show(Msg_Obj[0].Msg);

                    //for (int t = 0; t < MSG_BLK.Msgs.Length; t++)
                    //{

                    //    LV_MSGDATA.Items[t].SubItems.Add(MSG_BLK.Msgs[t]);
                    //}


                }
            }
        }

        private void FRM_MSGEDIT_Load(object sender, EventArgs e)
        {
            if (FRM_DEBUG.cur_file != string.Empty)
            {
                TSL_MSG_RDT.Text = FRM_DEBUG.cur_file;
                MSG_PARSE(FRM_DEBUG.cur_file, LIB_RDT.OFFSET_LIST[14]);
            }
            else
            {
                MessageBox.Show("No RDT LOADED YET DUDE!");
            }
            
          
        }

        private void LV_MSGDATA_SelectedIndexChanged(object sender, EventArgs e)
        {
            LV_MSGDATA.MultiSelect = false;

            MSGBOX_INPUT.Clear();

            if (LV_MSGDATA.SelectedItems.Count > 0)
            {
                int sel_idx = LV_MSGDATA.FocusedItem.Index;
                MSGBOX_INPUT.AppendText(LV_MSGDATA.Items[sel_idx].SubItems[3].Text);
            }


            

        }


       


    }







   


}
