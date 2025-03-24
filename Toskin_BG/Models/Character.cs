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
        public int Fate_Points { get; set; }
        public int Init_Bonus { get; set; }
        public string Photo_File_Name { get; set; }
        public int Initiative { get; set; }
        public int AT { get; set; }
        public int Bleeding { get; set; }
        public string DB { get; set; }
        public int Level { get; set; }
        public int Base_HP { get; set; }
        public int Current_HP { get; set; }
        public int Current_SP { get; set; }
        public int Max_SP { get; set; }
        public int Group { get; set; }
    }
}
