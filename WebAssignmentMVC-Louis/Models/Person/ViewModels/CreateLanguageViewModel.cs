using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person.ViewModels
{
    public class CreateLanguageViewModel
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        [Display(Name = "Language")]
        public string LangName { get; set; }
        public List<Person> PersonList { get; set; }

        public CreateLanguageViewModel() { }

        public CreateLanguageViewModel(Language language)
        {
            LangName = language.LangName;
        }
    }
}
