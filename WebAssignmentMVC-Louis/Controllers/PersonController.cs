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
        Person Addperson = new Person();
        List<Person> localStore = new List<Person>();
        private readonly IPeopleService _peopleService;
        IPeopleRepo _memoryPeople;

        public PersonController()
        {
            _memoryPeople = new IMemoryPeopleRepo();
            _peopleService = new PeopleService();
            
        }
        

        [HttpGet]
        public IActionResult Index(string firstName, string LastName, string city, string phone)
        {
            /*            if (Initialized)
                        {
                            return View(_memoryPeople.GetPersons(firstName, LastName, city, phone));
                        }
                        else
                        {
                            Initialized = _memoryPeople.Initialize();
                            return View(_memoryPeople.All());
                        }
            */
            Initialized = _memoryPeople.Initialize();

            return View(_memoryPeople.All());
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
            CreatePersonViewModel createPerson = new CreatePersonViewModel();
            createPerson.CityList = _memoryPeople.Getcities();
            return View(createPerson);
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createPeople)
        {
            Person addPerson = new Person();
            if (ModelState.IsValid)
            {
                addPerson =
                    _peopleService.Add(createPeople.FirstName, createPeople.LastName, createPeople.City, createPeople.Phone);
                //                _memoryPeople.Initialize();
                return RedirectToAction("Index", new
                {
//                    id = addPerson.Id,
                    firstName = addPerson.FirstName,
                    lastName = addPerson.LastName,
                    city = addPerson.City,
                    phone = addPerson.Phone
                });
            }

            createPeople.CityList = _memoryPeople.Getcities();

            return View(createPeople);
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
