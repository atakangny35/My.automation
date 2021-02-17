using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Business.Interfaces
{
   public interface IAppUserService
    {
        List<AppUser> GetPerconels(int id);
        List<AppUser> GetPerconels();
        List<AppUser> GetCurrents();
    }
}
