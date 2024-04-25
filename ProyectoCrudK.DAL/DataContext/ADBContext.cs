using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoCrudK.Models;

namespace ProyectoCrudK.DAL.DataContext
{
    public partial class ADBContext : DbContext
    {
        public ADBContext()
        {
        }

        public ADBContext(DbContextOptions<ADBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersonaK> PersonaKs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonaK>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PersonaK");

                entity.Property(e => e.ApellidoK)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusK)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimientoK).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NombreK)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SueldoK).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
