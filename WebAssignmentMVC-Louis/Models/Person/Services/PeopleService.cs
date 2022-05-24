using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Models.Person
{
    public class PeopleService : IPeopleService
    {

        IPeopleRepo _peopleRepo;

        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;

        }

        public List<Person> All()
        {
            return _peopleRepo.All();
         }

        public void Edit(int id, PersonViewModel personViewModel, List<PersonLanguage> langId)
        {
            Person person = _peopleRepo.FindByID(id);
            if (person != null)
            {
            person.FirstName = personViewModel.FirstName;
            person.LastName = personViewModel.LastName;
            person.Phone = personViewModel.Phone;
            person.CountryId = personViewModel.CountryId;
            person.CtyId = personViewModel.CityId;
            person.languageSpoken = personViewModel.PersonLang;
                _peopleRepo.Update(person);
                _peopleRepo.UpdateLang(person.Id, langId);
            }
        }

        public Person FindById(int id)
        {
            Person returnFound = _peopleRepo.FindByID(id);
            return returnFound;

        }

        public bool Remove(int id)
        {
            Person person = _peopleRepo.Read(id);
            if (person == null)
                return false;
            else
            return _peopleRepo.Delete(person);
        }

        public Person Add(CreatePersonViewModel personViewModel, List<PersonLanguage> personLang)
        {
            Person person = new Person();
            person.CountryId = personViewModel.CountryId;
            person.CtyId = personViewModel.CityId;
            person.FirstName = personViewModel.FirstName;
            person.LastName = personViewModel.LastName;
            person.Phone = personViewModel.Phone;

            return _peopleRepo.Create(person, personLang);
        }

        public List<Person> Search(string firstName, string lastName, int countryId, int cityId)
        {
            List<Person> person = _peopleRepo.Search(firstName, lastName, countryId, cityId);
            return person;
        }

        public List<PersonLanguage> GetLanguage(int id)
        {
            return _peopleRepo.GetLanguage(id);
        }
    }
}
