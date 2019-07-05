using CarManagement.Core.Entities;
using CarManagement.Core.Responses;

namespace CarManagement.Core.Interfaces
{
    public interface ICarPriceService
    {
        CarPriceResponse GetCarPrice(ModelInput input);
    }
}