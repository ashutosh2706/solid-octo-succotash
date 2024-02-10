using System.ComponentModel.DataAnnotations;

namespace MyApi.Data.Model
{
    public class User
    {
        [Key]
        public long id {get; set;}
        [Required]
        public string Username {get; set;}
        [Required]
        public string Password {get; set;}
        [Required]
        public string Role {get; set;}
    }
}