using System.Net;
using System.Net.Http;
using CarManagement.Core.Interfaces;
using CarManagement.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CarManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class SessionController : Controller
    {

        private readonly ISessionService _service;

        public SessionController(ISessionService service)
        {
            _service = service;
        }

        [HttpPost]
        public JsonResult Add([FromBody] SessionRequest request)
        {
            return Json(_service.Session(request));
        }

        [HttpGet]
        public HttpResponseMessage Get([FromQuery] VerifySessionRequest request)
        {
            return _service.VerifySession(request) ? new HttpResponseMessage(HttpStatusCode.OK) : new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}