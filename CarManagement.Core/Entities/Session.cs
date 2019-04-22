using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarManagementAPI.Models;

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