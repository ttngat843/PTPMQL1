using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Demo_MVC.Models.Entities
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public string FullName { get; set; } = default!;
        public int BirthYear { get; set; } = default!;
    }
}
