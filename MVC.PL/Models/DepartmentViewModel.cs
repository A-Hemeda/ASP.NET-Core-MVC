using System.ComponentModel.DataAnnotations;

namespace MVC.PL.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Department Code")]

        public string Code { get; set; }
        [Required(ErrorMessage = "Please enter the Department Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
    }
}
