using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.DataAccess.Interfaces
{
    public interface IFaturaKalemDal : IGenericDal<FaturaKalem>
    {
        List<decimal> GetInvoiceItemsWithBills(int billId);
        List<FaturaKalem> GetFaturaKalemsWithBill(int billId);
    }
}
