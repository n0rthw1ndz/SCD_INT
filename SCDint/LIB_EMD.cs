using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCDint
{
    // A static class with all EMD information, including enemy ID's, poses, and whatever enemy info
    public static class LIB_EMD
    {

        public static Dictionary<byte, string> BIO3_LUT_EMD = new Dictionary<byte, string>
        {
            {0x10, "Male Citizen Zombie"},
            {0x11, "Female Citizen Zombie"},
            {0x14, "Police Zombie" },
            {0x15, "Park Zombies" },
            {0x16, "Generic Zombie_00" },
            {0x17, "Generic Zombie_01" },
            {0x18, "Fat Zombie_00" },
            {0x19, "Fat Zombie_01" },
            {0x1A, "Blonde Male Zombie_00" },
            {0x1B, "Glasses Zombie" },
            {0x1C, "Darios Daughter" },
            {0x1D, "Blonde Male Zombie_02" },
            {0x1E, "Blonde Male Zombie_03" },
            {0x1F, "Blone Male Zombie_04" },
            {0x2C, "UBCS Zombie" },
            {0x2F, "Marvin" },
            

            {0x20, "Cerebus"},
            {0x21, "Crow" },
            {0x22, "Hunter" },
            {0x23, "Drain Demo" },
            {0x24, "Water Hunter" },
            {0x25, "Giant Spider" },
            {0x26, "Baby Spider" },
            {0x27, "Wtf" },
            {0x28, "Drain Demo Alternate"},
            {0x30, "Grave Digger_00"},
            {0x32, "Grave Digger_01"},
            {0x33, "Grave Digger_02"},
            {0x3A, "Nemesis_00"},
            {0x3B, "Nemesis_01"},
            {0x34, "Rocket Nemesis"},
            {0x35, "Rocket Nemesis" },
            {0x36, "Tentacle Nemesis"},
            {0x37, "Tentacle Nemesis"},
            {0x38, "Final Nemesis"},
            {0x50, "Carlos_00" },
            {0x51, "Mikhail" },
            {0x52, "Nicholai" },
            {0x53, "Brad Vickers" },
            {0x54, "Darrio Rosso"},
            {0x55, "Murphy Seeker" },
            {0x56, "Tyrell Patrick" },
            {0x57, "Marvin[DEAD]" },
            {0x58, "Zombie Brad" },
            {0x59, "Darrio [DEAD]" },
            {0x5A, "Phamarcy Girl_00" },
            {0x5B, "Blue Jill" },
            {0x5C, "Carlos_01" },
            {0x5E, "Nicholai" }



        };
        



    }
}
