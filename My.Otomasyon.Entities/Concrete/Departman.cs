using My.Otomasyon.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace My.Otomasyon.Entities.Concrete
{
    public class Departman:Itable
    {
        public int Id { get; set; }
       
        [StringLength(30)]
        public string DepartmanName { get; set; }
        public bool State { get; set; }
        public ICollection<AppUser> Perconels { get; set; }
    }
}
