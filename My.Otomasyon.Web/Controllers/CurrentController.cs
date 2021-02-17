using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DTO.CurrentDTO;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Otomasyon.Web.Controllers
{
    [Authorize(Roles = "Perconel")]
    public class CurrentController : Controller
    {
        private readonly IAppUserService _currentService;
        private readonly UserManager<AppUser> _userManager;
        public CurrentController(IAppUserService currentService,UserManager<AppUser> userManager)
        {
            _currentService = currentService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var currents = _currentService.GetCurrents().Where(x => x.State == true).Select(x => new CurrentListView()
            {
                Id = x.Id,
                City = x.City,
                Name = x.Name,
                PictureUrl = x.PictureUrl,
                State = x.State,
                Surname = x.Surname,
                Email=x.Email
                
            });
            return View(currents);
        }
        public async Task<IActionResult> Delete(int id)
        {

            var current = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(current);

            return Json(null);
        }
    }
}
