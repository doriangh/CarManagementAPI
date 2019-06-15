using System.ComponentModel.DataAnnotations;

namespace CarManagement.Core.Entities
{
    public class CarImages
    {
        [Key] public int Id { get; set; }
        public int CarId { get; set; }
        public string CarImage { get; set; }
    }
}