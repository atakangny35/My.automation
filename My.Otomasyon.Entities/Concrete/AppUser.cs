using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using My.Otomasyon.Entities.Interfaces;

namespace My.Otomasyon.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, Itable
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string City { get; set; }
        public bool State { get; set; }

        public ICollection<SellingMoves> SellingMoves { get; set; }

        public int? DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }

        public string PictureUrl { get; set; } = "~/img/personel.png";

    }
}
