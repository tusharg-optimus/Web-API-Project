using ExpenseApproval.DataAccess.Entity;
using ExpenseApproval.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.DataAccess.Repository.Implementations
{
    public class ApprovalRepository :  GenericRepository<Approval>, IApprovalRepository
    {
        public ApprovalRepository(ExpenseContext expenseContext) :base(expenseContext)
        {

        }
    }
}
