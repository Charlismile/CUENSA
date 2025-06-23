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

    public virtual DbSet<Clasificacion> Clasificacion { get; set; }

    public virtual DbSet<Instalacion> Instalacion { get; set; }

    public virtual DbSet<Sha1> Sha1 { get; set; }

    public virtual DbSet<Sha2> Sha2 { get; set; }

    public virtual DbSet<Sha3> Sha3 { get; set; }

    public virtual DbSet<Sha4> Sha4 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clasificacion>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CodigoSha)
                .HasMaxLength(255)
                .HasColumnName("CodigoSHA");
            entity.Property(e => e.CodigoShaId).HasColumnName("CodigoSHA_Id");
            entity.Property(e => e.DescripciónSha)
                .HasMaxLength(255)
                .HasColumnName("Descripción SHA ");
            entity.Property(e => e.F6).HasMaxLength(255);
            entity.Property(e => e.InstalacionesMinsaCssPanamá)
                .HasMaxLength(255)
                .HasColumnName("Instalaciones MINSA - CSS Panamá");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(255)
                .HasColumnName("Observaciones ");
        });

        modelBuilder.Entity<Instalacion>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ClasificacionCdSSha)
                .HasMaxLength(255)
                .HasColumnName("clasificacionCdS-SHA");
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
            entity.Property(e => e.InstalacionSalud)
                .HasMaxLength(255)
                .HasColumnName("instalacionSalud");
            entity.Property(e => e.InstalacionSaludId).HasColumnName("instalacionSalud_Id");
            entity.Property(e => e.NivelInstalacion)
                .HasMaxLength(255)
                .HasColumnName("nivelInstalacion");
            entity.Property(e => e.NivelInstalacionId).HasColumnName("nivelInstalacion_id");
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

        modelBuilder.Entity<Sha1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SHA1");

            entity.Property(e => e.Codigo).HasMaxLength(255);
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Sha2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SHA2");

            entity.Property(e => e.Codigo).HasMaxLength(255);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Sha1Id).HasColumnName("sha1_id");
        });

        modelBuilder.Entity<Sha3>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SHA3");

            entity.Property(e => e.Codigo).HasMaxLength(255);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Sha1Id).HasColumnName("sha1_id");
            entity.Property(e => e.Sha2Id).HasColumnName("sha2_id");
        });

        modelBuilder.Entity<Sha4>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SHA4");

            entity.Property(e => e.Codigo).HasMaxLength(255);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Sha1Id).HasColumnName("sha1_id");
            entity.Property(e => e.Sha2Id).HasColumnName("sha2_id");
            entity.Property(e => e.Sha3Id).HasColumnName("sha3_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
