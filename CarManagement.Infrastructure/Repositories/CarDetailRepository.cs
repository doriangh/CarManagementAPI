using CarManagement.Core.Interfaces;
using CarManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarManagement.Infrastructure.Repositories
{
    class CarDetailRepository : ICarDetailRepository
    {
        private readonly AppDbContext _context;
        public CarDetailRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
