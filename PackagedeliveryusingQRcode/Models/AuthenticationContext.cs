using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PackagedeliveryusingQRcode.Models;

public partial class AuthenticationContext : DbContext
{
    public AuthenticationContext()
    {
    }

    public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Authentication> Authentications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-551PSOA;Database=Authentication;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Authentication>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Authenti__CB9A1CFF962B5BC3");

            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("userId");
            entity.Property(e => e.Jwttoken)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Roles)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
