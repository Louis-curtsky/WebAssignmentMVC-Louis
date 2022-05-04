using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person
{
    public interface IPeopleService
    {
        List<Person> Add(Person personViewModel);
        List<Person> All();
        Person FindById(int id);

        bool Edit(int id, CreatePersonViewModel person);
        bool Remove(int id);
        
    }
}
