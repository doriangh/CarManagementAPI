using System.Collections.Generic;
using System.Linq;
using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using CarManagement.Infrastructure.Data;

namespace CarManagement.Infrastructure.Repositories
{
    public class CarImageRepository : ICarImageRepository
    {
        private readonly AppDbContext _context;

        public CarImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<CarImages> GetAllCarImages()
        {
            return _context.CarImages.ToList();
        }

        public void AddCarImage(CarImages carImages)
        {
            _context.CarImages.Add(carImages);
            _context.SaveChanges();
        }

        public void DeleteCarImage(int id)
        {
            _context.CarImages.Remove(GetByIdCarImages(id));
            _context.SaveChanges();
        }

        public void UpdateCarImage(CarImages carImages)
        {
            var oldCarImage = GetByIdCarImages(carImages.Id);
            oldCarImage.CarImage = carImages.CarImage;
            _context.SaveChanges();
        }

        public CarImages GetByIdCarImages(int id)
        {
            return _context.CarImages.FirstOrDefault(x => x.Id == id);
        }

        public List<CarImages> GetByCarId(int carId)
        {
            return _context.CarImages.Where(x => x.CarId == carId).ToList();
        }
    }
}