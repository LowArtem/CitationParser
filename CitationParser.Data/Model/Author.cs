using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CitationParser.Core.Model._Base;
using Microsoft.EntityFrameworkCore;

namespace CitationParser.Data.Model;

[Table("authors")]
[MySqlCharSet("utf8")]
[MySqlCollation("utf8_general_ci")]
public class Author : BaseEntity
{
    [Column("surname")]
    [StringLength(45)]
    public string? Surname { get; set; }

    [Column("initials")]
    [StringLength(45)]
    public string? Initials { get; set; }

    [ForeignKey("IdAuthors")]
    [InverseProperty("IdAuthors")]
    public virtual ICollection<Publication> IdPublications { get; set; } = new List<Publication>();
}
