using Microsoft.EntityFrameworkCore;

namespace Painter_cur.Models
{
    public partial class PainterContext: DbContext
    {
        public PainterContext(DbContextOptions<PainterContext> options) : base(options) { }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<Brush> Brushes { get; set; }
        public virtual DbSet<Implement> Implements { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderPosition> OrdersPositions { get; set; }
        public virtual DbSet<Paint> Paints { get; set; }
        public virtual DbSet<Paper> Papers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Technique> Techniques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Technique>()
                .HasKey(b => new { b.t_name, b.p_art });
            modelBuilder.Entity<OrderPosition>()
               .HasKey(b => new { b.o_code, b.p_art });
        }


    }
}
