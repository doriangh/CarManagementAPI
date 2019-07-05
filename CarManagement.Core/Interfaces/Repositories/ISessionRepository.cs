using CarManagement.Core.Entities;

namespace CarManagement.Core.Interfaces
{
    public interface ISessionRepository
    {
        Session GenerateSession(string username, string password);
        bool Valid(int userId, string key);
    }
}