using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person
{
    public class City
    {
        public City()
        { }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }

        public List<Person> Persons {get; set;}
    }
}
