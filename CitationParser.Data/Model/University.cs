﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CitationParser.Data.Model;

[Table("universities")]
[MySqlCharSet("utf8")]
[MySqlCollation("utf8_general_ci")]
public partial class University
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(200)]
    public string? Name { get; set; }

    [ForeignKey("IdUniversities")]
    [InverseProperty("IdUniversities")]
    public virtual ICollection<Publication> IdPublications { get; set; } = new List<Publication>();

    [ForeignKey("IdUniversities")]
    [InverseProperty("IdUniversities")]
    public virtual ICollection<ScientificCollection> IdScientificCollections { get; set; } = new List<ScientificCollection>();
}
