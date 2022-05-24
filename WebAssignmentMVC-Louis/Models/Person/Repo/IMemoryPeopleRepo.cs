using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person.Data;
using WebAssignmentMVC.Models.Person;
using WebAssignmentMVC.Models.Person.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WebAssignmentMVC.Models.Person
{
    public class IMemoryPeopleRepo : IPeopleRepo
    {
        private readonly PersonDBContext _personDbContext;
 
        public IMemoryPeopleRepo(PersonDBContext personDbContext)
        {
            _personDbContext = personDbContext;
        }

        public List<Person> All()
        {
            return _personDbContext.Persons
                .ToList();  
        }

        public Person Create(Person person, List<PersonLanguage> personLang)
        {
            _personDbContext.Add(person);
            _personDbContext.SaveChanges();
            PersonLanguage addPLang = new PersonLanguage();
            
            foreach (PersonLanguage lang in personLang)
            {
                addPLang.PersonId = person.Id;
                addPLang.LanguageId = lang.LanguageId;
                addPLang.Language = lang.Language;
                addPLang.Person = lang.Person;
            }
            _personDbContext.Add(addPLang);
            _personDbContext.SaveChanges();
            return person;
        }


        public List<Person> Search(string firstName, string lastName, int countryId, int cityId)
        {
            if (firstName == null)
                firstName = "";
            else if (lastName == null)
                lastName = "";
            else if (countryId < 0)
                countryId = 99999; // To be replace 
            else if (cityId < 0)
                cityId = 99999;

            List<Person> searchPerson = new List<Person>();
            searchPerson = _personDbContext.Persons
                .Include(person => person.Country)
                .Include(person => person.languageSpoken)
                .Where(person=>person.FirstName == firstName
                || person.LastName == lastName
                || person.CtyId == cityId
                || person.CountryId == countryId
                )
                .ToList();
            return searchPerson;
        }

        public Person FindByID(int id)
        {
            return _personDbContext.Persons
                .Include(person=>person.Country)
                .Include(person=>person.languageSpoken)
                .SingleOrDefault(person => person.Id == id);
        }


        public void Update(Person person, List<PersonLanguage> langId)
        {
            _personDbContext.Update(person);
            _personDbContext.SaveChanges();
            PersonLanguage addPLang = new PersonLanguage();
            foreach (PersonLanguage item in langId)
            {
                addPLang.PersonId = item.PersonId;
                addPLang.LanguageId = item.LanguageId;
                addPLang.Language = item.Language;

            }
            _personDbContext.Update(addPLang);
            _personDbContext.SaveChanges();
        }

        public bool Delete(Person person)
        {
            _personDbContext.Remove(person);
            int removed = _personDbContext.SaveChanges();
            if (removed == 2)
                return true;
            else
                return false;
        }

        public Person Read(int id)
        {
            foreach (Person person in _personDbContext.Persons)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }
            return null;
        }

        public List<PersonLanguage> GetLanguage(int id)
        {
            List<PersonLanguage> spokeLang = new List<PersonLanguage>();
            foreach (PersonLanguage langSpoke in _personDbContext.PersonLanguage)
            {
                if (langSpoke.PersonId == id)
                {
                    spokeLang.Add(langSpoke);
                }
            }
            return spokeLang;
        }
    }
}
