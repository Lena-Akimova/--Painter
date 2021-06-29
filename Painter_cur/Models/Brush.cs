using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Painter_cur.Models
{
    [Table("Brushes")]
    public class Brush
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("p_art")]
        public int p_art { get; set; }
        [Column("b_mater")]
        public string b_mater { get; set; }
        [Column("b_numb")]
        public int b_numb { get; set; }
        [Column("b_form")]
        public string b_form { get; set; }
    }

    public class BrushRepository : IRepository<Brush>
    {
        private List<Brush> cach;
        private PainterContext _cont;

        public BrushRepository(PainterContext _context)
        {
            _cont = _context;
            _cont.Brushes.Load();
            cach = _cont.Brushes.Local.ToList();
        }


        public void Save()
        {
            _cont.SaveChanges();
        }

        public void Create(Brush prod)
        {
            if (_cont == null) return;
            _cont.Brushes.Add(prod);
            Save();
        }

        public void Update(Brush prod)
        {
            if (_cont == null) return;
            var UpdEnt = _cont.Brushes.FirstOrDefault(x => x.p_art == prod.p_art);
            UpdEnt.p_art = prod.p_art;
            UpdEnt.b_numb = prod.b_numb;
            UpdEnt.b_form = prod.b_form;
            UpdEnt.b_mater = prod.b_mater;
            Save();
        }

        public void Delete(int id)
        {
            if (_cont == null) return;
            var EntDel = _cont.Brushes.FirstOrDefault(x => x.p_art == id);
            if (EntDel != null)
            {
                _cont.Brushes.Remove(EntDel);
                Save();
            }
            return;
        }

        public Brush Get(int id)
        {
            if (_cont == null) return null;
            return cach.Where(i => i.p_art == id).FirstOrDefault();
        }
        public List<Brush> GetList()
        {
            return cach;
        }

        public List<List<Brush>> TableView(List<Brush> pr, int col = 4)
        {
            List<List<Brush>> prod = new List<List<Brush>>();
            int j = 0;
            prod.Add(new List<Brush>());
            for (int i = 0; i < pr.Count; i++)
            {
                prod[j].Add(pr[i]);
                if (i % col == 0 && i != 0)
                {
                    j++;
                    prod.Add(new List<Brush>());
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
