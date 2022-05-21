﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoreApi.DAL.Models
{
    public partial class StoreContext : DbContext
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApiLog> ApiLogs { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-01TMK3G;Database=Store;User=developer;Password=123456789");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiLog>(entity =>
            {
                entity.ToTable("ApiLog");

                entity.Property(e => e.Body).IsUnicode(false);

                entity.Property(e => e.EndPoint)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.QueryParameters).IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.Name, e.Description, e.Category, e.CreationDate }, "index_Products");

                entity.Property(e => e.Category)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
