using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using My.Otomasyon.DataAccess.Concrete.Context;
using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Otomasyon.DataAccess.Concrete.EfCore
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductDal
    {
        public void DeleteSoft(int id)
        {
            using var context = new OtomasyonContext();
            var product = context.Products.Find(id);
            product.LimitState = false;
            context.SaveChanges();
        }

        public List<Product> GetProductsWithCategories()
        {
            using var context = new OtomasyonContext();
            return context.Products.Where(i=>i.LimitState==true).Include(x => x.Category).ToList();
        }

        public Product GetProductWithCategoryId(int id)
        {
            using var context = new OtomasyonContext();
            //var product = context.Products.Join(context.Categories, x => x.CategoryId, y => y.Id, (resultproduct, resultcategory) => new Product
            //{

            //    Id = resultproduct.Id,
            //    SellingMoves = resultproduct.SellingMoves,
            //    SellingPrice = resultproduct.SellingPrice,
            //    Stok = resultproduct.Stok,
            //    Category = resultcategory,
            //    CategoryId = resultproduct.CategoryId

            //}).Where(x => x.Id == id).FirstOrDefault();
            var product = context.Products.Where(i=>i.LimitState==true).Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            return product;
        }
    }
}
