using Microsoft.EntityFrameworkCore;

namespace CatGifBackend.Context
{
    public class CatGifContext: DbContext
    {
        public CatGifContext(DbContextOptions<CatGifContext> options) : base(options) 
        {
            
        }

        public DbSet<Historial_catgif> Historial_catgif { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Historial_catgif>().ToTable("historial_catgif"); // Nombre real de la tabla en la BD
        }
    }
}
