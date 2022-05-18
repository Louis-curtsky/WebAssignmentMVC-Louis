using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person.Repo;
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Models.Person.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepo _languageRepo;
        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }
        public Language Create(CreateLanguageViewModel language)
        {
            if (string.IsNullOrWhiteSpace(language.LangName))
            {
                return null;
            }
            Language newLanguage = new Language()
            {
                LangName = language.LangName
            };
            return _languageRepo.Create(newLanguage);
        }
        public Language Edit(int id, CreateLanguageViewModel editlanguage)
        {
            Language editedLanguage = new Language() { Id = id, LangName = editlanguage.LangName};
            return _languageRepo.Update(editedLanguage);
        }

        public Language FindById(int id)
        {
            Language languageFound = _languageRepo.FindById(id);
            return languageFound;
        }

        public List<Language> GetAll()
        {
            return _languageRepo.GetAll();
        }

        public bool Remove(int id)
        {
            Language language = _languageRepo.FindById(id);
            if (language != null)
                return _languageRepo.Delete(language);
            else
                return false;
        }
    }
}
