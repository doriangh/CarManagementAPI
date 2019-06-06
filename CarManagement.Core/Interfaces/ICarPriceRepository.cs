using CarManagement.Core.Entities;

namespace CarManagement.Core.Interfaces
{
    public interface ICarPriceRepository
    {
        float GetCarPrice(ModelInput input);
    }
}