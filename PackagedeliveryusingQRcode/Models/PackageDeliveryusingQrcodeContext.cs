using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PackagedeliveryusingQRcode.Models;

public partial class PackageDeliveryusingQrcodeContext : DbContext
{
    public PackageDeliveryusingQrcodeContext()
    {
    }

    public PackageDeliveryusingQrcodeContext(DbContextOptions<PackageDeliveryusingQrcodeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-551PSOA;Database=PackageDeliveryusingQRcode;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__5F5D191261EC49F6");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyId)
                .ValueGeneratedNever()
                .HasColumnName("Company_Id");
            entity.Property(e => e.CompanyLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Company_Location");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__8CB286993077CE28");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("Customer_Id");
            entity.Property(e => e.CustomerLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Customer_Location");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.DeliveryId).HasName("PK__Delivery__AA55A039398F2C7B");

            entity.ToTable("Delivery");

            entity.Property(e => e.DeliveryId)
                .ValueGeneratedNever()
                .HasColumnName("Delivery_Id");
            entity.Property(e => e.DeliveryOrder).HasColumnName("Delivery_Order");
            entity.Property(e => e.DeliveryStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Delivery_Status");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

            entity.HasOne(d => d.DeliveryOrderNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.DeliveryOrder)
                .HasConstraintName("FK__Delivery__Delive__571DF1D5");

            entity.HasOne(d => d.Employee).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Delivery__Employ__5812160E");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__781134A1A49D22E9");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("Employee_Id");
            entity.Property(e => e.EmployeeFullName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Employee_FullName");
            entity.Property(e => e.EmployeeLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Employee_Location");
            entity.Property(e => e.EmployeeStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Employee_Status");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__F1E4607B911D7C01");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("Order_Id");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.DeliveryPartner).HasColumnName("Delivery_Partner");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Order_Status");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__6383C8BA");

            entity.HasOne(d => d.DeliveryPartnerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DeliveryPartner)
                .HasConstraintName("FK__Orders__Delivery__52593CB8");

            entity.HasOne(d => d.PackagesNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Packages)
                .HasConstraintName("FK__Orders__Packages__5165187F");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.PackageId).HasName("PK__Packages__B7FCB96AE9EE44A3");

            entity.Property(e => e.PackageId)
                .ValueGeneratedNever()
                .HasColumnName("Package_Id");
            entity.Property(e => e.DeliveryLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Delivery_Location");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
