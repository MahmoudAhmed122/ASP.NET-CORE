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
    public class DepartmentRepository : GenericRepository<Department> , IDepartmentRepository// we will save operations on database 
    { 
        public ApplicationDbContext Context { get; }

        public DepartmentRepository(ApplicationDbContext context):base(context)
        {
            Context = context;
        }
        public async Task<IEnumerable<Department>> SearchByDepartmentName(string value) => await Context.Departments.Where(e => e.Name.Contains(value)).ToListAsync();


    }
}
