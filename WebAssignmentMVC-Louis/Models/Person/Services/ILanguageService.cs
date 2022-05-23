using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Models.Person.Services
{
    public interface ILanguageService
    {
        Language Create(CreateLanguageViewModel language);
        List<Language> GetAll();
        Language FindById(int id);
        string GetLanguageName(int id);
        Language Edit(int id, CreateLanguageViewModel editlanguage);
        bool Remove(int id);
        void AddLang(PersonLanguage personLang, List<Person> langId);
    }
}
