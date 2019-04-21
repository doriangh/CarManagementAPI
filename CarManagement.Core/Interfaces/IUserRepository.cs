using CarManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarManagement.Core.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        void Delete(int id);
        void Add(User user);
        void Update(int id, User user);
    }
}
