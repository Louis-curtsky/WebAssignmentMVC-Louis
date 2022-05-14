using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person.ViewModels
{
    public class CreateCityViewModel
    {
        [Required]
        [Display(Name = "City")]
        public String CName { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CnId { get; set; }
        public Country Cnty { get; set; }
        public List<Country> CountryList { get; set;}

        public CreateCityViewModel()
        {
        }
    }
}
