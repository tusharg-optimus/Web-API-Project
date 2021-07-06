using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.Utility.DTOs
{
    public class ApprovalDTO
    {
        public int Id { get; set; }

        public string ApprovalStatus { get; set; }

        public int ApprovalAmount { get; set; }

        public int TotalBudget { get; set; }

        public int Balance { get; set; }
    }
}
