using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace apitestingDatabase.Models;

public partial class ApitestingDatabaseContext : DbContext
{
    public ApitestingDatabaseContext()
    {
    }

    public ApitestingDatabaseContext(DbContextOptions<ApitestingDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserEducationDetail> UserEducationDetails { get; set; }

    public virtual DbSet<UserWork> UserWorks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-6UR01QA\\SQLEXPRESS;Database=apitestingDatabase;trusted_connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserDeta__3213E83F5557BC0A");

            entity.ToTable("UserDetail");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<UserEducationDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserEduc__3213E83FF0BE6E3F");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Degree)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("degree");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PassOut)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("passOut");
        });

        modelBuilder.Entity<UserWork>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserWork__3213E83F177F351C");

            entity.ToTable("UserWork");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Company)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("company");
            entity.Property(e => e.Job)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("job");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
