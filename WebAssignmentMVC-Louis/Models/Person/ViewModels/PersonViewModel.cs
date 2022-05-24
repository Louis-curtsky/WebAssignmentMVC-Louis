using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

    
        [Display(Name = "Country")]
        public int CountryId { get; set; }

    
        [Display(Name = "City")]
        public int CityId { get; set; }
        public List<PersonLanguage> PersonLang { get; set; }

    }
}
