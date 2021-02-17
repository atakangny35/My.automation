using My.Otomasyon.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Business.Interfaces
{
   public interface IgenericService<T> where T: class,Itable,new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}
