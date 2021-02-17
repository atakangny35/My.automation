using Microsoft.EntityFrameworkCore;
using My.Otomasyon.DataAccess.Concrete.Context;
using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Otomasyon.DataAccess.Concrete.EfCore
{
    public class EfFaturaKalemRepository : EfGenericRepository<FaturaKalem>, IFaturaKalemDal
    {
        public List<FaturaKalem> GetFaturaKalemsWithBill(int billId)
        {
            using var context = new OtomasyonContext();
            var dgr = context.FaturaKalems.Where(x => x.BillsId == billId).Include(x => x.Bills).ToList();
            return dgr;
        }

        public List<decimal> GetInvoiceItemsWithBills(int billId)
        {
            using var context = new OtomasyonContext();
            var dgr = context.FaturaKalems.Where(x => x.BillsId == billId).Include(x => x.Bills).Select(y => y.Tutar).ToList();

            decimal toplam = 0;
            foreach (var item in dgr)
            {
                toplam= item + toplam;
            }
            var bill = context.Bills.Find(billId);
            bill.Total = toplam;
            context.SaveChanges();
            return dgr;
        }

        
    }
}
