using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.DataAccess.Entity
{
    public class User
    {
        [Key]

        public int Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        //Collection Navigation Property - Defining one to many relationship with ExpenseRequest
        public ICollection<ExpenseRequest> ExpenseRequests { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
