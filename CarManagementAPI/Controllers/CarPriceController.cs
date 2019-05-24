using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using CarManagement.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CarManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPriceController : Controller
    {
        private ICarPriceService _service;

        public CarPriceController(ICarPriceService service)
        {
            _service = service;
        }

        [HttpPost]
        public JsonResult GetAll([FromBody] GetCarPriceRequest car)
        {
            return Json(_service.GetPrice(car));
        }

    }
}