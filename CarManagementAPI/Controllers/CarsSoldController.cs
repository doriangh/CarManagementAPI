using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class CarsSoldController : Controller
    {
        private readonly ICarsSoldService _carsSoldService;

        public CarsSoldController(ICarsSoldService carsSoldService)
        {
            _carsSoldService = carsSoldService;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_carsSoldService.GetAllCarsSold());
        }

        [HttpGet("{id}")]
        public JsonResult GetCarSold([FromRoute] int id)
        {
            return Json(_carsSoldService.GetById(id));
        }

        [HttpPut]
        public JsonResult UpdateCarSold([FromBody] CarsSold request)
        {
            return Json(_carsSoldService.UpdateCarsSold(request));
        }

        [HttpGet("User/{id}")]
        public JsonResult GetCarsSoldByUser([FromRoute] int id)
        {
            return Json(_carsSoldService.GetByUserId(id));
        }

        [HttpPost]
        public JsonResult AddCarSold([FromBody] CarsSold request)
        {
            return Json(_carsSoldService.AddCarsSold(request));
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteCarSold([FromRoute] int car)
        {
            return Json(_carsSoldService.RemoveCarsSold(car));
        }
    }
}