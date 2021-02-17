using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Concrete;
using System.Collections.Generic;

namespace My.Otomasyon.Business.Concrete
{

    public class MessagesManager : IMessagesService
    {
        private readonly IMessagesDal messages;
        public MessagesManager(IMessagesDal messagesDal)
        {
            messages = messagesDal;
        }

        public void Add(Messages entity)
        {
             messages.Add(entity);
        }

        public void Delete(Messages entity)
        {
            messages.Delete(entity);
        }

        public List<Messages> GetAll()
        {
            return messages.GetAll();
        }

        public Messages GetById(int id)
        {
            return messages.GetById(id);
        }

        public List<Messages> GetMessagesFromAdmin()
        {
            return messages.GetMessages();
        }

        public void Update(Messages entity)
        {
            messages.Update(entity);
        }
    }
}
