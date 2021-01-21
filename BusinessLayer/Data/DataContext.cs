using System;
using System.Collections.Generic;
using System.Text;

using BusinessLayer.Model;

using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Data
{
    public partial class DataContext : DbContext
    {
        public virtual DbSet<Leverancier> Leverancier { get; set; }
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // ConnectionString www.connectionstrings.com
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-DI4L7OAA\SQLEXPRESS;Initial Catalog=db_ElecVerbruik_EF_YA;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leverancier>(entity =>
            {
                entity.ToTable("LEVERANCIER");

                entity.HasIndex(e => e.Naam, "IX_LEVERANCIER_NAME");

                entity.Property(e => e.Id)
                      .IsRequired()
                      .HasColumnName("LEVERANCIER_ID");

                entity.Property(e => e.Naam)
                      .IsRequired()
                      .HasMaxLength(1024)
                      .HasColumnName("NAAM");

                entity.Property(e => e.PrijsKHW)
                      .HasColumnType("decimal(18, 2)")
                      .HasColumnName("PRIJS");

                entity.Property(e => e.MaatschappelijkeZetel)
                      .IsRequired()
                      .HasColumnName("MAATSCHAPPELIJKE_ZETEL");

                entity.Property(e => e.ToekenningLeveringvergunning)
                      .HasColumnName("TOEKENNING_LEVERINGVERGUNNING");

                entity.Property(e => e.PublicatiebeslissingInBelGischStaatsblad)
                      .HasColumnName("PUBLICATIEBESLISSING_IN_BELGIE");

                entity.Property(e => e.AutoTimeCreation)
                    .HasColumnName("AUTO_TIME_CREATION")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.leverancier)
                    .WithMany(p => p._Leveranciel)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK_LEVERANCIER");
            });
        }
    }
}
