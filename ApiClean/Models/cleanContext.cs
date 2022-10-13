using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiClean.Models
{
    public partial class cleanContext : DbContext
    {
        public cleanContext()
        {
        }

        public cleanContext(DbContextOptions<cleanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<TopProduct> TopProducts { get; set; } = null!;
        public virtual DbSet<Venta> Ventas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("server=localhost; database =clean; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproductos)
                    .HasName("PK__Producto__D63049743158B902");

                entity.Property(e => e.Idproductos).HasColumnName("IDProductos");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TopProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("topProducts");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            /*modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.Idventas)
                    .HasName("PK__Ventas__A1991031D45A9790");

                entity.Property(e => e.Idventas).HasColumnName("IDVentas");

                entity.Property(e => e.Idproductos).HasColumnName("IDProductos");

                entity.HasOne(d => d.IdproductosNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Idproductos)
                    .HasConstraintName("FK__Ventas__IDProduc__267ABA7A");
            });*/

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
