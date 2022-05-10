using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Your Contact No")]

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]

        public List<Country> Countries { get; set; }

    }
}
