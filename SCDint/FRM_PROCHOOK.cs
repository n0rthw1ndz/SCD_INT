using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


/// <summary>
/// This form handles Hooking to various bio processes
/// </summary>
namespace SCDint
{

    public struct HOOKED_GAME_OBJ
    {
        public string proc_name;
        public string Game_name;
        public Process Hooked_Process;
        public byte G_FLAG; // flag representing the game.. 
        public bool IsHooked;
    }

   
    public partial class FRM_PROCHOOK : Form
    {
        
        #region globals
       
        #endregion


        public FRM_PROCHOOK()
        {
            InitializeComponent();
        }


        public static HOOKED_GAME_OBJ HOOKED_DATA;



        public Dictionary<int, string> LUT_SUPPORTEDGAMES = new Dictionary<int, string>
        {
            {0, "bio2"}, // JP SOURCENEXT
            {1, "LEONU"}, // NA US
            {2, "CLAIREU"}, // NA US
            {3, "Bio3_PC"}, // JP MEDIAKITE
            {4, "Bio3_PC_Mercenaries"}, // MERCS?
            {5, "bio3_pc"}, // CHINA EA?
            {6, "bio3_pc_mercenaries"}, // CHINA EA MERCS
            {7, "BIOHAZARD(R) 3 PC"}, // JP SOURCENEXT
            {8, "ResidentEvil3"}, // NA US

        }; 

        private void FRM_PROCHOOK_Load(object sender, EventArgs e)
        {

          
            LB_PROCLIST.Items.Clear(); // prevent dupes

            List<string> procnames = new List<string>(); // probbaly useless

            var all_procs = Process.GetProcesses(); // store all running procs

            
            // loop thru all running procs and dump to list/listbox
            foreach (var proc in all_procs)
            {
                procnames.Add(proc.ProcessName.ToString());

                if (LUT_SUPPORTEDGAMES.ContainsValue(proc.ProcessName))
                {
                    LB_PROCLIST.Items.Add(proc.ProcessName);
                   
                }
                
            }
            
        }
        
        /// <summary>
        ///  CHeck if process even has a window style to filter out stupid ones..
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
  
        private void BTN_HOOKGAME_Click(object sender, EventArgs e)
        {
            /// if proc is selected, hook and close..
            if (LB_PROCLIST.SelectedItems.Count > 0)
            {
                LIB_MEMORY.DATA_HOOK.Process_Name = LB_PROCLIST.SelectedItems[LB_PROCLIST.SelectedIndex].ToString();              
                LIB_MEMORY.DATA_HOOK.IsHooked = true;

                var proc = Process.GetProcessesByName(LIB_MEMORY.DATA_HOOK.Process_Name);
                LIB_MEMORY.DATA_HOOK.Hooked_Process = proc[0];
                
                switch (LIB_MEMORY.DATA_HOOK.Process_Name)
                {
                    case "bio2": LIB_MEMORY.DATA_HOOK.G_FLAG = 0; break;
                    case "LEONU": LIB_MEMORY.DATA_HOOK.G_FLAG = 1; break;
                    case "CLAIREU": LIB_MEMORY.DATA_HOOK.G_FLAG = 2;  break;
                    case "Bio3_PC": LIB_MEMORY.DATA_HOOK.G_FLAG = 3; break;
                    case "Bio3_PC_Mercenaries": LIB_MEMORY.DATA_HOOK.G_FLAG = 4;  break;
                    case "bio3_pc": LIB_MEMORY.DATA_HOOK.G_FLAG = 5; break;
                    case "bio3_pc_mercenaries": LIB_MEMORY.DATA_HOOK.G_FLAG = 6; break;
                    case "BIOHAZARD(R) 3 PC": LIB_MEMORY.DATA_HOOK.G_FLAG = 7;  break;
                    case "ResidentEvil3": LIB_MEMORY.DATA_HOOK.G_FLAG = 8; break;
                }


             //   MessageBox.Show(HOOKED_DATA.Hooked_Process.ProcessName);

                this.Close();
                
            }
             
        }

        private void BTN_UNHOOK_Click(object sender, EventArgs e)
        {
            HOOKED_DATA.IsHooked = false;
        }
    }
}
