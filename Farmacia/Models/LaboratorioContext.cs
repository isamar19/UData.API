using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Farmacia.Models
{
    public partial class LaboratorioContext : DbContext
    {
        public LaboratorioContext()
        {
        }

        public LaboratorioContext(DbContextOptions<LaboratorioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DatosClinico> DatosClinicos { get; set; } = null!;
        public virtual DbSet<Medicamento> Medicamentos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TABDTU1\\SQLEXPRESS;Database=Laboratorio;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatosClinico>(entity =>
            {
                entity.Property(e => e.Contraindicaciones).IsUnicode(false);

                entity.Property(e => e.Indicaciones).IsUnicode(false);

                entity.Property(e => e.Posologia).IsUnicode(false);

                entity.Property(e => e.Precauciones).IsUnicode(false);

                entity.HasOne(d => d.Medicamento)
                    .WithMany(p => p.DatosClinicos)
                    .HasForeignKey(d => d.MedicamentoId)
                    .HasConstraintName("FK__DatosClin__Medic__38996AB5");
            });

            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.Property(e => e.Composicion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FormaFarmaceutica)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
