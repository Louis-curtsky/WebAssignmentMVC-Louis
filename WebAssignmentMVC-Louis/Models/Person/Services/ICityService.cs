﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Controllers;

namespace WebAssignmentMVC.Models.Person.Services
{
    public interface ICityService
    {
        City Create(City createCity);
        bool Edit(City city);
        City FindById(int id);
        List<City> GetAll();

        bool Remove(City city);
    }
}