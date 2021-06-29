using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Painter_cur.Models
{
    [Table("Implements")]
    public class Implement
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("p_art")]
        public int p_art { get; set; }
        [Column("i_type")]
        public string i_type { get; set; }
    }

    public class ImplementRepository : IRepository<Implement>
    {
        private List<Implement> cach;
        private PainterContext _cont;

        public ImplementRepository(PainterContext _context)
        {
            _cont = _context;
            _cont.Implements.Load();
            cach = _cont.Implements.Local.ToList();
        }


        public void Save()
        {
            _cont.SaveChanges();
        }

        public void Create(Implement prod)
        {
            if (_cont == null) return;
            _cont.Implements.Add(prod);
            Save();
        }

        public void Update(Implement prod)
        {
            if (_cont == null) return;
            var UpdEnt = _cont.Implements.FirstOrDefault(x => x.p_art == prod.p_art);
            UpdEnt.p_art = prod.p_art;
            UpdEnt.i_type = prod.i_type;
            Save();
        }

        public void Delete(int id)
        {
            if (_cont == null) return;
            var EntDel = _cont.Implements.FirstOrDefault(x => x.p_art == id);
            if (EntDel != null)
            {
                _cont.Implements.Remove(EntDel);
                Save();
            }
            return;
        }

        public Implement Get(int id)
        {
            if (_cont == null) return null;
            return cach.Where(i => i.p_art == id).FirstOrDefault();
        }

        public List<Implement> GetList()
        {
            return cach;
        }

        public List<List<Implement>> TableView(List<Implement> pr, int col = 4)
        {
            List<List<Implement>> prod = new List<List<Implement>>();
            int j = 0;
            prod.Add(new List<Implement>());
            for (int i = 0; i < pr.Count; i++)
            {
                prod[j].Add(pr[i]);
                if (i % col == 0 && i != 0)
                {
                    j++;
                    prod.Add(new List<Implement>());
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
