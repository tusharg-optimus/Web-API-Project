using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.Utility.DTOs
{
   public class InvoiceDTO
    {
        public int Id { get; set; }
        public int InvoiceAmount { get; set; }
        public string InvoiceDescription { get; set; }
    }
}
