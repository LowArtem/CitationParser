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
        
        modelBuilder.Entity<TypesOfPublication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.HasData(
                new TypesOfPublication() {Id = 1, Name = "DepositedManuscript"},
                new TypesOfPublication() {Id = 2, Name = "Certificate"},
                new TypesOfPublication() {Id = 3, Name = "Monograph"},
                new TypesOfPublication() {Id = 4, Name = "Other"},
                new TypesOfPublication() {Id = 5, Name = "Patent"},
                new TypesOfPublication() {Id = 6, Name = "Textbook"},
                new TypesOfPublication() {Id = 7, Name = "ReportAbstracts"},
                new TypesOfPublication() {Id = 8, Name = "StudyGuide"},
                new TypesOfPublication() {Id = 9, Name = "StudyGuideWithStamp"},
                new TypesOfPublication() {Id = 10, Name = "VstuMagazines"},
                new TypesOfPublication() {Id = 11, Name = "VstuNews"},
                new TypesOfPublication() {Id = 12, Name = "EducationalMethodicalComplex"},
                new TypesOfPublication() {Id = 13, Name = "ForeignCollectionArticle"},
                new TypesOfPublication() {Id = 14, Name = "ForeignMagazineArticle"},
                new TypesOfPublication() {Id = 15, Name = "RussianCollectionArticle"},
                new TypesOfPublication() {Id = 16, Name = "RussianMagazineArticle"}
            );
        });
        
        modelBuilder.Entity<ScientificCollection>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Company>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Author>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<City>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Editor>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Publication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Type).WithMany(p => p.Publications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_types_publications");
            
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}