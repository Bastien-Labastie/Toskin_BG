using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Toskin_BG.Models
{
    public class Character
    {
        public ObjectId Id { get; set; }
        public string Character_Name { get; set; }
        public string Character_Class { get; set; }
        public int Fate_Points { get; set; }
        public int Init_Bonus { get; set; }
        public string Photo_File_Name { get; set; }
    }
}
