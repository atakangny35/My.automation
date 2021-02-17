using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Otomasyon.Web.ViewCompenets
{
    public class PerconelSignIn:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("PerconelSignIn");
        }
    }
}
