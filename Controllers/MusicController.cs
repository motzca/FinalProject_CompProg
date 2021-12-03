using FinalProject_CompProg.Data;
using FinalProject_CompProg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalProject_CompProg.Interfaces;

namespace FinalProject_CompProg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicController : ControllerBase
    {

        private readonly ILogger<MusicController> _logger;
        private readonly IMusicContextDAO _context;

        public MusicController(ILogger<MusicController> logger, IMusicContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()  //Returns all of the songs 
       {
            return Ok(_context.GetAllSongs());
       }

        [HttpGet("id")]
        public IActionResult Get(int id) //returns the song based on the input ID
        {
                var student = _context.GetById(id);

                if(student == null)
                {
                    return NotFound();
                }
                return Ok(student);
        }

        [HttpDelete]
        public IActionResult Delete(int id) //Removes the song based on the input ID
        {
            var result = _context.RemoveSongById(id);
            
            if (result == null)
            {
                return NotFound(id);
            }
            if (result == 0)
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Music song) //Modifys a song that matches the input song
        {
            var result = _context.UpdateSong(song);
             if (result == null)
            {
                return NotFound(song);
            }
            if (result == 0)
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
        }


        [HttpPost]
        public IActionResult Post(Music song) //Adds a song
        {
            var result = _context.Add(song);

            if(result == null)
            {
                return StatusCode(500, "Student alreay added");
            }
             if (result == 0)
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
        }
    }
}