using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person
{
    public class PeopleService : IPeopleService
    {
 
        IPeopleRepo _peopleRepo;
        
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
            
        }

        public PeopleService() { }
        public List<Person> All()
        {
            IMemoryPeopleRepo storage = new IMemoryPeopleRepo(); 
            return storage.All();
         }

        public bool Edit(int id, CreatePersonViewModel person)
        {
            throw new NotImplementedException();
        }

        public Person FindById(int id)
        {
            List<Person> getByID = _peopleRepo.GetByID(id);
            Person returnFound = getByID[0];
            return returnFound;

        }

        public bool Remove(int id)
        {
            Person person = _peopleRepo.Read(id);
            if (person == null)
            {
                return false;
            }
            else
            {
                return _peopleRepo.Delete(person);
            }
        }

        public List<Person> Add(CreatePersonViewModel personViewModel)
        {
            List<Person> resultList = _peopleRepo.GetPersons(personViewModel.FirstName, personViewModel.LastName, personViewModel.City, personViewModel.Phone);
            return resultList;
        }
    }
}
