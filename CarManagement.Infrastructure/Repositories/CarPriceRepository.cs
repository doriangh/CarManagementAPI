using System;
using System.Collections.Generic;
using System.Linq;
using CarManagement.Core.Entities;
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
        
        public decimal GetPrice(GetCarPriceRequest car)
        {

            int differenceDown = 0;
            int differenceUp = 0;


            if (car.odometer < 1000)
            {
                differenceDown = 0;
                differenceUp = 5000;
            }
            else if (car.odometer < 50000)
            {
                differenceDown = 1000;
                differenceUp = 100000;
            }
            else if (car.odometer < 150000)
            {
                differenceDown = 50000;
                differenceUp = 200000;
            }
            else
            {
                differenceDown = 150000;
                differenceUp = 300000;
            }

            var carPrice = _context.CarPrices.Where(p => 
                p.make == car.make && 
                p.model == car.model && 
                p.year == car.year && 
                p.CC >= car.CC - 100 &&
                p.CC <= car.CC + 100 &&
                p.round25 >= differenceDown &&
                p.round25 <= differenceUp).ToList();

            if (carPrice.Count == 0)
            {
                if (car.odometer < 100000)
                {
                    differenceDown = 0;
                    differenceUp = 100000;
                }
                else
                {
                    differenceDown = 100000;
                    differenceUp = 300000;
                }

                carPrice = _context.CarPrices.Where(p =>
                p.make == car.make &&
                p.model == car.model &&
                p.year == car.year &&
                p.CC >= car.CC - 500 &&
                p.CC <= car.CC + 500 &&
                p.round25 >= differenceDown &&
                p.round25 <= differenceUp).ToList();
            }

            var price = 0;
            
            foreach (var currPrice in carPrice)
            {
                price += Convert.ToInt32(currPrice.price);
            }

            var avgPrice = Math.Floor(Convert.ToDecimal(price/carPrice.Count()));

            return avgPrice;
        }
        
        public GetCarPriceResponse GetPriceFirst(GetCarPriceRequest car)
        {
            var prices = _context.CarPrices.Where(p =>
                                    p.make == car.make &&
                                    p.model == car.model &&
                                    p.year == car.year &&
                                    p.CC == car.CC &&
                                    p.odometer == car.odometer).ToList();

            if (prices.Count == 0) return null;
            else
            {
                return CalculateAveragePrice(prices);
            }
        }

        public GetCarPriceResponse GetPriceSecond(GetCarPriceRequest car)
        {
            var differenceDown = 0;
            var differenceUp = 0;

            if (car.odometer < 10000)
            {
                differenceDown = 0;
                differenceUp = 10000;
            }
            else
            {
                differenceDown = 10000;
                differenceUp = 10000;
            }

            var prices = _context.CarPrices.Where(p =>
                                    p.make == car.make &&
                                    p.model == car.model &&
                                    p.year == car.year &&
                                    p.CC == car.CC &&
                                    p.odometer >= car.odometer - differenceDown &&
                                    p.odometer <= car.odometer + differenceUp).ToList();

            if (prices.Count == 0) return null;
            else
            {
                return CalculateAveragePrice(prices);
            }
        }

        public GetCarPriceResponse GetPriceThird(GetCarPriceRequest car)
        {
            var differenceDown = 0;
            var differenceUp = 0;

            if (car.odometer < 50000)
            {
                differenceDown = 0;
                differenceUp = 50000;
            }
            else if (car.odometer > 50000)
            {
                differenceDown = 50000;
                differenceUp = 50000;
            }
            else if (car.odometer > 215000)
            {
                differenceDown = 50000;
                differenceUp = 0;
            }

            var prices = _context.CarPrices.Where(p =>
                                    p.make == car.make &&
                                    p.model == car.model &&
                                    p.year == car.year &&
                                    p.CC == car.CC &&
                                    p.odometer >= car.odometer - differenceDown &&
                                    p.odometer <= car.odometer + differenceUp).ToList();

            if (prices.Count == 0) return null;
            else
            {
                return CalculateAveragePrice(prices);
            }
        }

        public GetCarPriceResponse GetPriceFourth(GetCarPriceRequest car)
        {
            var prices = _context.CarPrices.Where(p =>
                                    p.make == car.make &&
                                    p.model == car.model &&
                                    p.year == car.year &&
                                    p.CC == car.CC).ToList();

            if (prices.Count == 0) return null;
            else
            {
                return CalculateAveragePrice(prices);
            }
        }

        public GetCarPriceResponse GetPriceFifth(GetCarPriceRequest car)
        {
            var prices = _context.CarPrices.Where(p =>
                                    p.make == car.make &&
                                    p.model == car.model &&
                                    p.year >= car.year - 2 &&
                                    p.year <= car.year + 2 &&
                                    p.CC == car.CC).ToList();

            if (prices.Count == 0) return null;
            else
            {
                return CalculateAveragePrice(prices);
            }
        }

        public GetCarPriceResponse GetPriceSixth(GetCarPriceRequest car)
        {
            var prices = _context.CarPriceData.Where(p =>
                                    p.year == car.year &&
                                    p.Round5000 >= car.odometer - 5000 &&
                                    p.Round5000 <= car.odometer + 5000 &&
                                    p.RoundCC == car.CC).ToList();

            if (prices.Count == 0) return null;
            else
            {
                return CalculateAveragePrice(prices);
            }
        }


        public GetCarPriceResponse CalculateAveragePrice(List<CarPrice> carPrices)
        {
            var price = 0;
            foreach (var carPrice in carPrices)
                price += Convert.ToInt32(carPrice.price);

            return new GetCarPriceResponse()
            {
                price = price/carPrices.Count(),
                count = carPrices.Count()
            };
        }

        public GetCarPriceResponse CalculateAveragePrice(List<FallbackCarPrice> carPrices)
        {
            var price = 0;
            foreach (var carPrice in carPrices)
                price += Convert.ToInt32(carPrice.price);

            return new GetCarPriceResponse()
            {
                price = price / carPrices.Count(),
                count = carPrices.Count()
            };
        }
    }
}