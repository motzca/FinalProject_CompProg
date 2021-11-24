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
        public IActionResult Get()
       {
            return Ok(_context.GetAllStudents());
       }
    }
}
