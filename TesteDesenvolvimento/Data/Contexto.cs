using Microsoft.EntityFrameworkCore;
using TesteDesenvolvimento.Models;

namespace TesteDesenvolvimento.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasIndex(b => b.NomeUsuario)
                .IsUnique();
        }
    

    public Contexto(DbContextOptions<Contexto> options) : base(options)     
        {

        }
    }
}
