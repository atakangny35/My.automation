using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Business.Interfaces
{
   public interface ISellingMovesService:IgenericService<SellingMoves>
    {
        List<SellingMoves> GetSellingMovesWithPerconelFilter(int id);
        List<SellingMoves> GetSellingMovesWithPerconelFilter();
        void DecreaseStoc(int id, int number);
        SellingMoves GetSellingMovewithProduct(int id);
    }
}
