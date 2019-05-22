using CarManagement.Core.Entities;
using CarManagement.Core.Requests;
using CarManagement.Core.Responses;

namespace CarManagement.Core.Interfaces
{
    public interface ICarPriceService
    {
        decimal GetPriceForCar(GetCarPriceRequest car);
    }
}