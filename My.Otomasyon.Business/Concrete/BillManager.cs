using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DataAccess.Concrete.Context;
using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Business.Concrete
{
    public class BillManager : IBillsService
    {
        private readonly IBillsDal _billsDal;
        public BillManager(IBillsDal billsDal)
        {
            _billsDal = billsDal;
                
        }
        public void Add(Bills entity)
        {
            _billsDal.Add(entity);
            
        }

        public void Delete(Bills entity)
        {
            _billsDal.Delete(entity);
        }

        public List<Bills> GetAll()
        {
            return _billsDal.GetAll();
        }

        public Bills GetById(int id)
        {
            return _billsDal.GetById(id);
        }

        public void Update(Bills entity)
        {
            _billsDal.Update(entity);
        }
    }
}
