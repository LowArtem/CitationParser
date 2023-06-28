using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CitationParser.Data.Model;

[Table("scientific_collections")]
[MySqlCharSet("utf8")]
[MySqlCollation("utf8_general_ci")]
public partial class ScientificCollection
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(300)]
    public string? Title { get; set; }

    [Column("id_city")]
    public int IdCity { get; set; }

    [Column("country")]
    [StringLength(45)]
    public string? Country { get; set; }

    [Column("start_date")]
    public DateOnly? StartDate { get; set; }

    [Column("finish_date")]
    public DateOnly? FinishDate { get; set; }

    [Column("numberOfVolumes")]
    public int? NumberOfVolumes { get; set; }

    [Column("volumeNumber")]
    public int? VolumeNumber { get; set; }

    [ForeignKey("IdScientificCollections")]
    [InverseProperty("IdScientificCollections")]
    public virtual ICollection<Editor> IdEditors { get; set; } = new List<Editor>();

    [ForeignKey("IdScientificCollections")]
    [InverseProperty("IdScientificCollections")]
    public virtual ICollection<University> IdUniversities { get; set; } = new List<University>();
}
