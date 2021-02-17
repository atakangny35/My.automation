using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Business.Interfaces
{
    public interface IProductService:IgenericService<Product>
    {
        List<Product> GetProductsWithCategories();
        List<Product> GetbycategoryId(int id);
        Product GetProductWithCategoryId(int id);
        void DeleteSoft(int id);
    }
}
