using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using CarManagement.Core.Requests;
using CarManagement.Core.Responses;

namespace CarManagement.Services
{
    public class CarPriceService : ICarPriceService
    {
        private static ICarPriceRepository _repository;

        public CarPriceService(ICarPriceRepository repository)
        {
            _repository = repository;
        }
        
        public decimal GetPriceForCar(GetCarPriceRequest car)
        {
            return _repository.GetPrice(car);
        }
    }
}