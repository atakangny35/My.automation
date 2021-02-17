using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DTO.CurrentDTO;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Otomasyon.Web.ViewCompenets
{
    public class Update:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public Update(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var deger = await _userManager.FindByNameAsync(User.Identity.Name);
            CurrentUpdateView current = new CurrentUpdateView()
            {
                City = deger.City,
                Surname = deger.Surname,
                Email = deger.Email,
                Id = deger.Id,
                Name = deger.Name,
                UserName = deger.UserName

            };

            return View("Update",current);
        }
    }
}
