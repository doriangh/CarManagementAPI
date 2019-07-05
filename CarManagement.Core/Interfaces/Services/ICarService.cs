using System.Collections.Generic;
using CarManagement.Core.Entities;
using CarManagement.Core.Requests;
using CarManagement.Core.Responses;

namespace CarManagement.Core.Interfaces
{
    public interface ICarService
    {
        AddCarResponse AddCar(AddCarRequest request);
        List<Car> GetAll();
        Car GetById(int id);
        AddCarResponse Delete(int id);
        List<Car> GetByUserId(int id);
        UpdateCarResponse UpdateCar(int carId, UpdateCarRequest request);
    }
}