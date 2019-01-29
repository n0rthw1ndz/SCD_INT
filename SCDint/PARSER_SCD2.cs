using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCDint
{
    
    /// <summary>
    /// Re2 scd parser
    /// </summary>
    class PARSER_SCD2
    {   //////////////////////////////////////////////////////////////////////////////
        // 0x0_
        //////////////////////////////////////////////////////////////////////////////
        public class x04
        {
            private byte condition = 0;

            public byte Condition { get { return condition; } set { condition = value; } }
        }

        public class x09
        {
            private byte op = 10;
            private Int16 count = 0;

            public byte Dummy { get { return op; } set { op = value; } }
            public Int16 Count { get { return count; } set { count = value; } }
        }
        public class x0A
        {
            private Int16 count = 0;

            public Int16 Count { get { return count; } set { count = value; } }
        }
        //0B
        //0C
        public class x0D
        {
            private byte dummy = 0;
            private Int16 length = 0;
            private Int16 count = 0;

            public byte Dummy
            {
                get { return dummy; }
                set { dummy = value; }
            }
            public Int16 Length
            {
                get { return length; }
                set { length = value; }
            }
            public Int16 Count
            {
                get { return count; }
                set { count = value; }
            }
        }

        //////////////////////////////////////////////////////////////////////////////
        // 0x1_
        //////////////////////////////////////////////////////////////////////////////
        public class x14
        {
            private byte dummy = 0;
            private Int16 length = 0;
            private Int16 count = 0;

            public byte Dummy
            {
                get { return dummy; }
                set { dummy = value; }
            }
            public Int16 Length
            {
                get { return length; }
                set { length = value; }
            }
            public Int16 Count
            {
                get { return count; }
                set { count = value; }
            }
        }

        public class x18
        {
            private byte sub = 0;

            public byte Sub
            {
                get { return sub; }
                set { sub = value; }
            }
        }
        public class x1A
        {
            private byte u0 = 0;

            public byte U0 { get { return u0; } set { u0 = value; } }
        }

        //////////////////////////////////////////////////////////////////////////////
        // 0x2_
        //////////////////////////////////////////////////////////////////////////////
        public class x21
        {
            private byte ARRAY = 0;
            private byte FLAG = 0;
            private byte VALUE = 0;

            public byte Array
            {
                get { return ARRAY; }
                set { ARRAY = value; }
            }
            public byte Flag
            {
                get { return FLAG; }
                set { FLAG = value; }
            }
            public byte Value
            {
                get { return VALUE; }
                set { VALUE = value; }
            }
        }
        public class x22
        {
            private byte ARRAY = 0;
            private byte FLAG = 0;
            private byte VALUE = 0;

            public byte Array
            {
                get { return ARRAY; }
                set { ARRAY = value; }
            }
            public byte Flag
            {
                get { return FLAG; }
                set { FLAG = value; }
            }
            public byte Value
            {
                get { return VALUE; }
                set { VALUE = value; }
            }
        }
        public class x23
        {
            private byte dummy = 0;
            private byte index = 0;
            private byte op = 0;
            private Int16 val = 0;

            public byte Dummy
            {
                get { return dummy; }
                set { dummy = value; }
            }
            public byte Variable
            {
                get { return index; }
                set { index = value; }
            }
            public byte Comparison
            {
                get { return op; }
                set { op = value; }
            }
            public Int16 Value
            {
                get { return val; }
                set { val = value; }
            }
        }
        public class x24
        {
            private byte index = 0;
            private Int16 val = 0;

            public byte Variable { get { return index; } set { index = value; } }
            public Int16 Value { get { return val; } set { val = value; } }
        }
        public class x25
        {
            private byte dst = 0;
            private byte src = 0;

            public byte Target { get { return dst; } set { dst = value; } }
            public byte Source { get { return src; } set { src = value; } }
        }
        public class x26
        {
            private byte dummy = 0;
            private byte op = 0;
            private byte varw = 0;
            private Int16 val = 0;

            public byte Dummy { get { return dummy; } set { dummy = value; } }
            public byte Operation { get { return op; } set { op = value; } }
            public byte Variable { get { return varw; } set { varw = value; } }
            public Int16 Value { get { return val; } set { val = value; } }
        }
        public class x27
        {
            private byte op = 0;
            private byte varw = 0;
            private byte srcw = 0;

            public byte Operation { get { return op; } set { op = value; } }
            public byte Variable { get { return varw; } set { varw = value; } }
            public byte Variable2 { get { return srcw; } set { srcw = value; } }
        }


        public class x29
        {
            private byte cam = 0;

            public byte Camera
            {
                get { return cam; }
                set { cam = value; }
            }
        }

        public class x2B
        {
            private byte u0 = 0;
            private byte msg = 0;
            private byte u1 = 0;
            private Int16 mode = 0;

            public byte U0 { get { return u0; } set { u0 = value; } }
            public byte MSG_ID { get { return msg; } set { msg = value; } }
            public byte U1 { get { return u1; } set { u1 = value; } }
            public Int16 Mode { get { return mode; } set { mode = value; } }
        }
        public class x2C
        {
            private byte aot = 0;
            private byte id = 0;
            private byte type = 0;
            private byte floor = 0;
            private byte super = 0;
            private Int16 x = 0;
            private Int16 y = 0;
            private UInt16 w = 0;
            private UInt16 d = 0;
            private Int16 data0 = 0;
            private Int16 data1 = 0;
            private Int16 data2 = 0;

            public byte AOT
            {
                get { return aot; }
                set { aot = value; }
            }
            public byte ID
            {
                get { return id; }
                set { id = value; }
            }
            public byte Type
            {
                get { return type; }
                set { type = value; }
            }
            public byte Floor
            {
                get { return floor; }
                set { floor = value; }
            }
            public byte Super
            {
                get { return super; }
                set { super = value; }
            }
            public Int16 X
            {
                get { return x; }
                set { x = value; }
            }
            public Int16 Y
            {
                get { return y; }
                set { y = value; }
            }
            public UInt16 Width
            {
                get { return w; }
                set { w = value; }
            }
            public UInt16 Depth
            {
                get { return d; }
                set { d = value; }
            }
            public Int16 Data0
            {
                get { return data0; }
                set { data0 = value; }
            }
            public Int16 Data1
            {
                get { return data1; }
                set { data1 = value; }
            }
            public Int16 Data2
            {
                get { return data2; }
                set { data2 = value; }
            }
        }
        public class x2D
        {
            private byte id = 0;
            private byte tex_ctr = 0;
            private byte ani = 0;
            private byte ani_speed = 0;
            private byte floor = 0;
            private byte super = 0;
            private byte type = 0;
            private Int16 sflag = 0;
            private Int16 bflag = 0;
            private Int16 attr = 0;
            private Int16 x = 0;
            private Int16 z = 0;
            private Int16 y = 0;
            private Int16 rx = 0;
            private Int16 rz = 0;
            private Int16 ry = 0;
            private Int16 o_atarix = 0;
            private Int16 o_atariz = 0;
            private Int16 o_atariy = 0;
            private Int16 s_atarix = 0;
            private Int16 s_atariz = 0;
            private Int16 s_atariy = 0;

            public byte MD1_ID
            {
                get { return id; }
                set { id = value; }
            }
            public byte Texture
            {
                get { return tex_ctr; }
                set { tex_ctr = value; }
            }
            public byte Animation
            {
                get { return ani; }
                set { ani = value; }
            }
            public byte Speed
            {
                get { return ani_speed; }
                set { ani_speed = value; }
            }
            public byte Floor
            {
                get { return floor; }
                set { floor = value; }
            }
            public byte Super
            {
                get { return super; }
                set { super = value; }
            }
            public byte Type
            {
                get { return type; }
                set { type = value; }
            }
            public Int16 S_Flag
            {
                get { return sflag; }
                set { sflag = value; }
            }
            public Int16 BE_Flag
            {
                get { return bflag; }
                set { bflag = value; }
            }
            public Int16 Attribute
            {
                get { return attr; }
                set { attr = value; }
            }
            public Int16 X
            {
                get { return x; }
                set { x = value; }
            }
            public Int16 Z
            {
                get { return z; }
                set { z = value; }
            }
            public Int16 Y
            {
                get { return y; }
                set { y = value; }
            }
            public Int16 Rotation_X
            {
                get { return rx; }
                set { rx = value; }
            }
            public Int16 Rotation_Z
            {
                get { return rz; }
                set { rz = value; }
            }
            public Int16 Rotation_Y
            {
                get { return ry; }
                set { ry = value; }
            }
            public Int16 Offset_X
            {
                get { return o_atarix; }
                set { o_atarix = value; }
            }
            public Int16 Offset_Z
            {
                get { return o_atariz; }
                set { o_atariz = value; }
            }
            public Int16 Offset_Y
            {
                get { return o_atariy; }
                set { o_atariy = value; }
            }
            public Int16 Size_X
            {
                get { return s_atarix; }
                set { s_atarix = value; }
            }
            public Int16 Size_Z
            {
                get { return s_atariz; }
                set { s_atariz = value; }
            }
            public Int16 Size_Y
            {
                get { return s_atariy; }
                set { s_atariy = value; }
            }
        }
        public class x2E
        {
            private byte obj = 0;
            private byte id = 0;
            private byte dummy = 0;

            public byte Component
            {
                get { return obj; }
                set { obj = value; }
            }
            public byte ID
            {
                get { return id; }
                set { id = value; }
            }
            public byte Dummy
            {
                get { return dummy; }
                set { dummy = value; }
            }
        }
        public class x2F
        {
            private byte ARRAY = 0;
            private Int16 VALUE = 0;

            public byte Component { get { return ARRAY; } set { ARRAY = value; } }
            public Int16 Value { get { return VALUE; } set { VALUE = value; } }
        }

        //////////////////////////////////////////////////////////////////////////////
        // 0x3_
        //////////////////////////////////////////////////////////////////////////////
        public class x32
        {
            private byte dummy = 0;
            private Int16 x = 0;
            private Int16 z = 0;
            private Int16 y = 0;

            public byte Dummy { get { return dummy; } set { dummy = value; } }
            public Int16 X { get { return x; } set { x = value; } }
            public Int16 Z { get { return z; } set { z = value; } }
            public Int16 Y { get { return y; } set { y = value; } }
        }
        public class x36
        {
            private byte u0 = 0;
            private byte u1 = 0;
            private byte u2 = 0;
            private byte u3 = 0;
            private byte u4 = 0;
            private Int16 x = 0;
            private Int16 z = 0;
            private Int16 y = 0;

            public byte U0 { get { return u0; } set { u0 = value; } }
            public byte U1 { get { return u1; } set { u1 = value; } }
            public byte U2 { get { return u2; } set { u2 = value; } }
            public byte U3 { get { return u3; } set { u3 = value; } }
            public byte U4 { get { return u4; } set { u4 = value; } }
            public Int16 X { get { return x; } set { x = value; } }
            public Int16 Z { get { return z; } set { z = value; } }
            public Int16 Y { get { return y; } set { y = value; } }
        }
        public class x3B
        {
            private byte aot = 0;
            private byte id = 0;
            private byte type = 0;
            private byte floor = 0;
            private byte super = 0;
            private Int16 x = 0;
            private Int16 y = 0;
            private UInt16 w = 0;
            private UInt16 d = 0;
            private Int16 tx = 0;
            private Int16 tz = 0;
            private Int16 ty = 0;
            private Int16 r = 0;
            private byte stage = 0;
            private string room = "00";
            private byte cam = 0;
            private byte tfloor = 0;
            private string do2 = "00";
            private byte ani = 0;
            private byte sound = 0;
            private byte key = 0;
            private byte lock_flag = 0;
            private byte dummy = 0;

            public byte AOT
            {
                get { return aot; }
                set { aot = value; }
            }
            public byte ID
            {
                get { return id; }
                set { id = value; }
            }
            public byte Type
            {
                get { return type; }
                set { type = value; }
            }
            public byte Floor
            {
                get { return floor; }
                set { floor = value; }
            }
            public byte Super
            {
                get { return super; }
                set { super = value; }
            }
            public Int16 X
            {
                get { return x; }
                set { x = value; }
            }
            public Int16 Y
            {
                get { return y; }
                set { y = value; }
            }
            public UInt16 Width
            {
                get { return w; }
                set { w = value; }
            }
            public UInt16 Depth
            {
                get { return d; }
                set { d = value; }
            }
            public Int16 Target_X
            {
                get { return tx; }
                set { tx = value; }
            }
            public Int16 Target_Z
            {
                get { return tz; }
                set { tz = value; }
            }
            public Int16 Target_Y
            {
                get { return ty; }
                set { ty = value; }
            }
            public Int16 Rotation
            {
                get { return r; }
                set { r = value; }
            }
            public byte Stage
            {
                get { return stage; }
                set { stage = value; }
            }
            public string Room_ID
            {
                get { return room; }
                set { room = value; }
            }
            public byte Camera
            {
                get { return cam; }
                set { cam = value; }
            }
            public byte Target_Floor
            {
                get { return tfloor; }
                set { tfloor = value; }
            }
            public string DO2_File
            {
                get { return do2; }
                set { do2 = value; }
            }
            public byte Animation
            {
                get { return ani; }
                set { ani = value; }
            }
            public byte Sound
            {
                get { return sound; }
                set { sound = value; }
            }
            public byte Key_ID
            {
                get { return key; }
                set { key = value; }
            }
            public byte Lock_Flag
            {
                get { return lock_flag; }
                set { lock_flag = value; }
            }
        }
        public class x3C
        {
            private byte VALUE = 0;

            public byte Value
            {
                get { return VALUE; }
                set { VALUE = value; }
            }
        }

        //////////////////////////////////////////////////////////////////////////////
        // 0x4_
        //////////////////////////////////////////////////////////////////////////////
        public class x44
        {
            private byte dummy = 0;
            private byte no = 0;
            private string emd = "00";
            private byte ani = 0;
            private byte status = 0;
            private byte floor = 0;
            private string sound = "00";
            private byte tex = 0;
            private byte flag = 0;
            private Int16 x = 0;
            private Int16 z = 0;
            private Int16 y = 0;
            private Int16 r = 0;
            private Int16 motion = 0;
            private Int16 ctr = 0;

            public byte Dummy
            {
                get { return dummy; }
                set { dummy = value; }
            }
            public byte Number
            {
                get { return no; }
                set { no = value; }
            }
            public string EMD_File
            {
                get { return emd; }
                set { emd = value; }
            }
            public byte Animation
            {
                get { return ani; }
                set { ani = value; }
            }
            public byte Status
            {
                get { return status; }
                set { status = value; }
            }
            public byte Floor
            {
                get { return floor; }
                set { floor = value; }
            }
            public string Sound
            {
                get { return sound; }
                set { sound = value; }
            }
            public byte Texture
            {
                get { return tex; }
                set { tex = value; }
            }
            public byte Flag
            {
                get { return flag; }
                set { flag = value; }
            }
            public Int16 X
            {
                get { return x; }
                set { x = value; }
            }
            public Int16 Z
            {
                get { return z; }
                set { z = value; }
            }
            public Int16 Y
            {
                get { return y; }
                set { y = value; }
            }
            public Int16 Rotation
            {
                get { return r; }
                set { r = value; }
            }
            public Int16 Motion
            {
                get { return motion; }
                set { motion = value; }
            }
            public Int16 Control_Flag
            {
                get { return ctr; }
                set { ctr = value; }
            }
        }

        public class x46
        {
            private byte aot = 0;
            private byte id = 0;
            private byte type = 0;
            private Int16 data0 = 0;
            private Int16 data1 = 0;
            private Int16 data2 = 0;

            public byte AOT
            {
                get { return aot; }
                set { aot = value; }
            }
            public byte ID
            {
                get { return id; }
                set { id = value; }
            }
            public byte Type
            {
                get { return type; }
                set { type = value; }
            }
            public Int16 Data0
            {
                get { return data0; }
                set { data0 = value; }
            }
            public Int16 Data1
            {
                get { return data1; }
                set { data1 = value; }
            }
            public Int16 Data2
            {
                get { return data2; }
                set { data2 = value; }
            }
        }
        public class x47
        {
            private byte aot = 0;

            public byte AOT
            {
                get { return aot; }
                set { aot = value; }
            }
        }
        public class x4B
        {
            private byte oldc = 0;
            private byte newc = 0;

            public byte Old { get { return oldc; } set { oldc = value; } }
            public byte New { get { return newc; } set { newc = value; } }
        }
        public class x4E
        {
            private byte aot = 0;
            private byte id = 0;
            private byte type = 0;
            private byte floor = 0;
            private byte super = 0;
            private Int16 x = 0;
            private Int16 y = 0;
            private UInt16 w = 0;
            private UInt16 d = 0;
            private Int16 item = 0;
            private Int16 amount = 0;
            private Int16 flag = 0;
            private byte md1 = 0;
            private byte ani = 0;

            public byte AOT
            {
                get { return aot; }
                set { aot = value; }
            }
            public byte ID
            {
                get { return id; }
                set { id = value; }
            }
            public byte Type
            {
                get { return type; }
                set { type = value; }
            }
            public byte Floor
            {
                get { return floor; }
                set { floor = value; }
            }
            public byte Super
            {
                get { return super; }
                set { super = value; }
            }
            public Int16 X
            {
                get { return x; }
                set { x = value; }
            }
            public Int16 Y
            {
                get { return y; }
                set { y = value; }
            }
            public UInt16 Width
            {
                get { return w; }
                set { w = value; }
            }
            public UInt16 Depth
            {
                get { return d; }
                set { d = value; }
            }
            public Int16 Item_ID
            {
                get { return item; }
                set { item = value; }
            }
            public Int16 Amount
            {
                get { return amount; }
                set { amount = value; }
            }
            public Int16 Flag
            {
                get { return flag; }
                set { flag = value; }
            }
            public byte MD1_ID
            {
                get { return md1; }
                set { md1 = value; }
            }
            public byte Animation
            {
                get { return ani; }
                set { ani = value; }
            }
        }

        //////////////////////////////////////////////////////////////////////////////
        // 0x5_
        //////////////////////////////////////////////////////////////////////////////
        public class x5F
        {
            private byte vol = 0;

            public byte Volume { get { return vol; } set { vol = value; } }
        }
        //////////////////////////////////////////////////////////////////////////////
        // 0x6_
        //////////////////////////////////////////////////////////////////////////////
        public class x65
        {
            private byte eff = 0;

            public byte Effect_ID
            {
                get { return eff; }
                set { eff = value; }
            }
        }
        public class x6F
        {
            private byte fmv = 0;

            public byte FMV_ID
            {
                get { return fmv; }
                set { fmv = value; }
            }
        }

    }


    /// <summary>
    /// re3 sdc parser
    /// </summary>
    class PARSER_SCD3
    {

        

        /// <summary>
        ///  NOP
        /// </summary>
        public class x00
        {

        }


        /// <summary>
        /// exit current function
        /// </summary>
        public class x01
        {


        }


        /// <summary>
        /// Sleep, for 1 game tick
        /// </summary>
        public class x02
        {

        }


        /// <summary>
        /// EVT_EXEC
        /// </summary>
        public class x04
        {
            private byte _event = 0;
            private short _instruction = 0;

            public byte Event { get { return _event; } set { _event = value; } }
            public short instruction { get { return instruction; } set { instruction = value; } }  // most likely a function call 0x19xx)

        }

        /// <summary>
        /// EVT_KILL
        /// </summary>
        public class x05
        {
            private byte _event = 0;

            public byte EVent { get { return _event; } set { _event = value; } }

        }



        /// <summary>
        /// IF
        /// its either IF , END IF, or IF ELSE , there is no if/else/endif sequence
        /// </summary>
        public class x06
        {
            private byte _dummy00 = 0;
            private byte _block_length = 0;
            private byte _dummy01 = 0;

            public byte dummy00
            {
                get { return _dummy00; }
                set { _dummy00 = value; }

            }

            public byte block_length
            {
                get { return _block_length; }
                set { _block_length = value; }
            }


            public byte dummy01
            {
                get { return _dummy01; }
                set { _dummy01 = value; }

            }




        }

        /// <summary>
        /// ELSE
        /// </summary>
        public class x07
        {
            private byte _dummy00 = 0;
            private byte _block_length = 0;
            private byte _dummy01 = 0;

            public byte dummy00
            {
                get { return _dummy00; }
                set { _dummy00 = value; }

            }

            public byte block_length
            {
                get { return _block_length; }
                set { _block_length = value; }
            }


            public byte dummy01
            {
                get { return _dummy01; }
                set { _dummy01 = value; }

            }


        }


        /// <summary>
        ///  END IF 
        /// </summary>
        public class x08
        {
            private byte _dummy = 0;

            public byte dummy
            {
                get { return _dummy; }
                set { _dummy = value; }
            }

        }



        /// <summary>
        /// SLEEP?
        /// </summary>
        public class x09
        {
            private byte _unk;

            private byte unk
            {
                get { return _unk; }
                set { _unk = value; }
            }

        }

        /// <summary>
        /// Sleeping
        /// </summary>
        public class x0A
        {



        }


        /// <summary>
        /// SleepW
        /// </summary>
        public class x0B
        {


        }


        /// <summary>
        /// SleepingW
        /// </summary>
        public class x0C
        {



        }

        /// <summary>
        /// FOR
        /// </summary>
        public class x0D
        {
            private byte _dummy = 0;
            private byte _count = 0;
            private short _length = 0;

            private byte dummy
            {
                get { return _dummy; }
                set { _dummy = value; }

            }


            private short length
            {
                get { return _length; }
                set { _length = value; }
            }

            private byte count
            {
                get { return _count; }
                set { _count = value; }

            }
        }

        public class x0F
        {

        }


        /// <summary>
        /// WHILE
        /// </summary>
        ////WHILE
        public class X10
        {
            private byte _dummy = 0;

            private short _length = 0;

            private byte dummy
            {
                get { return _dummy; }
                set { _dummy = value; }

            }

            private short length
            {
                get { return _length; }
                set { _length = value; }

            }


        }


        /// <summary>
        /// END WHILE
        /// </summary>
        public class x11
        {
            private byte _dummy = 0;

            private byte dummy
            {
                get { return _dummy; }
                set { _dummy = value; }
            }
        }



        /// <summary>
        /// DO
        /// </summary>
        public class x12
        {
            private byte _dummy = 0;

            private short _length = 0;

            private byte dummy
            {
                get { return _dummy; }
                set { _dummy = value; }

            }

            private short length
            {
                get { return _length; }
                set { _length = value; }

            }


        }


        /// <summary>
        /// END DO
        /// </summary>
        public class x13
        {

            private byte _dummy = 0;

            private byte dummy
            {
                get { return _dummy; }
                set { _dummy = value; }
            }


        }


        /// <summary>
        /// SWITCH
        /// </summary>
        public class x14
        {
            private byte _unk00;
            private byte _unk01;
            private byte _dummy;

            private byte unk00
            {
                get { return _unk00; }
                set { _unk00 = value; }
            }

            private byte unk01
            {
                get { return _unk01; }
                set { _unk01 = value; }
            }

            private byte dummy
            {
                get { return _dummy; }
                set { _dummy = value; }
            }

        }


        /// <summary>
        /// CASE (for switch)
        /// </summary>
        public class x15
        {

            private byte _dummy = 0;

            private byte dummy
            {
                get { return _dummy; }
                set { _dummy = value; }
            }

        }



        /// <summary>
        /// default for case..
        /// </summary>
        public class x16
        {

            private byte _dummy = 0;

            private byte dummy
            {
                get { return _dummy; }
                set { _dummy = value; }
            }


        }


        /// <summary>
        /// END SWITCH
        /// </summary>
        public class x17
        {

            private byte _dummy = 0;

            private byte dummy
            {
                get { return _dummy; }
                set { _dummy = value; }
            }
        }



        /// <summary>
        /// GO TO (sub script jump)
        /// </summary>
        public class x18
        {
            private byte[] _unknown;
            private byte _dummy;

            private byte dummy
            {
                get { return _dummy; }
                set { _dummy = value; }
            }

        }



        /// <summary>
        /// CALL
        /// </summary>
        public class x19
        {
            private byte _func_num;

            public byte func_num
            {
                get { return _func_num; }
                set { _func_num = value; }
            }


        }


        /// <summary>
        /// RETURN
        /// </summary>
        public class x1A
        {


        }


        //break
        public class x1B
        {

        }


        /// <summary>
        /// BREAK POINt
        /// </summary>
        public class x1C
        {

        }

        /// <summary>
        ///  SET
        /// </summary>
        public class x1D
        {

        }


        /// <summary>
        /// SET
        /// </summary>
        public class x1F
        {

        }


        /// <summary>
        /// CALCULATE OPERATION
        /// </summary>
        public class x20
        {
            private byte _dummy;
            private byte _operator;
            private byte _accum_id;
            private short _value;

            public byte dummy
            {
                get { return _dummy; }
                set { _dummy = value; }
            }


            public byte op
            {
                get { return _operator; }
                set { _operator = value; }
            }

            public byte accum_id
            {
                get { return _accum_id; }
                set { _accum_id = value; }
            }

            public short value
            {
                get { return _value; }
                set { _value = value; }
            }


        }



        /// <summary>
        /// UNKNOWN FUNCTION
        /// </summary>
        public class x21
        {
            //???   
            // length 4
        }


        /// <summary>
        /// EVT_CUT
        /// </summary>
        public class X22
        {
            // length 4


        }

        /// <summary>
        ///  UNKNOWN FUNCTIOn
        /// </summary>
        public class X23
        {

            /// length 1
        }


        /// <summary>
        /// CHASER_EVT_CLR
        /// </summary>
        public class X24
        {
            // length 2

        }


        /// <summary>
        /// MAP OPEN
        /// </summary>
        public class X25
        {
            // length 4


        }


        // POINT ADD
        /// <summary>
        /// ADD MAP POINT?
        /// </summary>
        public class X26
        {
            // length 6

        }



        /// <summary>
        /// DOOR_CK;
        /// </summary>
        public class x27
        {
            // lenght 1
        }


        /// <summary>
        /// DIE DEMO ON?
        /// </summary>
        public class x28
        {
            // 1
        }

        /// <summary>
        /// DIR_CK
        /// </summary>
        public class X29
        {

            /// length 8?
        }


        /// <summary>
        /// PARTS SET
        /// </summary>
        public class x2A
        {
            // length 6    
        }



        /// <summary>
        /// VLOOP SET
        /// </summary>
        public class x2B
        {
            // length 2
        }


        /// <summary>
        /// OTA_BE_SET
        /// </summary>
        public class x2C
        {
            // length 4
        }



        //LINE BEGIN
        public class x2D
        {

            /// length 4
        }



        /// <summary>
        /// LINE MAIN
        /// </summary>
        public class x2E
        {
            // length 6
        }


        /// <summary>
        /// LINE END
        /// </summary>
        public class x2F
        {
            // length 2

        }



        /// <summary>
        /// LIGHT_POS_SEt
        /// </summary>
        public class x30
        {

            //length 6

        }


        /// <summary>
        /// LIGHT KIDO SET
        /// </summary>
        public class x31
        {

        }


        /// <summary>
        /// LIGHT_COLOR_SET
        /// </summary>
        public class x32
        {
            ///length 6

        }


        /// <summary>
        /// AHEAD_ROOM_SEt
        /// </summary>
        public class x33
        {
            // length 4. no idea what this is
        }


        /// <summary>
        /// ESPR_CTR
        /// </summary>
        public class x34
        {
            // length 10
        }

        //EVAL_BGM_TBL_CK
        public class x35
        {
            // length 6
        }


        /// <summary>
        /// ITEM_GET_CHECK
        /// </summary>
        public class x36
        {
            private byte _ItemID;
            private byte _Quantity;
            
            public byte Item_Id
            {
                get { return _ItemID; }
                set { _ItemID = value; }
                
            }
             

            public byte Quantity
            {
                get { return _Quantity; }
                set { _Quantity = value; }
            }


        }


        /// <summary>
        /// OM_REV
        /// </summary>
        public class x37
        {
            //length 2
        }

        //CHASER_LIFE_INIT (track nemesis HP?
        public class x38
        {
            // length 2
        }

        /// <summary>
        /// PARTS_BOMB
        /// </summary>
        public class x39
        {
            //length 16
        }


        /// <summary>
        /// PARTS DOWN
        /// </summary>
        public class x3A
        {
            //length 16
        }


        /// <summary>
        /// CHASER ITEM_SET, (SET NEMMY DRROP ITEM)
        /// </summary>
        public class x3B
        {
            //length 3, probably has an item ID
        }


        /// <summary>
        /// WEAPON_OLD_CHUG
        /// </summary>
        public class x3C
        {
            //length 1?
        }


        /// <summary>
        /// SEL_EVT_ON
        /// </summary>
        public class x3D
        {


        }

        /// <summary>
        /// ITEM_LOST
        /// </summary>
        public class x3E
        {
            private byte _ItemID;

            public byte ItemID
            {
                get { return _ItemID; }
                set { _ItemID = value; }
            }

        }

        /// <summary>
        /// FLOOR_SET
        /// </summary>
        public class x3F
        {
            private byte _id;
            private byte _value;

            private byte id
            {
                get { return _id; }
                set { _id = value; }
            }

            private byte value
            {
                get { return _value; }
                set { _value = value; }
            }

        }


        /// <summary>
        /// MEMB_SET
        /// </summary>
        public class x40
        {

        }

        /// <summary>
        ///  MEMB_SET2
        /// </summary>
        public class x41
        {

        }


        //MEMB_CPY
        public class x42
        {

        }

        //MEMB CMP
        public class x43
        {

        }


        /// <summary>
        /// MEMB_CALC
        /// </summary>
        public class x44
        {


        }


        /// <summary>
        /// MEMB_CALC2
        /// </summary>
        public class x45
        {


        }

        /// <summary>
        /// FADE_SET
        /// </summary>
        public class x46
        {


        }

        /// <summary>
        /// WORK_SET
        /// </summary>
        public class x47
        {
            private byte _component;
            private byte _optional_index;

            public byte component
            {
                get { return _component; }
                set { _component = value; }
            }

            public byte optional_index
            {
                get { return _optional_index; }
                set { _optional_index = value; }
            }


        }



        /// <summary>
        /// SPD_SET
        /// </summary>
        public class x48
        {

        }


        /// <summary>
        /// ADD_SPD
        /// </summary>
        public class x49
        {


        }

        /// <summary>
        /// ADD_ASPD
        /// </summary>
        public class x4A
        {


        }

        /// <summary>
        /// ADD_VSPD
        /// </summary>
        public class x4B
        {


        }


        /// <summary>
        /// EVAL_CHECK
        /// </summary>
        public class x4C
        {
            private byte _Index; // array index
            private byte _flag; //  bit value?
            private byte _value; // option comparer



            public byte index
            {
                get { return _Index; }
                set { _Index = value; }
            }

            public byte flag
            {
                get { return _flag; }
                set { _flag = value; }               
            }

            public byte value
            {
                get { return _value; }
                set { _value = value; }
            }


            

        }

        /// <summary>
        /// SET
        /// </summary>
        public class x4D
        {

            private byte _Index; // array index
            private byte _flag; //  bit value?
            private byte _value; // option comparer



            public byte index
            {
                get { return _Index; }
                set { _Index = value; }
            }

            public byte flag
            {
                get { return _flag; }
                set { _flag = value; }
            }

            public byte value
            {
                get { return _value; }
                set { _value = value; }
            }



        }

        /// <summary>
        /// EVAL_CMP
        /// </summary>
        public class x4E
        {
            private byte _dummy;
            private byte _var;
            private byte _op;
            private Int16 _value;


            public byte dummy
            {
                get { return _dummy; }
                set { _dummy = value; }
            }

            public byte var
            {
                get { return _var; }
                set { _var = value; }
            }

            public byte op
            {
                get { return _op; }
                set { _op = value; }
            }


            public Int16 Value
            {
                get { return _value; }
                set { _value = value; }
            }


        }


        /// <summary>
        /// RND?
        /// </summary>
        public class x4F
        {


        }


        /// <summary>
        /// CUT_CHG
        /// </summary>
        public class x50
        {
            private byte _CameraID;

            public byte CameraID
            {
               get { return _CameraID; }
               set { _CameraID = value; }
            }


        }


        /// <summary>
        /// CUT_OLD
        /// </summary>
        public class x51
        {


        }


        /// <summary>
        /// CUT_AUTO
        /// </summary>
        public class x52
        {


        }



        /// <summary>
        /// CUT_REPLACE
        /// </summary>
        public class x53
        {

            private byte _fromCam;
            private byte _targetCam;

            public byte FromCam
            {
                get { return _fromCam; }
                set { _fromCam = value; }
            }
            

            public byte TargetCam
            {
                get { return _targetCam; }
                set { _targetCam = value; }
            }


        }


        /// <summary>
        /// CUT_BE_SET
        /// </summary>
        public class x54
        {

        }

        /// <summary>
        /// POS_SET
        /// </summary>
        public class x55
        {

            private byte _dummy;
            private Int16 _posx;
            private Int16 _posy;
            private Int16 _posz;


            public byte dummy
            {
                get { return _dummy; }
                set { _dummy = value; }
            }

            public Int16 posx
            {
                get { return _posx; }
                set { _posx = value; }
            }


            public Int16 posy
            {
                get { return _posy; }
                set { _posy = value; }
            }


            public Int16 posz
            {
                get { return _posz; }
                set { _posz = value; }
            }


            




        }


        /// <summary>
        /// DIR_SET
        /// </summary>
        public class x56
        {
            private byte _dummy;
            private Int16 _posx;
            private Int16 _posy;
            private Int16 _posz;


            public byte dummy
            {
                get { return _dummy; }
                set { _dummy = value; }
            }

            public Int16 posx
            {
                get { return _posx; }
                set { _posx = value; }
            }


            public Int16 posy
            {
                get { return _posy; }
                set { _posy = value; }
            }


            public Int16 posz
            {
                get { return _posz; }
                set { _posz = value; }
            }


        }


        /// <summary>
        /// SET_VIB0
        /// </summary>
        public class x57
        {

        }

        /// <summary>
        /// SET_VIB1
        /// </summary>
        public class x58
        {

        }


        /// <summary>
        /// SET_VIB_FADE
        /// </summary>
        public class x59
        {

        }


        /// <summary>
        /// RBJ_SEt
        /// </summary>
        public class x5A
        {

        }

        /// <summary>
        /// MESSAGE_ON
        /// </summary>
        public class x5B
        {

        }

        /// <summary>
        /// RAIN_SET
        /// </summary>
        public class x5C
        {

        }


        /// <summary>
        /// MESSAGE_OFF
        /// </summary>
        public class x5D
        {

        }

        /// <summary>
        /// SHAKE_ON // EARTH QUAKE EVIL 5?!!
        /// </summary>
        public class x5E
        {

        }


        /// <summary>
        /// WEAPON_CHG (FORCILY CHANGE WEAPON)?
        /// </summary>
        public class x5F
        {


        }


        /// <summary>
        /// ??? UNKNOWN INSTRUCTION
        /// </summary>
        public class x60
        {

            // rip length 22
        }

        /// <summary>
        /// DOOR_SET
        /// </summary>
        public class x61
        {
            private byte _DoorIndex;
            private byte _ubyte00;
            private byte _ubyte01;
            private byte _ubyte02;
            private byte _ubyte03;

            private short _posx;
            private short _posy;
            private short _posz;
            private short _posr;

            private short _nextX;
            private short _nextY;
            private short _nextZ;
            private short _nextR;

            private byte _stage;
            private byte _roomNum;
            private byte _SetCam;
            private byte _ubyte04;
            private byte _doorType;
            private byte _Handle;
            private byte _ubyte05;
            private byte _lockflag;
            private byte _KeyID;


            public byte DoorIndex
            {
                get { return _DoorIndex; }
                set { _DoorIndex = value; }
            }



            public byte ubyte00
            {
                get { return _ubyte00; }
                set { _ubyte00 = value; }
            }



            public byte ubyte01
            {
                get { return _ubyte01; }
                set { _ubyte01 = value; }
            }



            public byte ubyte02
            {
                get { return _ubyte02; }
                set { _ubyte02 = value; }
            }


            public byte ubyte03
            {
                get { return _ubyte03; }
                set { _ubyte03 = value; }
            }


            public short posx
            {
                get { return _posx; }
                set { _posx = value; }
            }

            public short posy
            {
                get { return _posy; }
                set { _posy = value; }
            }

            public short posz
            {
                get { return _posz; }
                set { _posz = value; }
            }

            public short posr
            {
                get { return _posr; }
                set { _posr = value; }
            }


            public short nextx
            {
                get { return _nextX; }
                set { _nextX = value; }
            }


            public short nexty
            {
                get { return _nextY; }
                set { _nextY = value; }
            }

            public short nextz
            {
                get { return _nextZ; }
                set { _nextZ = value; }
            }

            public short nextr
            {
                get { return _nextR; }
                set { _nextR = value; }
            }

            public byte stageID
            {
                get { return _stage; }
                set { _stage = value; }
            }

            public byte roomNum
            {
                get { return _roomNum; }
                set { _roomNum = value; }
            }

            public byte setCam
            {
                get { return _SetCam; }
                set { _SetCam = value; }
            }



            public byte ubyte04
            {
                get { return _ubyte04; }
                set { _ubyte04 = value; }
            }

            public byte DoorType
            {
                get { return _doorType; }
                set { _doorType = value; }
            }


            public byte Handle
            {
                get { return _Handle; }
                set { _Handle = value; }
            }

            public byte ubyte05
            {
                get { return _ubyte05; }
                set { _ubyte05 = value; }
            }


            public byte LockFlag
            {
                get { return _lockflag; }
                set { _lockflag = value; }
            }

            public byte KeyId
            {
                get { return _KeyID; }
                set { _KeyID = value; }
            }



            //length 32
        }


        /// <summary>
        /// DOOR_AOT_SET
        /// </summary>
        public class x62
        {
            // len 40
        }

        /// <summary>
        /// AOT_SET
        /// </summary>
        public class x63
        {

            private byte _evtIdx;
            private byte _eventType;
            private byte _ActivationType;
            private byte _ubyte00;
            private byte _ubyte01;
            private byte _ubyte02;
            private short _posx;
            private short _posy;
            private short _width;
            private short _height;
            private byte _ubyte03;
            private byte _InputItem;


            public byte EvtIdx
            {
                get { return _evtIdx; }
                set { _evtIdx = value; }
            }

            public byte eventType
            {
                get { return _eventType; }
                set { _eventType = value; }
            }

            public byte ActivationType
            {
                get { return _ActivationType; }
                set { _ActivationType = value; }
            }

            public byte ubyte00
            {
                get { return _ubyte00; }
                set { _ubyte00 = value; }
            }


            public byte ubyte01
            {
                get { return _ubyte01; }
                set { _ubyte01 = value; }
            }



            public byte ubyte02
            {
                get { return _ubyte02; }
                set { _ubyte02 = value; }
            }

            public short posx
            {
                get { return _posx; }
                set { _posx = value; }
            }

            public short posy
            {
                get { return _posy; }
                set { _posy = value; }
            }

            public short width
            {
                get { return _width; }
                set { _width = value; }
            }

            public short height
            {
                get { return _height; }
                set { _height = value; }
            }

            public byte ubyte03
            {
                get { return _ubyte03; }
                set { _ubyte03 = value; }
            }

            public byte InputItem
            {
                get { return _InputItem; }
                set { _InputItem = value; }
            }


        }


        /// <summary>
        /// AOT_SET_4p
        /// </summary>
        public class x64
        {
            //len 28, like regular aot_set but 8 longer
        }


        /// <summary>
        /// AOT_RESET
        /// </summary>
        public class x65
        {
            private byte _event_type;
            private byte _event_flag;
            private byte[] _unknown; // 7


            public byte event_type
            {
                get { return _event_type; }
                set { _event_type = value; }
            }

            public byte event_flag
            {
                get { return _event_flag; }
                set { _event_flag = value; }
            }



            //len 10
        }


        /// <summary>
        /// AOT_ON
        /// </summary>
        public class x66
        {
            //len 2
        }

        /// <summary>
        /// ITEM_AOT_SET
        /// </summary>
        public class x67
        {
            // len 22
            private byte _Dummy;
            private byte _Index;
            private byte _flag00;
            private byte _flag01;
            private short _ushort00;
            private short _posx;
            private short _posy;
            private short _posz;
            private short _ushort01;
            private byte _itemID;
            private byte _flag02;
            private byte _flag03;
            private short _ushort02;
            private short _ushort03;
            private byte _ModelPickup;
            

            public byte dummy
            {
                get { return _Dummy; }
                set { _Dummy = value; }
            }

            public byte index
            {
                get { return _Index; }
                set { _Index = value; }
            }

            public byte flag00
            {
                get { return _flag00; }
                set { _flag00 = value; }
            }

            public byte flag01
            {
                get { return _flag01; }
               set { _flag01 = value; }
            }

            public short ushort00 
             {
                 get { return _ushort00; }
                 set { _ushort01 = value; }  
             }

            public short posX
            {
                get { return _posx; }
                set { _posx = value; }
            }


            public short posY
            {
                get { return _posy; }
                set { _posy = value; }
            }



            public short posZ
            {
                get { return _posz; }
                set { _posz = value; }
            }


            public short Ushort01
            {
                get { return _ushort01; }
                set { _ushort01 = value; }

            }

            public byte ItemID
            {
                get { return _itemID; }
                set { _itemID = value; }
            }


            public byte flag02
            {
                get { return _flag02; }
                set { _flag02 = value; }
            }


            public byte flag03
            {
                get { return _flag03; }
                set { _flag03 = value; }
            }


            public short Ushort02
            {
                get { return _ushort02; }
                set { _ushort02 = value; }
            }


            public short Ushort03
            {
                get { return _ushort03; }
                set { _ushort03 = value; }
            }

            public byte ModelPickup
            {
                get { return _ModelPickup; }
                set { _ModelPickup = value; }
            }


        }

        /// <summary>
        /// ITEM_AOT_SET_4P
        /// </summary>
        public class x68
        {
            // len 30 ( 8 larger then regular item_aot_set)

        }

        /// <summary>
        /// KAGE_SET
        /// </summary>
        public class x69
        {

        }


        /// <summary>
        /// SUPER_SEt, length 16
        /// </summary>
        public class x6A
        {
            private byte[] Unknown; // 15

        }




        /// <summary>
        /// KEEP_ITEM_CK
        /// </summary>
        public class x6B
        {

            //len 2
        }



        /// <summary>
        /// KEY_CK
        /// </summary>
        public class x6C
        {// len 4

        }


        /// <summary>
        /// TRG_CK
        /// </summary>
        public class x6D
        {
            // len 4
        }

        /// <summary>
        /// SCA ID_SET
        /// </summary>
        public class x6E
        {
            // len 4

        }


        /// <summary>
        /// OM BOMB (object model?)
        /// </summary>
        public class x6F
        {
            // len 2
        }


        /// <summary>
        /// ESPR_ON length 16
        /// </summary>
        public class x70
        {
            private byte _Type;
            private byte _uByte00;
            private byte _uByte01;
            private byte _uByte02;
            private byte _uByte03;
            private Int16 _Scale;
            private Int16 _posX;
            private Int16 _posY;
            private Int16 _posZ;
            private Int16 _posR;
            


            public byte Type
            {
                get { return _Type; }
                set { _Type = value; }
            }

            public byte Ubyte00
            {
                get { return _uByte00; }
                set { _uByte00 = value; }
            }

            public byte Ubyte01
            {
                get { return _uByte01; }
                set { _uByte01 = value; }
            }

            public byte Ubyte02
            {
                get { return _uByte02; }
                set { _uByte02 = value; }
            }

            public byte Ubyte03
            {
                get { return _uByte03; }
                set { _uByte03 = value; }
            }
            

            public Int16 Scale
            {
                get { return _Scale; }
                set { _Scale = value; }
            }

            public Int16 posX
            {
                get { return _posX; }
                set { _posX = value; }
            }

            public Int16 posy
            {
                get { return _posY; }
                set { _posY = value; }
            }

            public Int16 posZ
            {
                get { return _posZ; }
                set { _posZ = value; }
            }

            public Int16 posR
            {
                get { return _posR; }
                set { _posR = value; }
            }


        }

        /// <summary>
        /// ESPR_ON2
        /// </summary>
        public class x71
        {


        }

        /// <summary>
        /// ESPR3D_ON
        /// Enabling sprite effects..
        /// </summary>
        public class x72
        {
            private byte _ubyte00;
            private byte _ubyte01;
            private byte _EffectColor;
            private byte _ubyte02;
            private byte _ubyte03;
            private byte _ubyte04;
            private Int16 _posX;
            private Int16 _posY;
            private Int16 _posZ;
            private Int16 _posR;


            public byte Ubyte00
            {
                get { return _ubyte00; }
                set { _ubyte00 = value; }
            }

            public byte Ubyte01
            {
                get { return _ubyte01; }
                set { _ubyte01 = value; }
            }
            
            public byte EffectColor
            {
                get { return _EffectColor; }
                set { _EffectColor = value; }
            }

            public byte Ubyte02
            {
                get { return _ubyte02; }
                set { _ubyte02 = value; }
            }


            public byte Ubyte03
            {
                get { return _ubyte03; }
                set { _ubyte03 = value; }
            }

            public byte Ubyte04
            {
                get { return _ubyte04; }
                set { _ubyte04 = value; }
            }

            public Int16 PosX
            {
                get { return _posX; }
                set { _posX = value; }
            }

            public Int16 PosY
            {
                get { return _posY; }
                set { _posY = value; }
            }

            public Int16 PosZ
            {
                get { return _posZ; }
                set { _posZ = value; }
            }

            public Int16 PosR
            {
                get { return _posR; }
                set { _posR = value; }
            }


        }


        /// <summary>
        /// ESPR3D_ON2
        /// </summary>
        public class x73
        {

        }


        /// <summary>
        /// ESPR_KILL
        /// </summary>
        public class x74
        {

            private byte _EffectID;
            private byte _Flag;


            public byte EffectID
            {
                get { return _EffectID; }
                set { _EffectID = value; }
            }

            public byte Flag
            {
                get { return _Flag; }
                set { _Flag = value; }
            }





        }


        /// <summary>
        /// ESPR_KILL2
        /// </summary>
        public class x75
        {



        }


        /// <summary>
        /// ESPR_KILL_ALL
        /// </summary>
        public class x76
        {


        }


        /// <summary>
        /// SE_ON
        /// </summary>
        public class x77
        {

        }


        /// <summary>
        /// BGM_CTL
        /// </summary>
        public class x78
        {
            private byte _BgmID;
            private byte _Action;
            private byte _ubyte00;
            private byte _Vol;
            private byte _Channel;

            public byte BgmID
            {
                get { return _BgmID; }
                set { _BgmID = value; }
            }

            public byte Action
            {
                get { return _Action; }
                set { _Action = value; }
            }


            public byte Ubyte00
            {
                get { return _ubyte00; }
                set { _ubyte00 = value; }
            }

            public byte Vol
            {
                get { return _Vol; }
                set { _Vol = value; }
            }

            public byte Channel
            {
                get { return _Channel; }
                set { _Channel = value; }
            }


        }

        /// <summary>
        /// XA_ON
        /// </summary>
        public class x79
        {


        }


        /// <summary>
        /// MOVIE_ON
        /// </summary>
        public class x7A
        {

        }

        /// <summary>
        /// BGM_TBL_SEt
        /// </summary>
        public class x7B
        {


        }


        /// <summary>
        /// STATUS_ON
        /// </summary>
        public class x7C
        {

        }



        /// <summary>
        /// EM_SET (24 bytes)
        /// </summary>
        public class x7D
        {
            private byte _opdummy;
            private byte _ubyte00;
            private byte _emIndex;
            private byte _emdID;
            private byte _emPose;
            private short _AnimFlag00;
            private short _ushort00;
            private byte _SND;
            private byte _TEX;
            private byte _emFlag;
            private short _posx;
            private short _posy;
            private short _posz;
            private short _posr;
            private short _ushort01;
            private short _ushort02;



            public byte opdummy
            {
                get { return _opdummy; }
                set { _opdummy = value; }
            }

         

            public byte emIndex
            {
                get { return _emIndex; }
                set { _emIndex = value; }
            }

            public byte emdID
            {
                get { return _emdID; }
                set { _emdID = value; }
            }

            public byte emPose
            {
                get { return _emPose; }
                set { _emPose = value; }
            }


            public short AnimFlag00
            {
                get { return _AnimFlag00; }
                set { _AnimFlag00 = value; }

            }

            public short Ushort00
            {
                get { return _ushort00; }
                set { _ushort00 = value; }
            }

            public byte SND
            {
                get { return _SND; }
                set { _SND = value; }
            }

            public byte TEX
            {
                get { return _TEX; }
                set { _TEX = value; }
            }


            public byte emFlag
            {
                get { return _emFlag; }
                set { _emFlag = value; }
            }

            public short PosX
            {
                get { return _posx; }
                set { _posx = value; }
            }

            public short PosY
            {
                get { return _posy; }
                set { _posy = value; }
            }
            public short PosZ
            {
                get { return _posz; }
                set { _posz = value; }
            }


            public short PosR
            {
                get { return _posr; }
                set { _posr = value; }
            }

            public short Ushort01
            {
                get { return _ushort01; }
                set { _ushort01 = value; }
            }


            public short Ushort02
            {
                get { return _ushort02; }
                set { _ushort02 = value; }
            }


        }


        /// <summary>
        /// MIZU_DIV??
        /// </summary>
        public class x7E
        {


        }


        /// <summary>
        /// OM_SET (40 bytes) object model set?
        /// </summary>
        public class x7F
        {

        }


        /// <summary>
        /// PLC_MOTION
        /// </summary>
        public class x80
        {
            private byte _Anim00;
            private byte _Anim01;
            private byte _Speed;


            public byte Anim00
            {
                get { return _Anim00; }
                set { _Anim00 = value; }
            }

            public byte Anim01
            {
                get { return _Anim01; }
                set { _Anim01 = value; }
            }

            public byte Speed
            {
                get { return _Speed; }
                set { _Speed = value; }
            }



        }


        /// <summary>
        /// PLC_DEST
        /// </summary>
        public class x81
        {


        }


        /// <summary>
        /// PLC_NECK
        /// </summary>
        public class x82
        {

        }


        /// <summary>
        /// PLC_RET
        /// </summary>
        public class x83
        {

        }


        /// <summary>
        /// PLC_FLG
        /// </summary>
        public class x84
        {

        }

        /// <summary>
        /// PLC_GUN
        /// </summary>
        public class x85
        {

        }


        /// <summary>
        /// PLC_GUN_EFF
        /// </summary>
        public class x86
        {

        }


        /// <summary>
        /// PLC_STOP
        /// </summary>
        public class x87
        {

        }

        /// <summary>
        /// PLC_ROT
        /// </summary>
        public class x88
        {

        }



        /// <summary>
        /// PLC_CNT
        /// </summary>
        public class x89
        {

        }

        /// <summary>
        /// SPLC_RET
        /// </summary>
        public class x8A
        {

        }


        /// <summary>
        /// SPLC_SCE
        /// </summary>
        public class x8B
        {

        }


        /// <summary>
        /// PLC_SCE
        /// </summary>
        public class x8C
        {

        }


        /// <summary>
        /// SPL_WEAPON_CHG
        /// </summary>
        public class x8D
        {

        }


        //PLC_MOT_NUM
        public class x8E
        {

        }


        /// <summary>
        /// EM_RESET
        /// </summary>
        public class x8F
        {

        }


    }


    /// <summary>
    /// End for?
    /// </summary>
  





}
