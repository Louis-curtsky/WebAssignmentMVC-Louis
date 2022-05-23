using Microsoft.AspNetCore.Http;
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
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly IPeopleService _PeopleService;

        public LanguageController(ILanguageService languageService, IPeopleService peopleService)
        {
            _languageService = languageService;
            _PeopleService = peopleService;
        }
        // GET: LanguageController
        public ActionResult Index()
        {
            return View(_languageService.GetAll());
        }

        // GET: LanguageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LanguageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LanguageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLanguageViewModel createLanguage)
        {
            if (ModelState.IsValid)
            {
                Language language = _languageService.Create(createLanguage);
                if (language != null)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("System", "Fail to create language!!!");
            }
            return View(createLanguage);
        }

        // GET: LanguageController/Edit/5
        public ActionResult Edit(int id)
        {
            Language lang = _languageService.FindById(id);

            if (lang == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CreateLanguageViewModel editLanguage = new CreateLanguageViewModel()
            {
                LangName = lang.LangName
            };

            ViewBag.id = id;

            return View(editLanguage);
        }

        // POST: LanguageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateLanguageViewModel language)
        {
            if (ModelState.IsValid)
            {
                if (_languageService.Edit(id, language) != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("System", "Fail to edit Language!!!");
            }
            ViewBag.id = id;
            return View(language);
        }


        // GET: LanguageController/Delete/5
        public ActionResult Delete(int id)
        {
            Language lang = _languageService.FindById(id);

            if (lang != null)
            {
                if (_languageService.Remove(id))
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("System", "Fail to delete Language!!!");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: LanguageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
                if (_languageService.Remove(id))
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("System", "Fail to delete language!!!");
                }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult AddPerson(int id)
        {
            List<PersonLanguage> lang = _PeopleService.GetLanguage(id);
            List<Person> allPerson = _PeopleService.All();
            if (lang == null)
            {
                return RedirectToAction(nameof(Index));
            }
            PersonLanguage showLang = new PersonLanguage();
            if (showLang != null)
            {
            showLang.LanguageId = id;
            ViewBag.LangName = _languageService.GetLanguageName(id);
            ViewBag.Id = id;
            }
            ViewBag.Persons = allPerson;

            return View();  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPerson(PersonLanguage langPerson, int id)
        {
            var fromPerson = HttpContext.Request.Form["PersonId"];
            langPerson.LanguageId = id;
            langPerson.Language = _languageService.FindById(id);
            List<Person> maxPerson = _PeopleService.All();
            List<Language> maxLang = _languageService.GetAll();
            List<Person> toAddPer = new List<Person>();
            int count = 0;
            foreach (Person person in maxPerson)
            {
                if (count <= fromPerson.Count - 1)
                {
                    toAddPer.Add(new Person { Id = int.Parse(fromPerson[count]) });
                    count++;
                }
            }
            if (langPerson != null)
            {
                _languageService.AddLang(langPerson, toAddPer);
                return RedirectToAction(nameof(Index));
             }
            return View();
        }
        public IActionResult GetLanguages()
        {
            return Json(_languageService.GetAll());
        }
    }
}
