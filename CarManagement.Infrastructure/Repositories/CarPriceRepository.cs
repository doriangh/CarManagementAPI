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
        
        public GetCarPriceResponse GetPrice(GetCarPriceRequest car)
        {
            var price = new GetCarPriceResponse
            {
                Errors = new List<string>()
            };

            if (GetPriceFirst(car) == null)
                if (GetPriceSecond(car) == null)
                    if (GetPriceThird(car) == null)
                        if (GetPriceFourth(car) == null)
                            if (GetPriceFifth(car) == null)
                                if (GetPriceSixth(car) == null)
                                {
                                    price.Success = false;
                                    price.Errors.Add("Could not find car price");
                                }
                                else price = GetPriceSixth(car);
                            else price = GetPriceFifth(car);
                        else price = GetPriceFourth(car);
                    else price = GetPriceThird(car);
                else price = GetPriceSecond(car);
            else price = GetPriceFirst(car);

            price.Success = true;

            return price;
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
            var prices = _context.CarPriceData.FirstOrDefault(p =>
                                    p.year == car.year &&
                                    p.Round5000 >= car.odometer - 5000 &&
                                    p.Round5000 <= car.odometer + 5000 &&
                                    p.RoundCC == car.CC);

            if (prices == null) return null;
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

        public GetCarPriceResponse CalculateAveragePrice(FallbackCarPrice carPrices)
        {
            return new GetCarPriceResponse()
            {
                price = carPrices.avgPrice,
                count = carPrices.count
            };
        }
    }
}