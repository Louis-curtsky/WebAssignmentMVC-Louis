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
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly IPeopleService _peopleService;
        private readonly IPeopleRepo _memoryPeople;

        public PersonController(IPeopleService peopleService, ICountryService countryService, IPeopleRepo memoryPeople, ICityService cityService)
        {
//            _memoryPeople = new IMemoryPeopleRepo();
            _peopleService = peopleService;
            _countryService = countryService;
            _memoryPeople = memoryPeople;
            _cityService = cityService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            List<Person> listPerson = _peopleService.All();
            return View(listPerson);
        }

        [HttpGet]
        public IActionResult Detail()
        {
            return View();
        }


 //       [HttpGet]
        public IActionResult Create()
        {
            CreatePersonViewModel createPerson = new CreatePersonViewModel();
            createPerson.Countries = _countryService.GetAll();
            createPerson.Cities = _cityService.GetAll();
            return View (createPerson);
        }

        [HttpPost]
        public IActionResult Create(Person personViewModel, int countryId, int cityId)
        {
            if (ModelState.IsValid)
            {
                if (personViewModel != null)
                {
                    personViewModel.CountryId = countryId;
                    personViewModel.CtyId = cityId;
                    Person returnPerson = _peopleService.Add(personViewModel);

                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        [HttpGet]
        public IActionResult FindPerson()
        {
                return View();

        }

        [HttpPost]

        public IActionResult FindPerson(int id)
        {
            Person searchResult = _peopleService.FindById(id);
            PersonViewModel showResult = new PersonViewModel()
            {
                Id        = searchResult.Id,
                FirstName = searchResult.FirstName,
                LastName = searchResult.LastName,
                Phone = searchResult.Phone,
                Country = _countryService.FindById(searchResult.CountryId),
                Cities = _cityService.FindById(searchResult.CtyId),
                Language = searchResult.languageSpoken
            };
            return PartialView("_PersonDetailView", showResult);
        }

        [HttpGet]
        public IActionResult Details(List<Person> searchResult)
        {
            List<Person> person = _peopleService.All();

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
            Person searchResult = _peopleService.FindById(id);

            PersonViewModel showResult = new PersonViewModel()
            {
                FirstName = searchResult.FirstName,
                LastName = searchResult.LastName,
                Phone = searchResult.Phone,
                Country = _countryService.FindById(searchResult.CountryId),
                Cities = _cityService.FindById(searchResult.CtyId),
                Language = searchResult.languageSpoken
            };
            return PartialView ("_PersonDetailView",showResult);
        }

        [HttpGet]
        public IActionResult Searching()
        {
            PersonViewModel searchPerson = new PersonViewModel();

            List<Person> listPerson = new List<Person>();
            try
            {
                listPerson = _peopleService.All();
            }
            catch
            {
                if (listPerson.Count == 0)
                {
                    ModelState.AddModelError("System", "Person List has no record!!!");
                }
                foreach (Person person in listPerson)
                {
                    searchPerson.Id = person.Id;
                    searchPerson.FirstName = person.FirstName;
                    searchPerson.LastName = person.LastName;
                    searchPerson.Phone = person.Phone;
                    searchPerson.CountryId = person.Country.Id;
                    searchPerson.Country = person.Country.Cname;
                    searchPerson.CityId = person.CtyId;
                    searchPerson.Language = person.languageSpoken;
                 };
                return PartialView("_searchResult",searchPerson);
            }
               return View();
        }

        [HttpPost]

        public IActionResult Searching(string firstName, string lastName, int countryId, int cityId )
        {
            PersonViewModel peopleSearch = _peopleService.Search(firstName, lastName, cityId, countryId);
            List<PersonViewModel> searchResult = new List<PersonViewModel>();
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

        //-------------Ajax
        public IActionResult AjaxPersonList()
        {
            List<Person> persons = _peopleService.All();

            if (persons != null)
            {
                return PartialView("_PersonList", persons);
            }

            return NotFound();
        }
    }
}
