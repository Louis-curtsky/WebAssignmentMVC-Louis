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

        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<PersonLanguage> languageSpoken { get; set; }
    }
}
