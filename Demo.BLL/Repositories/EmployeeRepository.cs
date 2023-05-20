using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Demo.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public ApplicationDbContext Context { get; }

        public EmployeeRepository(ApplicationDbContext context) : base(context) { 
        Context=context;    
        }

        public async Task<IEnumerable<Employee>> SearchByEmplyeeName(string value) {
            var employees = await Context.Employees.Where(e => e.Name.Contains(value)).ToListAsync();
                return employees;
                }
        
    }
}
 