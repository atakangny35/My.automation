using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Otomasyon.DTO.PerconelDTO
{
  public  class PerconelAddViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        [Required]
        public int DepartmanId { get; set; }
    }
}
