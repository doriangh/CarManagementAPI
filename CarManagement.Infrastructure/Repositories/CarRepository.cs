using System.Collections.Generic;
using System.Linq;
using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using CarManagement.Infrastructure.Data;

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

        public List<Car> GetByUserId(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null) throw new KeyNotFoundException();

            return _context.Cars.Where(car => car.UserId == userId).ToList();
        }

        public void Update(int id, Car car)
        {
            var oldCar = GetById(id);
            oldCar.Make = car.Make;
            oldCar.Manufacturer = car.Manufacturer;
            oldCar.Plant = car.Plant;
            oldCar.ModelYear = car.ModelYear;
            oldCar.SequentialNumber = car.SequentialNumber;
            oldCar.Model = car.Model;
            oldCar.Body = car.Body;
            oldCar.Drive = car.Drive;
            oldCar.NumberofSeats = car.NumberofSeats;
            oldCar.NumberofDoors = car.NumberofDoors;
            oldCar.Steering = car.Steering;
            oldCar.EngineDisplacement = car.EngineDisplacement;
            oldCar.EngineCylinders = car.EngineCylinders;
            oldCar.NumberofGears = car.NumberofGears;
            oldCar.Engine = car.Engine;
            oldCar.Made = car.Made;
            oldCar.Color = car.Color;
            oldCar.Fuel = car.Fuel;
            oldCar.Cc = car.Cc;
            oldCar.Power = car.Power;
            oldCar.Emissions = car.Emissions;
            oldCar.Odometer = car.Odometer;
            oldCar.Vin = car.Vin;
            oldCar.License = car.License;
            oldCar.CarImage = car.CarImage;
            oldCar.CarPrice = car.CarPrice;
            _context.SaveChanges();
        }
    }
}