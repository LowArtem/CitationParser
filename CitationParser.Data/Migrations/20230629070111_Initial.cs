using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitationParser.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AuthorPublication",
                columns: table => new
                {
                    IdAuthors = table.Column<int>(type: "int", nullable: false),
                    IdPublications = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPublication", x => new { x.IdAuthors, x.IdPublications });
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    surname = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    initials = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    DateCreate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    DateCreate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "CityPublication",
                columns: table => new
                {
                    IdCities = table.Column<int>(type: "int", nullable: false),
                    IdPublications = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityPublication", x => new { x.IdCities, x.IdPublications });
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "editors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    surname = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    initials = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    DateCreate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "EditorScientificCollection",
                columns: table => new
                {
                    IdEditors = table.Column<int>(type: "int", nullable: false),
                    IdScientificCollections = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditorScientificCollection", x => new { x.IdEditors, x.IdScientificCollections });
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "PublicationUniversity",
                columns: table => new
                {
                    IdPublications = table.Column<int>(type: "int", nullable: false),
                    IdUniversities = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationUniversity", x => new { x.IdPublications, x.IdUniversities });
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "scientific_collections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    id_city = table.Column<int>(type: "int", nullable: false),
                    country = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    start_date = table.Column<DateOnly>(type: "date", nullable: true),
                    finish_date = table.Column<DateOnly>(type: "date", nullable: true),
                    numberOfVolumes = table.Column<int>(type: "int", nullable: true),
                    volumeNumber = table.Column<int>(type: "int", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "ScientificCollectionUniversity",
                columns: table => new
                {
                    IdScientificCollections = table.Column<int>(type: "int", nullable: false),
                    IdUniversities = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificCollectionUniversity", x => new { x.IdScientificCollections, x.IdUniversities });
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "types_of_publications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    DateCreate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    DateCreate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "scientific_collections_to_editors",
                columns: table => new
                {
                    id_scientific_collections = table.Column<int>(type: "int", nullable: false),
                    id_editors = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_scientific_collections, x.id_editors })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_scientific_collections_to_editors_editors",
                        column: x => x.id_editors,
                        principalTable: "editors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_scientific_collections_to_editros_scientific_collections",
                        column: x => x.id_scientific_collections,
                        principalTable: "scientific_collections",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "publications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    year = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    date = table.Column<DateOnly>(type: "date", nullable: true),
                    number = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    titleOfSource = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    numberOfPages = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    pageNumbers = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    DOI = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    information = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    URL = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    publishingHouse = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    articleNumber = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    parallelTitle = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    parallelSourceTitle = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    country = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    dataStorage = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    registrationNumber = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    dateOfRegistration = table.Column<DateOnly>(type: "date", nullable: true),
                    placeOfRegistration = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    numberOfVolumes = table.Column<int>(type: "int", nullable: true),
                    volumeNumber = table.Column<int>(type: "int", nullable: true),
                    informationAboutPublication = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    type_id = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_types_publications",
                        column: x => x.type_id,
                        principalTable: "types_of_publications",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "scientific_collections_to_universities",
                columns: table => new
                {
                    id_scientific_collections = table.Column<int>(type: "int", nullable: false),
                    id_universities = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_scientific_collections, x.id_universities })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_scientific_collections_to_universities_scientific_collections",
                        column: x => x.id_scientific_collections,
                        principalTable: "scientific_collections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_scientific_collections_to_universities_universities",
                        column: x => x.id_universities,
                        principalTable: "universities",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "publications_to_authors",
                columns: table => new
                {
                    id_Publications = table.Column<int>(type: "int", nullable: false),
                    id_Authors = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_Publications, x.id_Authors })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_Publications_to_authors",
                        column: x => x.id_Publications,
                        principalTable: "publications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_authors_to_publications",
                        column: x => x.id_Authors,
                        principalTable: "authors",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "publications_to_cities",
                columns: table => new
                {
                    id_Publications = table.Column<int>(type: "int", nullable: false),
                    id_cities = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_Publications, x.id_cities })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_Publications",
                        column: x => x.id_Publications,
                        principalTable: "publications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sities",
                        column: x => x.id_cities,
                        principalTable: "cities",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "publications_to_universities",
                columns: table => new
                {
                    id_Publications = table.Column<int>(type: "int", nullable: false),
                    id_Universities = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_Publications, x.id_Universities })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_publications_to_universities",
                        column: x => x.id_Publications,
                        principalTable: "publications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_universities_to_publications",
                        column: x => x.id_Universities,
                        principalTable: "universities",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateIndex(
                name: "FK_types_publications",
                table: "publications",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "FK_authors_to_publications",
                table: "publications_to_authors",
                column: "id_Authors");

            migrationBuilder.CreateIndex(
                name: "FK_Sities",
                table: "publications_to_cities",
                column: "id_cities");

            migrationBuilder.CreateIndex(
                name: "FK_universities_to_publications",
                table: "publications_to_universities",
                column: "id_Universities");

            migrationBuilder.CreateIndex(
                name: "FK_scientific_collections_to_editors_editors",
                table: "scientific_collections_to_editors",
                column: "id_editors");

            migrationBuilder.CreateIndex(
                name: "FK_scientific_collections_to_universities_universities",
                table: "scientific_collections_to_universities",
                column: "id_universities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorPublication");

            migrationBuilder.DropTable(
                name: "CityPublication");

            migrationBuilder.DropTable(
                name: "EditorScientificCollection");

            migrationBuilder.DropTable(
                name: "publications_to_authors");

            migrationBuilder.DropTable(
                name: "publications_to_cities");

            migrationBuilder.DropTable(
                name: "publications_to_universities");

            migrationBuilder.DropTable(
                name: "PublicationUniversity");

            migrationBuilder.DropTable(
                name: "scientific_collections_to_editors");

            migrationBuilder.DropTable(
                name: "scientific_collections_to_universities");

            migrationBuilder.DropTable(
                name: "ScientificCollectionUniversity");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "publications");

            migrationBuilder.DropTable(
                name: "editors");

            migrationBuilder.DropTable(
                name: "scientific_collections");

            migrationBuilder.DropTable(
                name: "universities");

            migrationBuilder.DropTable(
                name: "types_of_publications");
        }
    }
}
