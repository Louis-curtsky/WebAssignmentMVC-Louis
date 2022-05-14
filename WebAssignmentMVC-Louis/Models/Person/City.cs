using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person
{
    public class City
    {
        
        public City()
        { }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("CountryFiD")]
        public int CountryFiD { get; set; }
        public Country Countries { get; set; }
    }
}
