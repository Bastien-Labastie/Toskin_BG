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
    public class ToskinController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public ToskinController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            MongoClient dbclient = new MongoClient(_configuration.GetConnectionString("Conn_String"));

            var dbList = dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").AsQueryable();

            return new JsonResult(dbList);
        }

        [HttpPost]
        public JsonResult Post(Character charc)
        {
            MongoClient dbclient = new MongoClient(_configuration.GetConnectionString("Conn_String"));

            dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").InsertOne(charc);

            return new JsonResult("Added to the Queue");
        }

        [HttpPut]
        public JsonResult Put(Character charc)
        {
            MongoClient dbclient = new MongoClient(_configuration.GetConnectionString("Conn_String"));

            var filter = Builders<Character>.Filter.Eq("Character_Name", charc.Character_Name);
            var update = Builders<Character>.Update.Set("Character_Name", charc.Character_Name)
                                                   .Set("Character_class", charc.Character_Class)
                                                   .Set("Init_Bonus", charc.Init_Bonus)
                                                   .Set("Fate_Points", charc.Fate_Points)
                                                   .Set("Photo_File_Name", charc.Photo_File_Name);

            dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").UpdateOne(filter, update);

            return new JsonResult("Added Successfully");
        }

        [HttpDelete("{Character_Name}")]
        public JsonResult Delete(string Character_Name)
        {
            MongoClient dbclient = new MongoClient(_configuration.GetConnectionString("Conn_String"));

            var filter = Builders<Character>.Filter.Eq("Character_Name", Character_Name);

            dbclient.GetDatabase("Toskin").GetCollection<Character>("Characters").DeleteOne(filter);

            return new JsonResult("Successfully Deleted");
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }

    }
}
