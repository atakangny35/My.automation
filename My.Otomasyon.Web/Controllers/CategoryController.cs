using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DTO.CategoryDTO;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace My.Otomasyon.Web.Controllers
{
   
    [Authorize(Roles = "Perconel")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index(int page = 1)
        {
            var model = _categoryService.GetAll().Where(c => c.LimitState == true).Select(x => new CategoryListViewModel()
            {
                CategoryName = x.CategoryName,
                Id = x.Id
            }).ToPagedList(page, 5);

            return View(model);
        }
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(CategoryAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category()
                {
                    CategoryName = model.CategoryName

                };
                category.LimitState = true;
                _categoryService.Add(category);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteSoft(id);

            return Json(null);

        }
        public IActionResult Update(int id)
        {
            
            
                var eren = _categoryService.GetById(id);

                CategoryUpdateViewModel model = new CategoryUpdateViewModel()
                {
                    Id = eren.Id,
                    CategoryName = eren.CategoryName
                };
                return View(model);
               
        }
       [HttpPost]
       public IActionResult Update(CategoryUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
               var p= _categoryService.GetById(model.Id);

                Category category = new Category()
                {
                    Id = model.Id,
                    CategoryName = model.CategoryName,

                };
                _categoryService.Update(category);
                return RedirectToAction("Index");            
                
            }
            return View(model);
           
        }

    }
}
