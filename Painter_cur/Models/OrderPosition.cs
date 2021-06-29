
using System.ComponentModel.DataAnnotations.Schema;

namespace Painter_cur.Models
{
    [Table("OrderPositions")]
    public class OrderPosition
    {
        [Column("o_code")]
        public int o_code { get; set; }
        [Column("p_art ")]
        public int p_art { get; set; }
        [Column("quantity")]
        public int quantity { get; set; }
    }
}
