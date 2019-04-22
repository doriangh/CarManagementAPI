using CarManagement.Core.Entities;
using CarManagement.Core.Requests;
using CarManagement.Core.Responses;

namespace CarManagement.Core.Interfaces
{
    public interface ISessionService
    {
        SessionResponse Session(SessionRequest request);
        bool VerifySession(VerifySessionRequest request);
    }
}