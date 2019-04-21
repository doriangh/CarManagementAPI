using System;
using System.Collections.Generic;
using System.Text;

namespace CarManagement.Core.Requests
{
    public class AddCarDetailRequest
    {
        public int CarId { get; set; }
        public DateTime ITP { get; set; }
        public DateTime Rovinieta { get; set; }
        public bool WinterTires { get; set; }
        public DateTime OilChange { get; set; }
        public int ValoareAsigurare { get; set; }
        public int ValoareRovinieta { get; set; }
        public int ValoareImpozit { get; set; }
    }
}
