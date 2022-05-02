using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person
{
    public class PeopleService : IPeopleService
    {
        static List<Person> PeopleSearch = new List<Person>();
        static List<Person> peopleStorage = new List<Person>();

        IPeopleRepo _peopleRepo;

        IMemoryPeopleRepo _PeopleRepo;
        
        public PeopleService()
        {
            if (_PeopleRepo == null) _PeopleRepo = new IMemoryPeopleRepo();
            
        }

         PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }


        public List<Person> All()
        {
            IMemoryPeopleRepo storage = new IMemoryPeopleRepo();
            return storage.peopleStorage;
         }

        public Person Add(string firstName, string lastName, string city, string phone)
        {
//            IMemoryPeopleRepo addPerson = new IMemoryPeopleRepo();
            
            return _PeopleRepo.Create(firstName, lastName, city, phone);
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
            return _peopleRepo.Delete(id);
        }

   
    }
}
