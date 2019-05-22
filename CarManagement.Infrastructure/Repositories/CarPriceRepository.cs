using System;
using System.Linq;
using System.Net.NetworkInformation;
using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using CarManagement.Core.Requests;
using CarManagement.Infrastructure.Data;
using Remotion.Linq.Clauses;

namespace CarManagement.Infrastructure.Repositories
{
    public class CarPriceRepository : ICarPriceRepository
    {
        private static AppDbContext _context;

        public CarPriceRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public decimal GetPrice(GetCarPriceRequest car)
        {
            var carPrice = _context.CarPrices.Where(p => 
                p.make == car.make && 
                p.model == car.model && 
                p.year == car.year && 
                p.CC == car.CC &&
                Convert.ToInt32(p.mileage) >= Convert.ToInt32(car.odometer) - 20000 &&
                Convert.ToInt32(p.mileage) <= Convert.ToInt32(car.odometer) + 20000).ToList();

            if (carPrice == null) return 0;

            var price = 0;
            
            foreach (var currPrice in carPrice)
            {
                price += Convert.ToInt32(currPrice.price);
            }

            var avgPrice = Math.Floor(Convert.ToDecimal(price/carPrice.Count()));

            return avgPrice;

        }
    }
}