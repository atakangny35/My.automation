using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Business.Interfaces
{
   public interface IFaturaKalemService:IgenericService<FaturaKalem>
    {
        List<decimal> GetInvoiceItemsWithBills(int billId);
        List<FaturaKalem> GetFaturaKalemsWithBill(int billId);
    }
}
