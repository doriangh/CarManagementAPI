using System.Collections.Generic;
using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using CarManagement.Core.Responses;

namespace CarManagement.Services
{
    public class CarImageService : ICarImageService
    {
        private readonly ICarImageRepository _repository;

        public CarImageService(ICarImageRepository repository)
        {
            _repository = repository;
        }

        public List<CarImages> GetAll()
        {
            return _repository.GetAllCarImages();
        }

        public CarImageResponse AddCarImage(CarImages carImages)
        {
            var response = new CarImageResponse
            {
                Errors = new List<string>()
            };

            _repository.AddCarImage(carImages);

            response.Success = true;
            return response;
        }

        public CarImageResponse DeleteCarImage(int id)
        {
            var response = new CarImageResponse
            {
                Errors = new List<string>()
            };

            _repository.DeleteCarImage(id);

            response.Success = true;
            return response;
        }

        public CarImageResponse UpdateCarImage(CarImages carImages)
        {
            var response = new CarImageResponse
            {
                Errors = new List<string>()
            };

            _repository.UpdateCarImage(carImages);

            response.Success = true;
            return response;
        }

        public CarImages GetById(int id)
        {
            return _repository.GetByIdCarImages(id);
        }

        public List<CarImages> GetAllCarsImages(int carId)
        {
            return _repository.GetByCarId(carId);
        }
    }
}