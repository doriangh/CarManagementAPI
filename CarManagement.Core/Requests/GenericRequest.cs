using System;
using System.Collections.Generic;
using System.Text;

namespace CarManagement.Core.Requests
{
    public class GenericRequest
    {
        public int RequesterId { get; set; }
        public string AuthKey { get; set; }

    }
}
