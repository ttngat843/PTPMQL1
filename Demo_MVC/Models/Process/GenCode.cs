using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_MVC.Models.Process
{
    [Table("GenCodes")]
    public class GenCode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
