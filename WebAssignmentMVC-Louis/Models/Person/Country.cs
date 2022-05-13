using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person
{
    public class Country
    {
        public Country()
        { }
        [Key]
        public int Id { get; set; }
        public string Cname { get; set; }

        public List<City> Cities { get; set; }


    }
}
