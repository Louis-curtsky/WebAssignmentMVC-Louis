using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person.Repo
{
    public interface ICountryRepo
    {
        Country Create(Country country);
        List<Country> GetAll();
        Country FindById(int id);

        string Update(Country country);
        bool Delete(Country country);

    }
}
