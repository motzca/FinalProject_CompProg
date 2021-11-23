//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalProject_CompProg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult<StudentsController> Get()
        {
            return OK();
        }
    }
}
