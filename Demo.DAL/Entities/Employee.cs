using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entities
{
    public  class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength( 50)]
        [MinLength(5)]
        public string Name { get; set; }
        public int? Age { get; set; }
        public string EmployeeAddress { get; set; }

        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public DateTime HirngDate { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public string Phone { get; set; }

        public string? ImageName { get; set; }


        public virtual Department? Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
