using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using CarManagement.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CarManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public JsonResult AddUser([FromBody] AddUserRequest request)
        {
            return Json(_userService.AddUser(request));
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_userService.GetAll());
        }

        [HttpGet("{id}")]
        public JsonResult GetUser([FromRoute] int id)
        {
            return Json(_userService.GetById(id));
        }

        [HttpPut]
        public JsonResult UpdateUser([FromBody] User newUser)
        {
            return Json(_userService.UpdateUser(newUser));
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteUser([FromRoute] int id)
        {
            return Json(_userService.DeleteUser(id));
        }
    }
}