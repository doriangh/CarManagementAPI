using System.Collections.Generic;
using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using CarManagement.Core.Responses;

namespace CarManagement.Services
{
    public class CarsSoldService : ICarsSoldService
    {
        private readonly ICarsSoldRepository _repository;

        public CarsSoldService(ICarsSoldRepository repository)
        {
            _repository = repository;
        }

        public List<CarsSold> GetAllCarsSold()
        {
            return _repository.GetAllCarsSold();
        }

        public AddCarsSoldResponse AddCarsSold(CarsSold car)
        {
            var response = new AddCarsSoldResponse
            {
                Errors = new List<string>()
            };

            _repository.AddCarSold(car);

            response.Success = true;
            return response;
        }

        public AddCarsSoldResponse UpdateCarsSold(CarsSold car)
        {
            var response = new AddCarsSoldResponse
            {
                Errors = new List<string>()
            };

            _repository.UpdateCarsSold(car);

            response.Success = true;
            return response;
        }

        public AddCarsSoldResponse RemoveCarsSold(int id)
        {
            var response = new AddCarsSoldResponse
            {
                Errors = new List<string>()
            };

            _repository.DeleteCarsSold(id);

            response.Success = true;
            return response;
        }

        public CarsSold GetById(int id)
        {
            return _repository.GetCarsSoldById(id);
        }

        public List<CarsSold> GetByUserId(int userId)
        {
            return _repository.GetByUserId(userId);
        }
    }
}