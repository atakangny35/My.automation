using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DTO.BillsDTO;
using My.Otomasyon.DTO.FaturaKalemDTO;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Otomasyon.Web.Controllers
{
    [Authorize(Roles = "Perconel")]
    public class BillsController : Controller
    {
        private readonly IBillsService _billsService;
        private readonly IFaturaKalemService _faturaKalemService;
        public BillsController(IBillsService billsService, IFaturaKalemService faturaKalemService)
        {
            _billsService = billsService;
            _faturaKalemService = faturaKalemService;
                
        }
        public IActionResult Index()
        {
            var degerler = _billsService.GetAll().Select(c => new BillsListViewModel()
            {
                BillDate = c.BillDate,
                BillOrderno = c.BillOrderno,
                BillSeriNo = c.BillSeriNo,
                Deliverer = c.Deliverer,
                Receiver = c.Receiver,
                Hour = c.Hour,
                Id = c.Id,
                Total = c.Total
            }).ToList();
            foreach (var item in degerler)
            {
                var tutarlar = _faturaKalemService.GetInvoiceItemsWithBills(item.Id);
               
            }

            return View(degerler);
        }
        public IActionResult BillDetail(int id)
        {
            var invoice = _faturaKalemService.GetFaturaKalemsWithBill(id).Select(x => new FaturaKalemListView()
            {
                Bills = x.Bills,
                Desciription = x.Desciription,
                BillsId = x.BillsId,
                BirimFiyat = x.BirimFiyat,
                Quantity = x.Quantity,
                Tutar = x.Tutar
            }).ToList();
            ViewBag.serial = invoice.FirstOrDefault().Bills.BillSeriNo;
            ViewBag.dnm = id;
            return View(invoice);
        }
        public IActionResult AddInvoice(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddInvoice(FaturaKalemAddView p)
        {
            if (ModelState.IsValid)
            {
                FaturaKalem model = new FaturaKalem()
                {
                    BillsId = p.BillsId,
                    Desciription = p.Desciription,
                    BirimFiyat = p.BirimFiyat,
                    Quantity = p.Quantity,
                    Tutar = p.Quantity*p.BirimFiyat
                };
                _faturaKalemService.Add(model);
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public IActionResult Update(int id)
        {
            var model = _billsService.GetById(id);
            BillUpdateView bill = new BillUpdateView()
            {
                BillDate = model.BillDate,
                BillOrderno = model.BillOrderno,
                BillSeriNo = model.BillSeriNo,
                Deliverer = model.Deliverer,
                Hour = model.Hour,
                Receiver = model.Receiver,
                VergiDairesi = model.VergiDairesi,

            };
            return View(bill);

        }
        [HttpPost]
        public IActionResult Update(BillUpdateView model)
        {
            if (ModelState.IsValid)
            {
                var total = _billsService.GetById(model.Id).Total;
                Bills bills = new Bills()
                {
                    Deliverer = model.Deliverer,
                    BillDate = model.BillDate,
                    VergiDairesi = model.VergiDairesi,
                    BillOrderno = model.BillOrderno,
                    BillSeriNo = model.BillSeriNo,
                    Id = model.Id,
                    Hour = model.Hour,
                    Receiver = model.Receiver,
                    Total = total

                };
                _billsService.Update(bills);
                return RedirectToAction("Index");
            }
            return View(model);

        }
        public IActionResult Add()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Add(BillsAddView view)
        {
            if (ModelState.IsValid)
            {
                Bills model = new Bills
                {
                    BillDate = view.BillDate,
                    BillSeriNo = view.BillSeriNo,
                    Deliverer = view.Deliverer,
                    VergiDairesi = view.VergiDairesi,
                    BillOrderno = view.BillOrderno,
                    Hour = view.Hour,
                    Receiver = view.Receiver,

                };
                _billsService.Add(model);
                return RedirectToAction("Index");
            }
            return View(view);
        }
    }
}
