using CARAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CarController :ControllerBase
    {
        public static Car obj = new Car();
        [HttpGet]
        [Route("CarDetails")]
        public ActionResult<List<Car>> getAllCars()
        {
            return obj.GetCars().ToList();
        }
        [HttpGet]
        [Route("getcar")]
        public ActionResult<Car> getCarById(int id)
        {
            obj = (from i in obj.GetCars()
                   where i.CarNumber == id
                   select i).FirstOrDefault();
            if (obj == null)
                return NotFound();
            else
                return obj;
        }
        [HttpGet]
        [Route("getcarbybrand")]
        public ActionResult<List<Car>> getCarsByBrand(string brandname)
        {
            var result = (from i in obj.GetCars()
                          where i.Brand == brandname
                          select i).ToList();
            return result;
        }
        [HttpPost]
        [Route ("AddCar")]
        public ActionResult AddNewCar(Car c)
        {
            obj.AddCar(c);
            return Ok();
        }
        [HttpDelete]
        [Route("RemoveCar")]
        
        public ActionResult DeleteCar(int id)
        {
            obj.Deletecar(id);
            return Ok();
        }
        
    }

}