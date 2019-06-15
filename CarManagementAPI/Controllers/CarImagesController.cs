using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class CarImagesController : Controller
    {
        private readonly ICarImageService _service;

        public CarImagesController(ICarImageService service)
        {
            _service = service;
        }

        [Route("All")]
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_service.GetAll());
        }

        [HttpGet("{id}")]
        public JsonResult GetCarImages([FromRoute] int id)
        {
            return Json(_service.GetById(id));
        }

        [HttpGet]
        public JsonResult GetCarsImages([FromQuery] int carId)
        {
            return Json(_service.GetAllCarsImages(carId));
        }

        [HttpPut]
        public JsonResult UpdateCarImages([FromBody] CarImages request)
        {
            return Json(_service.UpdateCarImage(request));
        }

        [HttpPost]
        public JsonResult AddCarImages([FromBody] CarImages request)
        {
            return Json(_service.AddCarImage(request));
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteCarImages([FromRoute] int id)
        {
            return Json(_service.DeleteCarImage(id));
        }
    }
}