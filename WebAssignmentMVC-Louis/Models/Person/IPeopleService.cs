using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person
{
    public interface IPeopleService
    {
        Person Add(string firstName, string lastName, string city, string phone);
        List<Person> All();
        Person FindById(int id);

        bool Edit(int id, CreatePersonViewModel person);
        bool Remove(int id);
        
    }
}
