using System.Collections.Generic;
using System.Linq;
using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using CarManagement.Infrastructure.Data;

namespace CarManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(user => user.Username == username);
        }

        public void Delete(int id)
        {
            _context.Users.Remove(GetById(id));
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Update(User user)
        {
            var oldUser = GetById(user.Id);

            oldUser.Name = user.Name;
            oldUser.Age = user.Age;
            oldUser.Username = user.Username;
            oldUser.UserImage = user.UserImage;
            oldUser.PhoneNumber = user.PhoneNumber;
            oldUser.Address = user.Address;
            _context.SaveChanges();
        }
    }
}