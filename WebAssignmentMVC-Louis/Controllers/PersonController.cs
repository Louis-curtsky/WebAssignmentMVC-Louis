using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person;

namespace WebAssignmentMVC.Controllers
{
    public class PersonController : Controller
    {
        static bool Initialized;
        private readonly IPeopleService _peopleService;
        IPeopleRepo _memoryPeople;

        public PersonController()
        {
            _memoryPeople = new IMemoryPeopleRepo();
            _peopleService = new PeopleService();
            
        }
        

        [HttpGet]
        public IActionResult Index()
        {
                        if (Initialized)
                        {
                            return View(_memoryPeople.All());
                        }
                        else
                        {
                            Initialized = _memoryPeople.Initialize();
                            return View(_memoryPeople.All());
                        }
        }

        [HttpGet]
        public IActionResult Detail()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            return Json(_memoryPeople.Getcities());
        }

        public IActionResult GetPersonList()
        {
            return PartialView("_PersonList", _memoryPeople.All());
        }

        [HttpGet]
        public IActionResult Create()
        {
            Person inPerson = new Person();
            CreatePersonViewModel createPerson = new CreatePersonViewModel();
//            createPerson.CityList = _memoryPeople.Getcities();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel personViewModel)
        {
            List<Person> returnPerson = new List<Person>();
            if (ModelState.IsValid)
            {
                returnPerson = _peopleService.Add(personViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        [HttpGet]
        public IActionResult FindPerson(List<Person> searchResult)
        {
            List<Person> searchPerson = _memoryPeople.All();
            if (searchResult.Count!=0)
            return PartialView("_PersonDetailView", searchResult);
            else
            return View(searchPerson);
        }

        [HttpPost]

        public IActionResult FindPerson(int id)
        {
            List<Person>searchResult = _memoryPeople.GetByID(id);
            return View(searchResult);
        }

        [HttpGet]
        public IActionResult Details(List<Person> searchResult)
        {
            List<Person> person = _memoryPeople.All();

            if (searchResult.Count == 0)
            {
                return View(person);
            }
            else
                return View(searchResult);
        }

        [HttpPost]
        public IActionResult Detail(int id)
        {
            List<Person> searchResult = _memoryPeople.GetByID(id);
            return PartialView ("_PersonDetailView",searchResult);
        }

        [HttpGet]
        public IActionResult Searching(List<Person> peopleSearch)
        {
            List<Person> searchPerson = _memoryPeople.All();
            if (peopleSearch.Count == 0)
                return View(searchPerson);
            else
               return PartialView("_SearchResult",peopleSearch);
        }

        [HttpPost]

        public IActionResult Searching(string firstName, string lastName, string city)
        {
//            firstName = "Louis";
            List<Person> peopleSearch = new List<Person>();
            peopleSearch = _memoryPeople.Search(firstName, lastName, city);
            return View (peopleSearch);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            List<Person> searchPerson = _memoryPeople.GetByID(id);

            if (searchPerson != null)
            {
                _memoryPeople.Delete(id);
                return RedirectToAction(nameof(Index), new { 
                    id = searchPerson[0].Id,
                    firstName = searchPerson[0].FirstName, 
                    lastName = searchPerson[0].LastName, 
                    city = searchPerson[0].City, 
                    phone = searchPerson[0].Phone 
                });   
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
