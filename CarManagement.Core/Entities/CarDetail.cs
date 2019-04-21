using System;
using System.ComponentModel.DataAnnotations;

namespace CarManagement.Core.Entities
{
    public class CarDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
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
