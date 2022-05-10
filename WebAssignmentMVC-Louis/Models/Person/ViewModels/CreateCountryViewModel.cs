using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person.ViewModels
{
    public class CreateCountryViewModel
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        [Display(Name = "Country")]
        public string CountryName { get; set; }
        public List<Person> PersonList { get; set; }

        public CreateCountryViewModel() { }

        public CreateCountryViewModel(Country country)
        {
            CountryName = country.Cname;
        }
    }
}
