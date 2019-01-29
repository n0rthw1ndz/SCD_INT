using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace SCDint
{
    /// <summary>
    /// A class to return General AOT Info, Door Aot, Effects, whatever else i feel fits here under "General"
    /// </summary>
    public static class LIB_AOT_GEN
    {
        public static Dictionary<int, string> LUT_AOT_TYPES = new Dictionary<int, string>()
        {
            {0x04, "MESSAGE"},
            {0x05, "EVENT?"},
            {0x06, "EVENT?" },
            {0x08, "TYPE WRITER" },
            {0x09, "ITEMBOX"},
            {0x0C, "DAMAGE"},
            {0x0E, "HERB PLANTER" }

        };

        public static Dictionary<int, string> LUT_AOT_ACTIVATION = new Dictionary<int, string>()
        {
            {0x21, "Item Input"},
            {0x31, "Action"},
            {0x41, "Collision"}
            
        };

        public static Dictionary<int, string> LUT_EFF_COLOR = new Dictionary<int, string>()
        {
            {0x00, "Red" },
            {0x01, "Blue" },
            {0x02, "Green" },
            {0x03, "Yellow" },
            // no more
        };

        public static Dictionary<byte, string> LUT_EVAL_CMP_OP = new Dictionary<byte, string>()
        {
            {0x00, "==" },
            {0x02, ">=" },
            {0x05, "!=" },

        };




    }
}
