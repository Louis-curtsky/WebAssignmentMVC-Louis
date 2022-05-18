using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Models.Person
{
    public interface IPeopleRepo
    {
 //       bool Initialize();
        Person Read(int id);

        List<Person> All();
        Person Create(Person person);
        
        Person FindByID(int id);

        List<Person> Search(string firstName, string lastName, int countryId, int cityId);
        Person Update(Person person);
        bool Delete(Person person);
    }
}
