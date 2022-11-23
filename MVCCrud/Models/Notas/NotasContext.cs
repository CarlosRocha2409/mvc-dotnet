using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCCrud.Models.Notas;

public partial class NotasContext : DbContext
{
    public NotasContext()
    {
    }

    public NotasContext(DbContextOptions<NotasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Notum> Nota { get; set; }

    public virtual DbSet<ViewNota> ViewNotas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:LocalDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Notum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nota__3214EC27B09E081A");

            entity.HasIndex(e => e.Carnet, "UQ__Nota__5E387B4D5F86AB0D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Carnet)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.EConvo1).HasColumnName("E_Convo1");
            entity.Property(e => e.EConvo2).HasColumnName("E_Convo2");
            entity.Property(e => e.N1parcial).HasColumnName("N_1Parcial");
            entity.Property(e => e.N2parcial).HasColumnName("N_2Parcial");
            entity.Property(e => e.NSistematico).HasColumnName("N_Sistematico");
            entity.Property(e => e.Nombre).HasColumnType("text");
        });

        modelBuilder.Entity<ViewNota>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewNotas");

            entity.Property(e => e.Carnet)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.EConvo1).HasColumnName("E_Convo1");
            entity.Property(e => e.EConvo2).HasColumnName("E_Convo2");
            entity.Property(e => e.EFconvo1).HasColumnName("E_FConvo1");
            entity.Property(e => e.N1parcial).HasColumnName("N_1Parcial");
            entity.Property(e => e.N2parcial).HasColumnName("N_2Parcial");
            entity.Property(e => e.NFinal).HasColumnName("N_Final");
            entity.Property(e => e.NSistematico).HasColumnName("N_Sistematico");
            entity.Property(e => e.Nombre).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
