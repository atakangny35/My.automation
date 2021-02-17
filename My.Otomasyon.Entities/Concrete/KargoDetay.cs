using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using My.Otomasyon.Entities.Interfaces;

namespace My.Otomasyon.Entities.Concrete
{
   public class KargoDetay:Itable
    {
        [Key]
        public int CargoDetailid { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(12)]
        public string TrackNumber { get; set; }
        [StringLength(20)]
        public string Receiver { get; set; }
        [StringLength(20)]
        public string Perconel { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
