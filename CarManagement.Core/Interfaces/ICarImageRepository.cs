using System.Collections.Generic;
using CarManagement.Core.Entities;

namespace CarManagement.Core.Interfaces
{
    public interface ICarImageRepository
    {
        List<CarImages> GetAllCarImages();
        void AddCarImage(CarImages carImages);
        void DeleteCarImage(int id);
        void UpdateCarImage(CarImages carImages);
        CarImages GetByIdCarImages(int id);
        List<CarImages> GetByCarId(int carId);
    }
}