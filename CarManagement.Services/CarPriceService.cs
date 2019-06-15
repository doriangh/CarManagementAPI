using System;
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

            if (input.Odometer > 900000 || input.Odometer < 0)
            {
                response.Errors.Add("Please enter a real odometer value");
                response.Success = false;
                return response;
            }

            if (input.Year > DateTime.Today.Year || input.Year < 1962)
            {
                response.Errors.Add("Please enter a correct year value");
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