using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Spodaryk.Models;

public partial class SpodarykPz34Context : DbContext
{
    public SpodarykPz34Context()
    {
    }

    public SpodarykPz34Context(DbContextOptions<SpodarykPz34Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\;Database=Spodaryk_PZ34;Encrypt=False;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.IdMovie).HasName("PK__Movies__FB90FCD70801FABB");

            entity.Property(e => e.IdMovie).HasColumnName("id_movie");
            entity.Property(e => e.Comments)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("comments");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Path)
                .IsUnicode(false)
                .HasColumnName("path");
            entity.Property(e => e.Recomendation).HasColumnName("recomendation");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
