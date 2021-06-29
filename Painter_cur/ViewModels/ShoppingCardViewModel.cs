using Painter_cur.Models;
using System.Collections.Generic;


namespace Painter_cur.ViewModels
{
    public class ShoppingCardViewModel
    {
        public List<Basket> BaskPositions { get; set; }
        public List<Product> BaskProducts { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalSum { get; set; }
    }

    public class ShoppingCartRemoveViewModel
    {
        public decimal TotalSum { get; set; }
        public int TotalCount { get; set; }
        public int PosCount { get; set; }
        public int DeleteP_art { get; set; }
    }
}
