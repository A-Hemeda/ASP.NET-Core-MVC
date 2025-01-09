using System.ComponentModel.DataAnnotations;

namespace MVC.PL.Models
{
    public class EmployeeViewModel 
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile Image { get; set; }

        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
    }
}
