using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_MVC.Models.Entities
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }   // khóa chính

        [Required]
        public string FullName { get; set; } = default!;

        public int BirthYear { get; set; }

        public string? Address { get; set; }
    }
}
