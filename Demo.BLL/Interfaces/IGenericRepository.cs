using Demo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task <T> Get(int? id);
        Task <IEnumerable<T>> GetAll();
        Task <int> Add(T item); // it will return 1 if  true , else 0 false 
        Task<int> Update(T item);
        Task<int> Delete(T item);


    }
}
