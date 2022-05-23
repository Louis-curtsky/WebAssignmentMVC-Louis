using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person;
using WebAssignmentMVC.Models.Person.Repo;
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
        private readonly ILanguageRepo _languageService;

        public PersonController(ILanguageRepo languageRepo, IPeopleService peopleService, ICountryService countryService, IPeopleRepo memoryPeople, ICityService cityService)
        {
//            _memoryPeople = new IMemoryPeopleRepo();
            _peopleService = peopleService;
            _countryService = countryService;
            _memoryPeople = memoryPeople;
            _cityService = cityService;
            _languageService = languageRepo;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            List<Person> listPerson = _peopleService.All();
            string[] forLang= new string[listPerson.Count];
            List<PersonLanguage> chkLang = new List<PersonLanguage>();
            for(int i=1; i<listPerson.Count-1; i++)
            {
                
                listPerson[i].Country = _countryService.FindById(listPerson[i].CountryId);
                chkLang = _peopleService.GetLanguage(listPerson[i].Id);
                for (int j=0; j<chkLang.Count; j++)
                {
                    listPerson[i].languageSpoken[j].LanguageId = chkLang[j].LanguageId;
                    forLang[i] = "-";
                    forLang[i] = _languageService.GetLangName(chkLang[j].LanguageId);
                    listPerson[i].languageSpoken[j].Language.LangName = forLang[i];
                    listPerson[i].Country.Cname= _countryService.FindById(listPerson[i].CountryId).Cname;
                };
            }
            ViewBag.Language = chkLang;
            
            return View(listPerson);
        }

        [HttpGet]
        public IActionResult Detail()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            CreatePersonViewModel createPerson = new CreatePersonViewModel();
            List<Language> convLang = _languageService.GetAll();
            List<Country> convCountry = _countryService.GetAll();
            List<City> convCities = _cityService.GetAll();

            ViewBag.Countries = convCountry;
            ViewBag.Cities = convCities;        
            ViewBag.Language = convLang;
            return View (createPerson);
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel personViewModel, int countryId, int cityId)
        {
            var fromLang = HttpContext.Request.Form["Language"];
            var fromCountry = HttpContext.Request.Form["Countries"];
            var fromCity = HttpContext.Request.Form["Cities"];
            ViewBag.Language = _languageService.GetAll();
            List<PersonLanguage> langId = new List<PersonLanguage>();
            List<Language> maxLang = _languageService.GetAll();
            int count = 0;
            foreach (Language lang in maxLang)
            {
                if (count <= fromLang.Count-1)
                {
                    langId.Add(new PersonLanguage { 
                    LanguageId = int.Parse(fromLang[count]),
                    Language = lang
                    });
                    count++;
                }
             }
            if (ModelState.IsValid)
            {
                if (personViewModel != null)
                {
                    personViewModel.CountryId = countryId;
                    personViewModel.CityId = cityId;

                    Person returnPerson = _peopleService.Add(personViewModel, langId);

                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }



        public IActionResult FindPerson()
        {
            List<Person> allPerson = _peopleService.All();
            Person person = new Person();
            for (int i=0; i<allPerson.Count; i++)
            {
                person.Id = allPerson[i].Id;
                person.FirstName = allPerson[i].FirstName;
                person.languageSpoken = allPerson[i].languageSpoken;
                person.LastName = allPerson[i].LastName;
                person.Phone = allPerson[i].Phone;
                person.CountryId = allPerson[i].CountryId;
                person.CtyId = allPerson[i].CtyId;
                ViewBag.Person = allPerson;
            }
            return View(person);
        }

        [HttpPost]

        public IActionResult FindPerson(int id)
        {
            Person searchResult = _peopleService.FindById(id);
            ViewBag.City = _cityService.FindById(searchResult.CtyId);
            ViewBag.Country = _countryService.FindById(searchResult.CountryId);
            ViewBag.Language = _peopleService.GetLanguage(id);
            return PartialView("_View", searchResult);
        }

        public ActionResult LanguageDetails(int id)
        {
            Language lang = _languageService.FindById(id);
            return PartialView("_ShowLanguage", lang);
            // to do : Return the partial view for the markup you want (for the id)
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
        public IActionResult Details(int id)
        {
            Person searchResult = _peopleService.FindById(id);

            PersonViewModel showResult = new PersonViewModel()
            {
                FirstName = searchResult.FirstName,
                LastName = searchResult.LastName,
                Phone = searchResult.Phone,
                CountryId = searchResult.CountryId,
                CityId = searchResult.CtyId,
            };
            ViewBag.Language = _peopleService.GetLanguage(id);
            ViewBag.City = _cityService.FindById(searchResult.CtyId);
            ViewBag.Country = _countryService.FindById(searchResult.CountryId);
            return PartialView ("_PersonDetailView",showResult);
        }

        [HttpGet]
        public IActionResult Searching()
        {

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
                return PartialView("_searchResult",listPerson);
            }
               return View();
        }

        [HttpPost]

        public IActionResult Searching(string firstName, string lastName, int countryId, int cityId )
        {
            List<Person> peopleSearch = _peopleService.Search(firstName, lastName, cityId, countryId);          
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

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }
            List<Language> convLang = _languageService.GetAll();
            List<Country> convCountry = _countryService.GetAll();
            List<City> convCities = _cityService.GetAll();

            ViewBag.Countries = convCountry;
            ViewBag.Cities = convCities;
            ViewBag.Language = convLang;
            PersonViewModel editPerson = new PersonViewModel()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Phone = person.FirstName,
                CountryId = person.CountryId,
                CityId = person.CtyId,
                PersonLang = _peopleService.GetLanguage(person.Id)
            };

            ViewBag.id = id;

            return View(editPerson);
        }

        // POST: PersonViewModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Edit(id, person);
                    return RedirectToAction(nameof(Index));
            }
            else
                ModelState.AddModelError("System", "Fail to edit City!!!");

            ViewBag.id = id;
            return View(person);
        }
        public IActionResult GetCountries()
        {
            return Json(_countryService.GetAll());
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            return Json(_cityService.GetAll());
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
