using CarManagement.Core.Interfaces;
using CarManagement.Infrastructure.Data;
using CarManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManagement.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Cars.Remove(GetById(id));
            _context.SaveChanges();
        }

        public List<Car> GetAll()
        {
            return _context.Cars.ToList();
        }

        public Car GetById(int id)
        {
            return _context.Cars.FirstOrDefault(c => c.Id == id);
        }

        public List<Car> GetByUserId(int UserId)
        {
            var user = _context.Users.Find(UserId);
            if (user == null) throw new KeyNotFoundException();

            return _context.Cars.Where(car => car.UserId == UserId).ToList();
            
        }

        public void Update(int id, Car car)
        {
            _context.Cars.Update(car);
        }
    }
}
