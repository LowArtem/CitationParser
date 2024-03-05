using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CitationParser.Core.Model._Base;
using Microsoft.EntityFrameworkCore;

namespace CitationParser.Data.Model;

[Table("scientific_collections")]
[MySqlCharSet("utf8")]
[MySqlCollation("utf8_general_ci")]
public class ScientificCollection : BaseEntity
{
    [Column("title")] [StringLength(300)] public string? Title { get; set; }

    [ForeignKey("IdScientificCollection")]
    [InverseProperty("IdScientificCollection")]
    public virtual ICollection<Publication> IdPublications { get; set; } = new List<Publication>();
}