﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuleBasedSystem.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RuleBasedSystem.Controllers
{
    [Route("api/[controller]")]
    public class VerdiepingenController : Controller
    {
        Processor processor = new Processor();

       // GET api/verdiepingen/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            List<Room> rooms = processor.getRoomsOfLevel(id);
            return Json(rooms);

        }
    }
}
