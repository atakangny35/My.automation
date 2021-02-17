using Microsoft.AspNetCore.Mvc;
using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DTO.MessagesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Otomasyon.Web.ViewCompenets
{
    public class Announce: ViewComponent
    {
        private readonly IMessagesService _messagesService;
        public Announce(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }
        public IViewComponentResult Invoke()
        {
            var announce = _messagesService.GetMessagesFromAdmin().Select(x => new MessagesListView()
            {
                Content = x.Content,
                Date = x.Date,
                Sender = x.Sender,
                MessageId = x.MessageId,
                Receiver = x.Receiver,
                Topic = x.Topic
            }).ToList();
            return View("Announce",announce);
        }
    }
}
