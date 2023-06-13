using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Toskin_BG.Models
{
    public class Fate_Points
    {
        public ObjectId Id { get; set; }
        public string Character_Name { get; set; }
        public string Reason { get; set; }
        public string Player_Name { get; set; }
        public DateTime changed { get; set; }
        public int points_changed { get; set; }
    }
}
