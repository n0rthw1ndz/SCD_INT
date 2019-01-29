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
    public partial class FRM_CONFIG : Form
    {
        public string seL_path = string.Empty;
        public string config_file_path = AppDomain.CurrentDomain.BaseDirectory + "\\AppConfig.ini";
        public string[] path_array;


        public FRM_CONFIG()
        {
            InitializeComponent();

       


        }

        private void TV_CONFIG_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            MessageBox.Show(e.Node.Name);
            Panel_Enable(e.Node.Name);
        }
        
        
        private void Panel_Enable(string node_name) {

            switch (node_name)
            {
                case "Node_EXE": Panel_EXE.Visible = true; Panel_General.Visible = false; break;
                case "Node_General": Panel_General.Visible = true;  Panel_EXE.Visible = false; break;
            }
           
        }

        private void BTNPATH_BIO2SC_Click(object sender, EventArgs e)
        {
                      
            Config_OpenDLG.ShowDialog();
            seL_path = Config_OpenDLG.FileName;
            EXEPATH_BIO2_SC.Text = seL_path;
        }

        private void BTNPATH_LEONU_Click(object sender, EventArgs e)
        {
            Config_OpenDLG.ShowDialog();
            seL_path = Config_OpenDLG.FileName;
            EXE_PATH_LEONU.Text = seL_path;
            
        }

        private void BTNPATH_CLAIREU_Click(object sender, EventArgs e)
        {
            Config_OpenDLG.ShowDialog();
            seL_path = Config_OpenDLG.FileName;
            EXEPATH_CLAIREU.Text = seL_path;
        }

        private void BTNPATH_BIO3MK_Click(object sender, EventArgs e)
        {
            Config_OpenDLG.ShowDialog();
            seL_path = Config_OpenDLG.FileName;
            EXEPATH_BIO3MK.Text = seL_path;

        }

        private void BTNPATH_BIO3EA_Click(object sender, EventArgs e)
        {
            Config_OpenDLG.ShowDialog();
            seL_path = Config_OpenDLG.FileName;
            EXEPATH_BIO3EA.Text = seL_path;
        }

        private void BTN_SAVEPATHS_Click(object sender, EventArgs e)
        {
            string config_file = AppDomain.CurrentDomain.BaseDirectory + "\\AppConfig.ini";

            if (!File.Exists(config_file))
            {
                MessageBox.Show("App Config ini does not currently exist!, creating it now..", "APP_MSG", MessageBoxButtons.OK, MessageBoxIcon.Information);

                using (var fs = new FileStream(config_file,FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(EXEPATH_BIO2_SC.Text);
                        sw.WriteLine(EXE_PATH_LEONU.Text);
                        sw.WriteLine(EXEPATH_CLAIREU.Text);
                        sw.WriteLine(EXEPATH_BIO3MK.Text);
                        sw.WriteLine(EXEPATH_BIO3EA.Text);                       
                    }

                }
            }

        }

        private void FRM_CONFIG_Load(object sender, EventArgs e)
        {
            // if file exists..
            if (File.Exists(config_file_path))
            {
                path_array = File.ReadAllLines(config_file_path);
                
            for (int i = 0; i < path_array.Length; i++)
            {
                EXEPATH_BIO2_SC.Text = path_array[0];
                EXE_PATH_LEONU.Text = path_array[1];
                EXEPATH_CLAIREU.Text = path_array[2];
                EXEPATH_BIO3MK.Text = path_array[3];
                EXEPATH_BIO3EA.Text = path_array[4];                                                          
            }


            // set paths to global data
                LIB_EXE.EXE_PATHS.bio2_exe_path = path_array[0];
                LIB_EXE.EXE_PATHS.leonu_path = path_array[1];
                LIB_EXE.EXE_PATHS.claireu_path = path_array[2];
                LIB_EXE.EXE_PATHS.bio3_mk_path = path_array[3];
                LIB_EXE.EXE_PATHS.bio3_ea_path = path_array[4];


            //foreach (string str in path_array)
            //{
            //    MessageBox.Show(str);
            //}
            
            }
        }
    }

    public static class DIR_EXE_OBJ
    {
        
        
         
    }

}
