using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_MVC.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        public int BirthYear { get; set; }

        public string? Address { get; set; }

        // Thêm để khớp với View
        public string EmployeeCode { get; set; } = string.Empty;

        // Tính tuổi tự động
        [NotMapped]
        public int Age
        {
            get
            {
                if (BirthYear <= 0) return 0;
                return DateTime.Now.Year - BirthYear;
            }
        }

        // Quan hệ với Person
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person? Person { get; set; }
    }
}
