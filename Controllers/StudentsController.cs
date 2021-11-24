using FinalProject_CompProg.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalProject_CompProg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {

        private readonly ILogger<StudentsController> _logger;
        private readonly StudentsContext _context;

        public StudentsController(ILogger<StudentsController> logger, StudentsContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
       {
            return Ok(_context.Students.ToList());
       }
    }
}
