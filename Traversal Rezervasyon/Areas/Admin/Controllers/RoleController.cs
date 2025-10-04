using System.Collections.Generic;
using BusinessLayer.ValidationRule;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DTOs.RoleDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Traversal_Rezervasyon.Areas.Admin.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        private readonly UserManager<AppUser> _userManager;
        public RoleController(RoleManager<AppRole> roleManager,UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var gstr = _roleManager.Roles.ToList();

            return View(gstr);
        }

        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleDtos addRoleDtos)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole()
                {
                    Name = addRoleDtos.Name
                };

                var gstr = await _roleManager.CreateAsync(appRole);

                if (gstr.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                else
                {
                    return View();
                }

            }

            return View();
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var gstr = _roleManager.Roles.FirstOrDefault(n => n.Id == id);

            await _roleManager.DeleteAsync(gstr);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {

            var gstr = _roleManager.Roles.FirstOrDefault(n => n.Id == id);


            UpdateRoleDtos validationRules = new UpdateRoleDtos()
            {
                Name = gstr.Name,
                Id = gstr.Id
            };

            return View(validationRules);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleDtos updateRole)
        {
            AppRole appRole = new AppRole()
            {
                Id = updateRole.Id,
                Name = updateRole.Name
            };

            await _roleManager.UpdateAsync(appRole);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UserList()
        {
            var gstr = _userManager.Users.ToList();

            return View(gstr);
        }

        [HttpGet]
        public async Task< IActionResult> AssignedUser(int id)
        {
            var user =  _userManager.Users.FirstOrDefault(n=>n.Id==id);

            TempData["FindId"] = user.Id;

            var role = _roleManager.Roles.ToList();

            var UserRole = await _userManager.GetRolesAsync(user);

            List<AssignedRole> assignedRoles = new List<AssignedRole>();

           foreach(var item in role)
            {
                AssignedRole assignedRole = new AssignedRole()
                {
                    RoleName = item.Name,
                    RoleId = item.Id,
                    RoleExist =  UserRole.Contains(item.Name)
                };

                assignedRoles.Add(assignedRole);
            }

            return View(assignedRoles);
        }

        [HttpPost]
        public async Task<IActionResult> AssignedUser(List<AssignedRole> assignedRoles)
        {
            var gstr =Convert.ToInt32( TempData["FindId"]);

            var user = _userManager.Users.FirstOrDefault(n=>n.Id==gstr);

            foreach (var item in assignedRoles)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user,item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user,item.RoleName);
                }
            }

            return RedirectToAction("UserList");
        }
    }
}
