using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.DataAccess.Interfaces
{
    public interface IMessagesDal:IGenericDal<Messages>
    {
        List<Messages> GetMessages();
    }
}
