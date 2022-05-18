using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models.Person.Repo
{
    public interface ILanguageRepo
    {
        Language Create(Language language);
        List<Language> GetAll();
        Language FindById(int id);

        Language Update(Language language);
        bool Delete(Language language);
    }
}
