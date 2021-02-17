using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DTO.DepatmanDTO;
using My.Otomasyon.DTO.PerconelDTO;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Otomasyon.Web.Controllers
{
    [Authorize(Roles = "Perconel")]
    public class DepartmanController : Controller
    {
        private readonly IDepartmanService _departmanService;
        private readonly IAppUserService _appUserService;

        public DepartmanController(IDepartmanService departmanService, IAppUserService appUserService)
        {
            _departmanService = departmanService;
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            var degerler = _departmanService.GetAll().Select(x => new DepartmanListView()
            {
                Id = x.Id,
                DepartmanName = x.DepartmanName,


            }).ToList();


            return View(degerler);
        }
        public IActionResult Update(int id)
        {
            var model = _departmanService.GetById(id);
            DepartmanUpdateView view = new DepartmanUpdateView()
            {
                DepartmanName = model.DepartmanName,
                Id = model.Id
            };

            return View();
        }
        [HttpPost]
        public IActionResult Update(DepartmanUpdateView p)
        {
            if (ModelState.IsValid)
            {
                Departman departman = new Departman()
                {
                    Id = p.Id,
                    DepartmanName = p.DepartmanName
                };
                _departmanService.Update(departman);
                return RedirectToAction("Index");
            }

            return View(p);
        }
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(DepartmanAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                Departman departman = new Departman()
                {
                    DepartmanName = model.DepartmanAd
                };


                _departmanService.Add(departman);
                return RedirectToAction("Index");

            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var delete = _departmanService.GetById(id);

            _departmanService.Delete(delete);
            return RedirectToAction("Index");
        }
        public IActionResult DepartmanDetail(int id)
        {
            var deger = _appUserService.GetPerconels(id).Select(x => new PerconelListViewModel()
            {
                City = x.City,
                State = x.State,
                Surname = x.Surname,
                Departman = x.Departman,
                Name = x.Name,
                Id=x.Id

            }).ToList();
            ViewBag.DepName = _departmanService.GetById(id).DepartmanName;
            return View(deger);
        }
    }
}
