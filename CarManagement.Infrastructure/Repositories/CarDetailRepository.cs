using System.Collections.Generic;
using System.Linq;
using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using CarManagement.Infrastructure.Data;

namespace CarManagement.Infrastructure.Repositories
{
    public class CarDetailRepository : ICarDetailRepository
    {
        private readonly AppDbContext _context;
        public CarDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<CarDetail> GetAll()
        {
            return _context.CarDetails.ToList();
        }

        public CarDetail GetById(int id)
        {
            return _context.CarDetails.FirstOrDefault(detail => detail.Id == id);
        }

        public void Delete(int id)
        {
            _context.CarDetails.Remove(GetById(id));
            _context.SaveChanges();
        }

        public void Add(CarDetail carDetail)
        {
            _context.CarDetails.Add(carDetail);
            _context.SaveChanges();
        }

        public void Update(int id, CarDetail carDetail)
        {
            _context.CarDetails.Update(carDetail);
        }

        public List<CarDetail> GetByCarId(int carId)
        {
            var car = _context.Cars.Find(carId);
            if (car == null) throw new KeyNotFoundException();

            return _context.CarDetails.Where(detail => detail.CarId == carId).ToList();
        }
    }
}
