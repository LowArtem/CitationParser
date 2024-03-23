using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CitationParser.Core.Model._Base;
using Microsoft.EntityFrameworkCore;

namespace CitationParser.Data.Model;

[Table("publications")]
[Index("TypeId", Name = "FK_types_publications")]
[MySqlCharSet("utf8")]
[MySqlCollation("utf8_general_ci")]
public class Publication : BaseEntity
{
    [Column("title")] [StringLength(300)] public string Title { get; set; } = null!;

    [Column("year")] [StringLength(45)] public string? Year { get; set; }

    [Column("date")] public DateOnly? Date { get; set; }

    [Column("number")] [StringLength(45)] public string? Number { get; set; }

    [Column("titleOfSource")]
    [StringLength(300)]
    public string? TitleOfSource { get; set; }

    [Column("numberOfPages")]
    [StringLength(45)]
    public string? CountOfPages { get; set; }

    [Column("pageNumbers")]
    [StringLength(45)]
    public string? PageNumbers { get; set; }

    [Column("DOI")] [StringLength(200)] public string? Doi { get; set; }

    [Column("information")]
    [StringLength(200)]
    public string? Information { get; set; }

    [Column("URL")] [StringLength(300)] public string? Url { get; set; }

    [Column("publishingHouse")]
    [StringLength(100)]
    public string? PublishingHouse { get; set; }

    [Column("articleNumber")]
    [StringLength(45)]
    public string? ArticleNumber { get; set; }

    [Column("parallelTitle")]
    [StringLength(300)]
    public string? ParallelTitle { get; set; }

    [Column("parallelSourceTitle")]
    [StringLength(300)]
    public string? ParallelSourceTitle { get; set; }

    [Column("country")] [StringLength(45)] public string? Country { get; set; }

    [Column("dataStorage")]
    [StringLength(100)]
    public string? DataStorage { get; set; }

    [Column("registrationNumber")]
    [StringLength(100)]
    public string? RegistrationNumber { get; set; }

    [Column("dateOfRegistration")] public string? DateOfRegistration { get; set; }

    [Column("placeOfRegistration")]
    [StringLength(100)]
    public string? PlaceOfRegistration { get; set; }

    [Column("numberOfVolumes")] public int? NumberOfVolumes { get; set; }

    [Column("volumeNumber")] public string? VolumeNumber { get; set; }

    [Column("informationAboutPublication")]
    [StringLength(45)]
    public string? InformationAboutPublication { get; set; }
    
    [Column("dateIntroduction")]
    [StringLength(100)]
    public string? DateIntroduction { get; set; }
    
    [Column("language")]
    [StringLength(45)]
    public string? Language { get; set; }

    [Column("type_id")] public int TypeId { get; set; }

    [ForeignKey("TypeId")]
    [InverseProperty("Publications")]
    public virtual TypesOfPublication Type { get; set; } = null!;

    [ForeignKey("IdPublications")]
    [InverseProperty("IdPublications")]
    public virtual ICollection<Author> IdAuthors { get; set; } = new List<Author>();

    [ForeignKey("IdPublications")]
    [InverseProperty("IdPublications")]
    public virtual ICollection<City> IdCities { get; set; } = new List<City>();

    [ForeignKey("IdPublications")]
    [InverseProperty("IdPublications")]
    public virtual ICollection<Company> IdUniversities { get; set; } = new List<Company>();
    
    [ForeignKey("IdPublications")]
    [InverseProperty("IdPublications")]
    public virtual ICollection<Editor> IdEditors { get; set; } = new List<Editor>();

    [ForeignKey("IdPublications")]
    [InverseProperty("IdPublications")]
    public virtual ICollection<ScientificCollection> IdScientificCollection { get; set; } = new List<ScientificCollection>();
}