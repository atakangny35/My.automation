using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DTO.CurrentDTO;
using My.Otomasyon.DTO.PerconelDTO;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Otomasyon.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IProductService _productService;
        private readonly RoleManager<AppRole> _roleManager;
        public LoginController(IAppUserService appUserService,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,IProductService productService,RoleManager<AppRole> roleManager)
        {
            _appUserService = appUserService;
            _signInManager = signInManager;
            _userManager = userManager;
            _productService = productService;
            _roleManager = roleManager;

        }

        public IActionResult Index()
        {

            
            return View();
        }
        
        
            
        
        [HttpPost]
        public async Task<IActionResult> SignUp(CurrentAddModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = model.UserName,
                    Name = model.Name,
                    Email = model.Email,
                    City = model.City,
                    Surname = model.Surname
                    
                };
                
                var IdUser = await _userManager.CreateAsync(user, model.Password);
                if (IdUser.Succeeded)
                {
                    var role = await _userManager.AddToRoleAsync(user, "Current");
                    if (role.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    foreach (var item in role.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                foreach (var item in IdUser.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Index",model);
        }
        [HttpGet]
        public IActionResult CurrentLogin()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CurrentLogin(CurrentSignInModel model)
        {
            if (ModelState.IsValid)
            {
                var Iduser = await _userManager.FindByNameAsync(model.UserName);
                
                if(Iduser != null)
                {
                    var Signuser = await _signInManager.PasswordSignInAsync(Iduser, model.Password, model.RememberMe, false);
                    if (Signuser.Succeeded)
                    {
                        var deger = await _userManager.GetRolesAsync(Iduser);
                        foreach (var item in deger)
                        {
                            if (item == "Current")
                            {
                                return RedirectToAction("Index", "CurrentPanel");
                            }
                            else if (item=="Perconel"|| item == "Admin")
                            {
                                return RedirectToAction("Index", "Product");
                            }
                            

                        }
                       

                        
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or Password is not correct !");
                        return RedirectToAction("Index");
                    }
                }
            }

            return View("Index", model);
        }

       


        //[HttpPost]
        //public async Task<IActionResult> PerconelLogin(PerconelSignInModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var Iduser = await _userManager.FindByNameAsync(model.UserName);
        //        if (Iduser != null)
        //        {
        //            var Signuser = await _signInManager.PasswordSignInAsync(Iduser, model.Password, model.RememberMe, false);
        //            if (Signuser.Succeeded)
        //            {

        //                return RedirectToAction("Index", "Product");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "Username or Password is not correct !");
        //            }
        //        }
        //    }

        //    return View("Index", model);
        //}

    }
}
