using ExpenseApproval.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.DataAccess
{
    public class ExpenseContext : DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext>options) : base(options)
        {

        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<ExpenseRequest> ExpenseRequest { get; set; }

        public DbSet<Invoice> Invoice { get; set; }

        public DbSet<Approval> Approval { get; set; }
    }
}
