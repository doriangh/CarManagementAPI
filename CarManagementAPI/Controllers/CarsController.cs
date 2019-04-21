using CarManagement.Core.Interfaces;
using CarManagement.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CarManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        public JsonResult AddCar([FromBody] AddCarRequest request)
        {
            return Json(_carService.AddCar(request));
        }
        [Route("All")]
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_carService.GetAll());
        }

        [HttpGet("{id}")]
        public JsonResult GetCar([FromRoute] int id)
        {
            return Json(_carService.GetById(id));
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteCar([FromRoute]int id)
        {
            return Json(_carService.Delete(id));
        }

        [HttpGet]
        public JsonResult GetUserCars([FromQuery] int id)
        {
            return Json(_carService.GetByUserId(id));
        }
    }
}