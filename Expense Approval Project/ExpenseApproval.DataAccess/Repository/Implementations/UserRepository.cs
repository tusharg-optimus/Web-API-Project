using ExpenseApproval.DataAccess.Entity;
using ExpenseApproval.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.DataAccess.Repository.Implementations
{
   public class UserRepository : GenericRepository<User> , IUserRepository
    {
        public UserRepository(ExpenseContext expenseContext) : base(expenseContext)
        {

        }
    }
}
