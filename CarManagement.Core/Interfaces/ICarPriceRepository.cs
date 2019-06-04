using CarManagement.Core.Requests;
using CarManagement.Core.Responses;

namespace CarManagement.Core.Interfaces
{
    public interface ICarPriceRepository
    {
        GetCarPriceResponse GetPrice(GetCarPriceRequest car);
    }
}