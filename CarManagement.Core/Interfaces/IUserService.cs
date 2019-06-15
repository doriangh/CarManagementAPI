using System.Collections.Generic;
using CarManagement.Core.Entities;
using CarManagement.Core.Requests;
using CarManagement.Core.Responses;

namespace CarManagement.Core.Interfaces
{
    public interface IUserService
    {
        AddUserResponse AddUser(AddUserRequest request);
        List<User> GetAll();
        User GetById(int id);
        AddUserResponse DeleteUser(int id);
        UpdateUserResponse UpdateUser(User request);
    }
}