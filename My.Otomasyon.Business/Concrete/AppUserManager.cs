using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public List<AppUser> GetCurrents()
        {
            return _appUserDal.GetCurrents();
        }

        public List<AppUser> GetPerconels(int id)
        {
            return _appUserDal.GetPerconels(id);
        }

        public List<AppUser> GetPerconels()
        {
            return _appUserDal.GetPerconels();
        }
    }
}
