using System;
using System.Collections.Generic;
using System.Text;
using CarManagement.Core.Entities;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Abstractions.Internal;

namespace CarManagement.Core.Interfaces
{
    public interface ICarDetailRepository
    {
        List<CarDetail> GetAll();
        CarDetail GetById(int id);
        void Delete(int id);
        void Add(CarDetail carDetail);
        void Update(int id, CarDetail carDetail);
        List<CarDetail> GetByCarId(int carId);
    }
}
