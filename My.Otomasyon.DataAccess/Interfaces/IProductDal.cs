using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.DataAccess.Interfaces
{
   public interface IProductDal:IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        Product GetProductWithCategoryId(int id);
        void DeleteSoft(int id);
    }
}
