using CarManagement.Core.Entities;
using CarManagement.Core.Requests;
using CarManagement.Core.Responses;

namespace CarManagement.Core.Interfaces
{
    public interface ICarPriceService
    {
        GetCarPriceResponse GetPrice(GetCarPriceRequest car);
    }
}