using System;
using System.Collections.Generic;
using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using CarManagement.Core.Requests;
using CarManagement.Core.Responses;

namespace CarManagement.Services
{
    public class CarDetailService : ICarDetailService
    {
        private readonly ICarPriceRepository _carPriceRepository;
        private readonly ICarRepository _carRepository;
        private readonly ICarDetailRepository _repository;

        public CarDetailService(ICarDetailRepository repository, ICarRepository carRepository,
            ICarPriceRepository carPriceRepository)
        {
            _repository = repository;
            _carRepository = carRepository;
            _carPriceRepository = carPriceRepository;
        }

        public AddCarDetailResponse AddCarDetail(AddCarDetailRequest request)
        {
            var response = new AddCarDetailResponse
            {
                Errors = new List<string>()
            };

            var car = _carRepository.GetById(request.CarId);

            if (car == null)
            {
                response.Errors.Add("Car does not exist");
                response.Success = false;
                return response;
            }

            if (Convert.ToDateTime(request.Itp) > DateTime.Today &&
                Convert.ToDateTime(request.RoadTax) > DateTime.Today)
            {
                response.Errors.Add("Dates invalid");
                response.Success = false;
                return response;
            }

            _repository.Add(new CarDetail
            {
                CarId = request.CarId,
                InsuranceValue = request.InsuranceValue,
                Itp = request.Itp,
                OilChange = request.OilChange,
                RoadTax = request.RoadTax,
                RoadTaxValue = request.RoadTaxValue,
                TaxValue = request.TaxValue,
                WinterTires = request.WinterTires,
                Price = Convert.ToInt32(_carPriceRepository.GetCarPrice(new ModelInput
                {
                    Make = car.Make,
                    Model = car.Model,
                    Cc = float.Parse(car.Cc),
                    Fuel = car.Fuel,
                    Odometer = float.Parse(car.Odometer),
                    Power = float.Parse(car.Power),
                    Year = float.Parse(car.ModelYear)
                }))
            });

            response.Success = true;
            return response;
        }

        public UpdateCarDetailResponse UpdateCarDetail(int id, UpdateCarDetailRequest request)
        {
            var response = new UpdateCarDetailResponse
            {
                Errors = new List<string>()
            };

            _repository.Update(id, new CarDetail
            {
                InsuranceValue = request.InsuranceValue,
                Itp = request.Itp,
                OilChange = request.OilChange,
                RoadTax = request.RoadTax,
                RoadTaxValue = request.RoadTaxValue,
                TaxValue = request.TaxValue,
                WinterTires = request.WinterTires
            });

            response.Success = true;
            return response;
        }

        public List<CarDetail> GetAll()
        {
            return _repository.GetAll();
        }

        public CarDetail GetById(int id)
        {
            return _repository.GetById(id);
        }

        public AddCarDetailResponse Delete(int id)
        {
            var response = new AddCarDetailResponse
            {
                Errors = new List<string>()
            };

            _repository.Delete(id);

            response.Success = true;
            return response;
        }

        public List<CarDetail> GetByCarId(int id)
        {
            return _repository.GetByCarId(id);
        }
    }
}