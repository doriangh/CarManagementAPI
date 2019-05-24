using System.ComponentModel.DataAnnotations;

namespace CarManagement.Core.Entities
{
    public class FallbackCarPrice
    {
        [Key]
        public int id { get; set; }
        public int count { get; set; }
        public int year { get; set; }
        public int Round5000 { get; set; }
        public int RoundCC { get; set; }
        public int minPrice { get; set; }
        public int maxPrice { get; set; }
        public int avgPrice { get; set; }
        
    }
}
