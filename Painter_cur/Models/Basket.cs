using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;



namespace Painter_cur.Models
{
    [Table("BasketPositions")]
    public class Basket
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("pos_code")]
        public int pos_code { get; set; }

        [Column("b_code")]
        public string b_code { get; set; }
        
        [Column("p_art")]
        public int p_art { get; set; }
        [Column("quantity")]
        public int quantity { get; set; }
        [Column("b_date")]
        public DateTime b_date { get; set; } = DateTime.Now;
    }



    public partial class ShoppingBask
    {

        private PainterContext _cont;

        string _b_code { get; set; }

        public void SetId(IHttpContextAccessor context)
        {
            _b_code = GetCartId(context);
        }

        public ShoppingBask(PainterContext _context)
        {
            _cont = _context;
        }


        public void Save()
        {
            _cont.SaveChanges();
        }

        public void Create(Basket b_pos)
        {
            if (_cont == null) return;
            _cont.Baskets.Add(b_pos);
            Save();
        }


        public void AddToBask(int pr, int kol = 1)
        {
            var pos = GetPos(pr);
            if (pos == null)
            {
                Create(new Basket { b_code = _b_code, p_art = pr, b_date = DateTime.Now, quantity = kol });
            }
            else {
                pos.quantity += kol;
                Update(pos);
            }
        }


        public void Update(Basket pos)
        {
            if (_cont == null) return;
            var UpdEnt = _cont.Baskets.FirstOrDefault(x => x.b_code == pos.b_code && x.p_art == pos.p_art);
            UpdEnt.quantity = pos.quantity;
            Save();
        }

        public void Delete(int p_code)
        {
            if (_cont == null) return;
            var EntDel = _cont.Baskets.FirstOrDefault(x => x.p_art == p_code && x.b_code == _b_code);
            _cont.Baskets.Remove(EntDel);
            Save();
        }

        public void Delete(string bb_code,int p_code)
        {
            if (_cont == null) return;
            var EntDel = _cont.Baskets.FirstOrDefault(x => x.p_art == p_code && x.b_code == bb_code);
            _cont.Baskets.Remove(EntDel);
            Save();
        }

        public void ClearBask()
        {
            if (_cont == null) return;
            var poss = _cont.Baskets.Where(x => x.b_code == _b_code);
            foreach (var p in poss) {
                _cont.Baskets.Remove(p);
            }
            Save();
        }

        public int Reduce(int p_code)
        {
            if (_cont == null) return -1;
            int kol = 0;
            var pos = GetPos(p_code);
            if (pos != null)
            {
                if (pos.quantity > 1)
                {
                    kol = --pos.quantity;
                    Update(pos);
                }
                else
                {
                    Delete(p_code);
                }
            }
            else return -1;

            return kol;
        }


        public int Increase(int p_code)
        {
            if (_cont == null) return -1;
            
            var pos = GetPos(p_code);
            int kol;
            if (pos != null)
            {
                    kol = ++pos.quantity;
                    Update(pos);
            }
            else return -1;

            return kol;
        }



        public Basket GetPos(int p_code)
        {
            return _cont.Baskets.Where(i => i.b_code == _b_code && i.p_art == p_code).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            var bas=GetBasket();
            var results = bas.Join(_cont.Products,
                      b => b.p_art,
                      p => p.P_art,
                      (t, p) => p).ToList();
            return results;
        }


        public List<Basket> GetBasket( )
        {
            return _cont.Baskets.Where(x=>x.b_code==_b_code).ToList();
        }

        public int TotalCount() 
        {
            int k = 0;
            var b = GetBasket();
            if (b != null)
            {
               k = b.Sum(x => x.quantity);
            }
           
            return k;
        }


        public decimal TotalSum()
        {
            decimal k = 0;
            var b = GetBasket();
            if (b != null)
            {
                k = b.Sum(x => x.quantity *_cont.Products.Where(p=>p.P_art==x.p_art).FirstOrDefault().P_price);
            }
            return k;
        }

        public int CreateOrderPositions(Order ord)
        {
            var pos = GetBasket(); 
            if (pos != null)
            {
                foreach (var p in pos) {
                    _cont.OrdersPositions.Add(new OrderPosition { p_art = p.p_art, o_code = ord.o_code, quantity = p.quantity });
                }
                Save();
                ClearBask();
            }
            return ord.o_code;
        }

        public string GetCartId(IHttpContextAccessor context)
        {
            //.AspNetSession
            if (context.HttpContext.Session.GetString("CartId") == null)
            {

                if (!string.IsNullOrWhiteSpace( context.HttpContext.User.Identity.Name))
                {
                    context.HttpContext.Session.SetString("CartId", context.HttpContext.User.Identity.Name);
                }
                else
                {
                    var tempCartId = Guid.NewGuid();
                    context.HttpContext.Session.SetString("CartId", tempCartId.ToString());
                }
            }
            return context.HttpContext.Session.GetString("CartId");
        }

        public void BindCart(string userName)
        {
                var pos = GetBasket();

                _b_code = userName;
                var ex_pos = GetBasket();

                foreach (var p in pos)
                {
                    if (ex_pos.Any(x => x.p_art == p.p_art))
                    {
                        var foradd = GetPos(p.p_art);
                        foradd.quantity += p.quantity;
                        Update(foradd);
                        Delete(p.b_code, p.p_art);
                    }
                    else
                    {
                        p.b_code = userName;
                    }
                }
                Save();
           
        }

    }
}
