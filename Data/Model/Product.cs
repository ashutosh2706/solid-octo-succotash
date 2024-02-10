using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Data.Model
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public long Id {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Info {get; set;}
    }
}