using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Painter_cur.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("o_code")]
        public int o_code { get; set; }
        [Column("o_date")]
        public DateTime o_date { get; set; } = DateTime.Now;
        [Column("o_delivery")]
        public string o_delivery { get; set; }
        [Column("c_code")]
        public int c_code { get; set; }
    }

    public class OrderRepository : IRepository<Order>
    {
        private PainterContext _cont;

        public OrderRepository(PainterContext _context)
        {
            _cont = _context;
        }


        public void Save()
        {
            _cont.SaveChanges();
        }

        public void Create(Order or)
        {
            if (_cont == null) return;
            _cont.Orders.Add(or);
            Save();
        }



        public void Update(Order Order)
        {
            if (_cont == null) return;
            var UpdEnt = _cont.Orders.FirstOrDefault(x => x.o_code == Order.o_code);
            UpdEnt.c_code = Order.c_code;
            UpdEnt.o_date = Order.o_date;
            UpdEnt.o_delivery = Order.o_delivery;
            Save();
        }


        public void Delete(int id)
        {
            if (_cont == null) return;
            var EntDel = _cont.Orders.FirstOrDefault(x => x.o_code == id);
            _cont.Orders.Remove(EntDel);
            Save();
        }

        public Order Get(int id)
        {
            if (_cont == null) { return null; }
            Order c = _cont.Orders.Where(i => i.o_code == id).FirstOrDefault();
            return c;
        }

        public Order Get(int id_cl, DateTime data)
        {
            if (_cont == null) { return null; }
            Order c = _cont.Orders.Where(i => i.c_code == id_cl && i.o_date==data).FirstOrDefault();
            return c;
        }


        public List<Order> GetList(int cl_c)
        {
            if (_cont == null) { return null; }
            return _cont.Orders.Where(i => i.c_code == cl_c).OrderByDescending(x => x.o_date).ToList();
        }

        public List<Order> GetList()
        {
            if (_cont == null) { return null; }
            return _cont.Orders.ToList();
        }

        public List<OrderPosition> GetPositions(Order o) {
            return _cont.OrdersPositions.Where(x=>x.o_code==o.o_code).ToList();
        }

        public int Count(Order o) {
            int k = 0;
            
            var p = GetPositions(o);
            if (p != null)
            {
                k = p.Sum(x => x.quantity);
            }
            return k;
        }

        public decimal Sum(Order o)
        {
            decimal k = 0;
            var p = GetPositions(o);
            if (p != null)
            {
                k = p.Sum(x => x.quantity * _cont.Products.Where(p => p.P_art == x.p_art).FirstOrDefault().P_price);
            }
            return k;
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }



}
