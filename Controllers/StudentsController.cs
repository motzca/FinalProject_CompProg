using FinalProject_CompProg.Data;
using FinalProject_CompProg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalProject_CompProg.Interfaces;

namespace FinalProject_CompProg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {

        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentsContextDAO _context;

        public StudentsController(ILogger<StudentsController> logger, IStudentsContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() //Returns all of the students
       {
            return Ok(_context.GetAllStudents());
       }

        [HttpGet("id")]
        public IActionResult Get(int id) //Returns the given student based on the input ID
        {
                var student = _context.GetById(id);

                if(student == null)
                {
                    return NotFound();
                }
                return Ok(student);
        }

        [HttpDelete]
        public IActionResult Delete(int id) //Removes the student that has the same ID as the input ID 
        {
            var result = _context.RemoveStudentById(id);
            
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
        public IActionResult Put(Student student) //Updates the student that matches the input student
        {
            var result = _context.UpdateStudent(student);
             if (result == null)
            {
                return NotFound(student);
            }
            if (result == 0)
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
        }


        [HttpPost]
        public IActionResult Post(Student student) //Adds a student
        {
            var result = _context.Add(student);

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
