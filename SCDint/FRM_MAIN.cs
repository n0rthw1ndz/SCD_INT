using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Compatibility;
using System.Diagnostics;


namespace SCDint
{
    public partial class FRM_MAIN : Form
    {
        /// <summary>
        ///  PERSONAL NOTE, YOUR SCD INTERPRETERS FOR BIO2 & 3 ONLY HAVE TO PROCESS AND DISPLAY 1 SCRIPT AT A TIME, 
        ///  IF YOUR READING THE SCD RDT RELATIVE IT ONLY NEEDS TO PROCESS MAIN and then dissasemble the rest so they can be processed individually
        ///  
        /// </summary>

        string ConfigFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\AppConfig.ini";
        string BIO2_ECG_PATH = AppDomain.CurrentDomain.BaseDirectory + "\\ECG";
        string BIO2_ARMS_PATH = AppDomain.CurrentDomain.BaseDirectory + "\\ECG\\ARMS\\";
        string BIO3_ARMS_PATH = AppDomain.CurrentDomain.BaseDirectory + "\\ECG\\BIO3_ARMS\\";
        string BIO2_ROOM_DIR = AppDomain.CurrentDomain.BaseDirectory + "\\BIO2_DUMPED";
        string BIO3_ROOM_DIR = AppDomain.CurrentDomain.BaseDirectory + "\\BIO3_DUMPED";

        string selected_path = string.Empty;


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// DECLARATIONS
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        int g_TAB = 0;          //VALUE USED TO NEST CODE
        byte relative_flag; // 0 For RDT 1 for SCD relative parsing
        string g_TAB_STR = "";  //STRING USED TO REPRESENT CODE NESTING
     
       


        byte APP_MODE = 0; // 2 = RE2 , 3 = RE3 MODE

        
        

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// INTERFACE
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FRM_MAIN()
        {
            InitializeComponent();
       //     this.WindowState = FormWindowState.Maximized;
           
        }


        public static LIB_RDT.RDT_HEADER_OBJ RDT_DATA = new LIB_RDT.RDT_HEADER_OBJ();
        public static LIB_RDT.SCD_HEADER_OBJ SCD_DATA = new LIB_RDT.SCD_HEADER_OBJ();
        public static LIB_RDT.EM_SET_OBJ EM_SET = new LIB_RDT.EM_SET_OBJ();
        
     
      


        FRM_DEBUG DEBUG_FORM = new FRM_DEBUG();
        FRM_CALC CALC_FORM = new FRM_CALC();
        CalcTest CALC_TEST = new CalcTest();
        FRM_CONFIG CONFIG_FORM = new FRM_CONFIG();
        FRM_SAPMAKE SAP_FORM = new FRM_SAPMAKE();
        FRM_MSGEDIT MSG_FORM = new FRM_MSGEDIT();
      //  FRM_PROCHOOK HOOK_FORM = new FRM_PROCHOOK();
        FRM_INVOEDIT INVO_FORM = new FRM_INVOEDIT();
        FRM_EXE EXE_FORM = new FRM_EXE();
        FRM_SAVE SAVE_FORM = new FRM_SAVE();
        FRM_SCD_EDIT SCDEDITOR = new FRM_SCD_EDIT();
       public FRM_EM_SET EM_SET_FORM = new FRM_EM_SET();

        private void FRM_MAIN_Resize(object sender, EventArgs e)
        {
             LST_CODE.Width = (this.Width - 16) - 400;
                LST_CODE.Height = this.Height - 150;
              LST_BYTE.Width = (this.Width - 16) - 400;
               LST_BYTE.Height = this.Height - 150;

             //LST_PROP.Left = panel_scd.Width;
            // LST_PROP.Height = this.Height - 250;

         


           
        }
       

        private void M_FILE_EXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void M_VIEW_TOGGLE_Click(object sender, EventArgs e)
        {
            
        }

        private void LST_CODE_Click(object sender, EventArgs e)
        {
            if (LST_CODE.Items.Count > 0) 
            {
                if (selected_path.Substring(selected_path.Length - 11, 4) == "BIO2")
                {
                    BIO2_GET_ATTR(LST_CODE.SelectedIndices[0]);
                }
                else if (selected_path.Substring(selected_path.Length - 11, 4) == "BIO3")
                {
                    BIO3_GET_ATTR(LST_CODE.SelectedIndices[0]);
                }

                    LST_BYTE.Items[LST_CODE.SelectedIndices[0]].Selected = true;

               
            }
            
        }

        private void LST_CODE_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (LST_CODE.Items.Count > 0) { LST_BYTE.Items[LST_CODE.SelectedIndices[0]].Selected = true; }
            }

            catch
            {

            }

            
        }

        private void LST_BYTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (LST_CODE.Items.Count > 0) { LST_CODE.Items[LST_BYTE.SelectedIndices[0]].Selected = true; }
        }

        private void LST_BYTE_Click(object sender, EventArgs e)
        {
            if (LST_CODE.Items.Count > 0) { LST_CODE.Items[LST_BYTE.SelectedIndices[0]].Selected = true; }
        }

        private void BTN_OPEN_Click(object sender, EventArgs e)
        {
            LST_BYTE.Items.Clear();
            LST_CODE.Items.Clear();
            DLG_OPEN_FILE.FilterIndex = 2;
            g_TAB = 0;

            DLG_OPEN_FILE.ShowDialog();


            try
            {


                FRM_DEBUG.cur_file = DLG_OPEN_FILE.FileName;

                if (DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 3, 3).ToUpper() == "RDT")
                {
                    relative_flag = 0;
                    PARSE_RDT(DLG_OPEN_FILE.FileName);
                }
                else if (DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 3, 3) == "SCD".ToUpper())
                {
                    relative_flag = 1;
                }





                if (DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 3, 3) == "RDT")
                {
                    BIO2_PARSE_SCD(DLG_OPEN_FILE.FileName, relative_flag);
                    DIR_LISTBOX.Path = BIO2_ROOM_DIR + "\\" + DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 12, 8);
                    selected_path = BIO2_ROOM_DIR;
                }
                else if (DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 3, 3) == "rdt")
                {
                    BIO3_PARSE_SCD(DLG_OPEN_FILE.FileName, relative_flag);
                    DIR_LISTBOX.Path = BIO3_ROOM_DIR + "\\" + DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 8, 4);
                    selected_path = BIO3_ROOM_DIR;

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\" + "BIO3_BSS" + "\\" + DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 8, 4) + "00.jpg"))
                {
                    IMAGE_BG_RENDER_RDT.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\" + "BIO3_BSS" + "\\" + DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 8, 4) + "00.jpg");
                }

                   
                }

                LBL_PROC_STATUS.Text = DLG_OPEN_FILE.FileName;
                F_LISTBOX.FileName = DIR_LISTBOX.Path;

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            // parse scd according to rdt/scd relation

          

           
     

        }

        private void BTN_DISPLAY_TOGGLE_Click(object sender, EventArgs e)
        {
            TOGGLE_VIEW();
        }

        private void TOGGLE_VIEW()
        {
            if (LST_CODE.Visible)
            {
                LST_CODE.Visible = false;
                LST_CODE.Enabled = false;
                LST_BYTE.Visible = true;
                LST_BYTE.Enabled = true;
            }
            else
            {
                LST_CODE.Visible = true;
                LST_CODE.Enabled = true;
                LST_BYTE.Visible = false;
                LST_BYTE.Enabled = false;
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LST_CODE.Items[1].SubItems[2].Text);
            
        }
        

        
        /// <summary>
        /// parses and dumps main header data to debug view..
        /// </summary>
        /// <param name="file"></param>
        private void PARSE_RDT(string file)
        {
            try
            {
                using (var fs = new FileStream(file, FileMode.Open))
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    BinaryReader br = new BinaryReader(fs);

                    // read opening 8 byte array and store..
                    RDT_DATA.nSPrite = br.ReadByte();
                    RDT_DATA.nCut = br.ReadByte();
                    RDT_DATA.noModel = br.ReadByte();
                    RDT_DATA.nItem = br.ReadByte();
                    RDT_DATA.nDoor = br.ReadByte();
                    RDT_DATA.nRoom_At = br.ReadByte();
                    RDT_DATA.Reverb_lv = br.ReadByte();
                    RDT_DATA.nSprite_Max = br.ReadByte();

                    Array.Resize(ref RDT_DATA.nOffsets, 22); // resize all possible offsets to 23 max


                    //deump debug log..
                    DEBUG_FORM.Debug_Log.AppendText("\nnSprite: " + RDT_DATA.nSPrite.ToString());
                    DEBUG_FORM.Debug_Log.AppendText("\nnCut: " + RDT_DATA.nCut.ToString());
                    DEBUG_FORM.Debug_Log.AppendText("\nModel: " + RDT_DATA.noModel.ToString());
                    DEBUG_FORM.Debug_Log.AppendText("\nItem: " + RDT_DATA.nItem.ToString());
                    DEBUG_FORM.Debug_Log.AppendText("\nDoor: " + RDT_DATA.nDoor.ToString());
                    DEBUG_FORM.Debug_Log.AppendText("\nRoom_At: " + RDT_DATA.nRoom_At.ToString());
                    DEBUG_FORM.Debug_Log.AppendText("\nReverb_lv: " + RDT_DATA.Reverb_lv.ToString());
                    DEBUG_FORM.Debug_Log.AppendText("\nSprite_Max: " + RDT_DATA.nSprite_Max.ToString());


                    // loop read all offsets, add to debug log/list

                    for (int i = 0; i < RDT_DATA.nOffsets.Length; i++)
                    {
                        RDT_DATA.nOffsets[i] = br.ReadInt32();
                        LIB_RDT.OFFSET_LIST.Add(RDT_DATA.nOffsets[i]);
                        DEBUG_FORM.Debug_Log.AppendText("\n" + LIB_RDT.LUT_RDT_OFFSET[i] + " Offset[" + RDT_DATA.nOffsets[i].ToString() + "]");
                        DEBUG_FORM.LV_RDT.Items.Add(i.ToString());
                        DEBUG_FORM.LV_RDT.Items[i].SubItems.Add(LIB_RDT.LUT_RDT_OFFSET[i]);
                        DEBUG_FORM.LV_RDT.Items[i].SubItems.Add(RDT_DATA.nOffsets[i].ToString());

                    }


                    LIB_RDT.OFFSET_LIST.Sort();
                    
                    // close file stream
                    br.Close();
                    fs.Close();
                         
                }
                
            }
            
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }

        }



        /// <summary>
        /// Parsing ONE SCD at a time, this function will either parse a single scd or an rdt, if it parses it rdt relative it will only technically parse the main and then unpack the others which can be individually parsed by this same function later
        /// </summary>
        /// <param name="sfile"></param>
        /// <param name="flag_relative"></param>
        private void BIO3_PARSE_SCD(string sfile, byte flag_relative)
        {
            try
            {

                LST_BYTE.Items.Clear();
                LST_CODE.Items.Clear();

                FileStream fs = new FileStream(sfile, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);


                byte bbuffer;
                byte[] barr = new byte[0]; // resize to cmd length later
                string byte_str = string.Empty;
                string[] cmd_names;
                int cmd_len; // cur cmd length
                int[] sorted_rdt_offsets = new int[0]; // an array of rdt offsets used for sorting..
                int main_scd_idx = 0;
                int scd_00_sz = 0; // size of 00 script
                int scd_01_off = 0; // offset 01 '2nd' script


                cmd_names = File.ReadAllLines(Path.GetDirectoryName(Application.ExecutablePath) + @"\LIB\BIO3_SCD_OP_NAMES_C.LIB");
                

                switch (flag_relative)
                {
                    case 0:
                        fs.Seek(RDT_DATA.nOffsets[16], SeekOrigin.Begin);

                        // if rdt main scd sz is sub scd block offset - main


                        SCD_DATA.O_SCDMAIN = RDT_DATA.nOffsets[16]; // main and sub offsets are stored already
                        SCD_DATA.O_SCD_SUB = RDT_DATA.nOffsets[17]; // 



                        Array.Resize(ref sorted_rdt_offsets, RDT_DATA.nOffsets.Length);
                    
                        // set sorted array offsets to each rdt offset
                        for (int j = 0; j < RDT_DATA.nOffsets.Length; j++)
                        {
                            sorted_rdt_offsets[j] = RDT_DATA.nOffsets[j];   
                           // DEBUG_FORM.Debug_Log.AppendText("[ " + j.ToString() + "] " + RDT_DATA.nOffsets[j].ToString());
                        }

                        // sort the array
                        Array.Sort(sorted_rdt_offsets);

                        //get index of main scd.. from the sorted array
                        main_scd_idx = Array.BinarySearch(sorted_rdt_offsets, RDT_DATA.nOffsets[16]);
                        
                        // get next highest index after main scd to determine length
                        if (main_scd_idx >= 0)
                        {
                            // calculate true length of entire main block, NOT the first script
                            SCD_DATA.SCDMAIN_SZ = sorted_rdt_offsets[main_scd_idx + 1] - SCD_DATA.O_SCDMAIN;                           
                        }
                        

                        // calculate main sz is wrong.. use next highest offset instead of sub in this case

                        SCD_DATA.nMain = br.ReadInt16(); //  
                        SCD_DATA.nMain /= 2; // main is always 01 anyways..

                        
                        // pass main and sub cd offsets

                        fs.Seek(RDT_DATA.nOffsets[16], SeekOrigin.Begin); // reset back to main scd offset

                        Array.Resize(ref SCD_DATA.O_SCD_SUBS, SCD_DATA.nMain);


                        // loop thru count and read/store sub script ptrs
                        for (int i = 0; i < SCD_DATA.nMain; i++)
                        {
                            SCD_DATA.O_SCD_SUBS[i] = br.ReadInt16();
                            DEBUG_FORM.Debug_Log.AppendText("Execution SCE[" + i.ToString() + "]" + SCD_DATA.O_SCD_SUBS[i].ToString() + "\n");
                            //MessageBox.Show(SCD_DATA.O_SCD_SUBS[i].ToString());
                        }

                        // seek to 1st script offset
                        fs.Seek(RDT_DATA.nOffsets[16] + SCD_DATA.O_SCD_SUBS[0], SeekOrigin.Begin);

                        // calculate size of 1st script by subtracting the 1st 2 pointers
                        scd_00_sz = SCD_DATA.O_SCD_SUBS[1] - SCD_DATA.O_SCD_SUBS[0];
                        scd_01_off = RDT_DATA.nOffsets[16] + SCD_DATA.O_SCD_SUBS[1]; // calculate the offset of the 2nd script

                        break;
                        

                    case 1:

                        fs.Seek(0, SeekOrigin.Begin); // parse idv scd?


                        scd_00_sz = int.Parse(fs.Length.ToString()); // if single scd scd size is entire file                       
                        scd_01_off = scd_00_sz; // and there is no sub scd offset because it is a sub scd..

                        break;

                }


                // 
                
                // resize array of sub ptrs to number to correct main block count, since bio3 always has 19 in main..?
            

                // loop through the first scripts length
                for (int i = 0; i < scd_00_sz; i++)
                {
                    // MessageBox.Show("fs" + fs.Position + SCD_DATA.SCDMAIN_SZ.ToString());

                    if (fs.Position >= scd_01_off) { break; } // break if we hit 2nd script offset

                    LST_CODE.Items.Add(fs.Position.ToString());   // add index to lst side
                    LST_BYTE.Items.Add(fs.Position.ToString()); // add offset to byte code lst
                    LST_CODE.Items[i].UseItemStyleForSubItems = false; // no idea
                    //LST_CODE.Items[i].ForeColor = Color.Green;
                    bbuffer = br.ReadByte(); // read entire file into buffer

                    fs.Seek(-1, SeekOrigin.Current);


                    //if (GET_CMD_LEN(bbuffer) == 0) { MessageBox.Show("OPCODE ERROR !!!: " + " " + bbuffer.ToString("X").PadLeft(2, '0') + " OFFSET: " + fs.Position.ToString()); }

                    cmd_len = SET_SCD3_CMD_LEN(bbuffer); // set cmd length to currently read opcode length?
                    if (cmd_len == 0) { cmd_len = 1; } // force cmd length to 1?

                    Array.Resize(ref barr, cmd_len); // rsize byte array to cmd length
                    barr = br.ReadBytes(barr.Length); // read the opcode in its entirity 
                    byte_str = "";



                    for (int j = 0; j < barr.Length; j++) // loop through currently read buffer and set bytestr to opcode, padding to display without 0?
                    {
                        byte_str += barr[j].ToString("X").PadLeft(2, '0');
                    }

                    NEST_CODE(bbuffer); // not sure yet

                  
                    LST_BYTE.Items[i].SubItems.Add(byte_str);  // add byte string to byte code column
                    LST_CODE.Items[i].SubItems.Add(g_TAB_STR + cmd_names[bbuffer] + "" +BIO3_GET_ATTR(i)); // add some index, the cmd name, and its attirubutes to int column
                    LST_CODE.Items[i].SubItems.Add(""); // comment?

                    COLOR_CMD(bbuffer, i); // color code the interrepted shit

                    LST_CODE.Items[i].SubItems[2].ForeColor = Color.CornflowerBlue; // force comments green

                    // SET BIO3 COMMENTS FOR SPECIFIC OPERATIONS

                    if (bbuffer == 4) { LST_CODE.Items[i].SubItems[2].Text = "//" + CODE_COMMENT(LST_BYTE.Items[i].SubItems[1].Text); } // 
                    if (bbuffer == 0x4C || bbuffer == 0x4D) { LST_CODE.Items[i].SubItems[2].Text = "//" + BIO3_FLAG_COMMENT(LST_BYTE.Items[i].SubItems[1].Text); }

                }

                


                // if we are rdt relative run scd dissasembly
                if (relative_flag == 0)
                {
                    fs.Seek(RDT_DATA.nOffsets[16], SeekOrigin.Begin);

                    Array.Resize(ref SCD_DATA.O_SCD_SUBS, SCD_DATA.nMain); // resize arrays holding offsets and sizes to # of sub exec scripts
                    Array.Resize(ref SCD_DATA.SZ_SDS, SCD_DATA.nMain);
                    

                    for (int j = 0; j < SCD_DATA.nMain; j++)
                    {
                        // if not final scd script
                        if (j < SCD_DATA.nMain - 1)
                        {
                            SCD_DATA.SZ_SDS[j] = SCD_DATA.O_SCD_SUBS[j + 1] - SCD_DATA.O_SCD_SUBS[j]; // current script size is next ptr - current ptr
                        }
                        else
                        {
                            int final_scd_off = RDT_DATA.nOffsets[16] + SCD_DATA.O_SCD_SUBS[j]; // final script in main block is scd off + last ptr
                            SCD_DATA.SZ_SDS[j] = sorted_rdt_offsets[main_scd_idx + 1] - final_scd_off; // final size is next logical offset - final script offset
                         //   MessageBox.Show("last sz: " + SCD_DATA.SZ_SDS[j].ToString());

                        }


                    }


                    if (!Directory.Exists(BIO3_ROOM_DIR))
                    {
                        Directory.CreateDirectory(BIO3_ROOM_DIR + "\\" + DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 8, 4));

                    }
                    else // dump doesent exist
                    {
                        Directory.CreateDirectory(BIO3_ROOM_DIR + "\\" + DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 8, 4));

                    }


                    BIO3_SCD_UNPACK(RDT_DATA.nOffsets[16] + SCD_DATA.O_SCD_SUBS[0], SCD_DATA.nMain, fs, br, BIO3_ROOM_DIR);


                }


                fs.Close();
                br.Close();

               

            }

            catch
            {

            }

        }


       /// <summary>
       /// Parse SCD Data via RDT or SCD directly.., if RDT directly.. it only parses the main script, and calculates the length of all the others to run dissasembly
       /// </summary>
       /// <param name="sfile">The filestream</param>
       /// <param name="flag_relative">format flag, 0 RDT, 1 SCD relative</param>
        private void BIO2_PARSE_SCD(string sfile, byte flag_relative) 
        {
            try
            {
                LST_BYTE.Items.Clear(); // prevent dupes niggas
                LST_CODE.Items.Clear();

                FileStream fs = new FileStream(sfile, FileMode.Open); // opening fle streams
                BinaryReader br = new BinaryReader(fs);

                byte bbuffer;
                byte[] barr = new byte[0];
                string bytestr;
                string[] cmd_names;
                int cmd_len = 0;
               
                
                cmd_names = File.ReadAllLines(Path.GetDirectoryName(Application.ExecutablePath) + @"\LIB\BIO2_SCD_OP_NAMES_C.LIB"); // wow
                
                // run switch on relative flag, if rdt, set size and offsets
                switch (flag_relative)
                {
                    case 0:

                        fs.Seek(RDT_DATA.nOffsets[16], SeekOrigin.Begin);

                         // if rdt main scd sz is sub scd block offset - main
                       

                        SCD_DATA.O_SCDMAIN = RDT_DATA.nOffsets[16]; // main and sub offsets are stored already
                        SCD_DATA.O_SCD_SUB = RDT_DATA.nOffsets[17];

                        SCD_DATA.SCDMAIN_SZ = SCD_DATA.O_SCD_SUB - SCD_DATA.O_SCDMAIN; // calculate main sz, this might not always be true..

                        SCD_DATA.nMain = br.ReadInt16(); //  
                        SCD_DATA.nMain /= 2; // main is always 01 anyways.. for bio2..
                        
                        // pass main and sub cd offsets

                          fs.Seek(RDT_DATA.nOffsets[16] + 2, SeekOrigin.Begin);

                        break;
                    case 1:
                        
                        // if main scd skip the entry count
                        if (sfile.Substring(sfile.Length - 10, 4) == "MAIN")
                        {
                            fs.Seek(2, SeekOrigin.Begin);
                        }// other scds dont have any entry count ;)
                        else
                        {
                            fs.Seek(0, SeekOrigin.Begin);
                        }

                        
                        SCD_DATA.SCDMAIN_SZ = int.Parse(fs.Length.ToString()); // if single scd scd size is entire file                       
                        SCD_DATA.O_SCD_SUB = SCD_DATA.SCDMAIN_SZ; // and there is no sub scd offset because it is a sub scd..
                        break;

                }


              

              // this simply parses main scd..(used to), this should be for parsing all scds..?
                for (int i = 0; i < SCD_DATA.SCDMAIN_SZ; i++)
                {
                   // MessageBox.Show("fs" + fs.Position + SCD_DATA.SCDMAIN_SZ.ToString());

                    if (fs.Position >= SCD_DATA.O_SCD_SUB) { break; } // break if we hit sub scd offset

                    LST_CODE.Items.Add(fs.Position.ToString());   // add index to lst side
                    LST_BYTE.Items.Add(fs.Position.ToString()); // add offset to byte code lst
                    LST_CODE.Items[i].UseItemStyleForSubItems = false; // no idea
                    //LST_CODE.Items[i].ForeColor = Color.Green;
                    bbuffer = br.ReadByte(); // read entire file into buffer
                    
                    fs.Seek(-1, SeekOrigin.Current);
                  

                    //if (GET_CMD_LEN(bbuffer) == 0) { MessageBox.Show("OPCODE ERROR !!!: " + " " + bbuffer.ToString("X").PadLeft(2, '0') + " OFFSET: " + fs.Position.ToString()); }

                    cmd_len = SET_SCD2_CMD_LEN(bbuffer); // set cmd length to currently read opcode length?
                    if (cmd_len == 0) { cmd_len = 1; } // force cmd length to 1?

                    Array.Resize(ref barr, cmd_len); // rsize byte array to cmd length
                    barr = br.ReadBytes(barr.Length); // read the opcode in its entirity 
                    bytestr = ""; 



                    for (int j = 0; j < barr.Length; j++) // loop through currently read buffer and set bytestr to opcode, padding to display without 0?
                    {
                        bytestr += barr[j].ToString("X").PadLeft(2, '0');
                    }

                    NEST_CODE(bbuffer); // not sure yet

                    LST_BYTE.Items[i].SubItems.Add(bytestr);  // add byte string to byte code column
                    LST_CODE.Items[i].SubItems.Add(g_TAB_STR + cmd_names[bbuffer] + "" + BIO2_GET_ATTR(i)); // add some index, the cmd name, and its attirubutes to int column
                    LST_CODE.Items[i].SubItems.Add(""); // comment?

                    COLOR_CMD(bbuffer, i); // color code the interrepted shit

                    LST_CODE.Items[i].SubItems[2].ForeColor = Color.SeaGreen; // force comments green

                    if (bbuffer == 4) { LST_CODE.Items[i].SubItems[2].Text = "//" + CODE_COMMENT(LST_BYTE.Items[i].SubItems[1].Text); } // 
                    if (bbuffer == 33 || bbuffer == 34) { LST_CODE.Items[i].SubItems[2].Text = "//" + BIO2_FLAG_COMMENT(LST_BYTE.Items[i].SubItems[1].Text); }

                }



                // we only seek to a sub scd offset if were rdt relative, otherwise its jus a sub scd itself..
                if (relative_flag == 0)
                {
                    // seek to sub scd block if rdt relative..
                    fs.Seek(SCD_DATA.O_SCD_SUB, SeekOrigin.Begin);

                    // read first offset
                    SCD_DATA.nSub = br.ReadInt16();
                    SCD_DATA.nSub /= 2; // divide first ptr by 2 to get total sub(execution scripts);

                    fs.Seek(-2, SeekOrigin.Current); // go back again
                                                     //resize array
                    Array.Resize(ref SCD_DATA.O_SCD_SUBS, SCD_DATA.nSub); // resize arrays holding offsets and sizes to # of sub exec scripts
                    Array.Resize(ref SCD_DATA.SZ_SDS, SCD_DATA.nSub);



                    // loop thru all sub script ptrs and store them...
                    for (int i = 0; i < SCD_DATA.nSub; i++)
                    {
                        SCD_DATA.O_SCD_SUBS[i] = br.ReadInt16();
                    }

                    //  MessageBox.Show(SCD_DATA.SUB_SCD_PTR_T.ToString());

                    fs.Seek(SCD_DATA.O_SCD_SUB, SeekOrigin.Begin);


                    // loop through all sub script ptrs and calculate their true lengths.. store lengths..
                    for (int y = 0; y < SCD_DATA.nSub; y++)
                    {
                        // current indexed size is equal to next indexed ptr minus current
                        if (y < SCD_DATA.nSub - 1)
                        {
                            SCD_DATA.SZ_SDS[y] = SCD_DATA.O_SCD_SUBS[y + 1] - SCD_DATA.O_SCD_SUBS[y]; // current size is equal to next ptr - current
                            SCD_DATA.SUB_SCD_PTR_T += SCD_DATA.SZ_SDS[y]; // sum up all sizes (this should give entire sub scd length - last?)
                        }
                        else
                        {
                            // calculate the start of the last sub script..
                            int final_sub_off = SCD_DATA.O_SCD_SUB + SCD_DATA.O_SCD_SUBS[y];
                            int final_sub_sz = 0;
                            // resort the array for binary search
                            Array.Sort(RDT_DATA.nOffsets);

                            int index = Array.BinarySearch(RDT_DATA.nOffsets, SCD_DATA.O_SCD_SUB);

                            // if on first match skip + 1 to get next logical index
                            if (index >= 0)
                            {
                                final_sub_sz = RDT_DATA.nOffsets[index + 1] - final_sub_off;
                                SCD_DATA.SZ_SDS[y] = final_sub_sz;
                            }

                        }



                    }

                    //  MessageBox.Show(SCD_DATA.SUB_SCD_PTR_T.ToString());
                    // if dumped already exists
                    if (!Directory.Exists(BIO2_ROOM_DIR))
                    {
                        Directory.CreateDirectory(BIO2_ROOM_DIR + "\\" + DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 12, 8));

                    }
                    else // dump doesent exist
                    {
                        Directory.CreateDirectory(BIO2_ROOM_DIR + "\\" + DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 12, 8));

                    }


                    Dissasemble_SCDS(SCD_DATA.O_SCDMAIN, SCD_DATA.SCDMAIN_SZ, SCD_DATA.nSub, fs, br, BIO2_ROOM_DIR);
                }

                // seek to Sub scd data
            

                // ** Instead of viewing sub scripts RDT relative dump main/sub into room folders like mort has done..


                br.Close();
                fs.Close();


            }
            catch (System.ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }




        /// <summary>
        ///  need to figure this shit badly..
        /// </summary>
        /// <param name="sfile"></param>
        private void UPDATE_SCD(string sfile)
        {
            using (var fs = new FileStream(sfile, FileMode.Open))
            {
                BinaryWriter bw = new BinaryWriter(fs);
                fs.Seek(0, SeekOrigin.Begin);

                
                fs.Close();
                bw.Close();
            }


        }






        private void BIO3_SCD_UNPACK(int main_off, int nCount, FileStream fs, BinaryReader br, string dir_path)
        {
            string outstr = string.Empty;
            string ini_Data = "SCD.INI";

            // seek to first script position (past ptr array)
            fs.Seek(main_off, SeekOrigin.Begin);

            // for every script (probabaly always 19)
            for (int i = 0; i < nCount; i++)
            {
                // create and resize a buffer according to indexed size..
                byte[] buffer = new byte[SCD_DATA.SZ_SDS[i]];

                // read data into buffer
                for (int j = 0; j < buffer.Length; j++)
                {
                    buffer[j] = br.ReadByte();
                    
                }

                if (i < 10)
                {
                    outstr = i.ToString().PadLeft(2, '0');
                }
                else // otherwise 10/11/12 is cool
                {
                    outstr = i.ToString();
                }

                string tt = DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 8, 8);
             //   MessageBox.Show(tt);

                using (var output = new FileStream(dir_path + "\\" + DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 8, 4) + "\\SCE" + outstr + ".SCD", FileMode.Create))
                {
                    BinaryWriter bw = new BinaryWriter(output);

                    bw.Write(buffer, 0, buffer.Length);

                    bw.Close();

                }


                if (!File.Exists(dir_path + "\\" + DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 8, 4) + "\\" + ini_Data))
                {
                    using (StreamWriter sw = new StreamWriter(dir_path + "\\" + DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 8, 4) + "\\" + ini_Data))
                    {
                        sw.WriteLine("\nNcut[" + RDT_DATA.nCut.ToString() + "]");
                        sw.WriteLine("\nnDoor[" + RDT_DATA.nDoor.ToString() + "]");
                        sw.WriteLine("\nnItem[" + RDT_DATA.nItem.ToString() + "]");
                        sw.WriteLine("\nnSprite[" + RDT_DATA.nSPrite.ToString() + "]");
                        sw.WriteLine("\nnModel[" + RDT_DATA.noModel.ToString() + "]");
                        sw.WriteLine("\nReverbLvl[" + RDT_DATA.Reverb_lv.ToString() + "]");






                        for (int x = 0; x < SCD_DATA.O_SCD_SUBS.Length; x++)
                        {
                            sw.WriteLine("\nExec[" + x.ToString() + "]" + SCD_DATA.O_SCD_SUBS[x].ToString());
                        }
                    }
                }





            }

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Main_off"></param>
        /// <param name="main_sz"></param>
        /// <param name="nsub"></param>
        /// <param name="fs"></param>
        /// <param name="br"></param>
        private void Dissasemble_SCDS(int Main_off, int main_sz, int nsub, FileStream fs, BinaryReader br, string dir_path)
        {
            string outstr = string.Empty;

            // seek to main scd offset
            fs.Seek(Main_off, SeekOrigin.Begin);

            //create a buffer according to size
           // MessageBox.Show(main_sz.ToString());
            byte[] buffer = new byte[main_sz];
            

            //read entire scd into buffer
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = br.ReadByte();
            }


            //create new output filestream for main scd..
            using(var output = new FileStream(dir_path + "\\" + DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 12, 8) +"\\MAIN00.SCD", FileMode.Create))
            {
                BinaryWriter bw = new BinaryWriter(output);

                bw.Write(buffer, 0, buffer.Length);

                bw.Close();

            }
            
            // loop through all sub scripts
            for (int x = 0; x < SCD_DATA.nSub; x++)
            {

                //resize buffer to indexed sub script size
                Array.Resize(ref buffer, SCD_DATA.SZ_SDS[x]);

                // seek to the main sub script block + indexed sub script ptr
                fs.Seek(SCD_DATA.O_SCD_SUB + SCD_DATA.O_SCD_SUBS[x], SeekOrigin.Begin);

                // read appropriate sub script into buffer
                for (int j = 0; j < buffer.Length; j++)
                {
                    buffer[j] = br.ReadByte();

                }

                
                // if dumped index is < 10 then we want to pad a 0 to the string to make it 00/01/02 etc
                if (x < 10)
                {
                    outstr = x.ToString().PadLeft(2, '0');
                }
                else // otherwise 10/11/12 is cool
                {
                    outstr = x.ToString();
                }

                // dump buffer into iterated file and close
                using (var output = new FileStream(dir_path + "\\" + DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 12, 8) + "\\SUB" + outstr + ".SCD", FileMode.Create))
                {
                    BinaryWriter bw = new BinaryWriter(output);

                    bw.Write(buffer, 0, buffer.Length);

                    bw.Close();

                }

            }
            
        }



       


        //COLOR THE CODE!
        private void COLOR_CMD(byte XBYTE, int IDX)
        {
            Color new_color = this.BackColor;
            Color cmd_flag_op = Color.DarkCyan;
            Color cmd_key = Color.DeepSkyBlue;
            Color cmd_condition = Color.Cyan;
            Color cmd_aot = Color.PowderBlue;
            Color cmd_enemy = Color.IndianRed;
            Color cmd_event = Color.Goldenrod;
            Color cmd_obj_model = Color.LightGreen;
            Color cmd_item_set = Color.SeaGreen;
            Color cmd_effect_color = Color.Yellow;

            string xFF = XBYTE.ToString("X").PadLeft(2, '0');

            //CONDITIONS
            if (xFF == "01") { new_color = cmd_event; }     //EVENT END
            if (xFF == "02") { new_color = cmd_event; }     //EVENT NEXT
            if (xFF == "03") { new_color = cmd_event; }
            if (xFF == "04") { new_color = cmd_event; } 

            if (xFF == "06") { new_color = cmd_key; }     //IF
            if (xFF == "07") { new_color = cmd_key; }     //ELSE
            if (xFF == "08") { new_color = cmd_key; }     //END IF

            if (xFF == "09") { new_color = cmd_key; }     //SLEEP
            if (xFF == "0A") { new_color = cmd_key; }     //SLEEPING
            if (xFF == "0B") { new_color = cmd_key; }     //WSLEEP
            if (xFF == "0C") { new_color = cmd_key; }     //WSLEEPING 2

            if (xFF == "0D") { new_color = cmd_key; }     //FOR
            if (xFF == "0E") { new_color = cmd_key; }     //NEXT
            if (xFF == "0F") { new_color = cmd_key; }     //WHILE
            if (xFF == "10") { new_color = cmd_key; }     //END WHILE
            if (xFF == "11") { new_color = cmd_key; }     //DO
            if (xFF == "12") { new_color = cmd_key; }     //END DO
            if (xFF == "13") { new_color = cmd_key; }     //SWITCH
            if (xFF == "14") { new_color = cmd_key; }     //CASE
            if (xFF == "15") { new_color = cmd_key; }     //DEFAULT CASE
            if (xFF == "16") { new_color = cmd_key; }     //END SWITCH

            if (xFF == "17") { new_color = cmd_key; }     //GOTO
            if (xFF == "18") { new_color = cmd_key; }     //GO SUB
            if (xFF == "19") { new_color = cmd_key; }     //RETURN

            if (xFF == "1A") { new_color = cmd_key; }     //BREAK
            if (xFF == "1B") { new_color = cmd_key; }     //FOR v2
            if (xFF == "1C") { new_color = cmd_key; }     //BREAK POINT

            if (xFF == "21") { new_color = cmd_condition; }     //CHECK FLAG
            if (xFF == "22") { new_color = cmd_flag_op; }     //SET FLAG
            if (xFF == "23") { new_color = cmd_condition; }     //COMPARE FLAG
            if (xFF == "24") { new_color = cmd_flag_op; }     //COMPARE FLAG
            if (xFF == "25") { new_color = cmd_flag_op; }     //COMPARE FLAG
            if (xFF == "26") { new_color = cmd_flag_op; }     //COMPARE FLAG
            if (xFF == "27") { new_color = cmd_flag_op; }     //COMPARE FLAG

            if (xFF == "2C") { new_color = cmd_aot; }     //SET AOT
            if (xFF == "2D") { new_color = cmd_obj_model; }
            if (xFF == "3B" || xFF == "61") { new_color = cmd_aot; }     //SET DOOR AOT
            if (xFF == "44" | xFF == "7D") { new_color = cmd_enemy; }     //SET ENEMY
            if (xFF == "46") { new_color = cmd_aot; }     //RESET AOT
            if (xFF == "4E") { new_color = cmd_aot; }     //SET ITEM AOT
            
            if (xFF == "67") { new_color = Color.LawnGreen; }
            if (xFF == "72" || xFF == "70" || xFF == "74") { new_color = cmd_effect_color; }

            LST_CODE.Items[IDX].SubItems[1].ForeColor = new_color;

        }

        //NEST THE CODE!
        private void NEST_CODE(byte XBYTE)
        {
            string FF = XBYTE.ToString("X").PadLeft(2, '0');

            if (FF == "00" && g_TAB > 0) {g_TAB -= 1;} //ESCAPE ELSE..

            if (FF == "07") {g_TAB -= 1;}   //ELSE
            if (FF == "08") {g_TAB -= 1;}   //END IF

            if (FF == "0E") {g_TAB -= 1;}
            if (FF == "10") {g_TAB -= 1;}
            if (FF == "12") {g_TAB -= 1;}
            if (FF == "16") { g_TAB -= 1;}
            //if (FF == "1A") { g_TAB -= 1; }

            if (g_TAB < 0) { g_TAB = 0; }

            //if (g_TAB < 0) {g_TAB_STR = "";}
            if (g_TAB == 0) {g_TAB_STR = "";}
            if (g_TAB == 1) {g_TAB_STR = "    ";}
            if (g_TAB == 2) { g_TAB_STR = "    " + "    "; }
            if (g_TAB == 3) { g_TAB_STR = "    " + "    " + "    "; }
            if (g_TAB == 4) { g_TAB_STR = "    " + "    " + "    " + "    "; }
            if (g_TAB == 5) { g_TAB_STR = "    " + "    " + "    " + "    " + "    "; }

            if (FF == "07") {g_TAB += 1;}       //ELSE
            if (FF == "06") { g_TAB += 1; }     //IF
            if (FF == "0D") {g_TAB += 1;}       //
            if (FF == "0F") {g_TAB += 1;}       //
            if (FF == "11") {g_TAB += 1;}       //
            if (FF == "13") { g_TAB += 1; }     //
            //if (FF == "14") { g_TAB += 1; }   //
        }

       
        /// <summary>
        /// SET BIO2 SCD CMD LENGTH
        /// </summary>
        /// <param name="xBYTE"></param>
        /// <returns></returns>
        private int SET_SCD2_CMD_LEN(byte xBYTE)
        {

            string xFF = xBYTE.ToString("X").PadLeft(2, '0');   //CONVERT TO HEX BYTE, USE PADDING!
            
            int cmd_len = 0;

            if (xFF == "00") { cmd_len = 1; }
            if (xFF == "01") { cmd_len = 2; }
            if (xFF == "02") { cmd_len = 2; }   //MIGHT BE 0x0200 INSTEAD OF 0x02 REALITY, MOST OF THE TIME FOLLOWED BY A 0x00 NOP...
            if (xFF == "03") { cmd_len = 4; }
            if (xFF == "04") { cmd_len = 2; }   //WAS 4 BEFORE...
            if (xFF == "05") { cmd_len = 2; }
            if (xFF == "06") { cmd_len = 4; }
            if (xFF == "07") { cmd_len = 4; }
            if (xFF == "08") { cmd_len = 2; }
            if (xFF == "09") { cmd_len = 4; }
            if (xFF == "0A") { cmd_len = 3; }
            if (xFF == "0B") { cmd_len = 1; }
            if (xFF == "0C") { cmd_len = 1; }
            if (xFF == "0D") { cmd_len = 6; }
            if (xFF == "0E") { cmd_len = 2; }
            if (xFF == "0F") { cmd_len = 4; }

            if (xFF == "10") { cmd_len = 2; }
            if (xFF == "11") { cmd_len = 4; }
            if (xFF == "12") { cmd_len = 2; }
            if (xFF == "13") { cmd_len = 4; }
            if (xFF == "14") { cmd_len = 6; }
            if (xFF == "15") { cmd_len = 2; }
            if (xFF == "16") { cmd_len = 2; }
            if (xFF == "17") { cmd_len = 6; }
            if (xFF == "18") { cmd_len = 2; }
            if (xFF == "19") { cmd_len = 2; }
            if (xFF == "1A") { cmd_len = 2; }
            if (xFF == "1B") { cmd_len = 6; }
            if (xFF == "1C") { cmd_len = 1; }
            if (xFF == "1D") { cmd_len = 4; }
            if (xFF == "1E") { cmd_len = 1; }
            if (xFF == "1F") { cmd_len = 1; }

            if (xFF == "20") { cmd_len = 1; }
            if (xFF == "21") { cmd_len = 4; }
            if (xFF == "22") { cmd_len = 4; }
            if (xFF == "23") { cmd_len = 6; }
            if (xFF == "24") { cmd_len = 4; }
            if (xFF == "25") { cmd_len = 4; }   //WAS 3 BEFORE...
            if (xFF == "26") { cmd_len = 6; }
            if (xFF == "27") { cmd_len = 4; }
            if (xFF == "28") { cmd_len = 2; }
            if (xFF == "29") { cmd_len = 2; }
            if (xFF == "2A") { cmd_len = 1; }
            if (xFF == "2B") { cmd_len = 6; }
            if (xFF == "2C") { cmd_len = 20; }
            if (xFF == "2D") { cmd_len = 38; }
            if (xFF == "2E") { cmd_len = 4; }	//SET BACK TO 4 AGAIN!! NOT SURE IF 3 OR 4 :S
            if (xFF == "2F") { cmd_len = 4; }

            if (xFF == "30") { cmd_len = 1; }
            if (xFF == "31") { cmd_len = 1; }
            if (xFF == "32") { cmd_len = 8; }
            if (xFF == "33") { cmd_len = 8; }
            if (xFF == "34") { cmd_len = 4; }
            if (xFF == "35") { cmd_len = 4; }   //WAS 3 BEFORE...
            if (xFF == "36") { cmd_len = 12; }
            if (xFF == "37") { cmd_len = 4; }
            if (xFF == "38") { cmd_len = 3; }
            if (xFF == "39") { cmd_len = 8; }
            if (xFF == "3A") { cmd_len = 16; }
            if (xFF == "3B") { cmd_len = 32; }
            if (xFF == "3C") { cmd_len = 2; }
            if (xFF == "3D") { cmd_len = 4; }	//MOST PROBABLY 4...    //WAS 3 BEFORE...
            if (xFF == "3E") { cmd_len = 6; }
            if (xFF == "3F") { cmd_len = 4; }

            if (xFF == "40") { cmd_len = 8; }
            if (xFF == "41") { cmd_len = 10; }
            if (xFF == "42") { cmd_len = 1; }
            if (xFF == "43") { cmd_len = 4; }
            if (xFF == "44") { cmd_len = 22; }
            if (xFF == "45") { cmd_len = 5; }
            if (xFF == "46") { cmd_len = 10; }
            if (xFF == "47") { cmd_len = 2; }
            if (xFF == "48") { cmd_len = 16; }
            if (xFF == "49") { cmd_len = 8; }
            if (xFF == "4A") { cmd_len = 2; }
            if (xFF == "4B") { cmd_len = 3; }
            if (xFF == "4C") { cmd_len = 5; }
            if (xFF == "4D") { cmd_len = 22; }
            if (xFF == "4E") { cmd_len = 22; }
            if (xFF == "4F") { cmd_len = 4; }

            if (xFF == "50") { cmd_len = 4; }
            if (xFF == "51") { cmd_len = 6; }
            if (xFF == "52") { cmd_len = 6; }
            if (xFF == "53") { cmd_len = 6; }
            if (xFF == "54") { cmd_len = 22; }
            if (xFF == "55") { cmd_len = 6; }
            if (xFF == "56") { cmd_len = 4; }
            if (xFF == "57") { cmd_len = 8; }
            if (xFF == "58") { cmd_len = 4; }
            if (xFF == "59") { cmd_len = 4; }
            if (xFF == "5A") { cmd_len = 2; }
            if (xFF == "5B") { cmd_len = 2; }
            if (xFF == "5C") { cmd_len = 3; }
            if (xFF == "5D") { cmd_len = 2; }
            if (xFF == "5E") { cmd_len = 2; }
            if (xFF == "5F") { cmd_len = 2; }

            if (xFF == "60") { cmd_len = 1; }	//was 14, might be just 1 or 2
            if (xFF == "61") { cmd_len = 4; }
            if (xFF == "62") { cmd_len = 2; }
            if (xFF == "63") { cmd_len = 1; }
            if (xFF == "64") { cmd_len = 16; }
            if (xFF == "65") { cmd_len = 2; }
            if (xFF == "66") { cmd_len = 1; }
            if (xFF == "67") { cmd_len = 28; }
            if (xFF == "68") { cmd_len = 40; }
            if (xFF == "69") { cmd_len = 30; }
            if (xFF == "6A") { cmd_len = 6; }
            if (xFF == "6B") { cmd_len = 4; }
            if (xFF == "6C") { cmd_len = 2; }   //was 1 before
            if (xFF == "6D") { cmd_len = 4; }
            if (xFF == "6E") { cmd_len = 6; }
            if (xFF == "6F") { cmd_len = 2; }

            if (xFF == "70") { cmd_len = 1; }
            if (xFF == "71") { cmd_len = 1; }
            if (xFF == "72") { cmd_len = 16; }
            if (xFF == "73") { cmd_len = 8; }
            if (xFF == "74") { cmd_len = 4; }
            if (xFF == "75") { cmd_len = 22; }
            if (xFF == "76") { cmd_len = 3; }
            if (xFF == "77") { cmd_len = 4; }
            if (xFF == "78") { cmd_len = 6; }
            if (xFF == "79") { cmd_len = 1; }
            if (xFF == "7A") { cmd_len = 16; }
            if (xFF == "7B") { cmd_len = 16; }
            if (xFF == "7C") { cmd_len = 6; }
            if (xFF == "7D") { cmd_len = 6; }
            if (xFF == "7E") { cmd_len = 6; }
            if (xFF == "7F") { cmd_len = 6; }

            if (xFF == "80") { cmd_len = 2; }
            if (xFF == "81") { cmd_len = 3; }	//seems to be 4...
            if (xFF == "82") { cmd_len = 3; }
            if (xFF == "83") { cmd_len = 1; }
            if (xFF == "84") { cmd_len = 2; }
            if (xFF == "85") { cmd_len = 6; }
            if (xFF == "86") { cmd_len = 1; }
            if (xFF == "87") { cmd_len = 1; }
            if (xFF == "88") { cmd_len = 3; }
            if (xFF == "89") { cmd_len = 1; }
            if (xFF == "8A") { cmd_len = 6; }
            if (xFF == "8B") { cmd_len = 6; }
            if (xFF == "8C") { cmd_len = 8; }
            if (xFF == "8D") { cmd_len = 24; }
            if (xFF == "8E") { cmd_len = 24; }

            if (xFF == "D4") { cmd_len = 2; }
            if (xFF == "ED") { cmd_len = 2; }

            return cmd_len;

        }



     
        private int SET_SCD3_CMD_LEN(byte xBYTE)
        {
            string xFF = xBYTE.ToString("X").PadLeft(2, '0');
            int cmd_len = 0;

            
            if (xFF == "00") { cmd_len = 1; }
            if (xFF == "01") { cmd_len = 2; }
            if (xFF == "02") { cmd_len = 1; }   
            if (xFF == "03") { cmd_len = 2; }
            if (xFF == "04") { cmd_len = 4; }   
            if (xFF == "05") { cmd_len = 2; }
            if (xFF == "06") { cmd_len = 4; }
            if (xFF == "07") { cmd_len = 4; }
            if (xFF == "08") { cmd_len = 2; }
            if (xFF == "09") { cmd_len = 1; }
            if (xFF == "0A") { cmd_len = 3; }
            if (xFF == "0B") { cmd_len = 1; }
            if (xFF == "0C") { cmd_len = 1; }
            if (xFF == "0D") { cmd_len = 6; }
            if (xFF == "0E") { cmd_len = 5; }
            if (xFF == "0F") { cmd_len = 2; }

            if (xFF == "10") { cmd_len = 4; }
            if (xFF == "11") { cmd_len = 2; }
            if (xFF == "12") { cmd_len = 4; }
            if (xFF == "13") { cmd_len = 2; }
            if (xFF == "14") { cmd_len = 4; }
            if (xFF == "15") { cmd_len = 2; }
            if (xFF == "16") { cmd_len = 2; }
            if (xFF == "17") { cmd_len = 2; }
            if (xFF == "18") { cmd_len = 6; }
            if (xFF == "19") { cmd_len = 2; }
            if (xFF == "1A") { cmd_len = 4; }
            if (xFF == "1B") { cmd_len = 2; }
            if (xFF == "1C") { cmd_len = 1; }
            if (xFF == "1D") { cmd_len = 4; }
            if (xFF == "1E") { cmd_len = 4; }
            if (xFF == "1F") { cmd_len = 4; }

            if (xFF == "20") { cmd_len = 6; }
            if (xFF == "21") { cmd_len = 4; }
            if (xFF == "22") { cmd_len = 4; }
            if (xFF == "23") { cmd_len = 1; }
            if (xFF == "24") { cmd_len = 2; }
            if (xFF == "25") { cmd_len = 4; }  
            if (xFF == "26") { cmd_len = 6; }
            if (xFF == "27") { cmd_len = 1; }
            if (xFF == "28") { cmd_len = 1; }
            if (xFF == "29") { cmd_len = 8; }
            if (xFF == "2A") { cmd_len = 6; }
            if (xFF == "2B") { cmd_len = 2; }
            if (xFF == "2C") { cmd_len = 40; }
            if (xFF == "2D") { cmd_len = 48; }
            if (xFF == "2E") { cmd_len = 6; }	
            if (xFF == "2F") { cmd_len = 2; }

            if (xFF == "30") { cmd_len = 6; }
            if (xFF == "31") { cmd_len = 6; }
            if (xFF == "32") { cmd_len = 6; }
            if (xFF == "33") { cmd_len = 4; }
            if (xFF == "34") { cmd_len = 10; }
            if (xFF == "35") { cmd_len = 6; }  
            if (xFF == "36") { cmd_len = 3; }
            if (xFF == "37") { cmd_len = 2; }
            if (xFF == "38") { cmd_len = 2; }
            if (xFF == "39") { cmd_len = 16; }
            if (xFF == "3A") { cmd_len = 16; }
            if (xFF == "3B") { cmd_len = 3; }
            if (xFF == "3C") { cmd_len = 1; }
            if (xFF == "3D") { cmd_len = 2; }	
            if (xFF == "3E") { cmd_len = 2; }
            if (xFF == "3F") { cmd_len = 3; }

            if (xFF == "40") { cmd_len = 4; }
            if (xFF == "41") { cmd_len = 3; }
            if (xFF == "42") { cmd_len = 3; }
            if (xFF == "43") { cmd_len = 6; }
            if (xFF == "44") { cmd_len = 6; }
            if (xFF == "45") { cmd_len = 4; }
            if (xFF == "46") { cmd_len = 11; }
            if (xFF == "47") { cmd_len = 3; }
            if (xFF == "48") { cmd_len = 4; }
            if (xFF == "49") { cmd_len = 1; }
            if (xFF == "4A") { cmd_len = 1; }
            if (xFF == "4B") { cmd_len = 1; }
            if (xFF == "4C") { cmd_len = 4; }
            if (xFF == "4D") { cmd_len = 4; }
            if (xFF == "4E") { cmd_len = 6; }
            if (xFF == "4F") { cmd_len = 1; }

            if (xFF == "50") { cmd_len = 2; }
            if (xFF == "51") { cmd_len = 1; }
            if (xFF == "52") { cmd_len = 2; }
            if (xFF == "53") { cmd_len = 3; }
            if (xFF == "54") { cmd_len = 4; }
            if (xFF == "55") { cmd_len = 8; }
            if (xFF == "56") { cmd_len = 8; }
            if (xFF == "57") { cmd_len = 6; }
            if (xFF == "58") { cmd_len = 6; }
            if (xFF == "59") { cmd_len = 8; }
            if (xFF == "5A") { cmd_len = 2; }
            if (xFF == "5B") { cmd_len = 6; }
            if (xFF == "5C") { cmd_len = 2; }
            if (xFF == "5D") { cmd_len = 1; }
            if (xFF == "5E") { cmd_len = 3; }
            if (xFF == "5F") { cmd_len = 2; }

            if (xFF == "60") { cmd_len = 22; }	
            if (xFF == "61") { cmd_len = 32; }
            if (xFF == "62") { cmd_len = 40; }
            if (xFF == "63") { cmd_len = 20; }
            if (xFF == "64") { cmd_len = 28; }
            if (xFF == "65") { cmd_len = 10; }
            if (xFF == "66") { cmd_len = 2; }
            if (xFF == "67") { cmd_len = 22; }
            if (xFF == "68") { cmd_len = 30; }
            if (xFF == "69") { cmd_len = 14; }
            if (xFF == "6A") { cmd_len = 16; }
            if (xFF == "6B") { cmd_len = 2; }
            if (xFF == "6C") { cmd_len = 4; }  
            if (xFF == "6D") { cmd_len = 4; }
            if (xFF == "6E") { cmd_len = 4; }
            if (xFF == "6F") { cmd_len = 2; }

            if (xFF == "70") { cmd_len = 16; }
            if (xFF == "71") { cmd_len = 18; }
            if (xFF == "72") { cmd_len = 22; }
            if (xFF == "73") { cmd_len = 24; }
            if (xFF == "74") { cmd_len = 5; }
            if (xFF == "75") { cmd_len = 2; }
            if (xFF == "76") { cmd_len = 3; }
            if (xFF == "77") { cmd_len = 12; }
            if (xFF == "78") { cmd_len = 6; }
            if (xFF == "79") { cmd_len = 4; }
            if (xFF == "7A") { cmd_len = 2; }
            if (xFF == "7B") { cmd_len = 6; }
            if (xFF == "7C") { cmd_len = 1; }
            if (xFF == "7D") { cmd_len = 24; }
            if (xFF == "7E") { cmd_len = 2; }
            if (xFF == "7F") { cmd_len = 40; }

            if (xFF == "80") { cmd_len = 4; }
            if (xFF == "81") { cmd_len = 8; }	
            if (xFF == "82") { cmd_len = 10; }
            if (xFF == "83") { cmd_len = 1; }
            if (xFF == "84") { cmd_len = 4; }
            if (xFF == "85") { cmd_len = 2; }
            if (xFF == "86") { cmd_len = 1; }
            if (xFF == "87") { cmd_len = 1; }
            if (xFF == "88") { cmd_len = 4; }
            if (xFF == "89") { cmd_len = 2; }
            if (xFF == "8A") { cmd_len = 1; }
            if (xFF == "8B") { cmd_len = 1; }
            if (xFF == "8C") { cmd_len = 1; }
            if (xFF == "8D") { cmd_len = 1; }
            if (xFF == "8E") { cmd_len = 4; }
            if (xFF == "8F") { cmd_len = 2; }
            
        




            return cmd_len;


        }


        private int GET_CMD_LEN(byte xBYTE)
        {
            string xFF = xBYTE.ToString("X").PadLeft(2, '0');	//CONVERT TO HEX BYTE, USE PADDING!

            

            int cmd_len = 0;

            if (xFF == "00") { cmd_len = 1; }
            if (xFF == "01") { cmd_len = 2; }
            if (xFF == "02") { cmd_len = 2; }   //MIGHT BE 0x0200 INSTEAD OF 0x02 REALITY, MOST OF THE TIME FOLLOWED BY A 0x00 NOP...
            if (xFF == "03") { cmd_len = 4; }
            if (xFF == "04") { cmd_len = 2; }   //WAS 4 BEFORE...
            if (xFF == "05") { cmd_len = 2; }
            if (xFF == "06") { cmd_len = 4; }
            if (xFF == "07") { cmd_len = 4; }
            if (xFF == "08") { cmd_len = 2; }
            if (xFF == "09") { cmd_len = 4; }
            if (xFF == "0A") { cmd_len = 3; }
            if (xFF == "0B") { cmd_len = 1; }
            if (xFF == "0C") { cmd_len = 1; }
            if (xFF == "0D") { cmd_len = 6; }
            if (xFF == "0E") { cmd_len = 2; }
            if (xFF == "0F") { cmd_len = 4; }

            if (xFF == "10") { cmd_len = 2; }
            if (xFF == "11") { cmd_len = 4; }
            if (xFF == "12") { cmd_len = 2; }
            if (xFF == "13") { cmd_len = 4; }
            if (xFF == "14") { cmd_len = 6; }
            if (xFF == "15") { cmd_len = 2; }
            if (xFF == "16") { cmd_len = 2; }
            if (xFF == "17") { cmd_len = 6; }
            if (xFF == "18") { cmd_len = 2; }
            if (xFF == "19") { cmd_len = 2; }
            if (xFF == "1A") { cmd_len = 2; }
            if (xFF == "1B") { cmd_len = 6; }
            if (xFF == "1C") { cmd_len = 1; }
            if (xFF == "1D") { cmd_len = 4; }
            if (xFF == "1E") { cmd_len = 1; }
            if (xFF == "1F") { cmd_len = 1; }

            if (xFF == "20") { cmd_len = 1; }
            if (xFF == "21") { cmd_len = 4; }
            if (xFF == "22") { cmd_len = 4; }
            if (xFF == "23") { cmd_len = 6; }
            if (xFF == "24") { cmd_len = 4; }
            if (xFF == "25") { cmd_len = 4; }   //WAS 3 BEFORE...
            if (xFF == "26") { cmd_len = 6; }
            if (xFF == "27") { cmd_len = 4; }
            if (xFF == "28") { cmd_len = 2; }
            if (xFF == "29") { cmd_len = 2; }
            if (xFF == "2A") { cmd_len = 1; }
            if (xFF == "2B") { cmd_len = 6; }
            if (xFF == "2C") { cmd_len = 20; }
            if (xFF == "2D") { cmd_len = 38; }
            if (xFF == "2E") { cmd_len = 4; }	//SET BACK TO 4 AGAIN!! NOT SURE IF 3 OR 4 :S
            if (xFF == "2F") { cmd_len = 4; }

            if (xFF == "30") { cmd_len = 1; }
            if (xFF == "31") { cmd_len = 1; }
            if (xFF == "32") { cmd_len = 8; }
            if (xFF == "33") { cmd_len = 8; }
            if (xFF == "34") { cmd_len = 4; }
            if (xFF == "35") { cmd_len = 4; }   //WAS 3 BEFORE...
            if (xFF == "36") { cmd_len = 12; }
            if (xFF == "37") { cmd_len = 4; }
            if (xFF == "38") { cmd_len = 3; }
            if (xFF == "39") { cmd_len = 8; }
            if (xFF == "3A") { cmd_len = 16; }
            if (xFF == "3B") { cmd_len = 32; }
            if (xFF == "3C") { cmd_len = 2; }
            if (xFF == "3D") { cmd_len = 4; }	//MOST PROBABLY 4...    //WAS 3 BEFORE...
            if (xFF == "3E") { cmd_len = 6; }
            if (xFF == "3F") { cmd_len = 4; }

            if (xFF == "40") { cmd_len = 8; }
            if (xFF == "41") { cmd_len = 10; }
            if (xFF == "42") { cmd_len = 1; }
            if (xFF == "43") { cmd_len = 4; }
            if (xFF == "44") { cmd_len = 22; }
            if (xFF == "45") { cmd_len = 5; }
            if (xFF == "46") { cmd_len = 10; }
            if (xFF == "47") { cmd_len = 2; }
            if (xFF == "48") { cmd_len = 16; }
            if (xFF == "49") { cmd_len = 8; }
            if (xFF == "4A") { cmd_len = 2; }
            if (xFF == "4B") { cmd_len = 3; }
            if (xFF == "4C") { cmd_len = 5; }
            if (xFF == "4D") { cmd_len = 22; }
            if (xFF == "4E") { cmd_len = 22; }
            if (xFF == "4F") { cmd_len = 4; }

            if (xFF == "50") { cmd_len = 4; }
            if (xFF == "51") { cmd_len = 6; }
            if (xFF == "52") { cmd_len = 6; }
            if (xFF == "53") { cmd_len = 6; }
            if (xFF == "54") { cmd_len = 22; }
            if (xFF == "55") { cmd_len = 6; }
            if (xFF == "56") { cmd_len = 4; }
            if (xFF == "57") { cmd_len = 8; }
            if (xFF == "58") { cmd_len = 4; }
            if (xFF == "59") { cmd_len = 4; }
            if (xFF == "5A") { cmd_len = 2; }
            if (xFF == "5B") { cmd_len = 2; }
            if (xFF == "5C") { cmd_len = 3; }
            if (xFF == "5D") { cmd_len = 2; }
            if (xFF == "5E") { cmd_len = 2; }
            if (xFF == "5F") { cmd_len = 2; }

            if (xFF == "60") { cmd_len = 1; }	//was 14, might be just 1 or 2
            if (xFF == "61") { cmd_len = 4; }
            if (xFF == "62") { cmd_len = 2; }
            if (xFF == "63") { cmd_len = 1; }
            if (xFF == "64") { cmd_len = 16; }
            if (xFF == "65") { cmd_len = 2; }
            if (xFF == "66") { cmd_len = 1; }
            if (xFF == "67") { cmd_len = 28; }
            if (xFF == "68") { cmd_len = 40; }
            if (xFF == "69") { cmd_len = 30; }
            if (xFF == "6A") { cmd_len = 6; }
            if (xFF == "6B") { cmd_len = 4; }
            if (xFF == "6C") { cmd_len = 2; }   //was 1 before
            if (xFF == "6D") { cmd_len = 4; }
            if (xFF == "6E") { cmd_len = 6; }
            if (xFF == "6F") { cmd_len = 2; }

            if (xFF == "70") { cmd_len = 1; }
            if (xFF == "71") { cmd_len = 1; }
            if (xFF == "72") { cmd_len = 16; }
            if (xFF == "73") { cmd_len = 8; }
            if (xFF == "74") { cmd_len = 4; }
            if (xFF == "75") { cmd_len = 22; }
            if (xFF == "76") { cmd_len = 3; }
            if (xFF == "77") { cmd_len = 4; }
            if (xFF == "78") { cmd_len = 6; }
            if (xFF == "79") { cmd_len = 1; }
            if (xFF == "7A") { cmd_len = 16; }
            if (xFF == "7B") { cmd_len = 16; }
            if (xFF == "7C") { cmd_len = 6; }
            if (xFF == "7D") { cmd_len = 6; }
            if (xFF == "7E") { cmd_len = 6; }
            if (xFF == "7F") { cmd_len = 6; }

            if (xFF == "80") { cmd_len = 2; }
            if (xFF == "81") { cmd_len = 3; }	//seems to be 4...
            if (xFF == "82") { cmd_len = 3; }
            if (xFF == "83") { cmd_len = 1; }
            if (xFF == "84") { cmd_len = 2; }
            if (xFF == "85") { cmd_len = 6; }
            if (xFF == "86") { cmd_len = 1; }
            if (xFF == "87") { cmd_len = 1; }
            if (xFF == "88") { cmd_len = 3; }
            if (xFF == "89") { cmd_len = 1; }
            if (xFF == "8A") { cmd_len = 6; }
            if (xFF == "8B") { cmd_len = 6; }
            if (xFF == "8C") { cmd_len = 8; }
            if (xFF == "8D") { cmd_len = 24; }
            if (xFF == "8E") { cmd_len = 24; }

            if (xFF == "D4") { cmd_len = 2; }
            if (xFF == "ED") { cmd_len = 2; }

            return cmd_len;
        }

        private void LST_CODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }



        public string BIO3_GET_ATTR(int IDX)
        {

          string sAttr = "";
           
            try
            {
                string opcode = LST_BYTE.Items[IDX].SubItems[1].Text.Substring(0, 2); // store 1st 2 bytes out of indexed opcode
                string bcode = LST_BYTE.Items[IDX].SubItems[1].Text;

                LST_PROP.SelectedObject = null;

                //###############################################################################################
                // x0_
                //###############################################################################################
                #region

                if (opcode == "06")
                {
                    PARSER_SCD3.x06 op06 = new PARSER_SCD3.x06();

                    op06.dummy00 = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op06.block_length = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op06.dummy01 = Convert.ToByte(bcode.Substring(6, 2), 16);


                    sAttr = "(Block Length: " + op06.block_length + ")";

                    LST_PROP.SelectedObject = op06;

                }


                if (opcode == "07")
                {
                    PARSER_SCD3.x07 op07 = new PARSER_SCD3.x07();

                    op07.dummy00 = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op07.block_length = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op07.dummy01 = Convert.ToByte(bcode.Substring(6, 2), 16);


                    sAttr = "(Block Length: " + op07.block_length + ")";

                    LST_PROP.SelectedObject = op07;

                }




                #endregion



                //###############################################################################################
                // x1_
                //###############################################################################################
                #region

                if (opcode == "19")
                {
                    PARSER_SCD3.x19 op19 = new PARSER_SCD3.x19();

                    op19.func_num = Convert.ToByte(bcode.Substring(2, 2), 16);

                    if (op19.func_num < 10)
                    {
                        sAttr = "(SCE_0" + op19.func_num + ")";
                    }
                    else
                    {
                        sAttr = "(SCE_" + op19.func_num + ")";
                    }


                    LST_PROP.SelectedObject = op19;

                }

                #endregion


                //###############################################################################################
                // x2_
                //###############################################################################################
                #region

                if (opcode == "20")
                {
                    PARSER_SCD3.x20 op20 = new PARSER_SCD3.x20();

                    op20.dummy = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op20.op = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op20.accum_id = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op20.value = HEX2INT(bcode.Substring(8, 4));
                    string calc_op = string.Empty;

                    switch (op20.op)
                    {
                        case 0: calc_op = "ADD"; break;
                        case 1: calc_op = "SUB"; break;
                        case 4: calc_op = "MOD"; break;
                        case 5: calc_op = "OR"; break;
                        case 6: calc_op = "AND"; break;
                        case 7: calc_op = "XOR"; break;
                    }

                    sAttr = "(" + op20.dummy + ", " + calc_op + " , " + op20.accum_id + ", Value" + op20.value + ")";
                    LST_PROP.SelectedObject = op20;

                }

                #endregion


                //###############################################################################################
                // x3_
                //###############################################################################################
                #region

                if (opcode == "36")
                {
                    PARSER_SCD3.x36 op36 = new PARSER_SCD3.x36();

                    op36.Item_Id = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op36.Quantity = Convert.ToByte(bcode.Substring(4, 2), 16);

                    sAttr = "(" + LIB_ITEM.BIO3_ITEM_LUT[op36.Item_Id] + ", " + op36.Quantity.ToString() + ") ";
                    LST_PROP.SelectedObject = op36;

                }


                if (opcode == "3E")
                {
                    PARSER_SCD3.x3E op3E = new PARSER_SCD3.x3E();
                    op3E.ItemID = Convert.ToByte(bcode.Substring(2, 2), 16);
                    sAttr = " (" + LIB_ITEM.BIO3_ITEM_LUT[op3E.ItemID] + ")";
                    LST_PROP.SelectedObject = op3E;
                }


                #endregion

                //###############################################################################################
                // x4_
                //###############################################################################################
                #region

                if (opcode == "47")
                {
                    PARSER_SCD3.x47 op47 = new PARSER_SCD3.x47();
                    op47.component = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op47.optional_index = Convert.ToByte(bcode.Substring(4, 2), 16);

                    sAttr = "(" + LIB_MOTION.LUT_WORK_SET_COMPONENTS[op47.component] + ", " + op47.optional_index.ToString() + ")";
                    LST_PROP.SelectedObject = op47;
                }


                if (opcode == "4C")
                {
                    PARSER_SCD3.x4C op4C = new PARSER_SCD3.x4C();

                    op4C.index = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op4C.flag = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op4C.value = Convert.ToByte(bcode.Substring(6, 2), 16);


                    sAttr = "(Index: (0x" + op4C.index.ToString("X") + "), Flag: 0x" + op4C.flag.ToString("X") + ", == 0x" + op4C.value.ToString("X") + ")";
                    LST_PROP.SelectedObject = op4C;

                }




                if (opcode == "4D")
                {
                    PARSER_SCD3.x4D op4D = new PARSER_SCD3.x4D();
                    op4D.index = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op4D.flag = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op4D.value = Convert.ToByte(bcode.Substring(6, 2), 16);

                    sAttr = "(Index: (0x" + op4D.index.ToString("X") + "), Flag: 0x" + op4D.flag.ToString("X") + ", Value(0x" + op4D.value.ToString("X") + ")";
                    LST_PROP.SelectedObject = op4D;

                }



                // EVAL CMP
                if (opcode == "4E")
                {
                    PARSER_SCD3.x4E op4E = new PARSER_SCD3.x4E();
                    op4E.dummy = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op4E.var = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op4E.op = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op4E.Value = HEX2INT(bcode.Substring(8, 4));


                    sAttr = " (0x" + op4E.var.ToString("X") + " " + LIB_AOT_GEN.LUT_EVAL_CMP_OP[op4E.op] + " " + op4E.Value.ToString() + " )";
                    LST_PROP.SelectedObject = op4E;
                }


                #endregion


                //###############################################################################################
                // x5_
                //###############################################################################################
                #region

                if (opcode == "50")
                {
                    PARSER_SCD3.x50 op50 = new PARSER_SCD3.x50();

                    op50.CameraID = Convert.ToByte(bcode.Substring(2, 2), 16);

                    sAttr = "(Camera: " + op50.CameraID + ")";
                    LST_PROP.SelectedObject = op50;

                }


                if (opcode == "53")
                {
                    PARSER_SCD3.x53 op53 = new PARSER_SCD3.x53();
                    op53.FromCam = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op53.TargetCam = Convert.ToByte(bcode.Substring(4, 2), 16);

                    sAttr = "(From Cam: 0x" + op53.FromCam.ToString("X") + ", Target Cam: 0x" + op53.TargetCam.ToString("X");
                    LST_PROP.SelectedObject = op53;
                }



                if (opcode == "55")
                {
                    PARSER_SCD3.x55 op55 = new PARSER_SCD3.x55();
                    op55.dummy = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op55.posx = HEX2INT(bcode.Substring(4, 4));
                    op55.posy = HEX2INT(bcode.Substring(8, 4));
                    op55.posz = HEX2INT(bcode.Substring(12, 4));

                    sAttr = "(X: " + op55.posx.ToString() + ", Y: " + op55.posy.ToString() + ", Z: " + op55.posz.ToString() + ")";
                    LST_PROP.SelectedObject = op55;

                }



                if (opcode == "56")
                {
                    PARSER_SCD3.x56 op56 = new PARSER_SCD3.x56();
                    op56.dummy = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op56.posx = HEX2INT(bcode.Substring(4, 4));
                    op56.posy = HEX2INT(bcode.Substring(8, 4));
                    op56.posz = HEX2INT(bcode.Substring(12, 4));

                    sAttr = "(X: " + op56.posx.ToString() + ", Y: " + op56.posy.ToString() + ", Z: " + op56.posz.ToString() + ")";
                    LST_PROP.SelectedObject = op56;

                }


                #endregion


                //###############################################################################################
                // x6_
                //###############################################################################################
                #region



                if (opcode == "61")
                {
                    PARSER_SCD3.x61 op61 = new PARSER_SCD3.x61();
                    op61.DoorIndex = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op61.ubyte00 = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op61.ubyte01 = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op61.ubyte02 = Convert.ToByte(bcode.Substring(8, 2), 16);
                    op61.ubyte03 = Convert.ToByte(bcode.Substring(10, 2), 16);
                    op61.posx = HEX2INT(bcode.Substring(12, 4));
                    op61.posy = HEX2INT(bcode.Substring(16, 4));
                    op61.posz = HEX2INT(bcode.Substring(20, 4));
                    op61.posr = HEX2INT(bcode.Substring(24, 4));
                    op61.nextx = HEX2INT(bcode.Substring(28, 4));
                    op61.nexty = HEX2INT(bcode.Substring(32, 4));
                    op61.nextz = HEX2INT(bcode.Substring(36, 4));
                    op61.nextr = HEX2INT(bcode.Substring(40, 4));
                    op61.stageID = Convert.ToByte(bcode.Substring(44, 2), 16);
                    op61.roomNum = Convert.ToByte(bcode.Substring(46, 2), 16);
                    op61.setCam = Convert.ToByte(bcode.Substring(48, 2), 16);
                    op61.ubyte04 = Convert.ToByte(bcode.Substring(50, 2), 16);
                    op61.DoorType = Convert.ToByte(bcode.Substring(52, 2), 16);
                    op61.Handle = Convert.ToByte(bcode.Substring(54, 2), 16);
                    op61.ubyte05 = Convert.ToByte(bcode.Substring(56, 2), 16);
                    op61.LockFlag = Convert.ToByte(bcode.Substring(58, 2), 16);
                    op61.KeyId = Convert.ToByte(bcode.Substring(60, 2), 16);


                    sAttr = "(" +
                                           op61.DoorIndex + ", " + op61.ubyte00 + ", " + op61.ubyte01 + ", " + op61.ubyte02 + "," + op61.ubyte03 + ", X: " +
                                           op61.posx + ", Y: " + op61.posy + ", Z: " + op61.posz + ", R: " + op61.posr + ", NX: " +
                                          op61.nextx + ", NY: " + op61.nexty + ", NZ: " + op61.nextz + ", NR: " + op61.nextr + ", Stage: " + op61.stageID + ", RoomNum: 0x" + op61.roomNum.ToString("X") + ", Cam: " + op61.setCam + ", " + op61.ubyte04 +
                                          ", Door Type: " + op61.DoorType + ".DO2 " + ", Handle: " + op61.Handle + ", LockFlag: " + op61.LockFlag + ", Key: " + LIB_ITEM.BIO3_ITEM_LUT[op61.KeyId];
                    ;

                    LST_PROP.SelectedObject = op61;


                }


                if (opcode == "63")
                {

                    PARSER_SCD3.x63 op63 = new PARSER_SCD3.x63();
                    op63.EvtIdx = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op63.eventType = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op63.ActivationType = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op63.ubyte00 = Convert.ToByte(bcode.Substring(8, 2), 16);
                    op63.ubyte01 = Convert.ToByte(bcode.Substring(10, 2), 16);
                    op63.ubyte02 = Convert.ToByte(bcode.Substring(12, 2), 16);
                    op63.posx = HEX2INT(bcode.Substring(14, 4));
                    op63.posy = HEX2INT(bcode.Substring(18, 4));
                    op63.width = HEX2INT(bcode.Substring(22, 4));
                    op63.height = HEX2INT(bcode.Substring(26, 4));
                    op63.ubyte03 = Convert.ToByte(bcode.Substring(30, 2), 16);
                    op63.InputItem = Convert.ToByte(bcode.Substring(32, 2), 16);


                    if (op63.ActivationType != 0x21)
                    {
                        sAttr = "(" +
                                      op63.EvtIdx + ", " + LIB_AOT_GEN.LUT_AOT_TYPES[op63.eventType] + ", " + LIB_AOT_GEN.LUT_AOT_ACTIVATION[op63.ActivationType] + ", " + op63.ubyte00 + "," + op63.ubyte01 + "," +
                                      op63.ubyte02 + ", X: " + op63.posx + ", Y: " + op63.posy + ", W: " + op63.width + ", H: " +
                                     op63.height + ", " + op63.ubyte03.ToString() + ")";
                    }
                    else if (op63.ActivationType == 0x21)
                    {
                        sAttr = "(" +
                                      op63.EvtIdx + ", " + LIB_AOT_GEN.LUT_AOT_TYPES[op63.eventType] + ", " + LIB_AOT_GEN.LUT_AOT_ACTIVATION[op63.ActivationType] + ", " + op63.ubyte00 + "," + op63.ubyte01 + "," +
                                      op63.ubyte02 + ", X: " + op63.posx + ", Y: " + op63.posy + ", W: " + op63.width + ", H: " +
                                     op63.height + ", " + op63.ubyte03.ToString() + ", " + LIB_ITEM.BIO3_ITEM_LUT[op63.InputItem] + ")";
                    }




                    LST_PROP.SelectedObject = op63;


                }

                ///ITEM AOT///
                if (opcode == "67")
                {
                    PARSER_SCD3.x67 op67 = new PARSER_SCD3.x67();

                    op67.dummy = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op67.index = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op67.flag00 = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op67.flag01 = Convert.ToByte(bcode.Substring(8, 2), 16);
                    op67.ushort00 = HEX2INT(bcode.Substring(10, 4));
                    op67.posX = HEX2INT(bcode.Substring(14, 4));
                    op67.posY = HEX2INT(bcode.Substring(18, 4));
                    op67.posZ = HEX2INT(bcode.Substring(22, 4));
                    op67.Ushort01 = HEX2INT(bcode.Substring(26, 4));
                    op67.ItemID = Convert.ToByte(bcode.Substring(28, 2), 16);
                    op67.flag02 = Convert.ToByte(bcode.Substring(30, 2), 16);
                    op67.flag03 = Convert.ToByte(bcode.Substring(32, 2), 16);

                    op67.Ushort02 = HEX2INT(bcode.Substring(34, 4));
                    op67.Ushort03 = HEX2INT(bcode.Substring(38, 4));

                    op67.ModelPickup = Convert.ToByte(bcode.Substring(42, 2), 16);




                    sAttr = "(" +
                                       op67.index + ", " + op67.flag00 + ", " + op67.flag01 + ", " + op67.ushort00 + ", X: " + op67.posX + ", Y: " +
                                        op67.posY + ", Z: " + op67.posZ + ", " + op67.Ushort01 + ", " + LIB_ITEM.BIO3_ITEM_LUT[op67.ItemID] + "(0x" + op67.ItemID.ToString("X") + "), " +
                                       op67.flag02 + ", " + op67.flag03 + ", " + op67.Ushort02 + ", " + op67.Ushort03 + ", " + op67.ModelPickup + ")";

                    LST_PROP.SelectedObject = op67;



                }


                #endregion



                //###############################################################################################
                // x7_
                //###############################################################################################
                #region


                if (opcode == "70")
                {
                    PARSER_SCD3.x70 op70 = new PARSER_SCD3.x70();
                    op70.Type = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op70.Ubyte00 = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op70.Ubyte01 = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op70.Ubyte02 = Convert.ToByte(bcode.Substring(8, 2), 16);
                    op70.Ubyte03 = Convert.ToByte(bcode.Substring(10, 2), 16);
                    op70.Scale = HEX2INT(bcode.Substring(12, 4));
                    op70.posX = HEX2INT(bcode.Substring(16, 4));
                    op70.posy = HEX2INT(bcode.Substring(20, 4));
                    op70.posZ = HEX2INT(bcode.Substring(24, 4));
                    op70.posR = HEX2INT(bcode.Substring(28, 4));

                    sAttr = "(0x" + op70.Type.ToString("X") + ", " + op70.Ubyte00.ToString("X") + ", " + op70.Ubyte01.ToString("X") + ", "
                        + op70.Ubyte02.ToString("X") + ", " + op70.Ubyte03.ToString("X") +  ", Scale: " + op70.Scale.ToString() + ", X: " + op70.posX.ToString() + ", Y: " + op70.posy.ToString() + ", Z: " + op70.posZ.ToString() + ", R: " + op70.posR.ToString() + ")";


                    LST_PROP.SelectedObject = op70;

                }


                // ESPRD3D_ON
                if (opcode == "72")
                {

                    PARSER_SCD3.x72 op72 = new PARSER_SCD3.x72();
                    op72.Ubyte00 = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op72.Ubyte01 = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op72.EffectColor = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op72.Ubyte02 = Convert.ToByte(bcode.Substring(8, 2), 16);
                    op72.Ubyte03 = Convert.ToByte(bcode.Substring(10, 2), 16);
                    op72.Ubyte04 = Convert.ToByte(bcode.Substring(12, 2), 16);
                    op72.PosX = HEX2INT(bcode.Substring(14, 4));
                    op72.PosY = HEX2INT(bcode.Substring(18, 4));
                    op72.PosZ = HEX2INT(bcode.Substring(22, 4));
                    op72.PosR = HEX2INT(bcode.Substring(26, 4));

                    sAttr = "(" +
                                   op72.Ubyte00 + ", " + op72.Ubyte01 + ", " + LIB_AOT_GEN.LUT_EFF_COLOR[op72.EffectColor] + ",  " +
                                   op72.Ubyte02 + ", " + op72.Ubyte03 + ", " + op72.Ubyte04 + ", X: " + op72.PosX + "), Y: " +
                                   op72.PosY + ", Z: " + op72.PosZ + ", R: " + op72.PosR + ")";


                    LST_PROP.SelectedObject = op72;

                }



                if (opcode == "74")
                {
                    PARSER_SCD3.x74 op74 = new PARSER_SCD3.x74();
                    op74.EffectID = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op74.Flag = Convert.ToByte(bcode.Substring(4, 2), 16);

                    sAttr = "(0x" + op74.EffectID.ToString("X") + ", " + op74.Flag.ToString() + ")";
                    LST_PROP.SelectedObject = op74;

                }



                if (opcode == "78")
                {
                    PARSER_SCD3.x78 op78 = new PARSER_SCD3.x78();
                   op78.BgmID = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op78.Action = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op78.Ubyte00 = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op78.Vol = Convert.ToByte(bcode.Substring(8, 2), 16);
                    op78.Channel = Convert.ToByte(bcode.Substring(10, 2), 16);

                    string action = string.Empty;
                    if (op78.Action == 01) { action = "Play"; }
                    if (op78.Action == 02) { action = "Stop"; }

                    sAttr = "(BGM ID: " + op78.BgmID.ToString() + ", Action: " + action + ", Ubyte: " + op78.Ubyte00.ToString() + ", Volume: " + op78.Vol.ToString() + ", Channel: " + op78.Channel.ToString() + ")";
                    LST_PROP.SelectedObject = op78;  

                }

                //EM_SET
                if (opcode == "7D")
                {

                   
                    

                  PARSER_SCD3.x7D op7D = new PARSER_SCD3.x7D();
                    op7D.opdummy = Convert.ToByte(bcode.Substring(2, 2), 16);               
                    op7D.emIndex = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op7D.emdID = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op7D.emPose = Convert.ToByte(bcode.Substring(8, 2), 16);
                    op7D.AnimFlag00 = HEX2INT(bcode.Substring(10, 4));
                    op7D.Ushort00 = HEX2INT(bcode.Substring(14, 4));
                    op7D.SND = Convert.ToByte(bcode.Substring(16, 2), 16);
                    op7D.TEX = Convert.ToByte(bcode.Substring(18, 2), 16);
                    op7D.emFlag = Convert.ToByte(bcode.Substring(20, 2), 16);
                    op7D.PosX = HEX2INT(bcode.Substring(22, 4));
                    op7D.PosY = HEX2INT(bcode.Substring(26, 4));
                    op7D.PosZ = HEX2INT(bcode.Substring(30, 4));
                    op7D.PosR = HEX2INT(bcode.Substring(34, 4));
                    op7D.Ushort01 = HEX2INT(bcode.Substring(38, 4));
                    op7D.Ushort02 = HEX2INT(bcode.Substring(42, 4));

                    sAttr = "(" +
                                   "[" + op7D.emIndex + "]," + LIB_EMD.BIO3_LUT_EMD[op7D.emdID] + op7D.emPose + ",  " + op7D.AnimFlag00 + ",  " +
                                   op7D.Ushort00 + ", SND_" + op7D.SND + ", TEX_" + op7D.TEX + ", "  + op7D.emFlag + "), X: " +
                                   op7D.PosX + ", Y: " + op7D.PosY + ",Z: " + op7D.PosZ + ", " + op7D.PosR + ", " + ", " + op7D.Ushort01 + " ," + op7D.Ushort02 + ")";

                    LST_PROP.SelectedObject = op7D;

                    

                    // assign selected opcode data to transferable struct
                    EM_SET._opdummy = op7D.opdummy;
                    EM_SET._emIndex = op7D.emIndex;
                    EM_SET._emdID = op7D.emdID;
                    EM_SET._emPose = op7D.emPose;
                    EM_SET._AnimFlag00 = op7D.AnimFlag00;
                    EM_SET._ushort00 = op7D.Ushort00;
                    EM_SET._SND = op7D.SND;
                    EM_SET._TEX = op7D.TEX;
                    EM_SET._emFlag = op7D.emFlag;
                    EM_SET._posx = op7D.PosX;
                    EM_SET._posy = op7D.PosY;
                    EM_SET._posz = op7D.PosZ;
                    EM_SET._posr = op7D.PosR;
                    EM_SET._ushort01 = op7D.Ushort01;
                    EM_SET._ushort02 = op7D.Ushort02;

                    

                }

                #endregion


                //###############################################################################################
                // x8_
                //###############################################################################################

                if (opcode == "80")
                {

                    PARSER_SCD3.x80 op80 = new PARSER_SCD3.x80();

                    op80.Anim00 = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op80.Anim01 = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op80.Speed = Convert.ToByte(bcode.Substring(6, 2), 16);

                    sAttr = "(Anim:" + op80.Anim00.ToString() + ", Anim:" + op80.Anim01.ToString() + ", " + op80.Speed.ToString() + ")";

                    LST_PROP.SelectedObject = op80;

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return sAttr;

        }


        private string BIO2_GET_ATTR(int IDX)
        {
            string sATTR = "";

            try
            {
                string opcode = LST_BYTE.Items[IDX].SubItems[1].Text.Substring(0, 2);
                string bcode = LST_BYTE.Items[IDX].SubItems[1].Text;

                LST_PROP.SelectedObject = null;
                //###########################################################################################
                // x0_
                //###########################################################################################
                #region
                //x04////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "04")
                {
                    PARSER_SCD2.x04 op04 = new PARSER_SCD2.x04();
                    
                    
                    op04.Condition = Convert.ToByte(bcode.Substring(2, 2), 16);

                    sATTR = "(" + op04.Condition + "):";
                    LST_PROP.SelectedObject = op04;
                }
                //x09////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "09")
                {
                    PARSER_SCD2.x09 op09 = new PARSER_SCD2.x09();

                    op09.Count = HEX2INT(bcode.Substring(4, 4));

                    sATTR = "(" + op09.Count + ")";
                    LST_PROP.SelectedObject = op09;
                }
                //x0A////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "0A")
                {
                    PARSER_SCD2.x0A op0A = new PARSER_SCD2.x0A();

                    op0A.Count = HEX2INT(bcode.Substring(2, 4));

                    sATTR = "(" + op0A.Count + ")";
                    LST_PROP.SelectedObject = op0A;
                }
                //x0D////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "0D")
                {
                    PARSER_SCD2.x0D op0D = new PARSER_SCD2.x0D();

                    op0D.Dummy = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op0D.Length = HEX2INT(bcode.Substring(4, 4));
                    op0D.Count = HEX2INT(bcode.Substring(8, 4));

                    sATTR = "(" + op0D.Count + "):";
                    LST_PROP.SelectedObject = op0D;
                }
                #endregion

                //###########################################################################################
                // x1_
                //###########################################################################################
                #region
                //x14////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "14")
                {
                    PARSER_SCD2.x14 op14 = new PARSER_SCD2.x14();

                    op14.Dummy = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op14.Length = HEX2INT(bcode.Substring(4, 4));
                    op14.Count = HEX2INT(bcode.Substring(8, 4));

                    sATTR = "(" + op14.Count + "):";
                    LST_PROP.SelectedObject = op14;
                }
                //x18////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "18")
                {
                    PARSER_SCD2.x18 op18 = new PARSER_SCD2.x18();

                    op18.Sub = Convert.ToByte(bcode.Substring(2, 2), 16);

                    sATTR = "(" + op18.Sub + ")";
                    LST_PROP.SelectedObject = op18;
                }
                //x1A////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "1A")
                {
                    PARSER_SCD2.x1A op1A = new PARSER_SCD2.x1A();

                    op1A.U0 = Convert.ToByte(bcode.Substring(2, 2), 16);

                    sATTR = "(" + op1A.U0 + "):";
                    LST_PROP.SelectedObject = op1A;
                }
                #endregion

                //###########################################################################################
                // x2_
                //###########################################################################################
                #region
                //x21////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "21")
                {
                    PARSER_SCD2.x21 op21 = new PARSER_SCD2.x21();

                    op21.Array = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op21.Flag = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op21.Value = Convert.ToByte(bcode.Substring(6, 2), 16);

                    string tmp = GET_FLAG_REGISTER(op21.Array);

                    sATTR = "(" + tmp + "(" + op21.Flag + ") == " + op21.Value + ")";
                    LST_PROP.SelectedObject = op21;
                }

                //x22////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "22")
                {
                    PARSER_SCD2.x22 op22 = new PARSER_SCD2.x22();

                    op22.Array = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op22.Flag = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op22.Value = Convert.ToByte(bcode.Substring(6, 2), 16);

                    string tmp = GET_FLAG_REGISTER(op22.Array);

                    sATTR = "(" + tmp + "(" + op22.Flag + ") = " + op22.Value + ")";
                    LST_PROP.SelectedObject = op22;
                }

                //x23////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "23")
                {
                    PARSER_SCD2.x23 op23 = new PARSER_SCD2.x23();

                    op23.Dummy = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op23.Variable = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op23.Comparison = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op23.Value = HEX2INT(bcode.Substring(8, 4));

                    string varw = GET_VAR_NAME(op23.Variable);
                    string comp = op23.Comparison.ToString();

                    if (op23.Comparison == 0) { comp = "=="; }
                    if (op23.Comparison == 1) { comp = ">"; }
                    if (op23.Comparison == 2) { comp = ">="; }
                    if (op23.Comparison == 3) { comp = "<"; }
                    if (op23.Comparison == 4) { comp = "<="; }
                    if (op23.Comparison == 5) { comp = "!="; }

                    sATTR = "(" +
                        varw + " " + comp + " " + op23.Value + ")";

                    LST_PROP.SelectedObject = op23;
                }
                //x24////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "24")
                {
                    PARSER_SCD2.x24 op24 = new PARSER_SCD2.x24();

                    op24.Variable = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op24.Value = HEX2INT(bcode.Substring(4, 4));

                    string varw = op24.Variable.ToString();

                    if (op24.Variable == 0) { varw = "F_ATARI"; }
                    if (op24.Variable == 1) { varw = "U_ATARI"; }
                    if (op24.Variable == 2) { varw = "USE_ID"; }
                    if (op24.Variable == 3) { varw = "GET_ID"; }
                    if (op24.Variable == 4) { varw = "SCE_WORK(0)"; }
                    if (op24.Variable == 5) { varw = "SCE_WORK(1)"; }
                    if (op24.Variable == 6) { varw = "SCE_WORK(2)"; }
                    if (op24.Variable == 7) { varw = "SCE_WORK(3)"; }
                    if (op24.Variable == 8) { varw = "SCE_WORK(4)"; }
                    if (op24.Variable == 9) { varw = "SCE_WORK(5)"; }
                    if (op24.Variable == 10) { varw = "SCE_WORK(6)"; }
                    if (op24.Variable == 11) { varw = "SCE_WORK(7)"; }
                    if (op24.Variable == 12) { varw = "DSCE_WORK(0)"; }
                    if (op24.Variable == 13) { varw = "DSCE_WORK(1)"; }
                    if (op24.Variable == 14) { varw = "DSCE_WORK(2)"; }
                    if (op24.Variable == 15) { varw = "DSCE_WORK(3)"; }
                    if (op24.Variable == 16) { varw = "TMP_WORK(0)"; }
                    if (op24.Variable == 17) { varw = "TMP_WORK(1)"; }
                    if (op24.Variable == 18) { varw = "TMP_WORK(2)"; }
                    if (op24.Variable == 19) { varw = "TMP_WORK(3)"; }
                    if (op24.Variable == 20) { varw = "TMP_WORK(4)"; }
                    if (op24.Variable == 21) { varw = "TMP_WORK(5)"; }
                    if (op24.Variable == 22) { varw = "TMP_WORK(6)"; }
                    if (op24.Variable == 23) { varw = "TMP_WORK(7)"; }
                    if (op24.Variable == 24) { varw = "STAGE"; }
                    if (op24.Variable == 25) { varw = "ROOM"; }
                    if (op24.Variable == 26) { varw = "CAMERA"; }
                    if (op24.Variable == 27) { varw = "OLD_ROOM"; }
                    if (op24.Variable == 28) { varw = "OLD_CAMERA"; }
                    if (op24.Variable == 29) { varw = "SCE_RANDOM"; }
                    if (op24.Variable == 30) { varw = "PLD"; }
                    if (op24.Variable == 31) { varw = "DEF_EM_SET"; }
                    if (op24.Variable == 32) { varw = "DEF_AOT_SET"; }

                    sATTR = "(" + varw + " = " + op24.Value + ")";

                    LST_PROP.SelectedObject = op24;
                }
                //x25////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "25")
                {
                    PARSER_SCD2.x25 op25 = new PARSER_SCD2.x25();

                    op25.Target = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op25.Source = Convert.ToByte(bcode.Substring(4, 2), 16);
                    
                    string tvarw = GET_VAR_NAME(op25.Target);
                    string svarw = GET_VAR_NAME(op25.Source);
                    
                    sATTR = "(" + tvarw + " = " + svarw + ")";

                    LST_PROP.SelectedObject = op25;
                }
                //x26////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "26")
                {
                    PARSER_SCD2.x26 op26 = new PARSER_SCD2.x26();

                    op26.Dummy = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op26.Operation = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op26.Variable = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op26.Value = HEX2INT(bcode.Substring(8, 4));

                    string sop = op26.Operation.ToString();

                    if (op26.Operation == 0) { sop = " + "; }
                    if (op26.Operation == 1) { sop = " - "; }
                    if (op26.Operation == 2) { sop = " * "; }
                    if (op26.Operation == 3) { sop = " / "; }
                    if (op26.Operation == 4) { sop = " % "; }
                    if (op26.Operation == 5) { sop = " | "; }
                    if (op26.Operation == 6) { sop = " & "; }
                    if (op26.Operation == 7) { sop = " ^ "; }
                    if (op26.Operation == 8) { sop = " ~ "; }
                    if (op26.Operation == 9) { sop = " >> "; }
                    if (op26.Operation == 10) { sop = " << "; }
                    if (op26.Operation == 11) { sop = " ASR "; }

                    string varw = GET_VAR_NAME(op26.Variable);

                    sATTR = "(" + op26.Dummy + ", " + varw + " " + sop + " " + op26.Value + ")";

                    LST_PROP.SelectedObject = op26;
                }
                //x27////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "27")
                {
                    PARSER_SCD2.x27 op27 = new PARSER_SCD2.x27();

                    op27.Operation = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op27.Variable = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op27.Variable2 = Convert.ToByte(bcode.Substring(6, 2), 16);

                    string sop = op27.Operation.ToString();

                    if (op27.Operation == 0) { sop = " + "; }
                    if (op27.Operation == 1) { sop = " - "; }
                    if (op27.Operation == 2) { sop = " * "; }
                    if (op27.Operation == 3) { sop = " / "; }
                    if (op27.Operation == 4) { sop = " % "; }
                    if (op27.Operation == 5) { sop = " | "; }
                    if (op27.Operation == 6) { sop = " & "; }
                    if (op27.Operation == 7) { sop = " ^ "; }
                    if (op27.Operation == 8) { sop = " ~ "; }
                    if (op27.Operation == 9) { sop = " >> "; }
                    if (op27.Operation == 10) { sop = " << "; }
                    if (op27.Operation == 11) { sop = " ASR "; }

                    sATTR = "(" + GET_VAR_NAME(op27.Variable) + " " + sop + " " + GET_VAR_NAME(op27.Variable2) + ")";

                    LST_PROP.SelectedObject = op27;
                }
                //x29////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "29")
                {
                    PARSER_SCD2.x29 op29 = new PARSER_SCD2.x29();

                    op29.Camera = Convert.ToByte(bcode.Substring(2, 2), 16);

                    sATTR = "(" + op29.Camera + ")";
                    LST_PROP.SelectedObject = op29;
                }
                //x2B////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "2B")
                {
                    PARSER_SCD2.x2B op2B = new PARSER_SCD2.x2B();

                    op2B.U0 = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op2B.MSG_ID = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op2B.U1 = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op2B.Mode = HEX2INT(bcode.Substring(8, 4));

                    sATTR = "(" + op2B.U0 + ", " + op2B.MSG_ID + ", " + op2B.U1 + ", " + op2B.Mode + ")";

                    LST_PROP.SelectedObject = op2B;
                }
                //x2C////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "2C")
                {
                    PARSER_SCD2.x2C op2C = new PARSER_SCD2.x2C();

                    op2C.AOT = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op2C.ID = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op2C.Type = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op2C.Floor = Convert.ToByte(bcode.Substring(8, 2), 16);
                    op2C.Super = Convert.ToByte(bcode.Substring(10, 2), 16);
                    op2C.X = HEX2INT(bcode.Substring(12, 4));
                    op2C.Y = HEX2INT(bcode.Substring(16, 4));
                    op2C.Width = Convert.ToUInt16(HEX2INT(bcode.Substring(20, 4)));
                    op2C.Depth = Convert.ToUInt16(HEX2INT(bcode.Substring(24, 4)));
                    op2C.Data0 = HEX2INT(bcode.Substring(28, 4));
                    op2C.Data1 = HEX2INT(bcode.Substring(32, 4));
                    op2C.Data2 = HEX2INT(bcode.Substring(36, 4));

                    sATTR = "(" +
                        op2C.AOT + ", " + GET_AOT_ID(op2C.ID) + ", " + op2C.Type + ", " + op2C.Floor + ", " + op2C.Super + ", " +
                        op2C.X + ", " + op2C.Y + ", " + op2C.Width + ", " + op2C.Depth + ", " + op2C.Data0 + ", " + op2C.Data1 + ", " + op2C.Data2 + ")";

                    LST_PROP.SelectedObject = op2C;
                }
                //x2D////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "2D")
                {
                    PARSER_SCD2.x2D op2D = new PARSER_SCD2.x2D();

                    op2D.MD1_ID = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op2D.Texture = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op2D.Animation = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op2D.Speed = Convert.ToByte(bcode.Substring(8, 2), 16);
                    op2D.Floor = Convert.ToByte(bcode.Substring(10, 2), 16);
                    op2D.Super = Convert.ToByte(bcode.Substring(12, 2), 16);
                    op2D.Type = Convert.ToByte(bcode.Substring(14, 2), 16);
                    op2D.S_Flag = HEX2INT(bcode.Substring(16, 4));
                    op2D.BE_Flag = HEX2INT(bcode.Substring(20, 4));
                    op2D.Attribute = HEX2INT(bcode.Substring(24, 4));
                    op2D.X = HEX2INT(bcode.Substring(28, 4));
                    op2D.Z = HEX2INT(bcode.Substring(32, 4));
                    op2D.Y = HEX2INT(bcode.Substring(36, 4));
                    op2D.Rotation_X = HEX2INT(bcode.Substring(40, 4));
                    op2D.Rotation_Z = HEX2INT(bcode.Substring(44, 4));
                    op2D.Rotation_Y = HEX2INT(bcode.Substring(48, 4));
                    op2D.Offset_X = HEX2INT(bcode.Substring(52, 4));
                    op2D.Offset_Z = HEX2INT(bcode.Substring(56, 4));
                    op2D.Offset_Y = HEX2INT(bcode.Substring(60, 4));
                    op2D.Size_X = HEX2INT(bcode.Substring(64, 4));
                    op2D.Size_Z = HEX2INT(bcode.Substring(68, 4));
                    op2D.Size_Y = HEX2INT(bcode.Substring(72, 4));

                    sATTR = "(" + op2D.MD1_ID + ", " + op2D.Texture + ", " + op2D.Animation + ", " + op2D.Speed + ", " + op2D.Floor + ", " + op2D.Super + ", " +
                    op2D.Type + ", " + op2D.S_Flag + ", " + op2D.BE_Flag + ", " + op2D.Attribute + ", " + op2D.X + ", " + op2D.Z + ", " + op2D.Y + ", " +
                    op2D.Rotation_X + ", " + op2D.Rotation_Z + ", " + op2D.Rotation_Y + ", " + op2D.Offset_X + ", " + op2D.Offset_Z + ", " + op2D.Offset_Y + ", " +
                    op2D.Size_X + ", " + op2D.Size_Z + ", " + op2D.Size_Y + ")";

                    LST_PROP.SelectedObject = op2D;
                }
                //x2E////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "2E")
                {
                    PARSER_SCD2.x2E op2E = new PARSER_SCD2.x2E();

                    op2E.Component = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op2E.ID = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op2E.Dummy = Convert.ToByte(bcode.Substring(6, 2), 16);

                    string comp = op2E.Component.ToString();

                    if (op2E.Component == 0) { comp = "PLAYER"; }
                    if (op2E.Component == 3) { comp = "ENEMY/NPC"; }
                    if (op2E.Component == 4) { comp = "OBJECT"; }

                    sATTR = "(" +
                        comp + ", " + op2E.ID + ", " + op2E.Dummy + ")";

                    LST_PROP.SelectedObject = op2E;
                }
                //x2F////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "2F")
                {
                    PARSER_SCD2.x2F op2F = new PARSER_SCD2.x2F();

                    op2F.Component = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op2F.Value = HEX2INT(bcode.Substring(4, 4));

                    sATTR = "(" + op2F.Component + ", " + op2F.Value + ")";
                    LST_PROP.SelectedObject = op2F;
                }
                #endregion

                //###########################################################################################
                // x3_
                //###########################################################################################
                #region
                //x32////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "32")
                {
                    PARSER_SCD2.x32 op32 = new PARSER_SCD2.x32();

                    op32.Dummy = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op32.X = HEX2INT(bcode.Substring(4, 4));
                    op32.Z = HEX2INT(bcode.Substring(8, 4));
                    op32.Y = HEX2INT(bcode.Substring(12, 4));

                    sATTR = "(" + op32.Dummy + ", " + op32.X + ", " + op32.Z + ", " + op32.Y + ")";

                    LST_PROP.SelectedObject = op32;
                }
                //x36////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "36")
                {
                    PARSER_SCD2.x36 op36 = new PARSER_SCD2.x36();

                    op36.U0 = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op36.U1 = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op36.U2 = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op36.U3 = Convert.ToByte(bcode.Substring(8, 2), 16);
                    op36.U4 = Convert.ToByte(bcode.Substring(10, 2), 16);
                    op36.X = HEX2INT(bcode.Substring(12, 4));
                    op36.Z = HEX2INT(bcode.Substring(16, 4));
                    op36.Y = HEX2INT(bcode.Substring(20, 4));

                    sATTR = "(" + op36.U0 + ", " + op36.U1 + ", " + op36.U2 + ", " + op36.U3 + ", " + op36.U4 + ", " +
                    op36.X + ", " + op36.Z + ", " + op36.Y + ")";

                    LST_PROP.SelectedObject = op36;
                }
                //x3B////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "3B")
                {
                    PARSER_SCD2.x3B op3B = new PARSER_SCD2.x3B();

                    op3B.AOT = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op3B.ID = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op3B.Type = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op3B.Floor = Convert.ToByte(bcode.Substring(8, 2), 16);
                    op3B.Super = Convert.ToByte(bcode.Substring(10, 2), 16);
                    op3B.X = HEX2INT(bcode.Substring(12, 4));
                    op3B.Y = HEX2INT(bcode.Substring(16, 4));
                    op3B.Width = Convert.ToUInt16(HEX2INT(bcode.Substring(20, 4)));
                    op3B.Depth = Convert.ToUInt16(HEX2INT(bcode.Substring(24, 4)));
                    op3B.Target_X = HEX2INT(bcode.Substring(28, 4));
                    op3B.Target_Z = HEX2INT(bcode.Substring(32, 4));
                    op3B.Target_Y = HEX2INT(bcode.Substring(36, 4));
                    op3B.Rotation = HEX2INT(bcode.Substring(40, 4));
                    op3B.Stage = Convert.ToByte(bcode.Substring(44, 2), 16);
                    op3B.Room_ID = bcode.Substring(46, 2);
                    op3B.Camera = Convert.ToByte(bcode.Substring(48, 2), 16);
                    op3B.Target_Floor = Convert.ToByte(bcode.Substring(50, 2), 16);
                    op3B.DO2_File = bcode.Substring(52, 2);
                    op3B.Animation = Convert.ToByte(bcode.Substring(54, 2), 16);
                    op3B.Sound = Convert.ToByte(bcode.Substring(56, 2), 16);
                    op3B.Key_ID = Convert.ToByte(bcode.Substring(58, 2), 16);
                    op3B.Lock_Flag = Convert.ToByte(bcode.Substring(60, 2), 16);

                    sATTR = "(" +
                        op3B.AOT + ", " + GET_AOT_ID(op3B.ID) + ", " + op3B.Type + ", " + op3B.Floor + ", " + op3B.Super + ", " +
                        op3B.X + ", " + op3B.Y + ", " + op3B.Width + ", " + op3B.Depth + ", " + op3B.Target_X + ", " + op3B.Target_Z + ", " + op3B.Target_Y + ", " + op3B.Rotation + ", ROOM" +
                        (op3B.Stage + 1) + op3B.Room_ID + ", " + op3B.Camera + ", " + op3B.Target_Floor + ", DOOR" + op3B.DO2_File + ", " + op3B.Animation + ", " + op3B.Sound + ", " +
                        op3B.Key_ID + ", " + op3B.Lock_Flag + ")";

                    LST_PROP.SelectedObject = op3B;
                }
                //x3C////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "3C")
                {
                    PARSER_SCD2.x3C op3C = new PARSER_SCD2.x3C();

                    op3C.Value = Convert.ToByte(bcode.Substring(2, 2), 16);

                    sATTR = "(" + op3C.Value + ")";
                    LST_PROP.SelectedObject = op3C;
                }

                #endregion

                //###########################################################################################
                // x4_
                //###########################################################################################
                #region
                //x44////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "44")
                {
                    PARSER_SCD2.x44 op44 = new PARSER_SCD2.x44();

                    op44.Dummy = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op44.Number = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op44.EMD_File = bcode.Substring(6, 2);
                    op44.Animation = Convert.ToByte(bcode.Substring(8, 2), 16);
                    op44.Status = Convert.ToByte(bcode.Substring(10, 2), 16);
                    op44.Floor = Convert.ToByte(bcode.Substring(12, 2), 16);
                    op44.Sound = bcode.Substring(14, 2);
                    op44.Texture = Convert.ToByte(bcode.Substring(16, 2), 16);
                    op44.Flag = Convert.ToByte(bcode.Substring(18, 2), 16);
                    op44.X = HEX2INT(bcode.Substring(20, 4));
                    op44.Z = HEX2INT(bcode.Substring(24, 4));
                    op44.Y = HEX2INT(bcode.Substring(28, 4));
                    op44.Rotation = HEX2INT(bcode.Substring(32, 4));
                    op44.Motion = HEX2INT(bcode.Substring(36, 4));
                    op44.Control_Flag = HEX2INT(bcode.Substring(40, 4));

                    

                    sATTR = "(" +
                        op44.Dummy + ", " + op44.Number + ", EM_" + op44.EMD_File + ", " + op44.Animation + ", " + op44.Status + ", " +
                        op44.Floor + ", ENEM" + op44.Sound + ", " + op44.Texture + ", " + op44.Flag + ", " +
                        op44.X + ", " + op44.Z + ", " + op44.Y + ", " + op44.Rotation + ", " + op44.Motion + ", " + op44.Control_Flag + ")";

                    LST_PROP.SelectedObject = op44;
                }
                //x46////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "46")
                {
                    PARSER_SCD2.x46 op46 = new PARSER_SCD2.x46();

                    op46.AOT = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op46.ID = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op46.Type = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op46.Data0 = HEX2INT(bcode.Substring(8, 4));
                    op46.Data1 = HEX2INT(bcode.Substring(12, 4));
                    op46.Data2 = HEX2INT(bcode.Substring(16, 4));

                    sATTR = "(" + op46.AOT + ", " + GET_AOT_ID(op46.ID) + ", " + op46.Type + ", " + op46.Data0 + ", " + op46.Data1 + ", " + op46.Data2 + ")";

                    LST_PROP.SelectedObject = op46;
                }
                //x47////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "47")
                {
                    PARSER_SCD2.x47 op47 = new PARSER_SCD2.x47();

                    op47.AOT = Convert.ToByte(bcode.Substring(2, 2), 16);

                    sATTR = "(" + op47.AOT + ")";
                    LST_PROP.SelectedObject = op47;
                }
                //x4B////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "4B")
                {
                    PARSER_SCD2.x4B op4B = new PARSER_SCD2.x4B();

                    op4B.Old = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op4B.New = Convert.ToByte(bcode.Substring(4, 2), 16);

                    sATTR = "(" + op4B.Old + ", " + op4B.New + ")";

                    LST_PROP.SelectedObject = op4B;
                }
                //x4E////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "4E")
                {
                    PARSER_SCD2.x4E op4E = new PARSER_SCD2.x4E();

                    op4E.AOT = Convert.ToByte(bcode.Substring(2, 2), 16);
                    op4E.ID = Convert.ToByte(bcode.Substring(4, 2), 16);
                    op4E.Type = Convert.ToByte(bcode.Substring(6, 2), 16);
                    op4E.Floor = Convert.ToByte(bcode.Substring(8, 2), 16);
                    op4E.Super = Convert.ToByte(bcode.Substring(10, 2), 16);
                    op4E.X = HEX2INT(bcode.Substring(12, 4));
                    op4E.Y = HEX2INT(bcode.Substring(16, 4));
                    op4E.Width = Convert.ToUInt16(HEX2INT(bcode.Substring(20, 4)));
                    op4E.Depth = Convert.ToUInt16(HEX2INT(bcode.Substring(24, 4)));
                    op4E.Item_ID = HEX2INT(bcode.Substring(28, 4));
                    op4E.Amount = HEX2INT(bcode.Substring(32, 4));
                    op4E.Flag = HEX2INT(bcode.Substring(36, 4));
                    op4E.MD1_ID = Convert.ToByte(bcode.Substring(40, 2), 16);
                    op4E.Animation = Convert.ToByte(bcode.Substring(42, 2), 16);

                    sATTR = "(" +
                        op4E.AOT + ", " + GET_AOT_ID(op4E.ID) + ", " + op4E.Type + ", " + op4E.Floor + ", " + op4E.Super + ", " +
                        op4E.X + ", " + op4E.Y + ", " + op4E.Width + ", " + op4E.Depth + ", " + op4E.Item_ID + ", " + op4E.Amount + ", " + op4E.Flag + ", " + op4E.MD1_ID + ", "
                        + op4E.Animation + ")";

                    LST_PROP.SelectedObject = op4E;
                }

                #endregion

                //###########################################################################################
                // x5_
                //###########################################################################################
                #region
                //x5F////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "5F")
                {
                    PARSER_SCD2.x5F op5F = new PARSER_SCD2.x5F();

                    op5F.Volume = Convert.ToByte(bcode.Substring(2, 2), 16);

                    sATTR = "(" + op5F.Volume + ")";

                    LST_PROP.SelectedObject = op5F;
                }
                #endregion

                //###########################################################################################
                // x6_
                //###########################################################################################
                #region
                //x65////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "65")
                {
                    PARSER_SCD2.x65 op65 = new PARSER_SCD2.x65();

                    op65.Effect_ID = Convert.ToByte(bcode.Substring(2, 2), 16);

                    sATTR = "(" + op65.Effect_ID + ")";

                    LST_PROP.SelectedObject = op65;
                }
                //x6F////////////////////////////////////////////////////////////////////////////////////////
                if (opcode == "6F")
                {
                    PARSER_SCD2.x6F op6F = new PARSER_SCD2.x6F();

                    op6F.FMV_ID = Convert.ToByte(bcode.Substring(2, 2), 16);

                    sATTR = "(" + op6F.FMV_ID + ")";

                    LST_PROP.SelectedObject = op6F;
                }
                #endregion
            }
            catch (Exception e)
            {
                sATTR = e.ToString();
            }

            //RETURN THE OPCODE'S VALUES
            return sATTR;

        }

        private Int16 HEX2INT(string srcval)
        {
            Int16 outval = 0;

            outval = Convert.ToInt16(srcval.Substring(2, 2) + srcval.Substring(0, 2), 16);
            return outval;
        }

        private void LST_ATTR_Click(object sender, EventArgs e)
        {
            
        }


        private string GET_AOT_ID(byte id)
        {
            string tstr = "";

            if (id == 0) {tstr = "UNASSIGNED";}
            if (id == 1) {tstr = "DOOR";}
            if (id == 2) {tstr = "ITEM";}
            if (id == 3) {tstr = "STANDARD";}
            if (id == 4) {tstr = "MESSAGE";}
            if (id == 5) {tstr = "EVENT";}
            if (id == 6) {tstr = "FLAG CHANGE";}
            if (id == 7) {tstr = "WATER";}
            if (id == 8) {tstr = "MOVE";}
            if (id == 9) {tstr = "TYPEWRITER";}
            if (id == 10) {tstr = "ITEMBOX";}
            if (id == 11) {tstr = "DAMAGE";}
            if (id == 12) {tstr = "STATUS";}
            if (id == 13) {tstr = "DRAWER";}
            if (id == 14) { tstr = "WINDOWS"; }

            return tstr;
        }

        private string GET_FLAG_REGISTER(byte REG_ID)
        {
            string tmp = REG_ID.ToString();
            if (REG_ID == 4) { tmp = "FL_PERMANENT_ROOM_STATUS"; }
            if (REG_ID == 5) { tmp = "FL_TMP_ROOM_STATUS"; }
            if (REG_ID == 6) { tmp = "FL_ENEMY_0"; }
            if (REG_ID == 7) { tmp = "FL_ENEMY_1"; }
            if (REG_ID == 8) { tmp = "FL_ITEM_0"; }
            if (REG_ID == 9) { tmp = "FL_ITEM_1"; }
            if (REG_ID == 29) { tmp = "FL_INFLUENCE"; }
            return tmp;
        }

        private string GET_VAR_NAME(byte VAR)
        {
            string varw = "";

            if (VAR == 0) { varw = "F_ATARI"; }
            if (VAR == 1) { varw = "U_ATARI"; }
            if (VAR == 2) { varw = "USE_ID"; }
            if (VAR == 3) { varw = "GET_ID"; }
            if (VAR == 4) { varw = "SCE_WORK(0)"; }
            if (VAR == 5) { varw = "SCE_WORK(1)"; }
            if (VAR == 6) { varw = "SCE_WORK(2)"; }
            if (VAR == 7) { varw = "SCE_WORK(3)"; }
            if (VAR == 8) { varw = "SCE_WORK(4)"; }
            if (VAR == 9) { varw = "SCE_WORK(5)"; }
            if (VAR == 10) { varw = "SCE_WORK(6)"; }
            if (VAR == 11) { varw = "SCE_WORK(7)"; }
            if (VAR == 12) { varw = "DSCE_WORK(0)"; }
            if (VAR == 13) { varw = "DSCE_WORK(1)"; }
            if (VAR == 14) { varw = "DSCE_WORK(2)"; }
            if (VAR == 15) { varw = "DSCE_WORK(3)"; }
            if (VAR == 16) { varw = "TMP_WORK(0)"; }
            if (VAR == 17) { varw = "TMP_WORK(1)"; }
            if (VAR == 18) { varw = "TMP_WORK(2)"; }
            if (VAR == 19) { varw = "TMP_WORK(3)"; }
            if (VAR == 20) { varw = "TMP_WORK(4)"; }
            if (VAR == 21) { varw = "TMP_WORK(5)"; }
            if (VAR == 22) { varw = "TMP_WORK(6)"; }
            if (VAR == 23) { varw = "TMP_WORK(7)"; }
            if (VAR == 24) { varw = "STAGE"; }
            if (VAR == 25) { varw = "ROOM"; }
            if (VAR == 26) { varw = "CAMERA"; }
            if (VAR == 27) { varw = "OLD_ROOM"; }
            if (VAR == 28) { varw = "OLD_CAMERA"; }
            if (VAR == 29) { varw = "SCE_RANDOM"; }
            if (VAR == 30) { varw = "PLD"; }
            if (VAR == 31) { varw = "DEF_EM_SET"; }
            if (VAR == 32) { varw = "DEF_AOT_SET"; }

            return varw;
        }

        // set bit flag attributs?


            /// <summary>
            /// BIO2_FLAG_COMMENT
            /// </summary>
            /// <param name="bcode"></param>
            /// <returns></returns>
        private string BIO2_FLAG_COMMENT(string bcode)
        {
            string comment = "";
            byte ARRAY = Convert.ToByte(bcode.Substring(2, 2), 16);
            byte FLAG = Convert.ToByte(bcode.Substring(4, 2), 16);
            byte VALUE = Convert.ToByte(bcode.Substring(6, 2), 16);

            if (ARRAY == 0)
            {
                if (FLAG == 25 && VALUE == 0) { comment = "GAME DIFFICULTY IS 'EASY'"; }
                if (FLAG == 25 && VALUE == 1) { comment = "GAME DIFFICULTY IS 'NORMAL'"; }

            }

            if (ARRAY == 1)
            {
                if (FLAG == 0 && VALUE == 0) { comment = "PLAYER 'LEON'"; }
                if (FLAG == 0 && VALUE == 1) { comment = "PLAYER 'CLAIRE'"; }
                
                if (FLAG == 1 && VALUE == 0) { comment = "SCENARIO A"; }
                if (FLAG == 1 && VALUE == 1) { comment = "SCENARIO B"; }

                if (FLAG == 6 && VALUE == 0) { comment = "GAME TYPE IS 'LEON/CLAIRE'"; }
                if (FLAG == 6 && VALUE == 1) { comment = "GAME TYPE IS 'HUNK/TOFU'"; }

                if (FLAG == 27 && VALUE == 0) { comment = "END LETTERBOX ========================================================================================= "; }
                if (FLAG == 27 && VALUE == 1) { comment = "SHOW LETTERBOX ======================================================================================== "; }
                
            }
            if (ARRAY == 2)
            {
                if (FLAG == 7 && VALUE == 0) { comment = "MUTEX OFF"; }
                if (FLAG == 7 && VALUE == 1) { comment = "MUTEX ON"; }

            }
            if (ARRAY == 6)
            {
                if (VALUE == 0) { comment = "ENEMY " + FLAG + " IS ALIVE"; }
                if (VALUE == 1) { comment = "ENEMY " + FLAG + " IS DEAD"; }

            }
            if (ARRAY == 7)
            {
                if (VALUE == 0) { comment = "ENEMY " + FLAG + " IS ALIVE"; }
                if (VALUE == 1) { comment = "ENEMY " + FLAG + " IS DEAD"; }

            }
            if (ARRAY == 8)
            {
                if (VALUE == 0) { comment = "ITEM " + FLAG + " WAS NOT OBTAINED YET"; }
                if (VALUE == 1) { comment = "ITEM " + FLAG + " WAS OBTAINED"; }

            }
            if (ARRAY == 11)
            {
                if (FLAG == 31 && VALUE == 0) { comment = "PLAYER ANSWERED WITH YES"; }
                if (FLAG == 31 && VALUE == 1) { comment = "PLAYER ANSWERED WITH NO"; }
            }
            return comment;
        }



        /// <summary>
        /// set flag comments in interpreted code window for bio3
        /// </summary>
        /// <param name="bcode"></param>
        /// <returns></returns>
        private string BIO3_FLAG_COMMENT(string bcode)
        {
            string comment = "";
            byte ARRAY = Convert.ToByte(bcode.Substring(2, 2), 16);
            byte FLAG = Convert.ToByte(bcode.Substring(4, 2), 16);
            byte VALUE = Convert.ToByte(bcode.Substring(6, 2), 16);



            if (ARRAY == 0)
            {
                if (FLAG == 0x17 && VALUE == 0) { comment = "HEAVY MODE"; }
                if (FLAG == 0x17 && VALUE == 1) { comment = "LIGHT MODE"; }
                
            }

            if (ARRAY == 1)
            {
                if (FLAG == 0x1C && VALUE == 0) { comment = "-----LETTERBOX DISABLED-----"; }
                if (FLAG == 0x1C && VALUE == 1) { comment = "------LETTERBOX ENABLED-----"; }
            }


            if (ARRAY == 3)
            {
                if (FLAG == 0xFD && VALUE == 0) { comment = "DARRIO NOT SPOKEN TO "; }
                if (FLAG == 0xFD && VALUE == 1) { comment = "DARRIO SPOKEN TO"; }
            }




            if (ARRAY == 0x7)
            {
                if (FLAG == 0x1F && VALUE == 0) { comment = "WAREHOUSE LOCKER (GREEN)"; }
                if (FLAG == 0x1F && VALUE == 1) { comment = "WAREHOUSE LOCKER (RED)"; }
                if (FLAG == 0x05 && VALUE == 0) { comment = "LOCKPICK NOT OBTAINED"; }
                if (FLAG == 0x05 && VALUE == 1) { comment = "LOCKPICK OBTAINED"; }
                
            }




            if (ARRAY == 0x03)
            {
                if (FLAG == 0x09 && VALUE == 0) { comment = "HAVENT CONTACTED CARLOS YET(RADIO)"; }
                if (FLAG == 0x09 && VALUE == 1) { comment = "MADE CONTACT WITH CARLOS(RADIO)"; }
                if (FLAG == 0x25 && VALUE == 0) { comment = "BARRICADE HAS NOT FALLEN"; }
                if (FLAG == 0x25 && VALUE == 1) { comment = "BARRICADE HAS FALLEN"; }
                if (FLAG == 0x36 && VALUE == 0) { comment = "OIL ROOM ZOMBIES HAVENT BROKEN IN"; }
                if (FLAG == 0x36 && VALUE == 1) { comment = "OIL ROOM ZOMBIES BUSTED IN"; }


            }



            



            return comment;


        }




        private string CODE_COMMENT(string bcode)
        {
            string comment = "";
            byte Byte0 = Convert.ToByte(bcode.Substring(0, 2), 16);
            byte Byte1 = Convert.ToByte(bcode.Substring(2, 2), 16);

            if (Byte0 == 4 && Byte1 == 255) { comment = "THE NEXT INSTRUCTION WILL BE EXECUTED WHENEVER A CAMERA CHANGE OCCURS"; }
            

            return comment;
        }

		private void BTN_FLAG_MONITOR_Click(object sender, EventArgs e)
		{

		}

		private void BTN_AOT_MONITOR_Click(object sender, EventArgs e)
		{

		}

		private void M_FILE_OPEN_Click(object sender, EventArgs e)
		{
			LST_BYTE.Items.Clear();
			LST_CODE.Items.Clear();
			g_TAB = 0;
            DLG_OPEN_FILE.FilterIndex = 2;

			DLG_OPEN_FILE.ShowDialog();



            if (DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 3, 3).ToUpper() == "RDT")
            {
                relative_flag = 0;
                PARSE_RDT(DLG_OPEN_FILE.FileName);
            }
            else if (DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 3, 3) == "SCD")
            {
                relative_flag = 1;
            }




            if (DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 3, 3) == "RDT")
            {
                BIO2_PARSE_SCD(DLG_OPEN_FILE.FileName, relative_flag);
            }
            else if (DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 3, 3) == "rdt")
            {
                BIO3_PARSE_SCD(DLG_OPEN_FILE.FileName, relative_flag);
            }

            // parse scd according to rdt/scd relation

            LBL_PROC_STATUS.Text = DLG_OPEN_FILE.FileName;
            FRM_DEBUG.cur_file = DLG_OPEN_FILE.FileName;

            DIR_LISTBOX.Path = AppDomain.CurrentDomain.BaseDirectory + @"\DUMPED\" + DLG_OPEN_FILE.FileName.Substring(DLG_OPEN_FILE.FileName.Length - 12, 8);

            F_LISTBOX.FileName = DIR_LISTBOX.Path;


        }

		private void BTN_SAVE_Click(object sender, EventArgs e)
		{
            MessageBox.Show("Not yet implemented");
		}

		private void BTN_SAVE_AS_Click(object sender, EventArgs e)
		{

		}

        private void M_FILE_SAVE_Click(object sender, EventArgs e)
        {

        }

        private void M_FILE_SAVE_AS_Click(object sender, EventArgs e)
        {

        }

        private void LST_PROP_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {

            
        }

        private void BTN_DEBUG_Click(object sender, EventArgs e)
        {
            DEBUG_FORM.ShowDialog();
        }

        //
        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
            string[] path_array;

            // read config file paths on form load if it exists..
            if (File.Exists(ConfigFilePath))
            {
                path_array = File.ReadAllLines(ConfigFilePath);
                
                // set paths to global data
                LIB_EXE.EXE_PATHS.bio2_exe_path = path_array[0];
                LIB_EXE.EXE_PATHS.leonu_path = path_array[1];
                LIB_EXE.EXE_PATHS.claireu_path = path_array[2];
                LIB_EXE.EXE_PATHS.bio3_mk_path = path_array[3];
                LIB_EXE.EXE_PATHS.bio3_ea_path = path_array[4];
            }


            }

        private void CB_DRIVELST_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void DRIVE_LISTBOX_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DIR_LISTBOX.Path = DRIVE_LISTBOX.Drive;
            
        }

        private void LB_SCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            // view dumped scd
        }

        private void DIR_LISTBOX_SelectedIndexChanged(object sender, EventArgs e)
        {
            F_LISTBOX.FileName = DIR_LISTBOX.Path;
        }

        public void DIR_LISTBOX_Change(object sender, EventArgs e)
        {
           // F_LISTBOX.FileName = DIR_LISTBOX.Path;
        }

        private void DIR_LISTBOX_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void BTN_HOME_Click(object sender, EventArgs e)
        {
            Process.Start(AppDomain.CurrentDomain.BaseDirectory);
            DIR_LISTBOX.Path = AppDomain.CurrentDomain.BaseDirectory + @"\DUMPED";
            F_LISTBOX.FileName = DIR_LISTBOX.Path;

        }

        private void F_LISTBOX_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (F_LISTBOX.SelectedItem.ToString().Substring(F_LISTBOX.SelectedItem.ToString().Length - 3, 3) == "SCD")
                {
                    string fpath = F_LISTBOX.Path + "\\" + F_LISTBOX.SelectedItem.ToString();

                    relative_flag = 1;

                    if (selected_path.Substring(selected_path.Length - 11, 4) == "BIO2")
                    {
                        BIO2_PARSE_SCD(fpath, relative_flag);
                    }
                    else if (selected_path.Substring(selected_path.Length - 11, 4) == "BIO3")
                    {
                        BIO3_PARSE_SCD(fpath, relative_flag);
                    }
                }
            }
                        
            catch (Exception ex) {
                throw ex;
            }
           
        }

        private void BTN_HEX2DEC_Click(object sender, EventArgs e)
        {
            CALC_FORM.ShowDialog();
        }

        private void MAIN_TOOLBAR_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {

            //  MessageBox.Show(e.Button.Name.ToString());


            //**********************************************************************************
            // BIO 3 EXECUTABLE SELECTION
            //**********************************************************************************
            #region


            if (e.Button.Name == "TBTN_BIO3EXE")
            {
                // if no hook detected run prompt, run manual exe read
                if (LIB_MEMORY.DATA_HOOK.Hooked_Process == null)
                {
                    // give user a choice
                    string Choice = Microsoft.VisualBasic.Interaction.InputBox("EA OR MK?", "Select EXE", "EA");


                    switch (Choice)
                    {
                        case "EA":
                            // if EA path not empty or null
                            if (LIB_EXE.EXE_PATHS.bio3_ea_path != string.Empty || LIB_EXE.EXE_PATHS.bio3_ea_path != null)
                            {
                                //MessageBox.Show(LIB_EXE.EXE_PATHS.bio3_ea_path);
                                // parse exe item data and show dialog
                                LIB_EXE.Parse_ItemData(LIB_EXE.EXE_PATHS.bio3_ea_path, 0x12B3C8);
                                LIB_EXE.BIO3_ParseComboTable(LIB_EXE.EXE_PATHS.bio3_ea_path, 0x12B678, EXE_FORM.LST_Combo_Data);
                                EXE_FORM.ShowDialog();
                            }
                            else
                            {
                                // if it is empty or null point user towards config to write a proper .ini
                                DialogResult QResult = MessageBox.Show("No File Path set in Appconfig, Configure appconfig.ini under 'CONFIG Menu'... Open Now? ", "No Path Found", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                                if (QResult == DialogResult.Yes)
                                {
                                    CONFIG_FORM.ShowDialog();
                                }
                                else
                                {
                                    // ok then
                                }
                                    
                            }


                            break;
                        case "MK": MessageBox.Show(LIB_EXE.EXE_PATHS.bio3_mk_path); break;
                    }
                    

                }
                else // run automatic exe routine
                {

                    
                    if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3)
                    {
                       
                    }

                    if (LIB_MEMORY.DATA_HOOK.G_FLAG == 5)
                    {
                        LIB_EXE.Parse_ItemData(LIB_EXE.EXE_PATHS.bio3_ea_path, 0x12B3C8);
                        LIB_EXE.BIO3_ParseComboTable(LIB_EXE.EXE_PATHS.bio3_ea_path, 0x12B678, EXE_FORM.LST_Combo_Data);
                        EXE_FORM.ShowDialog();
                    }

                }
              


            }

            #endregion


            //**********************************************************************************
            // BIO 2 EXECUTABLE SELECTION
            //**********************************************************************************
            #region

            if (e.Button.Name == "TBTN_BIO2_EXE")
            {
                // if no hook (cant run file io on running exe anyways..
                if (LIB_MEMORY.DATA_HOOK.Hooked_Process == null)
                {
                    string Choice = Microsoft.VisualBasic.Interaction.InputBox("LEONU/CLAIREU/SOURCENEXT?", "Select EXE", "SOURCENEXT");


                    switch (Choice)
                    {
                        case "LEONU": MessageBox.Show(LIB_EXE.EXE_PATHS.leonu_path); break;
                        case "CLAIREU": MessageBox.Show(LIB_EXE.EXE_PATHS.claireu_path); break;
                        case "SOURCENEXT": MessageBox.Show(LIB_EXE.EXE_PATHS.bio2_exe_path); break;
                    }
                    
                }
                
              

            }

                #endregion



           if (e.Button.Name == "TBTN_SCD")
            {
                panel_scd.Visible = true;
            }

            if (e.Button.Name == "TBTN_DEBUG")
            {
                DEBUG_FORM.ShowDialog();
            }

            if (e.Button.Name == "TBTN_CONV")
            {
                CALC_FORM.ShowDialog();
            }

            if (e.Button.Name == "TBTN_CONFIG")
            {
                CONFIG_FORM.ShowDialog();
            }

            if (e.Button.Name == "TBTN_SAP")
            {
                SAP_FORM.ShowDialog();
            }


            if (e.Button.Name == "TBTN_FX")
            {

            }


            if (e.Button.Name == "TBTN_MSG")
            {
                MSG_FORM.ShowDialog();
            }


            if (e.Button.Name == "TBTN_SAVE")
            {
                SAVE_FORM.ShowDialog();
            }


            if (e.Button.Name == "TBTN_CALC") {

                CALC_TEST.ShowDialog();
            }


        }

        private void BAR_TOOL_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CONFIG_FORM.ShowDialog();
        }

        private void bIO2RE2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bIO2RE3ToolStripMenuItem.Checked = false;
            bIO2RE2ToolStripMenuItem.Checked = true;
            
        }

        private void bIO2RE3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bIO2RE2ToolStripMenuItem.Checked = false;
            bIO2RE3ToolStripMenuItem.Checked = true;

         


        }

        private void BTN_HOOK_Click(object sender, EventArgs e)
        {
            FRM_PROCHOOK PROCFORM = new FRM_PROCHOOK();
            PROCFORM.ShowDialog();
        }

        private void TIMER_HOOK_Tick(object sender, EventArgs e)
        {

            var proc = Process.GetProcessesByName(LIB_MEMORY.DATA_HOOK.Process_Name);

            
            if (proc == null || proc.Length == 0)
            {
                LBL_PROC_STATUS.Text = "FOUND: " + LIB_MEMORY.DATA_HOOK.Process_Name;
                return;
            }

            var hooked_proc = proc[0];


            // call certain functions for certain games
            switch (LIB_MEMORY.DATA_HOOK.G_FLAG)
            {
                case 0: LIB_MEMORY.BIO2_EXE_SOURCENEXT(hooked_proc); TimeSpan T_result = TimeSpan.FromSeconds(LIB_MEMORY.EXE_PLAYER.TIME_OFF);
                    LBL_IGT.Text = T_result.ToString("hh':'mm':'ss");

                    break;
                case 3: LIB_MEMORY.BIO3_EXE_MEDIAKITE(hooked_proc);
                    LBL_IGT.Text = LIB_MEMORY.EXE_PLAYER.Time.ToString("hh':'mm':'ss");
                    
                        LBL_ROOMDESC.Text = "r" + LIB_MEMORY.EXE_ROOM.STAGE_ID + "0" +LIB_MEMORY.EXE_ROOM.ROOM_ID.ToString("X") + ".RDT";
                    IMAGE_BG_RENDER.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\BIO3_BSS\\" + "r" + LIB_MEMORY.EXE_ROOM.STAGE_ID + "0" + LIB_MEMORY.EXE_ROOM.ROOM_ID + "0" + LIB_MEMORY.EXE_ROOM.CUR_CAM + ".jpg");
                    DEBUG_FORM.Debug_Log.AppendText("\n" + AppDomain.CurrentDomain.BaseDirectory + "\\BIO3_BSS\\" + "r" + LIB_MEMORY.EXE_ROOM.STAGE_ID + "0" + LIB_MEMORY.EXE_ROOM.ROOM_ID + "0" + LIB_MEMORY.EXE_ROOM.CUR_CAM + ".jpg");

                    break;

                case 5: LIB_MEMORY.BIO3_EXE_EACHINA(hooked_proc);
                    try
                    {


                        // if room id is < 16 use a 0
                        if (LIB_MEMORY.EXE_ROOM.ROOM_ID < 16)
                        {
                            LBL_ROOMDESC.Text = "r" + LIB_MEMORY.EXE_ROOM.STAGE_ID + "0" + LIB_MEMORY.EXE_ROOM.ROOM_ID.ToString("X") + ".RDT";
                            IMAGE_BG_RENDER.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\BIO3_BSS\\" + "r" + LIB_MEMORY.EXE_ROOM.STAGE_ID + "0" + LIB_MEMORY.EXE_ROOM.ROOM_ID.ToString("X") + "0" + LIB_MEMORY.EXE_ROOM.CUR_CAM.ToString("X") + ".jpg");
                        }
                        else // otherwise dont
                        {
                            LBL_ROOMDESC.Text = "r" + LIB_MEMORY.EXE_ROOM.STAGE_ID + LIB_MEMORY.EXE_ROOM.ROOM_ID.ToString("X") + ".RDT";

                            if (LIB_MEMORY.EXE_ROOM.CUR_CAM == 16)
                            {
                                IMAGE_BG_RENDER.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\BIO3_BSS\\" + "r" + LIB_MEMORY.EXE_ROOM.STAGE_ID + LIB_MEMORY.EXE_ROOM.ROOM_ID.ToString("X") + LIB_MEMORY.EXE_ROOM.CUR_CAM.ToString("X") + ".jpg");
                            }
                            else
                            {
                                IMAGE_BG_RENDER.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\BIO3_BSS\\" + "r" + LIB_MEMORY.EXE_ROOM.STAGE_ID + LIB_MEMORY.EXE_ROOM.ROOM_ID.ToString("X") + "0" + LIB_MEMORY.EXE_ROOM.CUR_CAM.ToString("X") + ".jpg");
                            }


                        }
                    }
                    catch (FileNotFoundException fnf)
                    {
                        IMAGE_BG_RENDER.Image = IMAGE_BG_RENDER.ErrorImage;
                    }
                   
                    break;
                    
            }


            LBL_HP.Text = LIB_MEMORY.EXE_PLAYER.PL_HP.ToString();
            LBL_POSX.Text = "X: " + LIB_MEMORY.EXE_PLAYER.POS_X.ToString();
            LBL_POSY.Text = "Y: " + LIB_MEMORY.EXE_PLAYER.POS_Y.ToString();
            LBL_POSZ.Text = "Z: " + LIB_MEMORY.EXE_PLAYER.POS_Z.ToString();
            LBL_POSR.Text = "R: " + LIB_MEMORY.EXE_PLAYER.POS_R.ToString();


            LBL_CAMID00.Text = LIB_MEMORY.EXE_ROOM.CUR_CAM.ToString("X");
            LBL_CAMID01.Text = LIB_MEMORY.EXE_ROOM.OLD_CAM.ToString("X");
            LBL_RID00.Text = LIB_MEMORY.EXE_ROOM.ROOM_ID.ToString("X");
            LBL_RID01.Text = LIB_MEMORY.EXE_ROOM.OLD_ROOM.ToString("X");

         

            //calculate and display IGT
   
            Equip_Set(LIB_MEMORY.EXE_PLAYER.PLD_ID, LIB_MEMORY.EXE_PLAYER.EQUIP_ID, BIO2_ARMS_PATH, hooked_proc);


        }

        /// <summary>
        /// Handle Status gifs\labels for BIO2/3
        /// </summary>
        public void ECG_STATUS_HANDLER(Int16 HP_OFF, byte PZN_FLAG,string ECGPATH)
        {
            if (HP_OFF >= 101)
            {
                Image Fine_Image = Image.FromFile(ECGPATH + "\\fine.gif");

                LBL_HP.ForeColor = Color.Lime;
                STATUS_IMAGE.Image = Fine_Image;
                
            }
            else if (HP_OFF >= 41)
            {
                Image Fine_Image = Image.FromFile(ECGPATH + "\\caution.gif");

                LBL_HP.ForeColor = Color.Orange;
                STATUS_IMAGE.Image = Fine_Image;
                
            }
            else if (HP_OFF >= 21)
            {
                Image Fine_Image = Image.FromFile(ECGPATH + "\\caution2.gif");

                LBL_HP.ForeColor = Color.DarkOrange;
                STATUS_IMAGE.Image = Fine_Image;

            }
            else if (HP_OFF <= 20)
            {
                Image Fine_Image = Image.FromFile(ECGPATH + "\\danger.gif");
                LBL_HP.ForeColor = Color.DarkRed;
                STATUS_IMAGE.Image = Fine_Image;

            }
            else
                return;

            if (PZN_FLAG == 21)
            {
                Image Pzn_Image = Image.FromFile(ECGPATH + "\\poison.gif");
                LBL_HP.ForeColor = Color.Purple;
            }

        }


        public void Equip_Set(byte PLD_ID, byte EQUIPD_ID, string ARMSPATH, Process proc)
        {

            try
            {


                for (int i = 0; i < LIB_MEMORY.EXE_INVO.Length; i++)
                {
                    if (EQUIPD_ID == LIB_MEMORY.EXE_INVO[i].WEAPON_ID)
                    {
                        LBL_AMMO.Text = "Q: " + LIB_MEMORY.EXE_INVO[i].AMMO_COUNT.ToString();
                    }

                }

                WPN_IMAGE.Image = Image.FromFile(ARMSPATH + EQUIPD_ID + ".jpg");

                if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0)
                {
                    switch (PLD_ID)
                    {
                        case 0: PLAYER_IMAGE.Image = Image.FromFile(ARMSPATH + "leon.png"); break;
                        case 1: PLAYER_IMAGE.Image = Image.FromFile(ARMSPATH + "claire.jpg"); break;
                        case 11: PLAYER_IMAGE.Image = Image.FromFile(ARMSPATH + "ada.png"); break;
                        case 14: PLAYER_IMAGE.Image = Image.FromFile(ARMSPATH + "sherry.png"); break;
                        case 15: PLAYER_IMAGE.Image = Image.FromFile(ARMSPATH + "chris.png"); break;
                    }
                }

                if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3)
                {
                    switch (PLD_ID)
                    {
                        case 1: PLAYER_IMAGE.Image = Image.FromFile(ARMSPATH + "jill.png"); break;

                        

                    }


                }
            

            }
            catch
            {
                return;
            }
            
        }

        
        private int? FindClosest(IEnumerable<int> numbers, int x)
        {
            return
                (from number in numbers
                 let difference = Math.Abs(number - x)
                 orderby difference, Math.Abs(number), number ascending
                 select (int?)number)
                .FirstOrDefault();
        }

        private void TIMER_ECG_Tick(object sender, EventArgs e)
        {
            if (LIB_MEMORY.DATA_HOOK.IsHooked)
            {
                if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0 || LIB_MEMORY.DATA_HOOK.G_FLAG == 3 || LIB_MEMORY.DATA_HOOK.G_FLAG == 5)
                {
                    ECG_STATUS_HANDLER(LIB_MEMORY.EXE_PLAYER.PL_HP, LIB_MEMORY.EXE_PLAYER.PZN_FLAG, BIO2_ECG_PATH);
                }
            }
            
        }

        private void LBL_POSY_Click(object sender, EventArgs e)
        {

        }

        private void BTN_INVO_Click(object sender, EventArgs e)
        {
            FRM_INVOEDIT INV = new FRM_INVOEDIT();

            INV.Owner = this;
            
            INV.Show();
        }

        private void STATUS_SELECTOR_SelectedIndexChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(STATUS_SELECTOR.SelectedItem.ToString());

         //   MessageBox.Show(FRM_PROCHOOK.HOOKED_DATA.G_FLAG.ToString());

            if (LIB_MEMORY.DATA_HOOK.G_FLAG == 0)
            {
                LIB_MEMORY.BIO2_EXE_SET_STATUS(LIB_MEMORY.DATA_HOOK.Hooked_Process, STATUS_SELECTOR.SelectedItem.ToString());
            }
            else if (LIB_MEMORY.DATA_HOOK.G_FLAG == 3)
            {
                LIB_MEMORY.BIO3_EXE_SET_STATUS(LIB_MEMORY.DATA_HOOK.Hooked_Process, STATUS_SELECTOR.SelectedItem.ToString());
            }

            
        }

        private void MAIN_TOOLBAR_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void LST_BYTE_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (LST_BYTE.SelectedItems.Count > 0)
            {
                int sel_dx = LST_BYTE.SelectedIndices[0];

                LIB_RDT.Selected_ByteStr = LST_BYTE.Items[sel_dx].SubItems[1].Text;
                //MessageBox.Show(LST_BYTE.Items[sel_dx].SubItems[1].Text);
                DEBUG_FORM.Debug_Log.AppendText("\nSCD OPCODE [" + sel_dx.ToString() + "] " + LST_BYTE.Items[sel_dx].SubItems[1].Text);


                byte opcode = Convert.ToByte(LST_BYTE.Items[sel_dx].SubItems[1].Text.Substring(0, 2), 16);

                
                switch (opcode)
                {
                    case 0x7D: 
                         EM_SET_FORM.ShowDialog();
                        EM_SET_FORM.Focus();
                        
                        break;
                        
                }


            }


            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SCD_INT", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SCD_BUTTON_REPACK_Click(object sender, EventArgs e)
        {
            string selected_path = string.Empty;

            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowDialog();

            selected_path = FBD.SelectedPath;
            MessageBox.Show(selected_path);



            
        }

        private void IMAGE_BG_RENDER_Click(object sender, EventArgs e)
        {

        }

        private void LST_CODE_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void LST_CODE_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                OPCODE_MENU.Show(Cursor.Position);
            }
        }

        private void SCD_BTN_CLIPBOARD_Click(object sender, EventArgs e)
        {
           

            Array.Resize(ref LIB_RDT.Current_SCD_Lines, LST_CODE.Items.Count);

            
            for (int i = 0; i < LIB_RDT.Current_SCD_Lines.Length; i++)
            {
                LIB_RDT.Current_SCD_Lines[i] = LST_CODE.Items[i].SubItems[1].Text;
               
            }

            SCDEDITOR.ShowDialog();


        }

        private void Panel_scd_Paint(object sender, PaintEventArgs e)
        {

        }
    }






}
