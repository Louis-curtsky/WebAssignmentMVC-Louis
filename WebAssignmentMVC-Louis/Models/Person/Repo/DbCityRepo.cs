﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Controllers;
using WebAssignmentMVC.Models.Person.Data;

namespace WebAssignmentMVC.Models.Person.Repo
{
    public class DbCityRepo : ICityRepo
    {
        private readonly PersonDBContext _personDBContext;

        public DbCityRepo(PersonDBContext personDBContext)
        {
            _personDBContext = personDBContext;
        }
        public City Create(City city)
        {
            _personDBContext.Cities.Add(city);
            _personDBContext.SaveChanges();
            return city;
        }

        public bool Delete(City city)
        {
            _personDBContext.Cities.Remove(city);

            if (_personDBContext.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public City FindById(int id)
        {
            return _personDBContext.Cities.Find(id);
        }

        public List<City> GetAll()
        {
            List<City> cityList = _personDBContext.Cities.ToList();
            return cityList;
        }

        public bool Update(City city)
        {
            _personDBContext.Cities.Update(city);
            if (_personDBContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
