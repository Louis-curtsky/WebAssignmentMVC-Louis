using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Models.Person
{
    public interface IPeopleService
    {
        List<Person> All();
        Person Add(Person personViewModel);
        Person FindById(int id);

        bool Edit(int id, CreatePersonViewModel person);
        bool Remove(int id);
        PersonViewModel Search(string firstName, string lastName, int countryId, int cityId);
    }
}
