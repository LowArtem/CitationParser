using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CitationParser.Data.Model;

[Table("types_of_publications")]
[MySqlCharSet("utf8")]
[MySqlCollation("utf8_general_ci")]
public partial class TypesOfPublication
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(45)]
    public string? Name { get; set; }

    [InverseProperty("Type")]
    public virtual ICollection<Publication> Publications { get; set; } = new List<Publication>();
}
