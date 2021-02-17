using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DTO.PerconelDTO;
using My.Otomasyon.DTO.SellingMovesDTO;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Otomasyon.Web.Controllers
{
    [Authorize(Roles = "Perconel")]
    public class PerconelController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserService;
        private readonly ISellingMovesService _sellingMovesService;
        private readonly IDepartmanService _departmanService;
        public PerconelController(UserManager<AppUser> userManager, IAppUserService appUserService, ISellingMovesService sellingMovesService,IDepartmanService departmanService)
        {
            _userManager = userManager;
            _appUserService = appUserService;
            _sellingMovesService = sellingMovesService;
            _departmanService = departmanService;


        }
        public IActionResult Index()
        {
            var perconeller = _appUserService.GetPerconels().Select(x => new PerconelListViewModel()
            {
                City = x.City,
                Departman = x.Departman,
                Id = x.Id,
                State = x.State,
                Surname = x.Surname,
                Name = x.Name,
                PictureUrl=x.PictureUrl
            }).ToList();            
            return View(perconeller);
        }
        public IActionResult Detail(int id)
        {
            var moves = _sellingMovesService.GetSellingMovesWithPerconelFilter(id).Select(x => new SellingMovesListView()
            {
                Adet = x.Adet,
                AppUserId = x.AppUserId,
                Date = x.Date,
                Id = x.Id,
                Products = x.Products,
                Price = x.Price,
                TotalPrice = x.TotalPrice,
                Cariler=x.Cariler,
                ProductId=x.ProductId
                
            }).ToList();
         
            return View(moves);
        }
        public IActionResult Add()
        {
            List<SelectListItem> DropDepartman = _departmanService.GetAll().Select(x => new SelectListItem()
            {
                Text = x.DepartmanName,
                Value = x.Id.ToString()
            }).ToList();
            ViewBag.Departman = DropDepartman;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(PerconelAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = model.UserName,
                    City = model.City,
                    Email = model.Email,
                    DepartmanId = model.DepartmanId,
                    Name = model.Name,
                    Surname = model.Surname
                };


                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Perconel");
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Update(int id)
        {   
            List<SelectListItem> DropDepartman = _departmanService.GetAll().Select(x => new SelectListItem()
            {
                Text = x.DepartmanName,
                Value = x.Id.ToString()
            }).ToList();
            ViewBag.Departman = DropDepartman;
          var model= await _userManager.FindByIdAsync(id.ToString());
            PerconelUpdateViewModel val = new PerconelUpdateViewModel()
            {
                Id = model.Id,
                City = model.City,
                Name = model.Name,
                Email = model.Email,
                Surname = model.Surname,
                UserName = model.UserName,
                DepartmanId = model.DepartmanId

            };
            return View(val);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PerconelUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByNameAsync(model.Name);
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.UserName = model.UserName;
                user.City = model.City;
                user.DepartmanId = model.DepartmanId;
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
    }
}
