using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DTO.ProductDTO;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace My.Otomasyon.Web.Controllers
{
   
    [Authorize(Roles ="Perconel")]
    


    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService,ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index(int page=1)
        {
            var products = _productService.GetProductsWithCategories().Select(x => new ProductListWithCategoriesModel()
            {
                Id = x.Id,
                Description = x.Description,
                BuyingPrice = x.BuyingPrice,
                Category = x.Category,
                Marka = x.Marka,
                Stok = x.Stok,
                ProductName=x.ProductName,
                SellingPrice=x.SellingPrice,
                LimitState=x.LimitState


            }).ToPagedList(page, 5);

            return View(products);
        }
        public IActionResult AddProduct()
        {
            List<SelectListItem> dropcategory = (from x in _categoryService.GetAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,

                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.dropcategory = dropcategory;

            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductAddViewModel model)
        {
           
                if (ModelState.IsValid)
                {
                    Product product = new Product()
                    {
                        Description = model.Description,
                        SellingPrice = model.SellingPrice,
                        BuyingPrice = model.BuyingPrice,
                        CategoryId = model.CategoryId,
                        ProductName = model.ProductName,
                        Marka = model.Marka,
                        Stok = model.Stok
                    };

                    _productService.Add(product);
                    return RedirectToAction("Index","Product");
                }
                return View(model);           
        }
        
        public IActionResult Delete(int id)
        {
            _productService.DeleteSoft(id);
                

                return Json(null);
            
        }
        public IActionResult Update(int id)
        {
            List<SelectListItem> dropcategory = _categoryService.GetAll().Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.Id.ToString()

            }).ToList();
            ViewBag.dropcategory = dropcategory;
            var model = _productService.GetById(id);
            ProductUpdateModel updateModel = new ProductUpdateModel()
            {
                SellingPrice = model.SellingPrice,
                Stok = model.Stok,
                BuyingPrice = model.BuyingPrice,
                CategoryId = model.CategoryId,
                Condition = model.Condition,
                Description = model.Description,
                Id = model.Id,
                Marka = model.Marka,
                ProductName = model.ProductName,
                ProductPicture = model.ProductPicture
            };


            return View(updateModel);
        }
        [HttpPost]
        public IActionResult Update(ProductUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _productService.GetById(model.Id);
                if (product != null)
                {
                    Product p = new Product()
                    {
                        Id = model.Id,
                        SellingPrice = model.SellingPrice,
                        Stok = model.Stok,
                        BuyingPrice = model.BuyingPrice,
                        CategoryId = model.CategoryId,
                        Marka = model.Marka,
                        ProductName = model.ProductName,
                        ProductPicture = model.ProductPicture,
                        Condition = model.Condition,
                        Description = model.Description
                    };
                    _productService.Update(p);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Update");
            }
            return View(model);
        }
    }
}
