﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.Utility.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }
    }
}
