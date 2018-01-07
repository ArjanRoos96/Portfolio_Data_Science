using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuleBasedSystem.Models;

namespace RuleBasedSystem.Controllers
{
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        Processor processor = new Processor();

        // POST api/rooms
        [HttpGet]
        public JsonResult Get()
        {
            return Json(processor.getAllRooms());
        }

        //GET api/rooms/5 -- Get sensors of this room
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(processor.getSensorsByRoom(id));
        }
    }
}
