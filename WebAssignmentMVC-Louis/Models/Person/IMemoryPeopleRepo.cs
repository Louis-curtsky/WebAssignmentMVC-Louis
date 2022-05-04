using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person
{
    public class IMemoryPeopleRepo : IPeopleRepo
    {
        public bool Initialized = false;
        private static int idCounter;
        private static readonly List<Person> peopleStorage = new List<Person>();
        private static readonly List<string> cityStorage = new List<string>();


        public bool Initialize()
        {
//            List<Person> returnList = new List<Person>();
            if (peopleStorage.Count==0)
            {
                idCounter = 0;
                // Below Never put outside of if loop
                //                Person storePerson = new Person(++idCounter, "Louis", "Lim", "Växjö", 0765551111);
                peopleStorage.Add(new Person() { Id = ++idCounter, FirstName = "Louis", LastName = "Lim", City = "Växjö", Phone = "0765551111" });
                peopleStorage.Add(new Person() { Id = ++idCounter, FirstName = "Michael", LastName = "Kent", City = "Gothenburg", Phone = "0733338888" });
                peopleStorage.Add(new Person() { Id = ++idCounter, FirstName = "Åsa", LastName = "Jason", City = "Malmö", Phone = "0721231234" });
                peopleStorage.Add(new Person() { Id = ++idCounter, FirstName = "Andy", LastName = "Birch", City = "Gothenburg", Phone = "0744448888" });
                peopleStorage.Add(new Person() { Id = ++idCounter, FirstName = "Johnny", LastName = "Walker", City = "Trollhättan", Phone = "0751244674" });
                Initialized = true;

  //              returnList = peopleStorage;
            }
            return Initialized;
        }

        public List<Person> All()
        {
            return peopleStorage;
        }
        public Person Create(string firstName, string lastName, string city, string phone)
        {
            Person person = new Person(++idCounter, firstName, lastName, city, phone);
            peopleStorage.Add(
                person);
                return person;
        }

        public List<PersonViewModel> GetList()
        {
            List<PersonViewModel> personViewModels = new List<PersonViewModel>();
            foreach (Person person in peopleStorage)
            {
                PersonViewModel personViewModel = new PersonViewModel();
                personViewModel.FirstName = person.FirstName;
                personViewModel.LastName = person.LastName;
                personViewModel.City = person.City;   
                personViewModel.Phone = person.Phone;   
            }
            return personViewModels;
        }

        public List<Person> GetPersons(string firstName, string lastName, string city, string phone)
        {
            peopleStorage.Add(new Person() { 
                Id = ++idCounter, 
                FirstName = firstName, 
                LastName = lastName, 
                City = city, 
                Phone = phone });
            List<Person> returnList = peopleStorage;
            return returnList;
        }

        public List<string> Getcities()
        { 
            if (cityStorage.Count == 0)
            {
                cityStorage.Add("Stockholm");
                cityStorage.Add("Gothenburg");
                cityStorage.Add("Malmö");
                cityStorage.Add("Uppsala");
                cityStorage.Add("Växjö");
                cityStorage.Add("Västerås");
            }
            return cityStorage;
        }

        public List<Person> Search(string firstName, string lastName, string city)
        {
            if (firstName == null)
                firstName = "";
            else if (lastName == null)
                lastName = "";
            else if (city == null)
                city = "";

             List<Person> searchPerson = new List<Person>();
 //           Initialize();
            foreach (Person person in peopleStorage)
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
                else if (person.City == city)
                {
                    searchPerson.Add(person);
                }
                else
                {
                }
            }
            return searchPerson;
        }

        public List<Person> GetByID(int id)
        {
//            Initialize();
            List<Person> searchResult = peopleStorage.Where(person => person.Id == id).ToList();
            return searchResult;
        }


            public Person Update(Person person)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            foreach (Person person in peopleStorage)
            {
                if (person.Id == id)
                {
                    return(peopleStorage.Remove(person));
                }
            }
            return false;
        }

        public Person Read(int id)
        {
            foreach (Person person in peopleStorage)
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
