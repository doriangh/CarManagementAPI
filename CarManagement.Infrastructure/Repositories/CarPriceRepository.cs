using System;
using System.Collections.Generic;
using CarManagement.Core.Interfaces;
using CarManagement.Core.Requests;
using CarManagement.Core.Responses;
using CarManagement.Infrastructure.Data;
using CarManagementAPIML.Model.DataModels;
using Microsoft.ML;

namespace CarManagement.Infrastructure.Repositories
{
    public class CarPriceRepository : ICarPriceRepository
    {
        public GetCarPriceResponse GetPrice(GetCarPriceRequest car)
        {
            var response = new GetCarPriceResponse
            {
                Errors = new List<string>()
            };

            var mlContext = new MLContext();

            var mlModel = mlContext.Model.Load("../CarManagementAPIML.Model/MLModel.zip", out var modelInputSchema);

            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            var input = new ModelInput
            {
                Cc = car.Cc,
                Make = car.Make,
                Model = car.Model,
                Odometer = car.Odometer,
                Year = car.Year
            };

            var result = predEngine.Predict(input);

            response.Price = Convert.ToInt32(result.Score);
            response.Success = true;

            return response;
        }
    }
}