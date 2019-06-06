using System.Collections.Generic;

namespace CarManagement.Core.Responses
{
    public class GenericResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}