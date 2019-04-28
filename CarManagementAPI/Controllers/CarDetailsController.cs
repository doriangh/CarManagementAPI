using CarManagement.Core.Interfaces;
using CarManagement.Core.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace CarManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDetailsController : Controller
    {
        private readonly ICarDetailService _carDetailService;

        public CarDetailsController(ICarDetailService carDetailService)
        {
            _carDetailService = carDetailService;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_carDetailService.GetAll());
        }

        [HttpGet("{id}")]
        public JsonResult GetCarDetail([FromRoute] int id)
        {
            return Json(_carDetailService.GetById(id));
        }

        [HttpGet("Car/{id}")]
        public JsonResult GetCarDetailForCar([FromRoute] int id)
        {
            return Json(_carDetailService.GetByCarId(id));
        }

        [HttpPost]
        public JsonResult AddCarDetail([FromBody] AddCarDetailRequest request)
        {
            return Json(_carDetailService.AddCarDetail(request));
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteCarDetail([FromRoute] int id)
        {
            return Json(_carDetailService.Delete(id));
        }
    }
}