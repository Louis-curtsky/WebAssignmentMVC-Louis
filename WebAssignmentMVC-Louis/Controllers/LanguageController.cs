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

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
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
            Language language = _languageService.FindById(id);

            if (language == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CreateLanguageViewModel editLanguage = new CreateLanguageViewModel()
            {
                LangName = language.LangName
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
            Language language = _languageService.FindById(id);

            if (language != null)
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
            Language language = _languageService.FindById(id);

            if (language != null)
            {
                if (_languageService.Remove(id))
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("System", "Fail to delete language!!!");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetLanguages()
        {
            return Json(_languageService.GetAll());
        }
    }
}
