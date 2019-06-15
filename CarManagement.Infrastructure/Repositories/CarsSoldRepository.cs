using System.Collections.Generic;
using System.Linq;
using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using CarManagement.Infrastructure.Data;

namespace CarManagement.Infrastructure.Repositories
{
    public class CarsSoldRepository : ICarsSoldRepository
    {
        private readonly AppDbContext _context;

        public CarsSoldRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<CarsSold> GetAllCarsSold()
        {
            return _context.CarsSold.ToList();
        }

        public void AddCarSold(CarsSold carsSold)
        {
            _context.CarsSold.Add(carsSold);
            _context.SaveChanges();
        }

        public CarsSold GetCarsSoldById(int id)
        {
            return _context.CarsSold.FirstOrDefault(x => x.id == id);
        }

        public void DeleteCarsSold(int id)
        {
            _context.CarsSold.Remove(GetCarsSoldById(id));
            _context.SaveChanges();
        }

        public void UpdateCarsSold(CarsSold car)
        {
            var oldCarSold = GetCarsSoldById(car.id);

            oldCarSold.Details = car.Details;
            oldCarSold.LongDescription = car.LongDescription;
            _context.SaveChanges();
        }

        public List<CarsSold> GetByUserId(int userId)
        {
            return _context.CarsSold.Where(x => x.UserId == userId).ToList();
        }
    }
}