using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Business.Concrete
{
    public class SellingMovesManager : ISellingMovesService
    {
        private readonly ISellingMovesDal _sellingMovesDal;
        public SellingMovesManager(ISellingMovesDal sellingMovesDal)
        {
            _sellingMovesDal = sellingMovesDal;
        }

        public void Add(SellingMoves entity)
        {
             _sellingMovesDal.Add(entity);
            
        }

        public void DecreaseStoc(int id, int number)
        {
            _sellingMovesDal.DecreaseStoc(id, number);
        }

        public void Delete(SellingMoves entity)
        {
            throw new NotImplementedException();
        }

        public List<SellingMoves> GetAll()
        {
            throw new NotImplementedException();
        }

        public SellingMoves GetById(int id)
        {
            return _sellingMovesDal.GetById(id);
        }

        public List<SellingMoves> GetSellingMovesWithPerconelFilter(int id)
        {
            return _sellingMovesDal.GetSellingMovesWithPerconelFilter(id);
        }

        public List<SellingMoves> GetSellingMovesWithPerconelFilter()
        {
            return _sellingMovesDal.GetSellingMovesWithPerconelFilter();
        }

        public SellingMoves GetSellingMovewithProduct(int id)
        {
            return _sellingMovesDal.GetSellingMovewithProduct(id);
        }

        public void Update(SellingMoves entity)
        {
             _sellingMovesDal.Update(entity);
        }
    }
}
