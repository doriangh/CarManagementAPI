using System;
using System.Collections.Generic;
using System.Linq;
using CarManagement.Core.Interfaces;
using CarManagement.Core.Requests;
using CarManagement.Core.Responses;
using CarManagement.Infrastructure.Data;

namespace CarManagement.Infrastructure.Repositories
{
    public class CarPriceRepository : ICarPriceRepository
    {
        private static AppDbContext _context;

        public CarPriceRepository(AppDbContext context)
        {
            _context = context;
        }

        public GetCarPriceResponse GetPrice(GetCarPriceRequest car)
        {
            var price = new GetCarPriceResponse
            {
                Errors = new List<string>()
            };

            var prices = _context.CarPrices.Where(p =>
                p.Make == car.Make &&
                p.Model == car.Model &&
                p.Cc >= car.Cc - 100 &&
                p.Cc <= car.Cc + 100 &&
                p.Year >= car.Year - 2 &&
                p.Year <= car.Year + 2).OrderBy(p => p.Odometer).ToList();

            if (prices.Count == 0)
            {
                price.Success = false;
                price.Errors.Add("Could not find car price!");
            }

            if (prices.Count == 1)
            {
                price.Success = true;
                price.Price = Convert.ToInt32(prices[0].Price);
            }
            else if (prices.Count > 1)
            {
                var higherOdometer = prices.Where(p => p.Odometer >= car.Odometer).Take(5).ToList();
                var lowerOdometer = prices.Where(p => p.Odometer <= car.Odometer).Take(5).ToList();

                var finalPrice = 0;

                foreach (var p in higherOdometer) finalPrice += Convert.ToInt32(p.Price);

                foreach (var p in lowerOdometer) finalPrice += Convert.ToInt32(p.Price);

                finalPrice /= higherOdometer.Count() + lowerOdometer.Count();

                price.Count = higherOdometer.Count() + lowerOdometer.Count();
                price.Success = true;
                price.Price = finalPrice;
            }

            return price;
        }
    }
}