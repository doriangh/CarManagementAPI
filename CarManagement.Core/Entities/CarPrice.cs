using System.ComponentModel.DataAnnotations;

namespace CarManagement.Core.Entities
{
    public class CarPrice
    {
        [Key]
        public  int id { get; set; }
        //public string Address { get; set; }
        public string body { get; set; }
        public string color { get; set; }
        //public string currency { get; set; }
        public string CC { get; set; }
        public string fuel { get; set; }
        public string gearbox { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string mileage { get; set; }
        public string price { get; set; }
        public string year { get; set; }
    }
}