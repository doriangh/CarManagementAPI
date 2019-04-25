using CarManagement.Core.Interfaces;

namespace CarManagement.Services
{
    public class CarDetailService : ICarDetailService
    {
        private readonly ICarDetailRepository _repository;

        public CarDetailService(ICarDetailRepository repository)
        {
            _repository = repository;
        }
    }
}
