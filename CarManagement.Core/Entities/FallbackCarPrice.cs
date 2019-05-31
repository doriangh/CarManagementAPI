using System.ComponentModel.DataAnnotations;

namespace CarManagement.Core.Entities
{
    public class FallbackCarPrice
    {
        [Key]
        public int Id { get; set; }
        public int Count { get; set; }
        public int Year { get; set; }
        public int Round5000 { get; set; }
        public int RoundCc { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int AvgPrice { get; set; }
        
    }
}
