using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Negocio.DbModels
{
    public partial class MockGestionContext : DbContext
    {
        public MockGestionContext()
        {
        }

        public MockGestionContext(DbContextOptions<MockGestionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Profesional> Profesional { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<TipoProfesional> TipoProfesional { get; set; }

        // Unable to generate entity type for table 'dbo.Equipo'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-0LO0DCC\\SQLEXPRESS;Database=MockGestion;User Id=sa;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Profesional>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NombreApelldo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoId).HasColumnName("TipoID");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Profesional)
                    .HasForeignKey(d => d.TipoId)
                    .HasConstraintName("FK__Profesion__TipoI__3B75D760");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoProfesional>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Señority)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
