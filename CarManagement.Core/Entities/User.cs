using System.ComponentModel.DataAnnotations;

namespace CarManagement.Core.Entities
{
    public class User
    {
        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public int Age { get; set; }

        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }

        public bool IsLogged { get; set; }
        public string UserImage { get; set; }
    }
}