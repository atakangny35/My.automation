using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.DTO.PerconelDTO
{
   public class PerconelListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string City { get; set; }
        public bool State { get; set; }
       
        public virtual Departman Departman { get; set; }
        public string PictureUrl { get; set; }

    }
}
