using System.Collections.Generic;
using CarManagement.Core.Entities;
using CarManagement.Core.Requests;
using CarManagement.Core.Responses;

namespace CarManagement.Core.Interfaces
{
    public interface ICarDetailService
    {
        AddCarDetailResponse AddCarDetail(AddCarDetailRequest request);
        List<CarDetail> GetAll();
        CarDetail GetById(int id);
        AddCarDetailResponse Delete(int id);
        List<CarDetail> GetByCarId(int id);
        UpdateCarDetailResponse UpdateCarDetail(int id, UpdateCarDetailRequest request);
    }
}
