using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person;
using WebAssignmentMVC.Models.Person.Services;
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IPeopleService _peopleService;
        private readonly IPeopleRepo _memoryPeople;

        public PersonController(IPeopleService peopleService, ICountryService countryService, IPeopleRepo memoryPeople)
        {
//            _memoryPeople = new IMemoryPeopleRepo();
            _peopleService = peopleService;
            _countryService = countryService;
            _memoryPeople = memoryPeople;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View(_peopleService.All());
        }

        [HttpGet]
        public IActionResult Detail()
        {
            return View();
        }
/*
        [HttpGet]
        public IActionResult GetCities()
        {
            return Json(_memoryPeople.Getcities());
        }

*/        public IActionResult GetPersonList()
        {
            return PartialView("_PersonList", _memoryPeople.All());
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreatePersonViewModel createPerson = new CreatePersonViewModel();
            createPerson.Countries = _countryService.GetAll();
            return View(createPerson);
        }

        [HttpPost]
        public IActionResult Create(Person personViewModel)
        {
            if (ModelState.IsValid)
            {
                Person returnPerson = _peopleService.Add(personViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        [HttpGet]
        public IActionResult FindPerson(List<Person> searchResult)
        {
            List<Person> searchPerson = _peopleService.All();
            if (searchResult.Count!=0)
            return PartialView("_PersonDetailView", searchResult);
            else
            return View(searchPerson);
        }

        [HttpPost]

        public IActionResult FindPerson(int id)
        {
            Person searchResult = _peopleService.FindById(id);
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
            Person searchResult = _memoryPeople.FindByID(id);
            return PartialView ("_PersonDetailView",searchResult);
        }

        [HttpGet]
        public IActionResult Searching(List<Person> peopleSearch)
        {
            List<Person> searchPerson = new List<Person>();
            try
            {
                searchPerson = _memoryPeople.All();
            }
            catch
            {
                if (peopleSearch.Count == 0)
                {
                    ModelState.AddModelError("System", "Person List has no record!!!");
                }
                return View(searchPerson);
            }
               return PartialView("_SearchResult",peopleSearch);
        }

        [HttpPost]

        public IActionResult Searching(string firstName, string lastName, int cid)
        {
//            firstName = "Louis";
            List<Person> peopleSearch = new List<Person>();
            peopleSearch = _memoryPeople.Search(firstName, lastName, cid);
            return View (peopleSearch);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            List<Person> peopleList = new List<Person>();
            if (_peopleService.Remove(id))
            {
                ViewBag.msg = "Person was removed.";
            }
            else
            {
                ViewBag.msg = "Unable to remove person with id: " + id;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
