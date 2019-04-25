using CarManagement.Core.Requests;
using CarManagement.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using CarManagement.Core.Entities;

namespace CarManagement.Core.Interfaces
{
    public interface ICarService
    { 
        AddCarResponse AddCar(AddCarRequest request);
        List<Car> GetAll();
        Car GetById(int id);
        AddCarResponse Delete(int id);
        List<Car> GetByUserId(int id);
    }
}
