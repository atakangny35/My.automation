using My.Otomasyon.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Otomasyon.Entities.Concrete
{
   public class KargoTrack:Itable
    {
        [Key]
        public int KargoDetailid { get; set; }
        [StringLength(12)]
        public string TrackNumber { get; set; }
        [StringLength(80)]
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
