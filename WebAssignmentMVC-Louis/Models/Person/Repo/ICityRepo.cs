using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Controllers;

namespace WebAssignmentMVC.Models.Person.Repo
{
    public interface ICityRepo
    {
        City Create(City city);
        List<City> GetAll();
        City FindById(int id);

        bool Update(City city);
        bool Delete(City city);
    }
}
