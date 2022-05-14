using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int CtyId { get; set; }

        public List<City> City { get; set; }

        public int CountryId { get; set; }
        public List<Country> Country { get; set; }
    }
}
