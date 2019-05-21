using CarManagement.Core.Requests;
using CarManagement.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using CarManagement.Core.Entities;

namespace CarManagement.Core.Interfaces
{
    public interface IUserService
    {
        AddUserResponse AddUser(AddUserRequest request);
        List<User> GetAll();
        User GetById(int id);
        AddUserResponse DeleteUser(int id);
        UpdateUserResponse UpdateUser(int userId, UpdateUserRequest request);
    }
}
