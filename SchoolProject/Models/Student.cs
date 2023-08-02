using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
