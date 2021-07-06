using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.DataAccess.Entity
{
    public class ExpenseRequest
    {
        [Key]
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public string ExpenseDescription { get; set; }
        public int ExpenseAmount { get; set; }
        public DateTime Date { get; set; }


        public int InvoiceId { get; set; }

        public int UserId { get; set; }


        public int ApprovalId { get; set; }


        //Navigation Property for one to many relationship
        [ForeignKey("UserId")]
        public User User { get; set; }

        //Reference Property to invoice details as one to one relationship

        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }

        //Reference Property to Approval details as one to one relationship
        [ForeignKey("ApprovalId")]
        public virtual Approval Approval { get; set; }
    }
}
