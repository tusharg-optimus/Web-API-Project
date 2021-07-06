using ExpenseApproval.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.DataAccess.Repository.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
  
        private readonly ExpenseContext _expenseContext;

        private DbSet<T> _entity;
        public GenericRepository(ExpenseContext expenseContext) //Doing Dependency Injection(Constructor injection)
        {
            _expenseContext = expenseContext;
            _entity = _expenseContext.Set<T>();
        }
        public async Task<T> Add(T obj)
        {
            var result = await _entity.AddAsync(obj);
            return result.Entity;
        }

        public void Delete(int id)
        {
            var result = _entity.Find(id);
            _entity.Remove(result);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entity.FindAsync(id);
        }

        public void SaveChanges()
        {
            _expenseContext.SaveChanges();
        }

        public void Update(int id,T obj)
        {
            T existing = _entity.Find(id);

            _expenseContext.Entry(existing).CurrentValues.SetValues(obj);
        }
    }
}
