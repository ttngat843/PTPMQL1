using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_MVC.Models.Entities
{
    public class Person
    {   
        [Key]
        public int PersonId { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        public int BirthYear { get; set; }

        public string? Address { get; set; }
    }
}