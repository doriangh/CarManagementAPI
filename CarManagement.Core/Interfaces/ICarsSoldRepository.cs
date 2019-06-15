using System.Collections.Generic;
using CarManagement.Core.Entities;

namespace CarManagement.Core.Interfaces
{
    public interface ICarsSoldRepository
    {
        List<CarsSold> GetAllCarsSold();
        void AddCarSold(CarsSold carsSold);
        CarsSold GetCarsSoldById(int id);
        void DeleteCarsSold(int id);
        void UpdateCarsSold(CarsSold car);
        List<CarsSold> GetByUserId(int userId);
    }
}