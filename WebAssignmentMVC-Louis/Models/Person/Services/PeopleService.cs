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

        public bool Edit(int id, CreatePersonViewModel person)
        {
            throw new NotImplementedException();
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

        public Person Add(Person personViewModel)
        {

            Person personToAdd = new Person();
            personToAdd.CountryId = personViewModel.CountryId;
            personToAdd.CtyId = personViewModel.CtyId;
            personToAdd.FirstName = personViewModel.FirstName;
            personToAdd.LastName = personViewModel.LastName;
            personToAdd.Phone = personViewModel.Phone;
            personToAdd.languageSpoken = personViewModel.languageSpoken;

            _peopleRepo.Create(personToAdd);
 
            return personToAdd;
        }

        public PersonViewModel Search(string firstName, string lastName, int countryId, int cityId)
        {
            List<Person> person = _peopleRepo.Search(firstName, lastName, countryId, cityId);
            PersonViewModel searchPerson = new PersonViewModel();
            foreach (Person personItem in person)
            {
                searchPerson.Id = personItem.Id;
                searchPerson.FirstName = personItem.FirstName;
                searchPerson.LastName = personItem.LastName;
                searchPerson.Phone = personItem.Phone;
                searchPerson.CountryId = personItem.Country.Id;
                searchPerson.Country = personItem.Country.Cname;
                searchPerson.CityId = personItem.CtyId;
                searchPerson.Language = personItem.languageSpoken;
            }
            return searchPerson;
        }
    }
}
