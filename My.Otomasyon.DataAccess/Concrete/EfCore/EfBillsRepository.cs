using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.DataAccess.Concrete.EfCore
{
   public class EfBillsRepository:EfGenericRepository<Bills>,IBillsDal
    {

    }
}
