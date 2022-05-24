using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Models.Person
{
    public interface IPeopleRepo
    {
 //       bool Initialize();
        Person Read(int id);

        List<Person> All();
        Person Create(Person person, List<PersonLanguage> personLang);
        
        Person FindByID(int id);

        List<Person> Search(string firstName, string lastName, int countryId, int cityId);
        void Update(Person person, List<PersonLanguage> langId);
        bool Delete(Person person);

        List<PersonLanguage> GetLanguage(int id);
    }
}
