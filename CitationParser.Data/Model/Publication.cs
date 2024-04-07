using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CitationParser.Core.Model._Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

    public override bool Equals(Object obj)
    {
        if (obj == null || !(obj is Publication))
            return false;

        if (this.IdAuthors.Count() != ((Publication)obj).IdAuthors.Count())
            return false;
        
        foreach (var author in ((Publication)obj).IdAuthors)
        {
            if (this.IdAuthors.Where(a => a.Name == author.Name).IsNullOrEmpty())
                return false;
        }
        
        if (this.IdScientificCollection.Count() != ((Publication)obj).IdScientificCollection.Count())
            return false;
        
        foreach (var collection in ((Publication)obj).IdScientificCollection)
        {
            if (this.IdScientificCollection.Where(sc => sc.Title == collection.Title).IsNullOrEmpty())
                return false;
        }
        
        if (this.IdCities.Count() != ((Publication)obj).IdCities.Count())
            return false;
        
        foreach (var city in ((Publication)obj).IdCities)
        {
            if (this.IdCities.Where(c => c.Name == city.Name).IsNullOrEmpty())
                return false;
        }
        
        if (this.IdEditors.Count() != ((Publication)obj).IdEditors.Count())
            return false;
        
        foreach (var editor in ((Publication)obj).IdEditors)
        {
            if (this.IdEditors.Where(e => e.Name == editor.Name).IsNullOrEmpty())
                return false;
        }
        
        if (this.IdUniversities.Count() != ((Publication)obj).IdUniversities.Count())
            return false;
        
        foreach (var university in ((Publication)obj).IdUniversities)
        {
            if (this.IdUniversities.Where(u => u.Name == university.Name).IsNullOrEmpty())
                return false;
        }
        
        return this.Title == ((Publication)obj).Title &&
               this.Year == ((Publication)obj).Year &&
               this.Date == ((Publication)obj).Date &&
               this.Number == ((Publication)obj).Number &&
               this.TitleOfSource == ((Publication)obj).TitleOfSource &&
               this.CountOfPages == ((Publication)obj).CountOfPages &&
               this.PageNumbers == ((Publication)obj).PageNumbers &&
               this.Doi == ((Publication)obj).Doi &&
               this.Information == ((Publication)obj).Information &&
               this.Url == ((Publication)obj).Url &&
               this.PublishingHouse == ((Publication)obj).PublishingHouse &&
               this.ArticleNumber == ((Publication)obj).ArticleNumber &&
               this.ParallelTitle == ((Publication)obj).ParallelTitle &&
               this.ParallelSourceTitle == ((Publication)obj).ParallelSourceTitle &&
               this.Country == ((Publication)obj).Country &&
               this.DataStorage == ((Publication)obj).DataStorage &&
               this.RegistrationNumber == ((Publication)obj).RegistrationNumber &&
               this.DateOfRegistration == ((Publication)obj).DateOfRegistration &&
               this.PlaceOfRegistration == ((Publication)obj).PlaceOfRegistration &&
               this.VolumeNumber == ((Publication)obj).VolumeNumber &&
               this.NumberOfVolumes == ((Publication)obj).NumberOfVolumes &&
               this.InformationAboutPublication == ((Publication)obj).InformationAboutPublication &&
               this.DateIntroduction == ((Publication)obj).DateIntroduction &&
               this.Language == ((Publication)obj).Language;
    }
}