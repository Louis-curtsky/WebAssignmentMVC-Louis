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

            Person resultList = _peopleRepo.Create(personViewModel);
 
            return resultList;
        }

    }
}
