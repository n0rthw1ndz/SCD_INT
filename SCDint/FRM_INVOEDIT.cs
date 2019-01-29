using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SCDint
{
    public partial class FRM_INVOEDIT : Form
    {
        


        public ComboBox[] ITEM_SLOTS = new ComboBox[10];
        public NumericUpDown[] QUAN_SLOTS = new NumericUpDown[10];
        public PictureBox[] ITEM_IMAGES = new PictureBox[10];
        public HOOKED_GAME_OBJ HOOKED_DATA = new HOOKED_GAME_OBJ();
        public Process[] procs;
        public Process theproc;
        

        public FRM_INVOEDIT()
        {
            InitializeComponent();

            ITEM_SLOTS[0] = Slot01_Box;
            ITEM_SLOTS[1] = Slot02_Box;
            ITEM_SLOTS[2] = Slot03_Box;
            ITEM_SLOTS[3] = Slot04_Box;
            ITEM_SLOTS[4] = Slot05_Box;
            ITEM_SLOTS[5] = Slot06_Box;
            ITEM_SLOTS[6] = Slot07_Box;
            ITEM_SLOTS[7] = Slot08_Box;
            ITEM_SLOTS[8] = Slot09_Box;
            ITEM_SLOTS[9] = Slot10_Box;

            QUAN_SLOTS[0] = Slot01_Quantity;
            QUAN_SLOTS[1] = Slot02_Quantity;
            QUAN_SLOTS[2] = Slot03_Quantity;
            QUAN_SLOTS[3] = Slot04_Quantity;
            QUAN_SLOTS[4] = Slot05_Quantity;
            QUAN_SLOTS[5] = Slot06_Quantity;
            QUAN_SLOTS[6] = Slot07_Quantity;
            QUAN_SLOTS[7] = Slot08_Quantity;
            QUAN_SLOTS[8] = Slot09_Quantity;
            QUAN_SLOTS[9] = Slot10_Quantity;



            ITEM_IMAGES[0] = Slot01_IMG;
            ITEM_IMAGES[1] = Slot02_IMG;
            ITEM_IMAGES[2] = Slot03_IMG;
            ITEM_IMAGES[3] = Slot04_IMG;
            ITEM_IMAGES[4] = Slot05_IMG;
            ITEM_IMAGES[5] = Slot06_IMG;
            ITEM_IMAGES[6] = Slot07_IMG;
            ITEM_IMAGES[7] = Slot08_IMG;
            ITEM_IMAGES[8] = Slot09_IMG;
            ITEM_IMAGES[9] = Slot10_IMG;
            
            

            //MessageBox.Show()

            /// if bio2 then populate bio2 item list..
            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0)
            {
                foreach (ComboBox slot in ITEM_SLOTS)
                {
                    foreach (string item_name in LIB_ITEM.BIO2_ITEM_LUT.Values)
                    {
                        slot.Items.Add(item_name);
                    }

                }

                

            }


            /// IF BIO3 MK OR EA CHINA .. POPULATE ITEM LISTS
            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3 || LIB_MEMORY.DATA_HOOK.G_FLAG == 5)
            {
                foreach (ComboBox slot in ITEM_SLOTS)
                {
                    foreach (string item_name in LIB_ITEM.BIO3_ITEM_LUT.Values)
                    {
                        slot.Items.Add(item_name);
                    }
                }
            }

          
            
        }

     


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void FRM_INVOEDIT_Load(object sender, EventArgs e)
        {
            procs = Process.GetProcessesByName(LIB_MEMORY.DATA_HOOK.Process_Name);
            if (procs.Length == 0 || procs == null)
            {
                return;
            }
            LIB_MEMORY.DATA_HOOK.Hooked_Process = procs[0];

            
            
            // if bio2..
            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0)
            {
                // loop through item slots
                for (int i = 0; i < ITEM_SLOTS.Length; i++)
                {
                    // if item look up contains indexed slot ID
                    if (LIB_ITEM.BIO2_ITEM_LUT.ContainsKey(LIB_MEMORY.EXE_INVO[i].WEAPON_ID))
                    {
                        // set each combo boxes selected item to the match/populate quantity for each slot
                        ITEM_SLOTS[i].SelectedItem = LIB_ITEM.BIO2_ITEM_LUT[LIB_MEMORY.EXE_INVO[i].WEAPON_ID];
                        
                        // assign indexed slot image to file
                        ITEM_IMAGES[i].Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\ARMS\\" + LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[i].SelectedItem.ToString()] + ".png");
                        QUAN_SLOTS[i].Value = LIB_MEMORY.EXE_INVO[i].AMMO_COUNT;
                        
                    }
                    
                }

                


                /// sset side pack state on load..
                if (LIB_MEMORY.EXE_PLAYER.SIDEPACK_FLAG == 10)
                {
                    Sidepack_Check.CheckState = CheckState.Checked;
                }
                else if (LIB_MEMORY.EXE_PLAYER.SIDEPACK_FLAG == 8)
                {
                    Sidepack_Check.CheckState = CheckState.Unchecked;
                }
               
            }

            
            // if BIO3 MK OR EA CHINA..
            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3 || LIB_MEMORY.DATA_HOOK.G_FLAG == 5)
            {
                for (int i = 0; i < ITEM_SLOTS.Length; i++)
                {
                    if (LIB_ITEM.BIO3_ITEM_LUT.ContainsKey(LIB_MEMORY.EXE_INVO[i].WEAPON_ID))
                    {
                        ITEM_SLOTS[i].SelectedItem = LIB_ITEM.BIO3_ITEM_LUT[LIB_MEMORY.EXE_INVO[i].WEAPON_ID];                      
                        ITEM_IMAGES[i].Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\BIO3_ARMS\\" + LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[i].SelectedItem.ToString()] + ".png");
                        QUAN_SLOTS[i].Value = LIB_MEMORY.EXE_INVO[i].AMMO_COUNT;
                    }
                }

            }

        }

        private void BTN_INVO_CLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_INVO_APPLY_Click(object sender, EventArgs e)
        {

            //var proc = Process.GetProcessesByName(LIB_MEMORY.DATA_HOOK.Process_Name);
            //if (proc == null || proc.Length == 0)
            //{
            //    return;
            //}
            //LIB_MEMORY.DATA_HOOK.Hooked_Process = proc[0];

            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0)
            {
                LIB_MEMORY.BIO2_EXE_UPDATE_INVO(LIB_MEMORY.DATA_HOOK.Hooked_Process, ITEM_SLOTS, QUAN_SLOTS);
            }


            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3 || LIB_MEMORY.DATA_HOOK.G_FLAG == 5)
            {
                LIB_MEMORY.BIO3_EXE_UPDATE_INVO(LIB_MEMORY.DATA_HOOK.Hooked_Process, ITEM_SLOTS, QUAN_SLOTS);
            }
            
        }

        private void Invo_Checkbox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
           
        }

        private void Sidepack_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (Sidepack_Check.Checked == true)
            {
                LIB_MEMORY.BIO2_EXE_SIDEPACK(LIB_MEMORY.DATA_HOOK.Hooked_Process, true);
                LBL_Slot08.BackColor = Color.White;
                ITEM_SLOTS[8].BackColor = Color.White;
                QUAN_SLOTS[8].BackColor = Color.White;
                ITEM_SLOTS[9].BackColor = Color.White;
                QUAN_SLOTS[9].BackColor = Color.White;


            }
            else
            {
                LIB_MEMORY.BIO2_EXE_SIDEPACK(LIB_MEMORY.DATA_HOOK.Hooked_Process, false);
                ITEM_SLOTS[8].BackColor = Color.Red;
                QUAN_SLOTS[8].BackColor = Color.Red;
                ITEM_SLOTS[9].BackColor = Color.Red;
                QUAN_SLOTS[9].BackColor = Color.Red;

            }



        }

        private void Infinite_Ammo_CheckStateChanged(object sender, EventArgs e)
        {
            if (e.Equals(CheckState.Checked))
            {
                MessageBox.Show("test");
            }
        }

        private void INVO_TABLE_Paint(object sender, PaintEventArgs e)
        {

        }

        
        
        /// <summary>
        /// Bio2 only needs this since bio3 doesent have double slotted items
        /// </summary>
        /// <param name="Sel_Id"></param>
        /// <param name="target_index"></param>
        private void Weapon_Helper(byte Sel_Id, byte target_index)
        {
            switch (Sel_Id)
            {
                case 0x0F: ITEM_SLOTS[target_index].SelectedItem = LIB_ITEM.BIO2_ITEM_LUT[0x65]; ITEM_IMAGES[target_index].Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\ARMS\\" + 101 + ".png"); break;
                case 0x10: ITEM_SLOTS[target_index].SelectedItem = LIB_ITEM.BIO2_ITEM_LUT[0x66]; ITEM_IMAGES[target_index].Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\ARMS\\" + 102 + ".png"); break;
                case 0x11: ITEM_SLOTS[target_index].SelectedItem = LIB_ITEM.BIO2_ITEM_LUT[0x67]; ITEM_IMAGES[target_index].Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\ARMS\\" + 103 + ".png"); break;
                case 0x12: ITEM_SLOTS[target_index].SelectedItem = LIB_ITEM.BIO2_ITEM_LUT[0x68]; ITEM_IMAGES[target_index].Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\ARMS\\" + 104 + ".png"); break;

            }
        }


        private void Slot01_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Slot01_Box_SelectionChangeCommitted(object sender, EventArgs e)
        {

            int idx = Slot01_Box.SelectedIndex;


            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0)
            {
                Slot01_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\ARMS\\" + LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[0].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[0].SelectedItem.ToString()];
                Weapon_Helper(Sel_Item_ID, 1);
            }

            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3)
            {
                Slot01_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\BIO3_ICONS\\" + LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[0].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[0].SelectedItem.ToString()];

            }
            
          
            

        }
        


        private void Slot02_Box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idx = Slot01_Box.SelectedIndex;


            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0)
            {
                Slot02_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\ARMS\\" + LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[1].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[1].SelectedItem.ToString()];
                Weapon_Helper(Sel_Item_ID, 2);
            }

            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3)
            {
                Slot02_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\BIO3_ICONS\\" + LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[1].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[1].SelectedItem.ToString()];

            }

        }



        private void Infinite_Ammo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Slot03_Box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idx = Slot01_Box.SelectedIndex;


            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0)
            {
                Slot03_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\ARMS\\" + LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[2].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[2].SelectedItem.ToString()];
                Weapon_Helper(Sel_Item_ID, 3);
            }

            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3)
            {
                Slot03_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\BIO3_ARMS\\" + LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[2].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[2].SelectedItem.ToString()];

            }
        }

        private void Slot04_Box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0)
            {
                Slot04_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\ARMS\\" + LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[3].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[3].SelectedItem.ToString()];
                Weapon_Helper(Sel_Item_ID, 5);
            }

            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3)
            {
                Slot04_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\BIO3_ARMS\\" + LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[3].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[3].SelectedItem.ToString()];

            }
        }

        private void Slot05_Box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0)
            {
                Slot05_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\ARMS\\" + LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[4].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[4].SelectedItem.ToString()];
                Weapon_Helper(Sel_Item_ID, 5);
            }

            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3)
            {
                Slot05_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\BIO3_ARMS\\" + LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[4].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[4].SelectedItem.ToString()];

            }
        }

        private void Slot06_Box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0)
            {
                Slot06_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\ARMS\\" + LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[5].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[5].SelectedItem.ToString()];
                Weapon_Helper(Sel_Item_ID, 6);
            }

            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3)
            {
                Slot06_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\BIO3_ARMS\\" + LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[5].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[5].SelectedItem.ToString()];

            }

        }

        private void Slot07_Box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0)
            {
                Slot07_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\ARMS\\" + LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[6].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[6].SelectedItem.ToString()];
                Weapon_Helper(Sel_Item_ID, 7);
            }

            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3)
            {
                Slot07_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\BIO3_ARMS\\" + LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[6].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[6].SelectedItem.ToString()];

            }
        }

        private void Slot08_Box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0)
            {
                Slot08_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\ARMS\\" + LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[7].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[7].SelectedItem.ToString()];
                Weapon_Helper(Sel_Item_ID, 8);
            }

            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3)
            {
                Slot08_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\BIO3_ARMS\\" + LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[7].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[7].SelectedItem.ToString()];

            }
        }

        private void Slot09_Box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0)
            {
                Slot09_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\ARMS\\" + LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[8].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[8].SelectedItem.ToString()];
                Weapon_Helper(Sel_Item_ID, 9);
            }

            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3)
            {
                Slot09_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\BIO3_ARMS\\" + LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[8].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[8].SelectedItem.ToString()];

            }
        }

        private void Slot10_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0)
            {
                Slot10_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\ARMS\\" + LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[9].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[9].SelectedItem.ToString()];
                Weapon_Helper(Sel_Item_ID, 10);
            }

            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3)
            {
                Slot10_IMG.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\BIO3_ARMS\\" + LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[9].SelectedItem.ToString()] + ".png");
                byte Sel_Item_ID = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[9].SelectedItem.ToString()];

            }
        }
    }
}
