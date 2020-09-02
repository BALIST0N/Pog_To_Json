using System;
using System.Collections.Generic;
using System.Text;

namespace Pog_To_Json.Classes
{
    public class MapItem
    {
        public byte[] Name;             //Model name
        public byte[] NULL;             //"NULL"
        public short XOffset;
        public short YOffset;
        public short ZOffset;


        public short ID;
        public short XRotation   ;        // 4096 = 360°
        public short YRotation   ;       // 4096 = 360°
        public short ZRotation  ;         // 4096 = 360°
        public short TypeID     ;         // Model type id (instancing)


        public short BoundingBoxWidth;
        public short BoundingBoxHeight;
        public short BoundingBoxLength;
        
        // BoundingBoxType:
        // - Box = 0
        // - Prism = 1
        public short BoundingBoxType;


        public short Short0;
        public char Byte0;
        
        // PigTeam:
        // - Team01 = 0x01
        // - Team02 = 0x02
        // - Team03 = 0x04
        // - Team04 = 0x08
        // - Team05 = 0x10
        // - Team06 = 0x20
        // - Team07 = 0x40
        // - Team08 = 0x80
        public char Team;
        
        // ScriptType:
        // - DESTROY_ITEM           = 01
        // - DESTROY_PROPOINT       = 02
        // - PROTECT_ITEM           = 03
        // - PROTECT_PROPOINT       = 04
        // - DROPZONE_ITEM          = 07
        // - DROPZONE_PROPOINT      = 08
        // - DESTROY_GROUP_ITEM     = 13
        // - DESTROY_GROUP_PROPOINT = 14
        // - PICKUP_ITEM            = 19
        // - TUTORIAL_DESTROY       = 20
        // - TUTORIAL_END           = 21
        // - TUTORIAL_BLAST         = 22
        // - TUTORIAL_DESTROY_GROUP = 23
        public short ScriptType;
 
        public char ScriptGroup;
        public byte[] ScriptParamters;
        public short ScriptXOffset;
        public short ScriptYOffset;
        public short ScriptZOffset;
 
         // ObjectFlag:
         // - None      = 0
         // - Player    = 1 << 0,
         // - Bit1      = 1 << 1,
         // - Bit2      = 1 << 2,
         // - Bit3      = 1 << 3,
         // - ScriptObj = 1 << 4,
         // - Inside    = 1 << 5
         // - Delayed   = 1 << 6
         // - Bit7      = 1 << 7
        public short Flag;

        public short Short1;
        public short Short2;

        public MapItem(byte[] hexblock)
        {
            this.Name = hexblock[0..15];
            this.NULL = hexblock[16..32];

            this.XOffset = Convert.ToInt16( hexblock[33] + hexblock[34] );
            this.YOffset = Convert.ToInt16( hexblock[35] + hexblock[36] );
            this.ZOffset = Convert.ToInt16( hexblock[37] + hexblock[38] );

            this.ID = Convert.ToInt16(hexblock[39] + hexblock[40]);
            this.XRotation = Convert.ToInt16( hexblock[41] + hexblock[42] );
            this.YRotation = Convert.ToInt16( hexblock[43] + hexblock[44] );
            this.ZRotation = Convert.ToInt16(hexblock[45] + hexblock[46]);
            this.TypeID = Convert.ToInt16(hexblock[47] + hexblock[48]);

            this.BoundingBoxWidth  = Convert.ToInt16( hexblock[49] + hexblock[50] );
            this.BoundingBoxHeight = Convert.ToInt16( hexblock[51] + hexblock[52] );
            this.BoundingBoxLength = Convert.ToInt16(hexblock[53] + hexblock[54]);
            
            this.BoundingBoxType = Convert.ToInt16(hexblock[55] + hexblock[56]);

            this.Short0 = Convert.ToInt16( hexblock[57] );
            this.Byte0 = Convert.ToChar( hexblock[58] );

            this.Team = Convert.ToChar(hexblock[59]);

            this.ScriptType = Convert.ToInt16(hexblock[60] + hexblock[61]);
            this.ScriptGroup = Convert.ToChar(hexblock[62]);
            this.ScriptParamters = hexblock[63..81];
            this.ScriptXOffset   = Convert.ToInt16(hexblock[82] + hexblock[83]);
            this.ScriptYOffset   = Convert.ToInt16(hexblock[84] + hexblock[85]);
            this.ScriptZOffset   = Convert.ToInt16(hexblock[86] + hexblock[87]);

            this.Flag = Convert.ToInt16(hexblock[88] + hexblock[89]);
            this.Short1 = Convert.ToInt16(hexblock[90] + hexblock[91]);
            this.Short2 = Convert.ToInt16(hexblock[92] + hexblock[93]);

        }
    }
}
