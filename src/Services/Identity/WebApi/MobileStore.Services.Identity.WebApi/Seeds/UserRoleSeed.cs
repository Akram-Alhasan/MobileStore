
using Microsoft.AspNetCore.Identity;
using MobileStore.Services.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Services.Identity.WebApi.Seeds
{
    public class UserRoleSeed
    {
       
        public static async Task createSeed(RoleManager<Role> _roleManager)
        {
            bool StoresManager = await _roleManager.RoleExistsAsync("Admin");
            if (!StoresManager)
            {
                var role = new Role();
                role.Name = "Admin";
                await _roleManager.CreateAsync(role);
            }
            bool storeEmployee = await _roleManager.RoleExistsAsync("Normal");
            if (!storeEmployee)
            {
                var role = new Role();
                role.Name = "Normal";
                await _roleManager.CreateAsync(role);
            }
        }
    }
}
