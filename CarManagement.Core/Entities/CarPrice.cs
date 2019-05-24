using System.ComponentModel.DataAnnotations;

namespace CarManagement.Core.Entities
{
    public class CarPrice
    {
        [Key]
        public  int id { get; set; }
        public string body { get; set; }
        public int CC { get; set; }
        public string color { get; set; }
        public string fuel { get; set; }
        public string gearbox { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int odometer { get; set; }
        public int power { get; set; }
        public string price { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public int round25 { get; set; }
    }
}