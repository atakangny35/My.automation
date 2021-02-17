using My.Otomasyon.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Entities.Concrete
{
    public class Stok:Itable
    {
        public int Id { get; set; }
        public int? Stock { get; set; }
    }
}
