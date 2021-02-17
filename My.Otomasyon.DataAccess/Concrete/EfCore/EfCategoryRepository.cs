using My.Otomasyon.DataAccess.Concrete.Context;
using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Concrete;

namespace My.Otomasyon.DataAccess.Concrete.EfCore
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryDal
    {   

        public void DeleteSoft(int id)
        {
            using var context = new OtomasyonContext();
            var category = context.Categories.Find(id);
            category.LimitState = false;
            context.SaveChanges();
           
        }
    }
}
