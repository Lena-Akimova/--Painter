using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Painter_cur.Models
{
    [Table("Paints")]
    public class Paint
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("p_art")]
        public int p_art { get; set; }
        [Column("pai_type")]
        public string pai_type { get; set; }
        [Column("pai_color")]
        public string pai_color { get; set; }
        [Column("pai_volume")]
        public int pai_volume { get; set; }
        [Column("pai_quant")]
        public int pai_quant { get; set; }

    }

    public class PaintRepository : IRepository<Paint>
    {
        private List<Paint> cach;
        private PainterContext _cont;

        public PaintRepository(PainterContext _context)
        {
            _cont = _context;
            _cont.Paints.Load();
            cach = _cont.Paints.Local.ToList();
        }

        public void Save()
        {
            _cont.SaveChanges();
        }

        public void Create(Paint prod)
        {
            if (_cont == null) return;
             _cont.Paints.Add(prod);
            Save();
        }

        public void Update(Paint prod)
        {
            if (_cont == null) return;
            var UpdEnt = _cont.Paints.FirstOrDefault(x => x.p_art == prod.p_art);
            UpdEnt.p_art = prod.p_art;
            UpdEnt.pai_type = prod.pai_type;
            UpdEnt.pai_color = prod.pai_color;
            UpdEnt.pai_quant = prod.pai_quant;
            UpdEnt.pai_volume = prod.pai_volume;
            Save();
        }

        public void Delete(int id)
        {
            if (_cont == null) return;
            var EntDel = _cont.Paints.FirstOrDefault(x => x.p_art == id);
            if (EntDel != null)
            {
                _cont.Paints.Remove(EntDel);
                Save();
            }
            return;
        }

        public Paint Get(int id)
        {
            if (_cont == null) return null;
            return cach.Where(i => i.p_art == id).FirstOrDefault();
        }

        public List<Paint> GetList()
        {
            return cach;
        }

        public List<List<Paint>> TableView(List<Paint> pr, int col = 4)
        {
            List<List<Paint>> prod = new List<List<Paint>>();
            int j = 0;
            prod.Add(new List<Paint>());
            for (int i = 0; i < pr.Count; i++)
            {
                prod[j].Add(pr[i]);
                if (i % col == 0 && i != 0)
                {
                    j++;
                    prod.Add(new List<Paint>());
                }
            }
            prod[prod.Count - 1].Add(prod[0][prod[0].Count - 1]);
            prod[0].Remove(prod[0][prod[0].Count - 1]);
            return prod;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}


