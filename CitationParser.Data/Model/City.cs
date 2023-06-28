using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CitationParser.Data.Model;

[Table("cities")]
[MySqlCharSet("utf8")]
[MySqlCollation("utf8_general_ci")]
public partial class City
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(45)]
    public string? Name { get; set; }

    [ForeignKey("IdCities")]
    [InverseProperty("IdCities")]
    public virtual ICollection<Publication> IdPublications { get; set; } = new List<Publication>();
}
