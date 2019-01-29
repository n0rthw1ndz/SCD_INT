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
    public partial class FRM_EXE : Form
    {
        public FRM_EXE()
        {
            InitializeComponent();

          

        }

        private void FRM_EXE_Load(object sender, EventArgs e)
        {
            // clear list items aswell as focused items to prevent dupes and other bullshit..
            LST_ITEMDATA.Items.Clear();
            LST_ITEMDATA.SelectedItems.Clear();
            LST_Combo_Data.Items.Clear();
            LST_Combo_Data.SelectedItems.Clear();
            LST_PRIMARYITEM.Items.Clear();
            LST_SECONDARYITEM.Items.Clear();



            

            // populate item data..
            for (int i = 0; i < LIB_EXE.BIO3_ITEM_DATA.Length; i++)
            {
                LST_ITEMDATA.Items.Add(i.ToString("X"));

                if (LIB_ITEM.BIO3_ITEM_LUT.ContainsKey(byte.Parse(i.ToString())))
                {
                    LST_ITEMDATA.Items[i].SubItems.Add(LIB_ITEM.BIO3_ITEM_LUT[byte.Parse(i.ToString())].ToString());
                }
                
                LST_ITEMDATA.Items[i].SubItems.Add(LIB_EXE.BIO3_ITEM_DATA[i].Item_Type.ToString());
                LST_ITEMDATA.Items[i].SubItems.Add(LIB_EXE.BIO3_ITEM_DATA[i].Max_Quantity.ToString());
                LST_ITEMDATA.Items[i].SubItems.Add(LIB_EXE.BIO3_ITEM_DATA[i].Quest_Code.ToString());
                LST_ITEMDATA.Items[i].SubItems.Add(LIB_EXE.BIO3_ITEM_DATA[i].Display_Mode.ToString());
                
            }


            // populate combo data..
            for (int j = 0; j < LIB_EXE.BIO3_COMBO_ENTRIES.Length; j++)
            {
                LST_Combo_Data.Items.Add(j.ToString());
                LST_Combo_Data.Items[j].SubItems.Add(LIB_EXE.BIO3_COMBO_ENTRIES[j].ComboFunction.ToString());
                LST_Combo_Data.Items[j].SubItems.Add(LIB_ITEM.BIO3_ITEM_LUT[LIB_EXE.BIO3_COMBO_ENTRIES[j].Primary_Item].ToString());
                LST_Combo_Data.Items[j].SubItems.Add(LIB_ITEM.BIO3_ITEM_LUT[LIB_EXE.BIO3_COMBO_ENTRIES[j].Secondary_Item].ToString());
                LST_Combo_Data.Items[j].SubItems.Add(LIB_ITEM.BIO3_ITEM_LUT[LIB_EXE.BIO3_COMBO_ENTRIES[j].Result_Item].ToString());
                LST_Combo_Data.Items[j].SubItems.Add(LIB_EXE.BIO3_COMBO_ENTRIES[j].New_Quantity.ToString());             
            }


            // populate combo boxes with item list
            foreach (string item in LIB_ITEM.BIO3_ITEM_LUT.Values)
            {
                LST_PRIMARYITEM.Items.Add(item);
                LST_SECONDARYITEM.Items.Add(item);
                LST_RESULTITEM.Items.Add(item);
            }




            //******************************
            // ITEM DATA INIT
            //******************************
            Sel_Quantity.Maximum = 255;
            Sel_QuestCode.Maximum = 255;
            Sel_Idx.Maximum = 255;

            //******************************
            // COMBO DATA INIT
            // ****************************
            NUD_ResultQuantity.Maximum = 255;





        }


        /// <summary>
        ///  Item Data Seleted Index Set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LST_ITEMDATA_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (LST_ITEMDATA.SelectedItems.Count > 0 )
            {

                int sel_idx = LST_ITEMDATA.FocusedItem.Index;

                if (sel_idx <= 0x85)
                {
                    Image_SelectedItem.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\BIO3_ARMS\\" + sel_idx + ".png");


                    Sel_Idx.Value = sel_idx;
                    Sel_ItemType.SelectedIndex = int.Parse(LST_ITEMDATA.Items[sel_idx].SubItems[2].Text);
                    
                    Sel_Quantity.Value = int.Parse(LST_ITEMDATA.Items[sel_idx].SubItems[3].Text);
                    Sel_QuestCode.Value = int.Parse(LST_ITEMDATA.Items[sel_idx].SubItems[4].Text);
                    Sel_DisplayMode.SelectedIndex = Set_DisplayMode(int.Parse(LST_ITEMDATA.Items[sel_idx].SubItems[5].Text));
                }
             
               
              

            }


        }




        /// <summary>
        /// Combo Data selected Index Set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LST_Combo_Data_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (LST_Combo_Data.SelectedItems.Count > 0)
            {
                int sel_idx = LST_Combo_Data.FocusedItem.Index;
                Image Selected_Primary_Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\BIO3_ARMS\\" + LIB_EXE.BIO3_COMBO_ENTRIES[sel_idx].Primary_Item + ".png");
                Image Selected_Secondary_Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\BIO3_ARMS\\" + LIB_EXE.BIO3_COMBO_ENTRIES[sel_idx].Secondary_Item + ".png");
                Image Selected_Resulting_Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ECG\\BIO3_ARMS\\" + LIB_EXE.BIO3_COMBO_ENTRIES[sel_idx].Result_Item + ".png");

                Image_PrimaryItem.Image = Selected_Primary_Image;
                Image_SecondaryItem.Image = Selected_Secondary_Image;
                Image_ResultItem.Image = Selected_Resulting_Image;




                /// populate editor controls with selected index properties..
                LST_COMBOFUNCTION.SelectedIndex = int.Parse(LST_Combo_Data.Items[sel_idx].SubItems[1].Text);
                
                LST_PRIMARYITEM.SelectedIndex = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[LST_Combo_Data.Items[sel_idx].SubItems[2].Text];
                LST_SECONDARYITEM.SelectedIndex = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[LST_Combo_Data.Items[sel_idx].SubItems[3].Text];
                LST_RESULTITEM.SelectedIndex = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[LST_Combo_Data.Items[sel_idx].SubItems[4].Text];

                NUD_ResultQuantity.Value = int.Parse(LST_Combo_Data.Items[sel_idx].SubItems[5].Text);


            }

            

        }
        
        // 00 - No display
        //01 - Number: Green
        //03 - Percentage: Green
        //05 - Number: Red
        //22  - Percentage: Red

        //09 - Number: Yellow
        //18 - Percentage: Yellow
        //13 - Number: Blue
        //02 - Percentage:Blue
        //

        private int Set_DisplayMode(int mode_flag)
        {
            int correct_index = 0;

            if (mode_flag == 0) { correct_index = 0; } // no display
           
            if (mode_flag == 1) { correct_index = 1; Sel_DisplayMode.ForeColor = Color.DarkOliveGreen; } // reg value green
            if (mode_flag == 18) { correct_index = 2; Sel_DisplayMode.ForeColor = Color.DarkOliveGreen; }  // Percentage Green

            if (mode_flag == 5) { correct_index = 3; Sel_DisplayMode.ForeColor = Color.DarkRed; } // reg value Red
            if (mode_flag == 22) { correct_index = 4; Sel_DisplayMode.ForeColor = Color.DarkRed; } // percentage red
           

            if (mode_flag == 9) { correct_index = 5; Sel_DisplayMode.ForeColor = Color.Yellow; } // reg value yellow
            if (mode_flag == 26) { correct_index = 6; Sel_DisplayMode.ForeColor = Color.Yellow; } // reg yellow percentage
            //if (mode_flag == 27) yellow infinite 

                if (mode_flag == 13) { correct_index = 7; Sel_DisplayMode.ForeColor = Color.DarkBlue; } // Reg Val Blue
            if (mode_flag == 14) { correct_index = 8; Sel_DisplayMode.ForeColor = Color.DarkBlue; } // percentage blue
            //if (mode_flag == 15) blue infinite
           
           


            return correct_index; 
        }


        // upadte selected item properties..
        private void BTN_UPDATE_ITEM_Click(object sender, EventArgs e)
        {
            // convert properties to usable values
            int sel_idx = int.Parse(Sel_Idx.Value.ToString());
            byte selected_type = byte.Parse(Sel_ItemType.Items[Sel_ItemType.SelectedIndex].ToString().Substring(0, 2));
            byte selected_display = byte.Parse(Sel_DisplayMode.Items[Sel_DisplayMode.SelectedIndex].ToString().Substring(0, 2));

            byte selected_quantity = byte.Parse(Sel_Quantity.Value.ToString());
            byte selected_quest_code = byte.Parse(Sel_QuestCode.Value.ToString());
     
            // re write new values and re parse the list
         LIB_EXE.Update_ItemData(LIB_EXE.EXE_PATHS.bio3_ea_path, 0x12B3C8, sel_idx, selected_type, selected_quantity, selected_quest_code, selected_display); 
         LIB_EXE.Parse_ItemData(LIB_EXE.EXE_PATHS.bio3_ea_path, 0x12B3C8);

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TAB_EXE_SelectedIndexChanged(object sender, EventArgs e)
        {
            // some hard coded form resizes..
            if (TAB_EXE.SelectedTab.Name == "Item_Page") { this.Height = 882; this.Width = 544; TAB_EXE.Width = 536; TAB_EXE.Height = 829;  }
            if (TAB_EXE.SelectedTab.Name == "Combo_Page") { this.Height = 882; this.Width = 843; TAB_EXE.Width = 822; TAB_EXE.Height = 829;  }
           
        }

        private void BTN_ComboUpdate_Click(object sender, EventArgs e)
        {
            // get usable values from controls..

            int index = LST_Combo_Data.SelectedIndices[0];
            byte Sel_ComboFunc = byte.Parse(LST_Combo_Data.Items[index].SubItems[1].Text);
            byte Sel_PItem = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[LST_Combo_Data.Items[index].SubItems[2].Text];
            byte Sel_SItem = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[LST_Combo_Data.Items[index].SubItems[3].Text];
            byte Sel_RItem = LIB_ITEM.BIO3_ITEM_LUT_INVERSE[LST_RESULTITEM.Text];
            byte Sel_RQuantity = byte.Parse(LST_Combo_Data.Items[index].SubItems[5].Text);



           // MessageBox.Show(Sel_RItem.ToString());
            // update combo data and re parse/refresh update
           LIB_EXE.Update_ComboData(LIB_EXE.EXE_PATHS.bio3_ea_path, 0x12B678, index, Sel_ComboFunc, Sel_PItem, Sel_SItem, Sel_RItem, Sel_RQuantity);
            LIB_EXE.BIO3_ParseComboTable(LIB_EXE.EXE_PATHS.bio3_ea_path, 0x12B678, LST_Combo_Data);


            LST_Combo_Data.EnsureVisible(index);
           
        }

        private void LST_Combo_Data_Leave(object sender, EventArgs e)
        {
            int index = LST_Combo_Data.SelectedIndices[0];
           
        }
    }
}
