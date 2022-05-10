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

        public int Cid { get; set; } // Country ID

        public string Phone { get; set; }
    }
}
