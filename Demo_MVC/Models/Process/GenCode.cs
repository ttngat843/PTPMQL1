using System.ComponentModel.DataAnnotations;

namespace Demo_MVC.Models.Process
{
    public class GenCode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
