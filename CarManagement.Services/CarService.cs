using CarManagement.Core.Interfaces;
using CarManagement.Core.Requests;
using CarManagement.Core.Responses;
using System.Collections.Generic;
using CarManagement.Core.Entities;

namespace CarManagement.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public AddCarResponse AddCar(AddCarRequest request)
        {
            var response = new AddCarResponse
            {
                Errors = new List<string>()
            };

            //TODO: validari


            _carRepository.Add(new Car()
            {
                UserId = request.UserId,
                Make = request.Make,
                Manufacturer = request.Manufacturer,
                Plant = request.Plant,
                ModelYear = request.ModelYear,
                Model = request.Model,
                Body = request.Body,
                Drive = request.Drive,
                NumberofSeats = request.NumberofSeats,
                NumberofDoors = request.NumberofDoors,
                Steering = request.Steering,
                EngineDisplacement = request.EngineDisplacement,
                EngineCylinders = request.EngineCylinders,
                NumberofGears = request.NumberofGears,
                Engine = request.Engine,
                Made = request.Made,
                Color = request.Color,
                Fuel = request.Fuel,
                Cc = request.Cc,
                Power = request.Power,
                Emissions = request.Emissions,
                Odometer = request.Odometer,
                Vin = request.Vin,
                License = request.License
            });

            response.Success = true;
            return response;
        }

        public AddCarResponse Delete(int id)
        {
            var response = new AddCarResponse
            {
                Errors = new List<string>()
            };

            _carRepository.Delete(id);

            response.Success = true;
            return response;
        }

        public List<Car> GetAll()
        {
            return _carRepository.GetAll();
        }

        public Car GetById(int id)
        {
            return _carRepository.GetById(id);
        }

        public List<Car> GetByUserId(int id)
        {
            return _carRepository.GetByUserId(id);
        }
    }
}
