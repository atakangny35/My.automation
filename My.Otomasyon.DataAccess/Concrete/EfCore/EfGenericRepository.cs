using My.Otomasyon.DataAccess.Concrete.Context;
using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace My.Otomasyon.DataAccess.Concrete.EfCore
{
    public class EfGenericRepository<T> : IGenericDal<T> where T: class,Itable,new()
    {
        

        public List<T> GetAll()
        {
            using var _context = new OtomasyonContext();
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            using var _context = new OtomasyonContext();

            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            using var _context = new OtomasyonContext();

            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Add(T entity)
        {
            using var _context = new OtomasyonContext();

            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            using var _context = new OtomasyonContext();

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public List<T> denemeexp(Expression<Func<T, bool>> filter = null)
        {
            using var _context = new OtomasyonContext();
            return filter == null
                ? _context.Set<T>().ToList()
                : _context.Set<T>().Where(filter).ToList();
        }
    }
}
