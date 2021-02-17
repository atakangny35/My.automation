using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Otomasyon.Web.ViewCompenets
{
    public  class CurrentSignIn: ViewComponent
    {
        private readonly SignInManager<AppUser>_signInManager;
            public CurrentSignIn(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IViewComponentResult Invoke()
        {
            return View("CurrentSignIn");
        }
    }
}
