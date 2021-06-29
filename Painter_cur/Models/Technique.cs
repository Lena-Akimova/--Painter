using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Painter_cur.Models
{
    [Table("TechniquesProducts")]
    public class Technique
    {
        [Column("t_name")]
        public string t_name { get; set; }
        [Column("p_art")]
        public int p_art { get; set; }
    }
}
