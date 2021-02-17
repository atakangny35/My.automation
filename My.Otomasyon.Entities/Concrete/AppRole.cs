using Microsoft.AspNetCore.Identity;
using My.Otomasyon.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Entities.Concrete
{
   public class AppRole:IdentityRole<int>,Itable
    {

    }
}
