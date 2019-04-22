using System.Linq;
using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using CarManagement.Core.Requests;
using CarManagement.Infrastructure.Data;
using CarManagement.Infrastructure.Utils;
using CarManagementAPI.Models;

namespace CarManagement.Infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _repository;

        public SessionRepository(AppDbContext context, IUserRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        
        public Session GenerateSession(string username, string password)
        {
            var user = _repository.GetByUsername(username);
            if (user == null) return null;

            var hash = Sha.Encrypt(RandomString.CreateString(256));
            var session = new Session()
            {
               UserId = user.Id,
               Key = hash
            };
            _context.Session.Add(session);
            _context.SaveChanges();
            return session;
        }

        public bool Valid(int userId, string key)
        {
            var currentSession = _context.Session.FirstOrDefault(u => u.UserId == userId && u.Key == key);

            return currentSession != null;
        }
    }
}