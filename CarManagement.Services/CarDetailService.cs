using CarManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarManagement.Services
{
    public class CarDetailService : ICarDetailService
    {
        readonly ICarDetailRepository _repository;

        public CarDetailService(ICarDetailRepository repository)
        {
            _repository = repository;
        }
    }
}
