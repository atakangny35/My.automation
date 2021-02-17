using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Business.Concrete
{
    public class DepartmanManager : IDepartmanService
    {
        private readonly IDepartmanDal departmanDal;
        public DepartmanManager(IDepartmanDal _departmanDal)
        {
            departmanDal = _departmanDal;
        }

        public void Add(Departman entity)
        {
            departmanDal.Add(entity);
        }

        public void Delete(Departman entity)
        {
            departmanDal.Delete(entity);
        }

        public List<Departman> GetAll()
        {
            return departmanDal.GetAll();
        }

        public Departman GetById(int id)
        {
            return departmanDal.GetById(id);
        }

        public void Update(Departman entity)
        {
            departmanDal.Update(entity);
        }
    }
}
