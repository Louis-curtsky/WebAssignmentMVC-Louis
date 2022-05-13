using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person.Data;
using WebAssignmentMVC.Models.Person;
using WebAssignmentMVC.Models.Person.ViewModels;

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
            return _personDbContext.Persons.ToList();  
        }

        public Person Create(Person person)
        {
            _personDbContext.Add(person);
            _personDbContext.SaveChanges();
                return person;
        }

        public List<PersonViewModel> GetList()
        {
            List<PersonViewModel> personViewModels = new List<PersonViewModel>();
            foreach (Person person in _personDbContext.Persons)
            {
                PersonViewModel personViewModel = new PersonViewModel();
                personViewModel.FirstName = person.FirstName;
                personViewModel.LastName = person.LastName;
                personViewModel.Country = person.Country;   
                personViewModel.Phone = person.Phone;   
            }
            return personViewModels;
        }


        public List<Person> Search(string firstName, string lastName, int id)
        {
            if (firstName == null)
                firstName = "";
            else if (lastName == null)
                lastName = "";
            else if (id < 0)
                id = 99999; // To be replace 

            List<Person> searchPerson = new List<Person>();

            foreach (Person person in _personDbContext.Persons)
            {
                if (person.FirstName == firstName)
                {
                    searchPerson.Add(person);
                }
                else
                if (person.LastName==lastName)
                {
                    searchPerson.Add(person);
                }
                else
                {
                }
            }
            return searchPerson;
        }

        public Person FindByID(int id)
        {
            return _personDbContext.Persons.SingleOrDefault(person => person.Id == id);
  
        }


            public Person Update(Person person)
        {
            throw new NotImplementedException();
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
    }
}
