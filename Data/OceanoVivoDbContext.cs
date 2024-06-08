using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OceanoVivo.Models;

namespace OceanoVivo.Data
{
    public class OceanoVivoDbContext : DbContext
    {
        public OceanoVivoDbContext(DbContextOptions<OceanoVivoDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Deteccao> Deteccoes { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<Ong> Ongs { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Situacao> Situacoes { get; set; }
        public DbSet<OngDeteccao> OngDeteccao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OngDeteccao>()
                .HasKey(od => new { od.OngId, od.DeteccaoId });

            modelBuilder.Entity<OngDeteccao>()
                .HasOne(od => od.Ong)
                .WithMany(o => o.OngDeteccoes)
                .HasForeignKey(od => od.OngId);

            modelBuilder.Entity<OngDeteccao>()
                .HasOne(od => od.Deteccao)
                .WithMany(d => d.OngDeteccoes)
                .HasForeignKey(od => od.DeteccaoId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Deteccoes)
                .WithOne(d => d.Usuario)
                .HasForeignKey(d => d.Id_Usuario);

            modelBuilder.Entity<Localizacao>()
                .HasMany(l => l.Deteccoes)
                .WithOne(d => d.Localizacao)
                .HasForeignKey(d => d.Id_Localizacao);

            modelBuilder.Entity<Especie>()
                .HasMany(e => e.Deteccoes)
                .WithOne(d => d.Especie)
                .HasForeignKey(d => d.Id_Especie);

            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Especies)
                .WithOne(e => e.Categoria)
                .HasForeignKey(e => e.Id_Categoria);

            modelBuilder.Entity<Situacao>()
                .HasMany(s => s.Especies)
                .WithOne(e => e.Situacao)
                .HasForeignKey(e => e.Id_Situacao);

            // Chamada ao método Seed para adicionar detecções pré-definidas
            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            // Adiciona uma detecção pré-definida ao iniciar o aplicativo
            modelBuilder.Entity<Deteccao>().HasData(
                new Deteccao
                {
                    Id_Deteccao = 1,
                    Url_Imagem = "https://exemplo.com/imagem.jpg",
                    Data_Deteccao = DateTime.Now,
                    Id_Usuario = 2, 
                    Id_Localizacao = 1, 
                    Id_Especie = 4, 
                }
            );
        }
    }
}
