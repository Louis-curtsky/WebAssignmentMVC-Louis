using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Models.Person
{
    public interface IPeopleService
    {
        List<Person> All();
        Person Add(CreatePersonViewModel personViewModel, List<PersonLanguage> personLang);
        Person FindById(int id);

        void Edit(int id, PersonViewModel person);
        bool Remove(int id);
        List<Person> Search(string firstName, string lastName, int countryId, int cityId);

        List<PersonLanguage> GetLanguage(int id);
    }
}
