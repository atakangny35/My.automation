using My.Otomasyon.DataAccess.Concrete.Context;
using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace My.Otomasyon.DataAccess.Concrete.EfCore
{
    public class EfMessagesRepository : EfGenericRepository<Messages>, IMessagesDal
    {
       
        public List<Messages> GetMessages()
        {
            using var context = new OtomasyonContext();
            var mesaj = context.Messages.Where(x => x.Sender == "Admin").ToList();
            return mesaj;
        }
    }
}
