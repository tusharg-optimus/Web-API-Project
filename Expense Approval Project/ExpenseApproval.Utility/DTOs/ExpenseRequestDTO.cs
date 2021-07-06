using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.Utility.DTOs
{
   public class ExpenseRequestDTO
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public string ExpenseDescription { get; set; }
        public int ExpenseAmount { get; set; }
        public DateTime Date { get; set; }


        public int InvoiceId { get; set; }

        public int UserId { get; set; }


        public int ApprovalId { get; set; }
    }
}
