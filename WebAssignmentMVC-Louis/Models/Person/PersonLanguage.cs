using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person
{
    public class PersonLanguage
    {
        [Key]
        public int ID { get; set; } 
        public  int PersonId { get; set; }
        public Person Person { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }


    }
}
