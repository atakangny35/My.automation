using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.DataAccess.Interfaces
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        void DeleteSoft(int id);
    }
}
