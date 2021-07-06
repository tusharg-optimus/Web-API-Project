using ExpenseApproval.DataAccess.Entity;
using ExpenseApproval.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.DataAccess.Repository.Implementations
{
   public class InvoiceRepository : GenericRepository<Invoice> , IInvoiceRepository
    {
        public InvoiceRepository(ExpenseContext expenseContext) : base(expenseContext)
        {

        }
    }
}
