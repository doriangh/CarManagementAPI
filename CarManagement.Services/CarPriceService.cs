using System.Collections.Generic;
using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using CarManagement.Core.Responses;

namespace CarManagement.Services
{
    public class CarPriceService : ICarPriceService
    {
        private readonly ICarPriceRepository _carPriceRepository;

        public CarPriceService(ICarPriceRepository carPriceRepository)
        {
            _carPriceRepository = carPriceRepository;
        }

        public CarPriceResponse GetCarPrice(ModelInput input)
        {
            var response = new CarPriceResponse
            {
                Errors = new List<string>(),
                Success = false
            };

            if (input.Make == null || input.Model == null)
            {
                response.Errors.Add("Please insert a car make and/or model!");
                response.Success = false;
                return response;
            }

            response.Price = _carPriceRepository.GetCarPrice(input);
            response.Success = true;
            response.Errors = null;

            return response;
        }
    }
}