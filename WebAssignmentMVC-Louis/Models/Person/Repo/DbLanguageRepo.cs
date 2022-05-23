using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person.Data;

namespace WebAssignmentMVC.Models.Person.Repo
{
    public class DbLanguageRepo : ILanguageRepo
    {
        readonly PersonDBContext _personDBContext;

        public DbLanguageRepo(PersonDBContext personDBContext)
        {
            _personDBContext = personDBContext;
        }

        public void AddLang(PersonLanguage personLang, List<Person> langId)
        {
            throw new NotImplementedException();
        }

        public Language Create(Language language)
        {
            _personDBContext.Add(language);
            _personDBContext.SaveChanges();
            return language;
        }

        public bool Delete(Language language)
        {
            _personDBContext.Language.Remove(language);
            int returnValue = _personDBContext.SaveChanges();
            return returnValue == 1 ? true : false;
        }

        public Language FindById(int id)
        {
            return _personDBContext.Language.Find(id);
        }

        public List<Language> GetAll()
        {
            return _personDBContext.Language.Include(language => language.personLanguage).ToList();
        }

        public string GetLangName(int id)
        {
            Language lang = new Language();
            lang = _personDBContext.Language.Find(id);
            return (lang.LangName);
        }

        public Language Update(Language language)
        {
            _personDBContext.Language.Update(language);
            if (_personDBContext.SaveChanges() > 0)
            {
                return language;
            }
            return null;
        }
    } // End of Public Class
}// End of NameSpace
