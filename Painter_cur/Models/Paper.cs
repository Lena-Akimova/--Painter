using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Painter_cur.Models
{
    [Table("Papers")]
    public class Paper
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("p_art")]
        public int p_art { get; set; }
        [Column("pap_type")]
        public string pap_type { get; set; }
        [Column("pap_format")]
        public string pap_format { get; set; }
        [Column("pap_density")]
        public double pap_density { get; set; }
    }

    public class PaperRepository : IRepository<Paper>
    {
        private List<Paper> cach;
        private PainterContext _cont;

        public PaperRepository(PainterContext _context)
        {
            _cont = _context;
            _cont.Papers.Load();
            cach = _cont.Papers.Local.ToList();
        }


        public void Save()
        {
            _cont.SaveChanges();
        }

        public void Create(Paper prod)
        {
            if (_cont == null) return;
            _cont.Papers.Add(prod);
            Save();
        }

        public void Update(Paper prod)
        {
            if (_cont == null) return;
            var UpdEnt = _cont.Papers.FirstOrDefault(x => x.p_art == prod.p_art);
            UpdEnt.p_art = prod.p_art;
            UpdEnt.pap_type = prod.pap_type;
            UpdEnt.pap_format = prod.pap_format;
            UpdEnt.pap_density = prod.pap_density;
            Save();
        }

        public void Delete(int id)
        {
            if (_cont == null) return;
            var EntDel = _cont.Papers.FirstOrDefault(x => x.p_art == id);
            if (EntDel != null)
            {
                _cont.Papers.Remove(EntDel);
                Save();
            }
            return;
        }

        public Paper Get(int id)
        {
            if (_cont == null) return null;
            return cach.Where(i => i.p_art == id).FirstOrDefault();
        }

        public List<Paper> GetList()
        {
            return cach;
        }

        public List<List<Paper>> TableView(List<Paper> pr, int col = 4)
        {
            List<List<Paper>> prod = new List<List<Paper>>();
            int j = 0;
            prod.Add(new List<Paper>());
            for (int i = 0; i < pr.Count; i++)
            {
                prod[j].Add(pr[i]);
                if (i % col == 0 && i != 0)
                {
                    j++;
                    prod.Add(new List<Paper>());
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
