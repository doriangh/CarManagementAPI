using CarManagement.Core.Requests;
using CarManagement.Core.Responses;
using CarManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarManagement.Core.Interfaces
{
    public interface IUserService
    {
        AddUserResponse AddUser(AddUserRequest request);
        List<User> GetAll();
        User GetById(int id);
        AddUserResponse DeleteUser(int id);
    }
}
