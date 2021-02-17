using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DTO.SellingMovesDTO;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Otomasyon.Web.Controllers
{
    [Authorize(Roles = "Perconel")]
    public class SalesController : Controller
    {
        private readonly ISellingMovesService _sellingMovesService;
        private readonly IAppUserService _appUserService;
        private readonly IProductService _productService;
            public SalesController(ISellingMovesService sellingMovesService, IAppUserService appUserService,IProductService productService)
        {
            _sellingMovesService = sellingMovesService;
            _appUserService = appUserService;
            _productService = productService;
        }
        public IActionResult Index()
        {
            var Moves = _sellingMovesService.GetSellingMovesWithPerconelFilter().Select(x => new SellingMovesListView()
            {
                Id = x.Id,
                Adet = x.Adet,
                AppUserId = x.AppUserId,
                Cariler = x.Cariler,
                Date = x.Date,
                Price = x.Price,
                ProductId = x.ProductId,
                Products = x.Products,
                TotalPrice = x.TotalPrice
            }).ToList();
            
            return View(Moves);
        }
        public IActionResult Sell(int id)
        {
           ViewBag.current = _appUserService.GetCurrents().Select(x => new SelectListItem()
            {
                Text = x.Name + " " + x.Surname,
               Value = x.Id.ToString()
            }).ToList();
            var deger = _productService.GetById(id).Id;
            ViewBag.Product = deger;

            return View();
        }
        [HttpPost]
        public IActionResult Sell(SellingMovesAddViewModel p)
        {

            if (ModelState.IsValid)
            {
                SellingMoves moves = new SellingMoves()
                {
                    Adet = p.Adet,
                    Price = p.Price,
                    TotalPrice = p.Price * p.Adet,
                    AppUserId = p.AppUserId,
                    Date = p.Date,
                    ProductId = p.ProductId

                };
               
                _sellingMovesService.Add(moves);
                _sellingMovesService.DecreaseStoc(moves.ProductId, moves.Adet);
                return RedirectToAction("Index");
            }
            return View(p);

        }
        public IActionResult SalesDetail(int id)
        {
            var deger = _sellingMovesService.GetSellingMovewithProduct(id);
            SellingMovesListView view = new SellingMovesListView()
            {
                Id = deger.Id,
                Date = deger.Date,
                Adet = deger.Adet,
                AppUserId = deger.AppUserId,
                Price = deger.Price,
                ProductId = deger.ProductId,
                TotalPrice = deger.TotalPrice,
                Products=deger.Products,
                Cariler=deger.Cariler
                
                
            };
          var f=  view.Products.ProductName;

            return View(view);
        }
        public IActionResult Update(int id)
        {
            ViewBag.current = _appUserService.GetCurrents().Select(x => new SelectListItem()
            {
                Text = x.Name + " " + x.Surname,
                Value = x.Id.ToString()
            }).ToList();
            

            var move = _sellingMovesService.GetSellingMovewithProduct(id);
            SellingMovesUpdateViewModel model = new SellingMovesUpdateViewModel()
            {
                Id = move.Id,
                Date = move.Date,
                Adet = move.Adet,
                AppUserId = move.AppUserId,
                Price = move.Price,
                ProductId = move.ProductId
                
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Update(SellingMovesUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                SellingMoves moves = new SellingMoves()
                {
                    Id = model.Id,
                    Date = model.Date,
                    Adet = model.Adet,
                    AppUserId = model.AppUserId,
                    ProductId = model.ProductId,
                    Price = model.Price,
                    TotalPrice = model.Price * model.Adet
                };
                _sellingMovesService.Update(moves);
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        
    }
}
