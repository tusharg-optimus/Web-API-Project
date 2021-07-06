using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.DataAccess.Entity
{
    public class Approval
    {
        [Key]

        public int Id { get; set; }

        public string ApprovalStatus { get; set; }

        public int ApprovalAmount { get; set; }

        public int TotalBudget { get; set; }

        public int Balance { get; set; }

        // public int RoleId { get; set; }

        //Navigation Property to ExpenseRequest for one to one Relationship
        public virtual ExpenseRequest ExpenseRequest { get; set; }
    }
}
