using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using Microsoft.Extensions.ML;

namespace CarManagement.Infrastructure.Repositories
{
    public class CarPriceRepository : ICarPriceRepository
    {
        private readonly PredictionEnginePool<ModelInput, ModelOutput> _predictionEnginePool;

        public CarPriceRepository(PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        public float GetCarPrice(ModelInput input)
        {
            var result = _predictionEnginePool.Predict(input);

            return result.Score;
        }
    }
}