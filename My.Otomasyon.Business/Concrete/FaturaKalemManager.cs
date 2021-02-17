using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Concrete;
using System.Collections.Generic;

namespace My.Otomasyon.Business.Concrete
{
    public class FaturaKalemManager : IFaturaKalemService
    {
        private readonly IFaturaKalemDal _faturaKalemDal;
            public FaturaKalemManager(IFaturaKalemDal faturaKalemDal)
        {
            _faturaKalemDal = faturaKalemDal;       
        }
        public void Add(FaturaKalem entity)
        {
            _faturaKalemDal.Add(entity);
            
        }

        public void Delete(FaturaKalem entity)
        {
            _faturaKalemDal.Delete(entity);
        }

        public List<FaturaKalem> GetAll()
        {
            return _faturaKalemDal.GetAll();
        }

        public FaturaKalem GetById(int id)
        {
            return _faturaKalemDal.GetById(id);
        }

        public List<FaturaKalem> GetFaturaKalemsWithBill(int billId)
        {
            return _faturaKalemDal.GetFaturaKalemsWithBill(billId);
        }

        public List<decimal> GetInvoiceItemsWithBills(int billId)
        {
          return _faturaKalemDal.GetInvoiceItemsWithBills(billId);
        }

        public void Update(FaturaKalem entity)
        {
             _faturaKalemDal.Update(entity);
        }
    }
}
