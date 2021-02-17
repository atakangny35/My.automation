using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Otomasyon.DTO.MessagesDTO
{
   public  class MessagesListView
    {
        
        public int MessageId { get; set; }

        public string Sender { get; set; }
        [StringLength(50)]
        public string Receiver { get; set; }
        [StringLength(50)]
        public string Topic { get; set; }
        [StringLength(500)]
        public string Content { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
