using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPriceController : Controller
    {
        //private readonly PredictionEnginePool<ModelInput, ModelOutput> _predictionEnginePool;

        /*public CarPriceController(PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }*/

        private readonly ICarPriceService _carPriceService;

        public CarPriceController(ICarPriceService carPriceService)
        {
            _carPriceService = carPriceService;
        }

        [HttpPost]
        public JsonResult Post([FromBody] ModelInput input)
        {
            return Json(_carPriceService.GetCarPrice(input));


            /*if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _predictionEnginePool.Predict(input);

            return Ok(result.Score);*/
        }
    }
}