using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Models.Person.Services
{
    public interface ICountryService
    {
        Country Create(CreateCountryViewModel country);
        List<Country> GetAll();
        Country FindById(int id);

        List<Country> Search(string search);
        string Edit(int id, CreateCountryViewModel editountry);
        bool Remove(int id);
    }
}
