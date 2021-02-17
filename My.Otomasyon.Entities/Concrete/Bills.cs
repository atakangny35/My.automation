using My.Otomasyon.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace My.Otomasyon.Entities.Concrete
{
    public class Bills:Itable
    {
        public int Id { get; set; }
       
        public string BillSeriNo { get; set; }
       
        [StringLength(10)]
        public string BillOrderno { get; set; }
        public DateTime BillDate { get; set; }
       
        public string Hour { get; set; }
      
        [StringLength(30)]
        public string VergiDairesi { get; set; }
        
        [StringLength(30)]
        public string Receiver { get; set; }
        
        [StringLength(30)]
        public string Deliverer { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
        public decimal Total { get; set; }


        //relations


    }
}
