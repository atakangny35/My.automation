using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
            public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Product entity)
        {
            _productDal.Add(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public void DeleteSoft(int id)
        {
            _productDal.DeleteSoft(id);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetbycategoryId(int id)
        {
            return _productDal.denemeexp(p => p.CategoryId == id);
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);

        }

        public List<Product> GetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

        public Product GetProductWithCategoryId(int id)
        {
          var product=  _productDal.GetProductWithCategoryId(id);
            return product;
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
