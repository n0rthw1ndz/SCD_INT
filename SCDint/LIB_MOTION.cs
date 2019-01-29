using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCDint
{
    public static class LIB_MOTION
    {
        public static Dictionary<byte, string> LUT_WORK_SET_COMPONENTS = new Dictionary<byte, string>()
        {
            {00, "Player"},
            {01, "Player"},
            {03, "Enemy"},
            {04, "Room Entitity"}
        };

    }
}
