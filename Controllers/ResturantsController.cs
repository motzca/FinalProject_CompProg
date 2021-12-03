using FinalProject_CompProg.Data;
using FinalProject_CompProg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalProject_CompProg.Interfaces;

namespace FinalProject_CompProg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly ILogger<RestaurantsController> _logger;
        private readonly IRestaurantsContextDAO _context;


        public RestaurantsController(ILogger<RestaurantsController> logger, IRestaurantsContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()  //returns all of the restaurants
        {
            return Ok(_context.GetAllRestaurants());    
        }

        [HttpGet("id")]
        public IActionResult Get(int id) //Returns the given restaurant based on the input ID
        {
                Restaurant restaurant = _context.GetById(id);

                if(restaurant == null)
                {
                    return NotFound();
                }
                return Ok(restaurant);
        }

        [HttpDelete]
        public IActionResult Delete(int id) //removes the given restaurant based on the input ID
        {
            var result = _context.RemoveRestaurantById(id);
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
        public IActionResult Put(Restaurant restaurant) //Modifys the restaurant that matches the ID of the one provided
        {
            var result = _context.UpdateRestaurant(restaurant);
            if(result == null)
            {
                return NotFound(restaurant.id);
            }
            if(result == 0)
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Restaurant restaurant) //Adds the restaurant provided
        {
            var result = _context.Add(restaurant);
            if(result == null)
            {
                return StatusCode(500, "Restaurant with same ID already exists");
            }
            if (result == 0)
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
        }
    }
}
