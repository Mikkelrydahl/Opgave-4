using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Obligatorisk_Opgave_4.Manager;

namespace Obligatorisk_Opgave_4.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]

    public class CarsController : Controller
    {

        private CarManager _manager = new CarManager();

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]

        public ActionResult<IEnumerable<Car>> Get([FromQuery] string modelFilter, [FromQuery] int? priceFilter,
            [FromQuery] string licenseplateFilter)
        {
            IEnumerable<Car> car = _manager.GetAll(modelFilter, priceFilter, licenseplateFilter);

            if (car.Count() <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(car);
            }

        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Car car = _manager.GetById(id);
            if (car == null) return NotFound("Not Found, id: " + id);
            return Ok(car);
        }

        [HttpPost]
        public Car Post([FromBody] Car newCar)
        {
            return _manager.AddCars(newCar);
        }

        [HttpDelete("{id}")]
        public Car Delete(int id)
        {
            Car car = _manager.GetById(id);
            return _manager.Delete(id);
        }


    }
    

}
