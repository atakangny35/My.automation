using My.Otomasyon.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace My.Otomasyon.DataAccess.Interfaces
{
   public interface IGenericDal<T> where T: class,Itable,new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        List<T> GetAll();
        List<T> denemeexp(Expression<Func<T, bool>> filter = null);
    }
}
