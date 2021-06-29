using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Painter_cur.Models
{
    ///<summary>
    ///Класс-оболочка для таблицы в бд
    ///</summary>
    [Table("Products")]
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("p_art")]
        public int P_art { get; set; }

        [DisplayName("Категория")]
        [Column("p_categ")]
        public string P_categ { get; set; }

        [Required(ErrorMessage = "Укажите название товара!")]
        [DisplayName("Наименование")]
        [StringLength(160, ErrorMessage ="Длина дб не больше 160 символов")]
        [Column("p_name")]
        public string P_name { get; set; }

        [Required(ErrorMessage = "Укажите цену товара!")]
        [DisplayName("Цена, руб")]
        [Range(0.01, Double.MaxValue,
            ErrorMessage = "Цена должна быть больше 0.01 руб")]
        [Column("p_price")]
        public decimal P_price { get; set; }

        [Required(ErrorMessage = "Укажите производителя!")]
        [DisplayName("Производитель")]
        [Column("p_prod")]
        public string P_prod { get; set; }

        [DisplayName("Изображение")]
        [Column("p_img")]
        public string P_img { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ProductRepository : IRepository<Product>
    {
        private List<Product> cach;
        private List<Technique> tcach;
        private PainterContext _cont;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public ProductRepository(PainterContext _context)
        {
            if (_context == null)
            {
                this.cach = null;
                this.tcach = null;
            }
            else
            {
                _cont = _context;
                ReLoad();
            }
        }

        public void ReLoad() {
            _cont.Products.Load();
            _cont.Techniques.Load();
            this.cach = _cont.Products.Local.ToList();
            this.tcach = _cont.Techniques.Local.ToList();

        }

        public void Save()
        {
            _cont.SaveChanges();
        }

        public void Create(Product prod)
        {
            if (_cont == null) return;
            _cont.Products.Add(prod);
            Save();
        }

        public void CreateTech(Technique te)
        {
            if (_cont == null) return;
            _cont.Techniques.Add(te);
            Save();
        }



        public void Update(Product prod)
        {
            if (_cont == null) return;
            var UpdEnt = _cont.Products.FirstOrDefault(x => x.P_art ==prod.P_art);
            UpdEnt.P_name = prod.P_name;
            UpdEnt.P_price = prod.P_price;
            UpdEnt.P_prod = prod.P_prod;
            if (prod.P_img!=null)
                UpdEnt.P_img = prod.P_img;
            Save();
        }

        public void UpdateTech(string tech, int part)
        {
            if (_cont == null) return;

            var delt = _cont.Techniques.FirstOrDefault(x => x.p_art == part);
            if (delt != null)
            {
                _cont.Techniques.Remove(delt);
                Save();
            }
            _cont.Techniques.Add(new Technique() { p_art = part, t_name = tech });
            Save();
        }


        public void Delete(int id)
        {
            if (_cont == null) return;
            var EntDel = _cont.Products.FirstOrDefault(x => x.P_art == id);
            switch (EntDel.P_categ)
            {
                case "Paints":
                    PaintRepository repos = new PaintRepository(_cont);
                    repos.Delete(id);
                    break;
                case "Brushes":
                    BrushRepository repos1 = new BrushRepository(_cont);
                    repos1.Delete(id);
                    break;
                case "Papers":
                    PaperRepository repos2 = new PaperRepository(_cont);
                    repos2.Delete(id);
                    break;
                case "Implements":
                    ImplementRepository repos3 = new ImplementRepository(_cont);
                    repos3.Delete(id);
                    break;
            }
            var delt = _cont.Techniques.FirstOrDefault(x => x.p_art == id);
            if (delt != null)
            {
                _cont.Techniques.Remove(delt);
                Save();
            }

            _cont.Products.Remove(EntDel);
            Save();
        }
        /// <summary>
        /// Метод для получения товара по номеру
        /// </summary>
        /// <param name="id">id товара</param>
        /// <returns>Экземпляр <c>товара</c> или <c>null</c></returns>
        public Product Get(int id)
        {
            if (cach == null) { return null; }
            return cach.Where(i => i.P_art == id).FirstOrDefault();
        }

        public string GetTech(int id)
        {
            if (cach == null) { return null; }  
            return tcach.Where(t => t.p_art == id).Select(p=>p.t_name).FirstOrDefault();
        }



        /// <summary>
        /// Получение списка продуктов
        /// </summary>
        /// <overload>Полный список продуктов из бд</overload>
        /// <returns>Список продуктов</returns>
        public List<Product> GetList()
        {
            return cach;
        }
        public List<string> GetListCategories()
        {
            var cat =cach.Select( p=>p.P_categ).Distinct();
            return cat.ToList();
        }

        public List<string> GetListTech()
        {
            var t = tcach.Select(p => p.t_name).Distinct();
            return t.ToList();
        }
       

        public List<List<Product>> TableView(List<Product> pr, int col=4)
        {
            List<List<Product>> prod = new List<List<Product>>();
            int j = 0;
            prod.Add(new List<Product>());
            for (int i = 0; i < pr.Count; i++)
            {
                prod[j].Add(pr[i]);
                if (i % col == 0 && i != 0)
                {
                    j++;
                    prod.Add(new List<Product>());
                }
            }
            prod[prod.Count - 1].Add(prod[0][prod[0].Count - 1]);
            prod[0].Remove(prod[0][prod[0].Count - 1]);
            return prod;
        }

        /// <summary>
        /// Получение списка продуктов
        /// </summary>
        /// <param name="categ">Категория продукта</param>
        /// <overload>Список продуктов определенной категории</overload>
        /// <returns>Список продуктов</returns>
        public List<Product> GetList(string categ)
        {
            if (cach == null) { return null; }
            return cach.Where(x => x.P_categ == categ).ToList();
        }

        public List<Product> GetListProdOfTech(string tech)
        {
            if (tcach == null || tech=="") { return null; }
            var results = tcach.Where(t => t.t_name==tech)
                            .DefaultIfEmpty()
                            .Join(cach,
                                  t => t.p_art,
                                  p => p.P_art,
                                  (t, p) => p).ToList();
            return results;
        }

        public List<Product> GetTopSellingProducts()
        {
            var gr = _cont.OrdersPositions.GroupBy(p => p.p_art).Select(g => new { p_art = g.Key, count = g.Count() });
            double av = gr.Average(p => p.count);
            var top = gr.Where(x => x.count > av).OrderByDescending(g => g.count).ToList();
            var pr = top.Join(GetList(),
                        t => t.p_art,
                        p => p.P_art,
                        (t, p) => p).ToList();
            return pr;
        }

        public bool HasKonkr(Product pr) {
            var k = (from pai in _cont.Paints
                    from pap in _cont.Papers
                    from br in _cont.Brushes
                    from i in _cont.Implements
                    from p in _cont.Products
                    where pai.p_art == pr.P_art && p.P_art == pai.p_art ||
                          pap.p_art == pr.P_art && p.P_art == pap.p_art ||
                          i.p_art == pr.P_art && p.P_art == i.p_art ||
                          br.p_art == pr.P_art && p.P_art == br.p_art
                    select p).FirstOrDefault();
            if (k != null)
                return true;
            return false;
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

