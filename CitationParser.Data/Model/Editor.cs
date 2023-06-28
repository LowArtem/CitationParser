using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CitationParser.Data.Model;

[Table("editors")]
[MySqlCharSet("utf8")]
[MySqlCollation("utf8_general_ci")]
public partial class Editor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("surname")]
    [StringLength(45)]
    public string? Surname { get; set; }

    [Column("initials")]
    [StringLength(45)]
    public string? Initials { get; set; }

    [ForeignKey("IdEditors")]
    [InverseProperty("IdEditors")]
    public virtual ICollection<ScientificCollection> IdScientificCollections { get; set; } = new List<ScientificCollection>();
}
