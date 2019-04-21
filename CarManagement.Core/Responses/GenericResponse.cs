using System;
using System.Collections.Generic;
using System.Text;

namespace CarManagement.Core.Responses
{
    public class GenericResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }

    }
}
