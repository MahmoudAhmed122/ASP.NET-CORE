using Demo.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Demo.Pl.Models.ViewModels
{
    public class DepartmentViewModel
    {

        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public virtual ICollection<Employee>? employees { get; set; }
    }
}
