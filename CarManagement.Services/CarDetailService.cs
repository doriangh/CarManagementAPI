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
        private readonly ICarDetailRepository _repository;
        private readonly ICarRepository _carRepository;

        public CarDetailService(ICarDetailRepository repository, ICarRepository carRepository)
        {
            _repository = repository;
            _carRepository = carRepository;
        }

        public AddCarDetailResponse AddCarDetail(AddCarDetailRequest request)
        {
            var response = new AddCarDetailResponse()
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

            if (Convert.ToDateTime(request.ITP) < DateTime.Today && Convert.ToDateTime(request.RoadTax) < DateTime.Today && Convert.ToDateTime(request.OilChange) < DateTime.Today)
            {
                response.Errors.Add("Dates invalid");
                response.Success = false;
                return response;
            }
            
            _repository.Add(new CarDetail()
            {
                CarId = request.CarId,
                InsuranceValue = request.InsuranceValue,
                Itp = request.ITP,
                OilChange = request.OilChange,
                RoadTax = request.RoadTax,
                RoadTaxValue = request.RoadTaxValue,
                TaxValue = request.TaxValue,
                WinterTires = request.WinterTires
            });

            response.Success = true;
            return response;
        }

        public UpdateCarDetailResponse UpdateCarDetail(int id, UpdateCarDetailRequest request)
        {
            var response = new UpdateCarDetailResponse()
            {
                Errors = new List<string>()
            };
            
            _repository.Update(id, new CarDetail()
            {
                InsuranceValue = request.InsuranceValue,
                Itp = request.ITP,
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
            var response = new AddCarDetailResponse()
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
