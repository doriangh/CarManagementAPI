using CarManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;

namespace CarManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPriceController : Controller
    {
        private readonly PredictionEnginePool<ModelInput, ModelOutput> _predictionEnginePool;

        public CarPriceController(PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        [HttpPost]
        public ActionResult<float> Post([FromBody] ModelInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _predictionEnginePool.Predict(input);

            return Ok(result.Score);
        }
    }
}