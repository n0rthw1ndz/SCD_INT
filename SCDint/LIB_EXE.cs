using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace SCDint
{
    public static class LIB_EXE
    {
        public struct exe_path_obj
        {
            public string bio2_exe_path; // jp sourcenext
            public string leonu_path;   // us leon platinum
            public string claireu_path; // us claire platinum
            public string bio3_mk_path; // jp mediakite
            public string bio3_ea_path; // ea china
        }


        // 
        public struct BIO3_ITEM_OBJ
        {
            public byte Item_Type;
            public byte Max_Quantity;
            public byte Quest_Code;
            public byte Display_Mode; // for quantity
        }


        public struct BIO3_COMBINE_OBJ
        {
            public byte ComboFunction;
            public byte Primary_Item;
            public byte Secondary_Item;
            public byte Result_Item;
            public byte New_Quantity;
            public byte ubyte00;
            public byte ubyte01;
            public byte ubyte02;
        }


        public struct BIO3_NEMESIS_OBJ
        {
            public byte ItemDrop00;
            public byte Item00_Quantity;
            public byte ItemDrop01;
            public byte Item01_Quantity;
            public byte ItemDrop02;
            public byte Item02_Quantity;
            public byte ItemDrop03;
            public byte Item03_Quantity;
            public byte ItemDrop04;
            public byte Item04_Quantity;
            public byte ItemDrop05;
            public byte Item05_Quantity;

        }


        public struct BIO3_PLAYER_SPEED_OBJ
        {
            public byte fine_speed;
            public byte caution_speed;
            public byte danger_speed;
            public byte dummy;

        }


        public static exe_path_obj EXE_PATHS = new exe_path_obj();
        public static BIO3_ITEM_OBJ[] BIO3_ITEM_DATA = new BIO3_ITEM_OBJ[171]; // block size / 4? 
        public static BIO3_COMBINE_OBJ[] BIO3_COMBO_ENTRIES = new BIO3_COMBINE_OBJ[125];
        public static BIO3_NEMESIS_OBJ BIO3_NEM_DROP = new BIO3_NEMESIS_OBJ(); // dont need an array
        public static BIO3_PLAYER_SPEED_OBJ[] BIO3_MOVEMENT_SPEED = new BIO3_PLAYER_SPEED_OBJ[3]; 



        /// <summary>
        ///  Parse and store bio3 combo information
        ///  can be used for multi versions 
        /// </summary>
        /// <param name="file_path">Dir path</param>
        /// <param name="offset">relative offset</param>
        public static void BIO3_ParseComboTable(string file_path, int offset, ListView Combo_LV)
        {


            using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    fs.Seek(offset, SeekOrigin.Begin);


                    for (int i = 0; i < BIO3_COMBO_ENTRIES.Length; i++)
                    {
                        BIO3_COMBO_ENTRIES[i].ComboFunction = br.ReadByte();
                        BIO3_COMBO_ENTRIES[i].Primary_Item = br.ReadByte();
                        BIO3_COMBO_ENTRIES[i].Secondary_Item = br.ReadByte();
                        BIO3_COMBO_ENTRIES[i].Result_Item = br.ReadByte();
                        BIO3_COMBO_ENTRIES[i].New_Quantity = br.ReadByte();
                        BIO3_COMBO_ENTRIES[i].ubyte00 = br.ReadByte();
                        BIO3_COMBO_ENTRIES[i].ubyte01 = br.ReadByte();
                        BIO3_COMBO_ENTRIES[i].ubyte02 = br.ReadByte();
                        
                    }


                }

            }

            Combo_LV.Items.Clear();

            for (int j = 0; j < LIB_EXE.BIO3_COMBO_ENTRIES.Length; j++)
            {
                Combo_LV.Items.Add(j.ToString());
                Combo_LV.Items[j].SubItems.Add(LIB_EXE.BIO3_COMBO_ENTRIES[j].ComboFunction.ToString());
                Combo_LV.Items[j].SubItems.Add(LIB_ITEM.BIO3_ITEM_LUT[LIB_EXE.BIO3_COMBO_ENTRIES[j].Primary_Item].ToString());
                Combo_LV.Items[j].SubItems.Add(LIB_ITEM.BIO3_ITEM_LUT[LIB_EXE.BIO3_COMBO_ENTRIES[j].Secondary_Item].ToString());
                Combo_LV.Items[j].SubItems.Add(LIB_ITEM.BIO3_ITEM_LUT[LIB_EXE.BIO3_COMBO_ENTRIES[j].Result_Item].ToString());
                Combo_LV.Items[j].SubItems.Add(LIB_EXE.BIO3_COMBO_ENTRIES[j].New_Quantity.ToString());
            }


        }

        public static void Parse_ItemData(string file_path, int offset)
        {
            using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    fs.Seek(offset, SeekOrigin.Begin);

                    for (int i = 0; i < BIO3_ITEM_DATA.Length; i++)
                    {
                        BIO3_ITEM_DATA[i].Item_Type = br.ReadByte();
                        BIO3_ITEM_DATA[i].Max_Quantity = br.ReadByte();
                        BIO3_ITEM_DATA[i].Quest_Code = br.ReadByte();
                        BIO3_ITEM_DATA[i].Display_Mode = br.ReadByte();
                    }
                }

            }


        }


        /// <summary>
        /// Update Selected Item Properties (bio3 atm)
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="offset"></param>
        /// <param name="sel_idx"></param>
        /// <param name="Item_Type"></param>
        /// <param name="Max_Quantity"></param>
        /// <param name="Quest_Code"></param>
        /// <param name="Display_mode"></param>
        public static void Update_ItemData(string file_path, int offset, int sel_idx, byte Item_Type, byte Max_Quantity, byte Quest_Code, byte Display_mode)
        {
            using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    if (sel_idx > 0)
                    {
                        fs.Seek(offset * sel_idx + 4, SeekOrigin.Begin);
                    }
                    else
                    {
                        fs.Seek(offset, SeekOrigin.Begin);

                    }


                    bw.Write(Item_Type);
                    bw.Write(Max_Quantity);
                    bw.Write(Quest_Code);
                    bw.Write(Display_mode);

                }
            }


        }

        public static void Update_ComboData(string file_path, int offset, int sel_idx, byte combo_function, byte P_Item, byte S_Item, byte R_Item, byte R_Quantity)
        {
            using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    // cant multply index by 0 cuz then itl just jump back to 0.. lmao
                    if (sel_idx > 0)
                    {
                        fs.Seek(offset + 8 * sel_idx, SeekOrigin.Begin);
                        MessageBox.Show(fs.Position.ToString());
                    }
                    else   // if 0 just go to the actual offset..
                    {

                        fs.Seek(offset, SeekOrigin.Begin);
                    }


                    bw.Write(combo_function);
                    bw.Write(P_Item);
                    bw.Write(S_Item);
                    bw.Write(R_Item);
                  
                    bw.Write(R_Quantity);

                }

            }


        }




    }
}
