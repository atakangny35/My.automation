using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DTO.MessagesDTO;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace My.Otomasyon.Web.ViewCompenets
{
    public class MessagePartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessagesService _messagesService;
        public MessagePartial(UserManager<AppUser> userManager,IMessagesService messagesService)
        {
            _userManager = userManager;
            _messagesService = messagesService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var mesaj =  _messagesService.GetAll().Where(x => x.Receiver == user.Email).Select(x => new MessagesListView()
            {
                Content = x.Content,
                Sender = x.Sender,
                Date = x.Date,
                MessageId = x.MessageId,
                Receiver = x.Receiver,
                Topic = x.Topic
            }).ToList();
             return View("MessagePartial",mesaj);
        }

    }
}
