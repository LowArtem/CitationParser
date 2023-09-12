using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CitationParser.Core.Model._Base;
using Microsoft.EntityFrameworkCore;

namespace CitationParser.Data.Model;

[Table("editors")]
[MySqlCharSet("utf8")]
[MySqlCollation("utf8_general_ci")]
public class Editor : BaseEntity
{
    [Column("name")] [StringLength(45)] public string Name { get; set; }

    [ForeignKey("IdEditors")]
    [InverseProperty("IdEditors")]
    public virtual ICollection<ScientificCollection> IdScientificCollections { get; set; } =
        new List<ScientificCollection>();
}