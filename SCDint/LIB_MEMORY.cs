using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace SCDint
{
    public static class LIB_MEMORY
    {
        public static Dictionary<int, string> LUT_SUPPORTEDGAMES = new Dictionary<int, string>
        {
            {0, "bio2"}, // JP SOURCENEXT
            {1, "LEONU"}, // NA US
            {2, "CLAIREU"}, // NA US
            {3, "Bio3_PC"}, // JP MEDIAKITE
            {4, "Bio3_PC_Mercenaries"}, // MEDIAKITE MERCS
            {5, "bio3_pc"}, // EA CHINA
            {6, "bio3_pc_mercenaries"}, // EA CHINA
            {7, "BIOHAZARD(R) 3 PC"}, // JP SOURCENEXT
            {8, "ResidentEvil3" }, // NA US

        };



        public static Dictionary<int, string> LUT_BIO2_ITEM_TBL = new Dictionary<int, string>
        {



        };


        public struct HOOKED_DATA_OBJ
        {
            public string Process_Name;
            public Process Hooked_Process;
            public bool IsHooked;
            public byte G_FLAG;
        }

        /// <summary>
        /// WEAPON/INVO INFo
        /// </summary>
        public struct EXE_WEAPON_OBJ
        {
            public byte WEAPON_ID;
            public byte AMMO_COUNT;
            public byte SLOT_COUNT; // on bio2 its a slot_COUNT on bio3 is controls the type 0x00 - 0x0F

            public byte dummy;

        }


        public struct EXE_PLAYER_SAVE
        {
            public int PlayTime;
            public byte Stage;
            public byte Room;
            public byte Camera;
            public Int16 X;
            public Int16 Y;
            public Int16 Z;
            public Int16 R;
            public byte Floor;
            public Int16 HP;
            public byte Poison;
            public byte Player;
            public byte PLD;
            public byte Equipped;
            
        }




        /// <summary>
        /// Player Related Data and Stats
        /// </summary>
        public struct EXE_PLAYER_OBJ
        {
            public Int16 PL_HP;
            public byte FLOOR_FLAG;
            public byte PLD_ID;
            public byte ANIM_FLAG;
            public byte PZN_FLAG;
            public Int16 SIDEPACK_FLAG;
            public byte EQUIP_ID;


            public Int32 POS_X;
            public Int32 POS_Y;
            public Int32 POS_Z;
            public Int32 POS_R;
            public Int16 FAS_COUNT;
            public Int16 BODY_COUNT;
            public Int16 T_SAVES;
            public Int16 TIME_OFF;
            public TimeSpan Time;

        }



        /// <summary>
        /// ROOM INITILIASION DATA
        /// </summary>
        public struct EXE_ROOM_INIT
        {
            public Int16 SCENE_ID;
            public Int16 STAGE_ID;
            public Int16 ROOM_ID;
            public Int16 CUR_CAM;
            public Int16 OLD_CAM;
            public Int16 OLD_ROOM;

            public byte SND;
            public byte VH;
            public byte VB;
            public byte VH_TRIAL;
            public byte VB_TRIAL;
            public byte OTA; // unused/
            public byte SCA;
            public byte RID;
            public byte RVD;
            public byte LIT;
            public byte MD1_TABLE;
            public byte MSG_MAIN;
            public byte MSG_SUB;
            public byte TIM_CAM;
            public byte SCD_MAIN;
            public byte SCD_SUB;
            public byte ESP;
            public byte EFF;
            public byte RBJ;
            public byte PRI;
        }


        public static EXE_PLAYER_OBJ EXE_PLAYER = new EXE_PLAYER_OBJ();
        public static EXE_WEAPON_OBJ[] EXE_INVO = new EXE_WEAPON_OBJ[10];
        public static EXE_ROOM_INIT EXE_ROOM = new EXE_ROOM_INIT();
        public static HOOKED_DATA_OBJ DATA_HOOK = new HOOKED_DATA_OBJ();
        public static EXE_PLAYER_SAVE MEM_SAVE = new EXE_PLAYER_SAVE();

        //###################################################################
        //         BIOHAZARD 2 SOURCENEXT MEMORY FUNCTIONS
        // ------------------------------------------------------------------


        public static void BIO2_EXE_SOURCENEXT(Process bio_2proc)
        {
            EXE_PLAYER.PL_HP = Memory.Read<Int16>(bio_2proc, new IntPtr(0x989FE6));
            EXE_PLAYER.BODY_COUNT = Memory.Read<Int16>(bio_2proc, new IntPtr(0x98E958));
            EXE_PLAYER.FAS_COUNT = Memory.Read<Int16>(bio_2proc, new IntPtr(0x98E951));
            EXE_PLAYER.T_SAVES = Memory.Read<Int16>(bio_2proc, new IntPtr(0x98E95C));
            EXE_PLAYER.EQUIP_ID = Memory.Read<byte>(bio_2proc, new IntPtr(0x691F0A));
            EXE_PLAYER.PLD_ID = Memory.Read<byte>(bio_2proc, new IntPtr(0x98EAC4));
            EXE_PLAYER.TIME_OFF = Memory.Read<Int16>(bio_2proc, new IntPtr(0x680538));
            EXE_PLAYER.SIDEPACK_FLAG = Memory.Read<Int16>(bio_2proc, new IntPtr(0x98E944));

            EXE_PLAYER.POS_X = Memory.Read<Int16>(bio_2proc, new IntPtr(0x989EC8));
            EXE_PLAYER.POS_Y = Memory.Read<Int16>(bio_2proc, new IntPtr(0x989ECC));
            EXE_PLAYER.POS_Z = Memory.Read<Int16>(bio_2proc, new IntPtr(0x989ED0));
            EXE_PLAYER.POS_R = Memory.Read<Int16>(bio_2proc, new IntPtr(0x989F06));

            EXE_PLAYER.FLOOR_FLAG = Memory.Read<byte>(bio_2proc, new IntPtr(0x989F96));

            for (int i = 0; i < EXE_INVO.Length; i++)
            {
                EXE_INVO[i].WEAPON_ID = Memory.Read<byte>(bio_2proc, new IntPtr(0x98ECD4 + (i * 4)));
                EXE_INVO[i].AMMO_COUNT = Memory.Read<byte>(bio_2proc, new IntPtr(0x98ECD5 + (i * 4)));
                EXE_INVO[i].SLOT_COUNT = Memory.Read<byte>(bio_2proc, new IntPtr(0x98ECD6 + (i * 4)));
                EXE_INVO[i].dummy = Memory.Read<byte>(bio_2proc, new IntPtr(0x98ECD7 + (i * 4)));
            }

            EXE_ROOM.SCENE_ID = Memory.Read<byte>(bio_2proc, new IntPtr(0x98E950));
            EXE_ROOM.STAGE_ID = Memory.Read<byte>(bio_2proc, new IntPtr(0x98EAB6));
            EXE_ROOM.CUR_CAM = Memory.Read<byte>(bio_2proc, new IntPtr(0x98EAB8));
            EXE_ROOM.OLD_CAM = Memory.Read<byte>(bio_2proc, new IntPtr(0x9855B4));
            EXE_ROOM.ROOM_ID = Memory.Read<byte>(bio_2proc, new IntPtr(0x98EAB6));
            EXE_ROOM.OLD_ROOM = Memory.Read<byte>(bio_2proc, new IntPtr(0x98EABA));

            

        }

        public static void BIO2_EXE_UPDATE_INVO(Process bio2_proc, System.Windows.Forms.ComboBox[] ITEM_SLOTS, System.Windows.Forms.NumericUpDown[] QUAN_SLOTS)
        {
            // loop through all invo slots and re update ..
            for (int i = 0; i < EXE_INVO.Length; i++)
            {
                switch (LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[i].SelectedItem.ToString()])
                {
                    // handle flame thrower

                    case 0x10:
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD4 + (i * 4)), 0x10);
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD5 + (i * 4)), byte.Parse(QUAN_SLOTS[i].Value.ToString()));
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD6 + (i * 4)), 0x01);
                        break;


                    case 0x66:
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD4 + (i * 4)), 0x10);
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD5 + (i * 4)), 0x01);
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD6 + (i * 4)), 0x02);
                        break;


                    case 0x11:
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD4 + (i * 4)), 0x11);
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD5 + (i * 4)), byte.Parse(QUAN_SLOTS[i].Value.ToString()));
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD6 + (i * 4)), 0x01);
                        break;

                    case 0x67:
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD4 + (i * 4)), 0x11);
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD5 + (i * 4)), 0x01);
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD6 + (i * 4)), 0x02);
                        break;



                    case 0x12:
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD4 + (i * 4)), 0x12);
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD5 + (i * 4)), byte.Parse(QUAN_SLOTS[i].Value.ToString()));
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD6 + (i * 4)), 0x01);
                        break;

                    case 0x68:
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD4 + (i * 4)), 0x12);
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD5 + (i * 4)), 0x01);
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD6 + (i * 4)), 0x02);
                        break;







                    // handle INGRAM MAC 10
                    case 0x0F:
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD4 + (i * 4)), 0x0F);
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD5 + (i * 4)), byte.Parse(QUAN_SLOTS[i].Value.ToString()));
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD6 + (i * 4)), 0x01);
                        break;


                    case 0x65:
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD4 + (i * 4)), 0x0F);
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD5 + (i * 4)), 0x01);
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD6 + (i * 4)), 0x02);
                        break;



                    default:
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD4 + (i * 4)), LIB_ITEM.BIO2_ITEM_LUT_INVERSE[ITEM_SLOTS[i].SelectedItem.ToString()]);
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD5 + (i * 4)), byte.Parse(QUAN_SLOTS[i].Value.ToString()));
                        Memory.Write<byte>(bio2_proc, new IntPtr(0x98ECD6 + (i * 4)), 0x00);
                        break;


                }



            }

        }

        
        public static void BIO2_EXE_SIDEPACK(Process bio2_proc, bool enabled)
        {
            if (enabled)
            {
                Memory.Write<Int16>(bio2_proc, new IntPtr(0x98E944), 10);
            }
            else
            {
                Memory.Write<Int16>(bio2_proc, new IntPtr(0x98E944), 8);
            }

        }


        /// <summary>
        /// Programmatically jump between fine.caution/danger for debugging
        /// </summary>
        public static void BIO2_EXE_SET_STATUS(Process bio2_proc, string status)
        {
            switch (status.ToUpper())
            {
                case "FINE": Memory.Write<Int16>(bio2_proc, new IntPtr(0x989FE6), 200); break;
                case "CAUTION0": Memory.Write<Int16>(bio2_proc, new IntPtr(0x989FE6), 100); break;
                case "CAUTION1": Memory.Write<Int16>(bio2_proc, new IntPtr(0x989FE6), 40); break;
                case "DANGER": Memory.Write<Int16>(bio2_proc, new IntPtr(0x989FE6), 19); break;
            }



            //#############################################
        }


        public static void BIO2_EXE_SAVE_ANYWHERE(Process bio2_proc, string file_path)
        {
            byte[] tmp_save = new byte[2048];

            for (int i = 0; i < tmp_save.Length; i++)
            {
                tmp_save[i] = Memory.Read<byte>(bio2_proc, new IntPtr(0x98E73C + i));
            }


            MEM_SAVE.PlayTime = Memory.Read<int>(bio2_proc, new IntPtr(0x680538));

            MEM_SAVE.Stage = Memory.Read<byte>(bio2_proc, new IntPtr(0x989EC8 - 171));
            MEM_SAVE.Camera = Memory.Read<byte>(bio2_proc, new IntPtr(0x989EC8 - 62));
            MEM_SAVE.X = Memory.Read<Int16>(bio2_proc, new IntPtr(0x989EC8));
            MEM_SAVE.Z = Memory.Read<Int16>(bio2_proc, new IntPtr(0x989EC8 + 4));
            MEM_SAVE.Y = Memory.Read<Int16>(bio2_proc, new IntPtr(0x989EC8 + 8));
            MEM_SAVE.R = Memory.Read<Int16>(bio2_proc, new IntPtr(0x989EC8 + 62));
            MEM_SAVE.Floor = Memory.Read<byte>(bio2_proc, new IntPtr(0x989EC8 + 206));
            MEM_SAVE.HP = Memory.Read<Int16>(bio2_proc, new IntPtr(0x989EC8 + 286));
            MEM_SAVE.Poison = Memory.Read<byte>(bio2_proc, new IntPtr(0x989EC8 + 480));

            MEM_SAVE.Player = Memory.Read<byte>(bio2_proc, new IntPtr(0x98E73C + 522));
            MEM_SAVE.Room = Memory.Read<byte>(bio2_proc, new IntPtr(0x98E73C + 890));
            MEM_SAVE.PLD = Memory.Read<byte>(bio2_proc, new IntPtr(0x98E73C + 904));


            using (FileStream fs = new FileStream(file_path, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {

                    bw.Write(tmp_save);

                    fs.Seek(512, SeekOrigin.Begin);
                    bw.Write(MEM_SAVE.PlayTime);

                    fs.Seek(528, SeekOrigin.Begin);
                    bw.Write(MEM_SAVE.Poison);

                    fs.Seek(538, SeekOrigin.Begin);
                    bw.Write(MEM_SAVE.HP);

                    fs.Seek(546, SeekOrigin.Begin);
                    bw.Write(MEM_SAVE.X);
                    bw.Write(MEM_SAVE.Y);
                    bw.Write(MEM_SAVE.Z * 1800);


                  

                    fs.Seek(888, SeekOrigin.Begin);
                    bw.Write(MEM_SAVE.Stage);

                    fs.Seek(890, SeekOrigin.Begin);
                    bw.Write(MEM_SAVE.Room);

                    fs.Seek(892, SeekOrigin.Begin);
                    bw.Write(MEM_SAVE.Camera);


                    fs.Seek(1756, SeekOrigin.Begin);
                    bw.Write(MEM_SAVE.R);

                    fs.Seek(1758, SeekOrigin.Begin);
                    bw.Write(MEM_SAVE.Floor);
                    
                }
            }


        }



        //###################################################################
        //         BIOHAZARD 3 MEDIAKITE JP MEMORY FUNCTIONS
        // ------------------------------------------------------------------


        public static void BIO3_EXE_MEDIAKITE(Process bio3_proc)
        {
            EXE_PLAYER.PL_HP = Memory.Read<Int16>(bio3_proc, new IntPtr(0xA5BE60));
            EXE_PLAYER.PLD_ID = Memory.Read<byte>(bio3_proc, new IntPtr(0x6F8729));
            EXE_PLAYER.POS_R = Memory.Read<Int16>(bio3_proc, new IntPtr(0xA5BE03));
            EXE_PLAYER.PZN_FLAG = Memory.Read<byte>(bio3_proc, new IntPtr(0xA5BE67));


            Int32 t_save = Memory.Read<Int32>(bio3_proc, new IntPtr(0xA5BAE4));
            Int32 t_total = Memory.Read<Int32>(bio3_proc, new IntPtr(0xA610F8));
            Int32 t_current = Memory.Read<Int32>(bio3_proc, new IntPtr(0x53399C + 0x5ac));

            EXE_PLAYER.Time = TimeSpan.FromSeconds((t_current - t_save + t_total) / 60.0f);
 
            //   EXE_PLAYER.POS_X = Memory.Read<Int16>(bio3_proc, new IntPtr(0xA5BE))

            

            for (int i = 0; i < EXE_INVO.Length; i++)
            {
                EXE_INVO[i].WEAPON_ID = Memory.Read<byte>(bio3_proc, new IntPtr(0xA61304 + (i * 4)));
                EXE_INVO[i].AMMO_COUNT = Memory.Read<byte>(bio3_proc, new IntPtr(0xA61305 + (i* 4)));
                EXE_INVO[i].SLOT_COUNT = Memory.Read<byte>(bio3_proc, new IntPtr(0xA61306 + (i * 4))); // this is actually type flag for ammo display
                EXE_INVO[i].dummy = Memory.Read<byte>(bio3_proc, new IntPtr(0xA61307 + (i * 4)));                             
            }

            

            EXE_ROOM.ROOM_ID = Memory.Read<byte>(bio3_proc, new IntPtr(0xA61148));
            EXE_ROOM.OLD_ROOM = Memory.Read<byte>(bio3_proc, new IntPtr(0xA6114C));
            EXE_ROOM.CUR_CAM = Memory.Read<byte>(bio3_proc, new IntPtr(0xA6114A));
            EXE_ROOM.OLD_CAM = Memory.Read<byte>(bio3_proc, new IntPtr(0xA6114E));
            EXE_ROOM.STAGE_ID = Memory.Read<byte>(bio3_proc, new IntPtr(0xA6114D)); 
            

        }


        public static void BIO3_EXE_SET_STATUS(Process bio3_proc, string status)
        {
            switch (status.ToUpper())
            {
                case "FINE": Memory.Write<Int16>(bio3_proc, new IntPtr(0xA5BE60), 200); break;
                case "CAUTION0": Memory.Write<Int16>(bio3_proc, new IntPtr(0xA5BE60), 100); break;
                case "CAUTION1": Memory.Write<Int16>(bio3_proc, new IntPtr(0xA5BE60), 40); break;
                case "DANGER": Memory.Write<Int16>(bio3_proc, new IntPtr(0xA5BE60), 19); break;
            }
        }


        /// <summary>
        /// Update Bio3 invo, needs a flag for MK/EA
        /// </summary>
        /// <param name="bio3_proc"></param>
        /// <param name="ITEM_SLOTS"></param>
        /// <param name="QUAN_SLOTS"></param>
        public static void BIO3_EXE_UPDATE_INVO(Process bio3_proc, System.Windows.Forms.ComboBox[] ITEM_SLOTS, System.Windows.Forms.NumericUpDown[] QUAN_SLOTS)
        {

            for (int i = 0; i < EXE_INVO.Length; i++)
            {
                Memory.Write<byte>(bio3_proc, new IntPtr(0xA61304 + (i * 4)), LIB_ITEM.BIO3_ITEM_LUT_INVERSE[ITEM_SLOTS[i].SelectedItem.ToString()]);
                Memory.Write<byte>(bio3_proc, new IntPtr(0xA61305 + (i * 4)), byte.Parse(QUAN_SLOTS[i].Value.ToString()));
                Memory.Write<byte>(bio3_proc, new IntPtr(0xA61306 + (i * 4)), LIB_MEMORY.EXE_INVO[i].SLOT_COUNT); // this is actually type flag for ammo display
                Memory.Write<byte>(bio3_proc, new IntPtr(0xA61307 + (i * 4)), LIB_MEMORY.EXE_INVO[i].dummy);

            }

        }

        //###################################################################
        //         BIOHAZARD 3 EA CHINA MEMORY FUNCTIONS
        // ------------------------------------------------------------------

        public static void BIO3_EXE_EACHINA(Process bio3_proc)
        {

            EXE_PLAYER.PL_HP = Memory.Read<Int16>(bio3_proc, new IntPtr(0xAFFC00));
            EXE_PLAYER.PLD_ID = Memory.Read<byte>(bio3_proc, new IntPtr(0x6F8729));
            EXE_PLAYER.POS_R = Memory.Read<Int16>(bio3_proc, new IntPtr(0xA5BE03));
            EXE_PLAYER.PZN_FLAG = Memory.Read<byte>(bio3_proc, new IntPtr(0xA5BE67));
            


            //  EXE_PLAYER.Time = TimeSpan.FromSeconds((t_current - t_save + t_total) / 60.0f);



            EXE_PLAYER.POS_X = Memory.Read<Int16>(bio3_proc, new IntPtr(0xAFFBC4));
            EXE_PLAYER.POS_Y = Memory.Read<Int16>(bio3_proc, new IntPtr(0xAFFBC8));
            EXE_PLAYER.POS_Z = Memory.Read<Int16>(bio3_proc, new IntPtr(0xAFFBCA));
            EXE_PLAYER.POS_R = Memory.Read<Int16>(bio3_proc, new IntPtr(0xAFFBA2));




            for (int i = 0; i < EXE_INVO.Length; i++)
            {
                

                EXE_INVO[i].WEAPON_ID = Memory.Read<byte>(bio3_proc, new IntPtr(0xB050A4 + (i * 4)));
                EXE_INVO[i].AMMO_COUNT = Memory.Read<byte>(bio3_proc, new IntPtr(0xB050A5 + (i * 4)));
                EXE_INVO[i].SLOT_COUNT = Memory.Read<byte>(bio3_proc, new IntPtr(0xB050A6 + (i * 4))); // this is actually type flag for ammo display
                EXE_INVO[i].dummy = Memory.Read<byte>(bio3_proc, new IntPtr(0xB050A7 + (i * 4)));
            }



            EXE_ROOM.ROOM_ID = Memory.Read<byte>(bio3_proc, new IntPtr(0xB04EE8));
            EXE_ROOM.OLD_ROOM = Memory.Read<byte>(bio3_proc, new IntPtr(0xB04EEC));
            EXE_ROOM.CUR_CAM = Memory.Read<byte>(bio3_proc, new IntPtr(0xB04EEA));
            EXE_ROOM.OLD_CAM = Memory.Read<byte>(bio3_proc, new IntPtr(0xB04EEE));
            EXE_ROOM.STAGE_ID = Memory.Read<byte>(bio3_proc, new IntPtr(0xB04EED));
        }


       



    }
}
