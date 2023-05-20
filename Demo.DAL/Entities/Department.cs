using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entities
{
    public  class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required!")]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Name Length Must be between 100 and 5 characters!")]
        public string Name { get; set;}
        [Required(ErrorMessage = "Code is Required!")]
        public string Code { get; set;}
        public DateTime? DateOfCreation { get; set; } = DateTime.Now;
        public virtual ICollection<Employee>? employees { get; set; }
    }
}
