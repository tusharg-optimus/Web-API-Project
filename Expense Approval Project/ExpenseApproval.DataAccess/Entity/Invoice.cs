using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.DataAccess.Entity
{
    public class Invoice
    {
        [Key]

        public int Id { get; set; }
        public int InvoiceAmount { get; set; }
        public string InvoiceDescription { get; set; }

        //Reference property to expenseRequest
        public virtual ExpenseRequest ExpenseRequest { get; set; }
    }
}
