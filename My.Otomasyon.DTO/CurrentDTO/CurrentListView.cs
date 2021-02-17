using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.DTO.CurrentDTO
{
   public class CurrentListView
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
        public string City { get; set; }
        public bool State { get; set; }

        
        public string PictureUrl { get; set; }
    }
}
