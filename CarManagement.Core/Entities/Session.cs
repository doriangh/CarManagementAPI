using System.ComponentModel.DataAnnotations;

namespace CarManagement.Core.Entities
{
    public class Session
    {
        [Key]
        public int KeyId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Key { get; set; }
    }
}