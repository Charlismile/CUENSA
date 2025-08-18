using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CUENSA.Models.Entities.BdSicuensa;

public partial class DbContextSicuensa : DbContext
{
    public DbContextSicuensa()
    {
    }

    public DbContextSicuensa(DbContextOptions<DbContextSicuensa> options)
        : base(options)
    {
    }

    public virtual DbSet<TbClasificacion> TbClasificacion { get; set; }

    public virtual DbSet<TbInstalacion> TbInstalacion { get; set; }

    public virtual DbSet<TbSha1> TbSha1 { get; set; }

    public virtual DbSet<TbSha2> TbSha2 { get; set; }

    public virtual DbSet<TbSha3> TbSha3 { get; set; }

    public virtual DbSet<TbSha4> TbSha4 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbClasificacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TbClasif__3213E83F18AA53AC");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CodigoSha)
                .HasMaxLength(255)
                .HasColumnName("codigoSHA");
            entity.Property(e => e.CodigoShaId).HasColumnName("codigoSHA_id");
            entity.Property(e => e.DescripcionSha)
                .HasMaxLength(255)
                .HasColumnName("descripcionSHA");
            entity.Property(e => e.F6).HasMaxLength(255);
            entity.Property(e => e.InstalacionesMinsaCss)
                .HasMaxLength(255)
                .HasColumnName("instalacionesMinsaCss");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(255)
                .HasColumnName("observaciones");
        });

        modelBuilder.Entity<TbInstalacion>(entity =>
        {
            entity.HasKey(e => e.InstalacionId).HasName("PK__TbInstal__14A69352A613FA6C");

            entity.Property(e => e.InstalacionId)
                .ValueGeneratedNever()
                .HasColumnName("instalacion_id");
            entity.Property(e => e.ClasificacionCdSSha)
                .HasMaxLength(255)
                .HasColumnName("clasificacionCdS_SHA");
            entity.Property(e => e.ClasificacionCtasNacId).HasColumnName("clasificacionCtasNac_id");
            entity.Property(e => e.CodigoInstalacion).HasColumnName("codigoInstalacion");
            entity.Property(e => e.CodigoSha1)
                .HasMaxLength(255)
                .HasColumnName("codigoSHA1");
            entity.Property(e => e.CodigoSha2)
                .HasMaxLength(255)
                .HasColumnName("codigoSHA2");
            entity.Property(e => e.CodigoSha3)
                .HasMaxLength(255)
                .HasColumnName("codigoSHA3");
            entity.Property(e => e.CodigoSha4)
                .HasMaxLength(255)
                .HasColumnName("codigoSHA4");
            entity.Property(e => e.DependenciaInstalacion)
                .HasMaxLength(255)
                .HasColumnName("dependenciaInstalacion");
            entity.Property(e => e.DependenciaInstalacionId).HasColumnName("dependenciaInstalacion_id");
            entity.Property(e => e.NivelInstalacion)
                .HasMaxLength(255)
                .HasColumnName("nivelInstalacion");
            entity.Property(e => e.NivelInstalacionId).HasColumnName("nivelInstalacion_id");
            entity.Property(e => e.NombreInstalacion)
                .HasMaxLength(255)
                .HasColumnName("nombreInstalacion");
            entity.Property(e => e.NomenclaturaSha)
                .HasMaxLength(255)
                .HasColumnName("nomenclaturaSHA");
            entity.Property(e => e.TipoInstalacion)
                .HasMaxLength(255)
                .HasColumnName("tipoInstalacion");
            entity.Property(e => e.TipoInstalacionId).HasColumnName("tipoInstalacion_id");
            entity.Property(e => e.TitularidadInstalacion)
                .HasMaxLength(255)
                .HasColumnName("titularidadInstalacion");
            entity.Property(e => e.TitularidadInstalacionId).HasColumnName("titularidadInstalacion_id");
        });

        modelBuilder.Entity<TbSha1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TbSHA1__3213E83FF95D0D33");

            entity.ToTable("TbSHA1");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Codigo).HasMaxLength(255);
            entity.Property(e => e.InstalacionId).HasColumnName("instalacion_id");

            entity.HasOne(d => d.Instalacion).WithMany(p => p.TbSha1)
                .HasForeignKey(d => d.InstalacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbSHA1_TbInstalacion");
        });

        modelBuilder.Entity<TbSha2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TbSHA2__3213E83F04CF2314");

            entity.ToTable("TbSHA2");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Codigo).HasMaxLength(255);
            entity.Property(e => e.InstalacionId).HasColumnName("instalacion_id");
            entity.Property(e => e.Sha1Id).HasColumnName("sha1_id");

            entity.HasOne(d => d.Instalacion).WithMany(p => p.TbSha2)
                .HasForeignKey(d => d.InstalacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbSHA2_TbInstalacion");

            entity.HasOne(d => d.Sha1).WithMany(p => p.TbSha2)
                .HasForeignKey(d => d.Sha1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbSHA2_TbSHA1");
        });

        modelBuilder.Entity<TbSha3>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TbSHA3__3213E83F0356D792");

            entity.ToTable("TbSHA3");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Codigo).HasMaxLength(255);
            entity.Property(e => e.InstalacionId).HasColumnName("instalacion_id");
            entity.Property(e => e.Sha1Id).HasColumnName("sha1_id");
            entity.Property(e => e.Sha2Id).HasColumnName("sha2_id");

            entity.HasOne(d => d.Instalacion).WithMany(p => p.TbSha3)
                .HasForeignKey(d => d.InstalacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbSHA3_TbInstalacion");

            entity.HasOne(d => d.Sha1).WithMany(p => p.TbSha3)
                .HasForeignKey(d => d.Sha1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbSHA3_TbSHA1");

            entity.HasOne(d => d.Sha2).WithMany(p => p.TbSha3)
                .HasForeignKey(d => d.Sha2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbSHA3_TbSHA2");
        });

        modelBuilder.Entity<TbSha4>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TbSHA4__3213E83F051841FD");

            entity.ToTable("TbSHA4");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Codigo).HasMaxLength(255);
            entity.Property(e => e.InstalacionId).HasColumnName("instalacion_id");
            entity.Property(e => e.Sha1Id).HasColumnName("sha1_id");
            entity.Property(e => e.Sha2Id).HasColumnName("sha2_id");
            entity.Property(e => e.Sha3Id).HasColumnName("sha3_id");

            entity.HasOne(d => d.Instalacion).WithMany(p => p.TbSha4)
                .HasForeignKey(d => d.InstalacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbSHA4_TbInstalacion");

            entity.HasOne(d => d.Sha1).WithMany(p => p.TbSha4)
                .HasForeignKey(d => d.Sha1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbSHA4_TbSHA1");

            entity.HasOne(d => d.Sha2).WithMany(p => p.TbSha4)
                .HasForeignKey(d => d.Sha2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbSHA4_TbSHA2");

            entity.HasOne(d => d.Sha3).WithMany(p => p.TbSha4)
                .HasForeignKey(d => d.Sha3Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbSHA4_TbSHA3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
