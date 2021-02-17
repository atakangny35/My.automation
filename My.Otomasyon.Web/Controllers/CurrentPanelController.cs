using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using My.Otomasyon.DTO.CurrentDTO;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DTO.SellingMovesDTO;

namespace My.Otomasyon.Web.Controllers
{
    [Authorize(Roles = "Current")]
    public class CurrentPanelController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ISellingMovesService _sellingMovesService;
        private readonly SignInManager<AppUser> _signInManager;
        public CurrentPanelController(UserManager<AppUser> userManager, ISellingMovesService sellingMovesService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _sellingMovesService = sellingMovesService;
            _signInManager = signInManager;

        }
        public async Task<IActionResult> Index()
        {
            var user=await _userManager.FindByNameAsync(User.Identity.Name);
            CurrentListView current = new CurrentListView()
            {
                City = user.City,
                State = user.State,
                Surname = user.Surname,
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                PictureUrl = user.PictureUrl
            };
            return View(current);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CurrentUpdateView model)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByNameAsync(model.Name);
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.UserName = model.UserName;
                user.City = model.City;
                
                user.Email = model.Email;
                user.Id = model.Id;


                await _userManager.UpdateSecurityStampAsync(user);
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View(model);
        }
        public async Task<IActionResult> Order()
        {

            var id = await _userManager.FindByNameAsync(User.Identity.Name);
            if(id!= null)
            {
                var moves = _sellingMovesService.GetSellingMovesWithPerconelFilter().Where(x => x.AppUserId == id.Id).Select(x => new OrderViewModel()
                {
                    Date = x.Date,
                    Price = x.Price,
                    ProductId = x.ProductId,
                    Product = x.Products
                }).ToList();
                return View(moves);
            }

            return RedirectToAction("Index", "Login");
        }
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

    }
}
