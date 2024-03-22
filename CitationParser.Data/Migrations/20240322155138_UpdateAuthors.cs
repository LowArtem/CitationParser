using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CitationParser.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAuthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "country",
                table: "scientific_collections");

            migrationBuilder.DropColumn(
                name: "finish_date",
                table: "scientific_collections");

            migrationBuilder.DropColumn(
                name: "id_city",
                table: "scientific_collections");

            migrationBuilder.DropColumn(
                name: "numberOfVolumes",
                table: "scientific_collections");

            migrationBuilder.DropColumn(
                name: "start_date",
                table: "scientific_collections");

            migrationBuilder.DropColumn(
                name: "volumeNumber",
                table: "scientific_collections");

            migrationBuilder.DropColumn(
                name: "initials",
                table: "editors");

            migrationBuilder.DropColumn(
                name: "surname",
                table: "editors");

            migrationBuilder.DropColumn(
                name: "initials",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "surname",
                table: "authors");

            migrationBuilder.AlterColumn<string>(
                name: "volumeNumber",
                table: "publications",
                type: "longtext",
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AlterColumn<string>(
                name: "dateOfRegistration",
                table: "publications",
                type: "longtext",
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "dateIntroduction",
                table: "publications",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "language",
                table: "publications",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "editors",
                type: "varchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "",
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "cities",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "authors",
                type: "varchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "",
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "CompanyPublication",
                columns: table => new
                {
                    IdPublications = table.Column<int>(type: "int", nullable: false),
                    IdUniversities = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPublication", x => new { x.IdPublications, x.IdUniversities });
                    table.ForeignKey(
                        name: "FK_CompanyPublication_publications_IdPublications",
                        column: x => x.IdPublications,
                        principalTable: "publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyPublication_universities_IdUniversities",
                        column: x => x.IdUniversities,
                        principalTable: "universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "EditorPublication",
                columns: table => new
                {
                    IdEditors = table.Column<int>(type: "int", nullable: false),
                    IdPublications = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditorPublication", x => new { x.IdEditors, x.IdPublications });
                    table.ForeignKey(
                        name: "FK_EditorPublication_editors_IdEditors",
                        column: x => x.IdEditors,
                        principalTable: "editors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditorPublication_publications_IdPublications",
                        column: x => x.IdPublications,
                        principalTable: "publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "PublicationScientificCollection",
                columns: table => new
                {
                    IdPublications = table.Column<int>(type: "int", nullable: false),
                    IdScientificCollection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationScientificCollection", x => new { x.IdPublications, x.IdScientificCollection });
                    table.ForeignKey(
                        name: "FK_PublicationScientificCollection_publications_IdPublications",
                        column: x => x.IdPublications,
                        principalTable: "publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicationScientificCollection_scientific_collections_IdSci~",
                        column: x => x.IdScientificCollection,
                        principalTable: "scientific_collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.InsertData(
                table: "types_of_publications",
                columns: new[] { "Id", "DateCreate", "DateUpdate", "IsDelete", "name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9040), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9040), false, "DepositedManuscript" },
                    { 2, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9047), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9047), false, "Certificate" },
                    { 3, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9049), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9049), false, "Monograph" },
                    { 4, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9051), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9051), false, "Other" },
                    { 5, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9053), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9053), false, "Patent" },
                    { 6, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9055), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9055), false, "Textbook" },
                    { 7, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9057), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9057), false, "ReportAbstracts" },
                    { 8, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9059), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9059), false, "StudyGuide" },
                    { 9, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9061), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9061), false, "StudyGuideWithStamp" },
                    { 10, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9063), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9063), false, "VstuMagazines" },
                    { 11, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9065), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9065), false, "VstuNews" },
                    { 12, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9067), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9067), false, "EducationalMethodicalComplex" },
                    { 13, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9069), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9069), false, "ForeignCollectionArticle" },
                    { 14, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9071), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9071), false, "ForeignMagazineArticle" },
                    { 15, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9073), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9073), false, "RussianCollectionArticle" },
                    { 16, new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9074), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9074), false, "RussianMagazineArticle" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityPublication_IdPublications",
                table: "CityPublication",
                column: "IdPublications");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPublication_IdPublications",
                table: "AuthorPublication",
                column: "IdPublications");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPublication_IdUniversities",
                table: "CompanyPublication",
                column: "IdUniversities");

            migrationBuilder.CreateIndex(
                name: "IX_EditorPublication_IdPublications",
                table: "EditorPublication",
                column: "IdPublications");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationScientificCollection_IdScientificCollection",
                table: "PublicationScientificCollection",
                column: "IdScientificCollection");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorPublication_authors_IdAuthors",
                table: "AuthorPublication",
                column: "IdAuthors",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorPublication_publications_IdPublications",
                table: "AuthorPublication",
                column: "IdPublications",
                principalTable: "publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CityPublication_cities_IdCities",
                table: "CityPublication",
                column: "IdCities",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CityPublication_publications_IdPublications",
                table: "CityPublication",
                column: "IdPublications",
                principalTable: "publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorPublication_authors_IdAuthors",
                table: "AuthorPublication");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorPublication_publications_IdPublications",
                table: "AuthorPublication");

            migrationBuilder.DropForeignKey(
                name: "FK_CityPublication_cities_IdCities",
                table: "CityPublication");

            migrationBuilder.DropForeignKey(
                name: "FK_CityPublication_publications_IdPublications",
                table: "CityPublication");

            migrationBuilder.DropTable(
                name: "CompanyPublication");

            migrationBuilder.DropTable(
                name: "EditorPublication");

            migrationBuilder.DropTable(
                name: "PublicationScientificCollection");

            migrationBuilder.DropIndex(
                name: "IX_CityPublication_IdPublications",
                table: "CityPublication");

            migrationBuilder.DropIndex(
                name: "IX_AuthorPublication_IdPublications",
                table: "AuthorPublication");

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DropColumn(
                name: "dateIntroduction",
                table: "publications");

            migrationBuilder.DropColumn(
                name: "language",
                table: "publications");

            migrationBuilder.DropColumn(
                name: "name",
                table: "editors");

            migrationBuilder.DropColumn(
                name: "country",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "name",
                table: "authors");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "scientific_collections",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<DateOnly>(
                name: "finish_date",
                table: "scientific_collections",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_city",
                table: "scientific_collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "numberOfVolumes",
                table: "scientific_collections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "start_date",
                table: "scientific_collections",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "volumeNumber",
                table: "scientific_collections",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "volumeNumber",
                table: "publications",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "dateOfRegistration",
                table: "publications",
                type: "date",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "initials",
                table: "editors",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "surname",
                table: "editors",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "initials",
                table: "authors",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "surname",
                table: "authors",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

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
    }
}
