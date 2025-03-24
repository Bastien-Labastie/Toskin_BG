using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Toskin_BG.Models;

namespace Toskin_BG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitiativeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public InitiativeController(IConfiguration configuration)
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

        [HttpPut]
        public JsonResult Put(Character charc)
        {
            MongoClient dbclient = new MongoClient(_configuration.GetConnectionString("Conn_String"));

            var dbList = dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").AsQueryable();

            foreach (Character charac in dbList)
            {
                Random RNG = new Random();
                int Init_Roll = RNG.Next(1, 101) + charac.Init_Bonus;

                var filter = Builders<Character>.Filter.Eq("Character_Name", charac.Character_Name);
                var update = Builders<Character>.Update.Set("Initiative", Init_Roll);


                dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").UpdateOne(filter, update);
            }

            return new JsonResult("Initiative Rolled");
        }
    }
}
