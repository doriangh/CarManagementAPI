using CarManagement.Core.Entities;
using CarManagement.Core.Requests;

namespace CarManagement.Core.Interfaces
{
    public interface ICarPriceRepository
    {
        decimal GetPrice(GetCarPriceRequest car);
    }
}