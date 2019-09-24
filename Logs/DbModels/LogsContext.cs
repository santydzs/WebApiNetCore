using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Log.DbModels
{
    public partial class LogsContext : DbContext
    {
        public LogsContext()
        {
        }

        public LogsContext(DbContextOptions<LogsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Logs> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Logs;User Id=sa;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.Property(e => e.Controller).IsUnicode(false);

                entity.Property(e => e.LineaCodigo).IsUnicode(false);

                entity.Property(e => e.Mensaje).IsUnicode(false);
            });
        }
    }
}
