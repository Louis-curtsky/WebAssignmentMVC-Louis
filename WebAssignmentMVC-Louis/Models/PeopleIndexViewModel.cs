using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person
{
    public class PeopleIndexViewModel
    {
        public List<Person> PersonList { get; set; }

        public PeopleIndexViewModel()
        {
            PersonList = new List<Person>();
        }
    }
}
