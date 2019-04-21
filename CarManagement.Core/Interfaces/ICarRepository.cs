using CarManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarManagement.Core.Interfaces
{
    public interface ICarRepository
    {
        List<Car> GetAll();
        Car GetById(int id);
        void Delete(int id);
        void Add(Car car);
        void Update(int id, Car car);
        List<Car> GetByUserId(int UserId);
    }
}
