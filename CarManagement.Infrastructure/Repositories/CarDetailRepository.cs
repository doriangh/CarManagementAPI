using CarManagement.Core.Interfaces;
using CarManagement.Infrastructure.Data;

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
