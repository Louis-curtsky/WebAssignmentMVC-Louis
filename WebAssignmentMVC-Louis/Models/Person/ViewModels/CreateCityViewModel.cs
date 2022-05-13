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
        public Country CLink { get; set; }

        public CreateCityViewModel() { }

        public CreateCityViewModel(City city)
        {
        }
    }
}
