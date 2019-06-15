using System.ComponentModel.DataAnnotations;

namespace CarManagement.Core.Entities
{
    public class CarsSold
    {
        [Key] public int id { get; set; }

        public int UserId { get; set; }
        public int CarId { get; set; }
        public int CarDetail { get; set; }
        public string Details { get; set; }
        public string LongDescription { get; set; }
    }
}