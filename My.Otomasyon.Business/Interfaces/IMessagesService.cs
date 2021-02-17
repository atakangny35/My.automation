using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Business.Interfaces
{
   public interface IMessagesService:IgenericService<Messages>
    {
        List<Messages> GetMessagesFromAdmin();
    }
}
