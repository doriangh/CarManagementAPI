using System;
using System.ComponentModel.DataAnnotations;

namespace CarManagement.Core.Entities
{
    public class CarDetail
    {
        [Key] public int Id { get; set; }

        [Required] public int CarId { get; set; }

        public DateTime Itp { get; set; }
        public DateTime RoadTax { get; set; }
        public bool WinterTires { get; set; }
        public int Price { get; set; }
        public int OilChange { get; set; }
        public int InsuranceValue { get; set; }
        public int RoadTaxValue { get; set; }
        public int TaxValue { get; set; }
    }
}