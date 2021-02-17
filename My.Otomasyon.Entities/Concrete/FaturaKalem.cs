using My.Otomasyon.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace My.Otomasyon.Entities.Concrete
{
    public class FaturaKalem : Itable
    {
        public int Id { get; set; }

        [StringLength(75)]
        public string Desciription { get; set; }
        public int Quantity { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }
        public int BillsId { get; set; }
        public virtual Bills Bills { get; set; }
    }
}
