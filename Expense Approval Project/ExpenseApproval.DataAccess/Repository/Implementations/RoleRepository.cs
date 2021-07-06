using ExpenseApproval.DataAccess.Entity;
using ExpenseApproval.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.DataAccess.Repository.Implementations
{
    public class RoleRepository : GenericRepository<Role> , IRoleRepository
    {
        public RoleRepository(ExpenseContext expenseContext) : base(expenseContext)
        {

        }
    }
}
