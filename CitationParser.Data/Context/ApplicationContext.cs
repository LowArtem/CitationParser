using CitationParser.Data.Model;
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
        });

        modelBuilder.Entity<ScientificCollection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasMany(d => d.IdEditors).WithMany(p => p.IdScientificCollections)
                .UsingEntity<Dictionary<string, object>>(
                    "ScientificCollectionsToEditor",
                    r => r.HasOne<Editor>().WithMany()
                        .HasForeignKey("IdEditors")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_scientific_collections_to_editors_editors"),
                    l => l.HasOne<ScientificCollection>().WithMany()
                        .HasForeignKey("IdScientificCollections")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_scientific_collections_to_editros_scientific_collections"),
                    j =>
                    {
                        j.HasKey("IdScientificCollections", "IdEditors")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j
                            .ToTable("scientific_collections_to_editors")
                            .HasCharSet("utf8")
                            .UseCollation("utf8_general_ci");
                        j.HasIndex(new[] { "IdEditors" }, "FK_scientific_collections_to_editors_editors");
                        j.IndexerProperty<int>("IdScientificCollections").HasColumnName("id_scientific_collections");
                        j.IndexerProperty<int>("IdEditors").HasColumnName("id_editors");
                    });

            entity.HasMany(d => d.IdUniversities).WithMany(p => p.IdScientificCollections)
                .UsingEntity<Dictionary<string, object>>(
                    "ScientificCollectionsToUniversity",
                    r => r.HasOne<Company>().WithMany()
                        .HasForeignKey("IdUniversities")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_scientific_collections_to_universities_universities"),
                    l => l.HasOne<ScientificCollection>().WithMany()
                        .HasForeignKey("IdScientificCollections")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_scientific_collections_to_universities_scientific_collections"),
                    j =>
                    {
                        j.HasKey("IdScientificCollections", "IdUniversities")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j
                            .ToTable("scientific_collections_to_universities")
                            .HasCharSet("utf8")
                            .UseCollation("utf8_general_ci");
                        j.HasIndex(new[] { "IdUniversities" },
                            "FK_scientific_collections_to_universities_universities");
                        j.IndexerProperty<int>("IdScientificCollections").HasColumnName("id_scientific_collections");
                        j.IndexerProperty<int>("IdUniversities").HasColumnName("id_universities");
                    });
        });

        modelBuilder.Entity<TypesOfPublication>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Company>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}