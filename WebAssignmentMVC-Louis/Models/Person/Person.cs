using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAssignmentMVC.Models.Person
{
    public class Person
    {
        public Person()
        { }
        [Key]
        public int Id { get; set; }

        public string FirstName{ get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }
        public Country Country { get; set; }

        public City City { get; set; }


    }
}
