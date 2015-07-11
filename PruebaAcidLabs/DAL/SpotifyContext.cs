using PruebaAcidLabs.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PruebaAcidLabs.DAL
{
    public class SpotifyContext : DbContext
    {
        public SpotifyContext()
            : base("SpotifyContext")
        {
        }
        
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Album> Albumes { get; set; }
        public DbSet<Pista> Pistas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}