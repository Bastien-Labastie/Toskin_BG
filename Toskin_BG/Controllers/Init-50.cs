using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toskin_BG.Models;

namespace Toskin_BG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Init_50 : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public Init_50(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            MongoClient dbclient = new MongoClient(_configuration.GetConnectionString("Conn_String"));

            var dbList = dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").AsQueryable();

            return new JsonResult(dbList);
        }

        [Route("Sub50")]
        [HttpPut]
        public JsonResult Put_50(Character charc)
        {
            MongoClient dbclient = new MongoClient(_configuration.GetConnectionString("Conn_String"));

            var dbList = dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").AsQueryable();

            int high = 0;
            var top_char = charc;
            
                foreach (Character charac in dbList)
                {
                    if (charac.Group == 1)
                    {
                        if (charac.Initiative > high)
                        {
                            high = charac.Initiative;
                            top_char = charac;

                        }
                    }
                }
            

            var filter = Builders<Character>.Filter.Eq("Character_Name", top_char.Character_Name);
            var update = Builders<Character>.Update.Set("Initiative", (high - 50));

            dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").UpdateOne(filter, update);

            return new JsonResult("50 initiative subtracted from " + top_char.Character_Name);
        }

        [Route("Sub65")]
        [HttpPut]
        public JsonResult Put_65(Character charc)
        {
            MongoClient dbclient = new MongoClient(_configuration.GetConnectionString("Conn_String"));

            var dbList = dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").AsQueryable();

            int high = 0;
            var top_char = charc;

            foreach (Character charac in dbList)
            {
                if (charac.Group == 1)
                {
                    if (charac.Initiative > high)
                    {
                        high = charac.Initiative;
                        top_char = charac;

                    }
                }
            }


            var filter = Builders<Character>.Filter.Eq("Character_Name", top_char.Character_Name);
            var update = Builders<Character>.Update.Set("Initiative", (high - 65));

            dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").UpdateOne(filter, update);

            return new JsonResult("65 initiative subtracted from " + top_char.Character_Name);
        }

        [Route("Sub25")]
        [HttpPut]
        public JsonResult Put_25(Character charc)
        {
            MongoClient dbclient = new MongoClient(_configuration.GetConnectionString("Conn_String"));

            var dbList = dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").AsQueryable();

            int high = 0;
            var top_char = charc;

            foreach (Character charac in dbList)
            {
                if (charac.Group == 1)
                {
                    if (charac.Initiative > high)
                    {
                        high = charac.Initiative;
                        top_char = charac;

                    }
                }
            }


            var filter = Builders<Character>.Filter.Eq("Character_Name", top_char.Character_Name);
            var update = Builders<Character>.Update.Set("Initiative", (high - 25));

            dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").UpdateOne(filter, update);

            return new JsonResult("25 initiative subtracted from " + top_char.Character_Name);
        }

        [Route("Sub100")]
        [HttpPut]
        public JsonResult Put_100(Character charc)
        {
            MongoClient dbclient = new MongoClient(_configuration.GetConnectionString("Conn_String"));

            var dbList = dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").AsQueryable();

            int high = 0;
            var top_char = charc;

            foreach (Character charac in dbList)
            {
                if (charac.Group == 1)
                {
                    if (charac.Initiative > high)
                    {
                        high = charac.Initiative;
                        top_char = charac;

                    }
                }
            }


            var filter = Builders<Character>.Filter.Eq("Character_Name", top_char.Character_Name);
            var update = Builders<Character>.Update.Set("Initiative", (high - 100));

            dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").UpdateOne(filter, update);

            return new JsonResult("100 initiative subtracted from " + top_char.Character_Name);
        }

        [Route("Next")]
        [HttpPut]
        public JsonResult Next(Character charc)
        {
            MongoClient dbclient = new MongoClient(_configuration.GetConnectionString("Conn_String"));

            var dbList = dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").AsQueryable();

            int high = 0;
            var top_char = charc;

            foreach (Character charac in dbList)
            {
                if (charac.Group == 1)
                {
                    if (charac.Initiative > high)
                    {
                        high = charac.Initiative;
                        top_char = charac;

                    }
                }
            }


            var filter = Builders<Character>.Filter.Eq("Character_Name", top_char.Character_Name);
            var update = Builders<Character>.Update.Set("Initiative", (high - high));

            dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").UpdateOne(filter, update);

            return new JsonResult(top_char.Character_Name + " has been set to 0 Initative");
        }
    }
}
