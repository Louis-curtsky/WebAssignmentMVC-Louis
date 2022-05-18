using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Phone { get; set; }

        public string Country { get; set; } // Link using Country ID
        public List<PersonLanguage> Language { get; set; }
        public string Cities { get; set; }
    }
}
