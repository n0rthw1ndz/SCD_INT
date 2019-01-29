using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace SCDint
{
    public static class LIB_RDT
    {
        public static string[] Current_SCD_Lines;
        public static string Selected_ByteStr;

        public static Dictionary<int, string> LUT_RDT_OFFSET = new Dictionary<int, string>()
        {
            {0, "Sound Effect Attributes (*.SND)"},
            {1, "Sound Effect Header (*.VH)"},
            {2, "Sound Effect Bank (*.VB)"},
            {3, "Sound Effect Header (*.VH) (UNUSED - Trial Edition, Only)" },
            {4, "Sound Effect Bank (*.VB) (UNUSED - Trial Edition, Only)" },
            {5, "UNUSED (.OTA)" },
            {6, "Collision Boundaries for 3D Models (*.SCA)"},
            {7, "Camera Positions & Targets, pointers to Camera Sprites (*.RID)"},
            {8, "Camera Zones/Switches (*.RVD)"},
            {9, "Lighting for 3D Models (*.LIT)"},
            {10, "3D Model pointer array (*.MD1;*.TIM)"},
            {11, "Floor data (*.FLR)"},
            {12, "Block data (*.BLK)" },
            {13, "Event Text/Message data (Japanese) (*.MSG)"},
            {14, "Event Text/Message data (Other) (*.MSG)"},
            {15, "Camera Scroll Texture (*.TIM)"},
            {16, "Initialization Script(s) (*.SCD)"},
            {17, "Execution Script(s) (*.SCD)"},
            {18, "Effect Sprite ID List (*.ESP)"},
            {19, "Effect Sprite Data (*.EFF)"},
            {20,  "Effect Sprite Texture (*.TIM)"},
            {21, "3D Model Textures (*.TIM) (sizeof RDT, if nOmodel=0)"},
            {22, "Animation Data for 3D Models (*.RBJ)"},
            
        };

        public static List<Int32> OFFSET_LIST = new List<int>();

        public struct RDT_HEADER_OBJ
        {
            public byte nSPrite;  /* unknown */
            public byte nCut;     /* Amount of Camera arrays */
            public byte noModel; /* Amount of Object 3D models */
            public byte nItem;   /* Amount of Item 3D models (UNUSED) */
            public byte nDoor;   /* unknown */
            public byte nRoom_At; /* unknown */
            public byte Reverb_lv; /* unknown */
            public byte nSprite_Max; /* Sum total of individual Camera Sprites/Masks */

            public int[] nOffsets; // 
        }

        /// <summary>
        /// Holds current RDT's SCD_DATA INFO..
        /// </summary>
        public struct SCD_HEADER_OBJ
        {
            public Int32 O_SCDMAIN; 
            public Int32 O_SCD_SUB;

            public Int16 nMain; 
            public Int16 nSub; // divide these by 2 to get true scd length

            public Int32 SCDMAIN_SZ; // total size of main scd block
            public Int32 SCDSUB_SZ; // total size of sub scd block, which will be broken apart based on count

            public Int16[] O_SCD_SUBS; // array of pointers to 
            public int[] SZ_SDS;
            public int SUB_SCD_PTR_T; // total of all scd ptrs
          

        }


        /// <summary>
        ///  struct for holding / transfering selected em_set opcode data
        /// </summary>
        public struct EM_SET_OBJ
        {
            public byte _opdummy;
            public byte _ubyte00;
            public byte _emIndex;
            public byte _emdID;
            public byte _emPose;
            public short _AnimFlag00;
            public short _ushort00;
            public byte _SND;
            public byte _TEX;
            public byte _emFlag;
            public short _posx;
            public short _posy;
            public short _posz;
            public short _posr;
            public short _ushort01;
            public short _ushort02;

        }



        /// <summary>
        /// struct for holding current rdt's message data
        /// </summary>
        public struct MSG_BLK_OBJ
        {
            public Int16[] Msg_Ptrs;
            public Int16 Total;
            public string[] Msgs;
           
        }

        public struct MsgAot_Obj
        {
           public byte[] Msg_Data;
            public string bytestr;
            public string Msg;
            public int msg_sz;
        }



    }
}
