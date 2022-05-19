using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HuertoUrbano.Models.dbModels
{
    public partial class HuertoUrbanoContext : DbContext
    {
        public HuertoUrbanoContext()
        {
        }

        public HuertoUrbanoContext(DbContextOptions<HuertoUrbanoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LugarPlantado> LugarPlantados { get; set; }
        public virtual DbSet<Publicación> Publicacións { get; set; }
        public virtual DbSet<Temporadum> Temporada { get; set; }
        public virtual DbSet<TipoHortaliza> TipoHortalizas { get; set; }
        public virtual DbSet<Vpublicación> Vpublicacións { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Publicación>(entity =>
            {
                entity.HasOne(d => d.LugarPlantadoNavigation)
                    .WithMany(p => p.Publicacións)
                    .HasForeignKey(d => d.LugarPlantado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publicación_LugarPlantado");

                entity.HasOne(d => d.TemporadaNavigation)
                    .WithMany(p => p.Publicacións)
                    .HasForeignKey(d => d.Temporada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publicación_Temporada");

                entity.HasOne(d => d.TipoHortalizaNavigation)
                    .WithMany(p => p.Publicacións)
                    .HasForeignKey(d => d.TipoHortaliza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publicación_TipoHortaliza");
            });

            modelBuilder.Entity<Vpublicación>(entity =>
            {
                entity.ToView("VPublicación");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
