using FinalProject_CompProg.Data;
using FinalProject_CompProg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalProject_CompProg.Interfaces;

namespace FinalProject_CompProg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HobbiesController : ControllerBase
    {
        private readonly ILogger<HobbiesController> _logger;
        private readonly IHobbiesContextDAO _context;


        public HobbiesController(ILogger<HobbiesController> logger, IHobbiesContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllHobbies());    
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveHobbiesById(id);
            if(result == null)
            {
                return NotFound(id);
            }
            if(result == 0)
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Hobbies hobbies)
        {
            var result = _context.UpdateHobbies(hobbies);
            if(result == null)
            {
                return NotFound(hobbies.id);
            }
            if(result == 0)
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Hobbies hobbies)
        {
            var result = _context.Add(hobbies);
            if(result == null)
            {
                return StatusCode(500, "Hobbies with same ID already exists");
            }
            if (result == 0)
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
        }








    }
}
