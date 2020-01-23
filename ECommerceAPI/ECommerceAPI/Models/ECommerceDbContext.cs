using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Perfil>().ToTable("Perfil");

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasOne(d => d.Perfil).WithMany(p => p.Usuarios).HasForeignKey(d => d.IdPerfil);
                entity.ToTable("Usuario");
            });
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasOne(c => c.UsuarioCriador).WithMany(u => u.Produtos).HasForeignKey(p => p.IdUsuario);
                entity.ToTable("Produto");
            });
        }
    }
}