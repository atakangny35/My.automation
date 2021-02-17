using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Otomasyon.DTO.ProductDTO
{
    public class ProductListWithCategoriesModel
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string ProductName { get; set; }

        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string Description { get; set; }
        public bool LimitState { get; set; }
        public virtual Category Category { get; set; }
    }
}
