using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.DTO.FaturaKalemDTO
{
   public class FaturaKalemAddView
    {
        public string Desciription { get; set; }

        public int Quantity { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }
        public int BillsId { get; set; }
        
    }
}
