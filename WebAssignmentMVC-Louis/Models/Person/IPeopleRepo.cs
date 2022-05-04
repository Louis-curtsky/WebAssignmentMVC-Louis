using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person
{
    public interface IPeopleRepo
    {
        bool Initialize();
        Person Read(int id);

        List<Person> All();
        List<PersonViewModel> GetList();
        List<Person> GetPersons(string firstName, string lastName, string city, string phone);
        List<string> Getcities();
        List<Person> GetByID(int id);

        List<Person> Search(string firstName, string lastName, string city);
        Person Update(Person person);
        bool Delete(Person person);
    }
}
