using Microsoft.Extensions.DependencyInjection;
using My.Otomasyon.Business.Concrete;
using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DataAccess.Concrete.EfCore;
using My.Otomasyon.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Business.CostumExtensions.Depandecies
{
   public static class AddDepandecies
    {
        public static void AddDepandencies(this IServiceCollection services)
        {
            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();
            services.AddScoped<IDepartmanDal, EfDepartmanRepository>();
            services.AddScoped<IDepartmanDal, EfDepartmanRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<ISellingMovesDal, EfSellingMovesRepository>();
            services.AddScoped<IBillsDal, EfBillsRepository>();
            services.AddScoped<IFaturaKalemDal, EfFaturaKalemRepository>();
            services.AddScoped<IMessagesDal, EfMessagesRepository>();




            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IDepartmanService, DepartmanManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<ISellingMovesService, SellingMovesManager>();
            services.AddScoped<IFaturaKalemService, FaturaKalemManager>();
            services.AddScoped<IBillsService, BillManager>();
            services.AddScoped<IMessagesService, MessagesManager>();
        }

       
    }
}
