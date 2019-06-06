using System.Collections.Generic;
using CarManagement.Core.Entities;

namespace CarManagement.Core.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        User GetByUsername(string username);
        void Delete(int id);
        void Add(User user);
        void Update(int id, User user);
    }
}