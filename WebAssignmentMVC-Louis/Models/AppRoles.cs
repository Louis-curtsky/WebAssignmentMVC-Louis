using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models
{
    public class AppRoles : IdentityRole
    {
        public string UserId { get; set; } 
        public string RoleId { get; set; }

    }
}
