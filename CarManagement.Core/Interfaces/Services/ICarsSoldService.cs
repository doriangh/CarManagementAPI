using System.Collections.Generic;
using CarManagement.Core.Entities;
using CarManagement.Core.Responses;

namespace CarManagement.Core.Interfaces
{
    public interface ICarsSoldService
    {
        List<CarsSold> GetAllCarsSold();
        AddCarsSoldResponse AddCarsSold(CarsSold car);
        AddCarsSoldResponse UpdateCarsSold(CarsSold car);
        AddCarsSoldResponse RemoveCarsSold(int id);
        CarsSold GetById(int id);
        List<CarsSold> GetByUserId(int userId);
    }
}