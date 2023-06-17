using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RegistroUsuarios.Models;

namespace RegistroUsuarios.Models;

public partial class DbtestContext : DbContext
{
    public DbtestContext()
    {
    }

    public DbtestContext(DbContextOptions<DbtestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Empleado> Empleado { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__5B65BF977B5B8FC4");

            entity.ToTable("USUARIO");

            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.DPI)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.NombreCompleto)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        });

      
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<RegistroUsuarios.Models.Palindromo> Palindromo { get; set; }
}
