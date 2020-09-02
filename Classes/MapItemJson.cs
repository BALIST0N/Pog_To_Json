using System;
using System.Collections.Generic;
using System.Text;


namespace Pog_To_Json.Classes
{
    class MapItemJson
    {
        public string Name { get; set; }
        public string NULL { get; set; }

        public int[] Position { get; set; }
        public int ID { get; set; }
        public int TypeID { get; set; }

        public int[] Rotation { get; set; }
        public int[] BoundingBox { get; set; }

        public enum boudingBoxType {Box = 0 ,Prism = 1}

        public ushort Team { get; set; }
        public enum ScriptTypeEnum
        {   DESTROY_ITEM           = 01,
            DESTROY_PROPOINT       = 02,
            PROTECT_ITEM           = 03,
            PROTECT_PROPOINT       = 04,
            DROPZONE_ITEM          = 07,
            DROPZONE_PROPOINT      = 08,
            DESTROY_GROUP_ITEM     = 13,
            DESTROY_GROUP_PROPOINT = 14,
            PICKUP_ITEM            = 19,
            TUTORIAL_DESTROY       = 20,
            TUTORIAL_END           = 21,
            TUTORIAL_BLAST         = 22,
            TUTORIAL_DESTROY_GROUP = 23
        }
        public string ScriptType { get; set; }
        public int ScriptGroup { get; set; }
        public string ScriptParameters { get; set; }
        public int[] ScriptOffest { get; set; }

        public enum Flag
        {
            None      = 0,
            Player    = 1 << 0,
            Bit1      = 1 << 1,
            Bit2      = 1 << 2,
            Bit3      = 1 << 3,
            ScriptObj = 1 << 4,
            Inside    = 1 << 5,
            Delayed   = 1 << 6,
            Bit7      = 1 << 7
        }
        public int flag { get; set; }
        public int Byte0 { get; set; }
        public int[] Shorts { get; set; }

        public MapItemJson(MapItem mapitem)
        {
            this.Name = Encoding.Default.GetString( mapitem.Name );
            this.NULL = Encoding.Default.GetString( mapitem.NULL );

            this.Position = new int[] { mapitem.XOffset, mapitem.YOffset, mapitem.ZOffset };

            this.ID = mapitem.ID;
            this.TypeID = mapitem.TypeID;

            this.Rotation = new int[] { mapitem.XRotation, mapitem.YRotation, mapitem.ZRotation };
            this.BoundingBox = new int[] { mapitem.BoundingBoxWidth, mapitem.BoundingBoxHeight, mapitem.BoundingBoxLength, mapitem.BoundingBoxType };

            this.Team = mapitem.Team;

            this.ScriptType = Enum.GetName(typeof(ScriptTypeEnum),mapitem.ScriptType) ;
            this.ScriptGroup = mapitem.ScriptGroup;
            this.ScriptParameters = BitConverter.ToString( mapitem.ScriptParamters ) ;
            this.ScriptOffest = new int[] { mapitem.ScriptXOffset, mapitem.ScriptYOffset, mapitem.ScriptZOffset };

            this.flag = mapitem.Flag;
            this.Byte0 = mapitem.Byte0;
            this.Shorts = new int[] {mapitem.Short0,mapitem.Short1,mapitem.Short2};


        }
    }








}
