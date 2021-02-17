using Microsoft.EntityFrameworkCore;
using My.Otomasyon.DataAccess.Concrete.Context;
using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace My.Otomasyon.DataAccess.Concrete.EfCore
{
    public class EfSellingMovesRepository : EfGenericRepository<SellingMoves>, ISellingMovesDal
    {
        public void DecreaseStoc(int id,int number)
        {
            using var context = new OtomasyonContext();

            var product = context.Products.Find(id);
            product.Stok = (short)(product.Stok - number);
            context.SaveChanges();
        }

        public List<SellingMoves> GetSellingMovesWithPerconelFilter(int id)
        {
            using var context = new OtomasyonContext();
            var deger = context.sellingMoves.Where(İ => İ.AppUserId == id).Include(x => x.Products).Join(context.Users, x => x.AppUserId, user => user.Id, (moves, Current) => new
            {

                moves = moves,
                Current = Current
            }).Select(x => new SellingMoves
            {
                Id = x.moves.Id,
                Adet = x.moves.Adet,
                AppUserId = x.moves.Id,
                Cariler = x.Current,
                Date = x.moves.Date,
                Price = x.moves.Price,
                Products = x.moves.Products,
                ProductId = x.moves.ProductId,
                TotalPrice = x.moves.TotalPrice



            }).ToList();

            return deger;
            

               
        }

        public List<SellingMoves> GetSellingMovesWithPerconelFilter()
        {
            using var context = new OtomasyonContext();
            var deger = context.sellingMoves.Include(x => x.Products).Join(context.Users, x => x.AppUserId, user => user.Id, (moves, Current) => new
            {

                moves = moves,
                Current = Current
            }).Select(x => new SellingMoves
            {
                Id = x.moves.Id,
                Adet = x.moves.Adet,
                AppUserId = x.moves.Id,
                Cariler = x.Current,
                Date = x.moves.Date,
                Price = x.moves.Price,
                Products = x.moves.Products,
                ProductId = x.moves.ProductId,
                TotalPrice = x.moves.TotalPrice



            }).ToList();

            return deger;

        }

        public SellingMoves GetSellingMovewithProduct(int id)
        {
            using var context = new OtomasyonContext();
            var deger = context.sellingMoves.Include(x => x.Products).Join(context.Users, x => x.AppUserId, user => user.Id, (moves, Current) => new
            {

                moves = moves,
                Current = Current
            }).Select(x => new SellingMoves
            {
                Id = x.moves.Id,
                Adet = x.moves.Adet,
                AppUserId = x.moves.Id,
                Cariler = x.Current,
                Date = x.moves.Date,
                Price = x.moves.Price,
                Products = x.moves.Products,
                ProductId = x.moves.ProductId,
                TotalPrice = x.moves.TotalPrice



            }).Where(x => x.Id == id).FirstOrDefault();
            return deger;
        }
    }
}
