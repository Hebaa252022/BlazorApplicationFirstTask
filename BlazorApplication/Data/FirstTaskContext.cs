using System;
using System.Collections.Generic;
using BlazorApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorApplication.Data
{
    public partial class FirstTaskContext : DbContext
    {
        public virtual DbSet<CustomerTable> CustomerTables { get; set; }
        public virtual DbSet<ProductTable> ProductTabes { get; set; }

        public FirstTaskContext()
        {
        }

        public FirstTaskContext(DbContextOptions<FirstTaskContext> options) : base(options)
        {
        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-TTPBP3I\\SQLEXPRESS;Initial Catalog=FirstTask;Integrated Security=True;Trust Server Certificate=True;Command Timeout=300");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerTable>(entity =>
            {
                entity.HasKey(e => e.CustomerID);

                entity.ToTable("CustomerTable");

                entity.Property(e => e.CustomerID).ValueGeneratedNever();

                entity.Property(e => e.Cus_Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cus_ProductNavigation)
                    .WithMany(p => p.CustomerTables)
                    .HasForeignKey(d => d.Cus_Product)
                    .HasConstraintName("FK_CustomerTable_ProductTabe");
            });

            modelBuilder.Entity<ProductTable>(entity =>
            {
                entity.HasKey(e => e.ProductID);

                entity.ToTable("ProductTabe");

                entity.Property(e => e.ProColor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
