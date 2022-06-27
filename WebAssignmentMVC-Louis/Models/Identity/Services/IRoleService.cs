using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Identity.ViewModels;

namespace WebAssignmentMVC.Models.Identity.Services
{
    public interface IRoleService
    {
        IdentityRole Create(CreateRolesViewModel role);
        List<IdentityRole> GetAll();
        IdentityRole FindById(int id);

        IdentityRole Edit(int id, CreateRolesViewModel editRole);
        bool Remove(int id);
    }
}
