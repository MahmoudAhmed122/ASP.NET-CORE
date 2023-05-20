using Demo.DAL.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IDepartmentRepository :IGenericRepository<Department>
    {
       Task<IEnumerable<Department>> SearchByDepartmentName(string departmentName);

    }
}
