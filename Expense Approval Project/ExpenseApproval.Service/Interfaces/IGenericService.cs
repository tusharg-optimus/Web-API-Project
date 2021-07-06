using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.Service.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();

        public Task<T> GetById(int id);

        public Task<T> Add(T obj);

        public void Update(int id,T obj);

        public void Delete(int id);

        public void SaveChanges();

    }
}
