using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Identity.ViewModels
{
    public class CreateRolesViewModel
    {
        [Required]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}
