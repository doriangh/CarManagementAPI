using System.ComponentModel.DataAnnotations;

namespace CarManagement.Core.Entities
{
    public class CarPrice
    {
        [Key]
        public  int Id { get; set; }
        public string Body { get; set; }
        public int Cc { get; set; }
        public string Color { get; set; }
        public string Fuel { get; set; }
        public string Gearbox { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Odometer { get; set; }
        public int Power { get; set; }
        public string Price { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        //public int round25 { get; set; }
    }
}