using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string LangName { get; set; }

        public List<PersonLanguage> personLanguage { get; set; }
    }
}
