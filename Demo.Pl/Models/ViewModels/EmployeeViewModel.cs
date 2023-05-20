using Demo.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Demo.Pl.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name Is Required!")]
        [MaxLength(50, ErrorMessage = "Name must not be more than 50 Characters!")]
        [MinLength(5, ErrorMessage = "Name must  be more than 5 Characters!")]
        public string Name { get; set; }
        [Range(20, 60, ErrorMessage = "Age must be between 20 and 60 years!")]
        public int? Age { get; set; }
        [Display(Name = "Address")]
        [RegularExpression(@"^[0-9]{1,10}-[a-zA-Z]{1,40}-[a-zA-Z]{1,40}-[a-zA-Z]{1,40}$",
            ErrorMessage = "Address must be like 123-Street-Region-City")]
        public string EmployeeAddress { get; set; }

        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Hiring Date")]
        public DateTime HirngDate { get; set;}
        [Display(Name = "Date Of Creation")]

        [Phone]
        public string Phone { get; set; }

        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
        public virtual Department? Department { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
    }
}
