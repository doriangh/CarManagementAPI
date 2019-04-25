using System.Collections.Generic;
using CarManagement.Core.Interfaces;
using CarManagement.Core.Requests;
using CarManagement.Core.Responses;

namespace CarManagement.Services
{
    public class SessionService : ISessionService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository, IUserRepository userRepository)
        {
            _sessionRepository = sessionRepository;
            _userRepository = userRepository;
        }

        public SessionResponse Session(SessionRequest request)
        {
            var sessionResponse = new SessionResponse {Errors = new List<string>(), Success = true};

            var user = _userRepository.GetByUsername(request.Username);

            if (user == null)
            {
                sessionResponse.Success = false;
                sessionResponse.Errors.Add("User not in DB");
                return sessionResponse;
            }

            if (request.Password != user.Password)
            {
                sessionResponse.Success = false;
                sessionResponse.Errors.Add("Incorrect Password");
            }

            if (!sessionResponse.Success) return sessionResponse;

            var session = _sessionRepository.GenerateSession(request.Username, request.Password);
            sessionResponse.Success = true;
            sessionResponse.Key = session.Key;
            sessionResponse.UserId = session.UserId;
            return sessionResponse;

        }

        public bool VerifySession(VerifySessionRequest request)
        {
            return _sessionRepository.Valid(request.UserId, request.Key);
        }
    }
}