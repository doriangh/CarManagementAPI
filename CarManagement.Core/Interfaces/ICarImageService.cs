using System.Collections.Generic;
using CarManagement.Core.Entities;
using CarManagement.Core.Responses;

namespace CarManagement.Core.Interfaces
{
    public interface ICarImageService
    {
        List<CarImages> GetAll();
        CarImageResponse AddCarImage(CarImages carImages);
        CarImageResponse DeleteCarImage(int id);
        CarImageResponse UpdateCarImage(CarImages carImages);
        CarImages GetById(int id);
        List<CarImages> GetAllCarsImages(int carId);
    }
}