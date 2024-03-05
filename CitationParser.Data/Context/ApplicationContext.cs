﻿using CitationParser.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CitationParser.Data.Context;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Editor> Editors { get; set; }

    public virtual DbSet<Publication> Publications { get; set; }

    public virtual DbSet<ScientificCollection> ScientificCollections { get; set; }

    public virtual DbSet<TypesOfPublication> TypesOfPublications { get; set; }

    public virtual DbSet<Company> Universities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;database=vstu_library;uid=root;pwd=root",
            ServerVersion.Parse("8.0.28-mysql"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Author>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<City>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Editor>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Publication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Type).WithMany(p => p.Publications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_types_publications");

            entity.HasMany(d => d.IdAuthors).WithMany(p => p.IdPublications)
                .UsingEntity<Dictionary<string, object>>(
                    "PublicationsToAuthor",
                    r => r.HasOne<Author>().WithMany()
                        .HasForeignKey("IdAuthors")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_authors_to_publications"),
                    l => l.HasOne<Publication>().WithMany()
                        .HasForeignKey("IdPublications")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Publications_to_authors"),
                    j =>
                    {
                        j.HasKey("IdPublications", "IdAuthors")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j
                            .ToTable("publications_to_authors")
                            .HasCharSet("utf8")
                            .UseCollation("utf8_general_ci");
                        j.HasIndex(new[] { "IdAuthors" }, "FK_authors_to_publications");
                        j.IndexerProperty<int>("IdPublications").HasColumnName("id_Publications");
                        j.IndexerProperty<int>("IdAuthors").HasColumnName("id_Authors");
                    });

            entity.HasMany(d => d.IdCities).WithMany(p => p.IdPublications)
                .UsingEntity<Dictionary<string, object>>(
                    "PublicationsToCity",
                    r => r.HasOne<City>().WithMany()
                        .HasForeignKey("IdCities")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Sities"),
                    l => l.HasOne<Publication>().WithMany()
                        .HasForeignKey("IdPublications")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Publications"),
                    j =>
                    {
                        j.HasKey("IdPublications", "IdCities")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j
                            .ToTable("publications_to_cities")
                            .HasCharSet("utf8")
                            .UseCollation("utf8_general_ci");
                        j.HasIndex(new[] { "IdCities" }, "FK_Sities");
                        j.IndexerProperty<int>("IdPublications").HasColumnName("id_Publications");
                        j.IndexerProperty<int>("IdCities").HasColumnName("id_cities");
                    });

            entity.HasMany(d => d.IdUniversities).WithMany(p => p.IdPublications)
                .UsingEntity<Dictionary<string, object>>(
                    "PublicationsToUniversity",
                    r => r.HasOne<Company>().WithMany()
                        .HasForeignKey("IdUniversities")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_universities_to_publications"),
                    l => l.HasOne<Publication>().WithMany()
                        .HasForeignKey("IdPublications")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_publications_to_universities"),
                    j =>
                    {
                        j.HasKey("IdPublications", "IdUniversities")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j
                            .ToTable("publications_to_universities")
                            .HasCharSet("utf8")
                            .UseCollation("utf8_general_ci");
                        j.HasIndex(new[] { "IdUniversities" }, "FK_universities_to_publications");
                        j.IndexerProperty<int>("IdPublications").HasColumnName("id_Publications");
                        j.IndexerProperty<int>("IdUniversities").HasColumnName("id_Universities");
                    });
            entity.HasMany(d => d.IdScientificCollection).WithMany(p => p.IdPublications)
                .UsingEntity<Dictionary<string, object>>(
                    "PublicationsToScientificCollection",
                    r => r.HasOne<ScientificCollection>().WithMany()
                        .HasForeignKey("IdScientificCollection")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_scientific_collections_to_publications"),
                    l => l.HasOne<Publication>().WithMany()
                        .HasForeignKey("IdPublications")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_publications_to_scientific_collections"),
                    j =>
                    {
                        j.HasKey("IdPublications", "IdScientificCollection")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j
                            .ToTable("FK_publications_to_scientific_collections")
                            .HasCharSet("utf8")
                            .UseCollation("utf8_general_ci");
                        j.HasIndex(new[] { "IdScientificCollection" }, "FK_scientific_collections_to_publications");
                        j.IndexerProperty<int>("IdPublications").HasColumnName("id_Publications");
                        j.IndexerProperty<int>("IdIdScientificCollection").HasColumnName("id_IdScientificCollection");
                    });
        });

        modelBuilder.Entity<ScientificCollection>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<TypesOfPublication>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Company>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}