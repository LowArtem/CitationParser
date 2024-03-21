using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CitationParser.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInitType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditorScientificCollection");

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
                name: "country",
                table: "cities",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
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
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "publications_to_editors",
                columns: table => new
                {
                    id_Publications = table.Column<int>(type: "int", nullable: false),
                    IdEditors = table.Column<int>(type: "int", nullable: false),
                    id_Editor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_Publications, x.IdEditors })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_editor_to_publications",
                        column: x => x.id_Editor,
                        principalTable: "editors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_publications_to_editors",
                        column: x => x.id_Publications,
                        principalTable: "publications",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "publications_to_scientific_collections",
                columns: table => new
                {
                    id_Publications = table.Column<int>(type: "int", nullable: false),
                    id_ScientificCollection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_Publications, x.id_ScientificCollection })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_publications_to_scientific_collections",
                        column: x => x.id_Publications,
                        principalTable: "publications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_scientific_collections_to_publications",
                        column: x => x.id_ScientificCollection,
                        principalTable: "scientific_collections",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

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
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.InsertData(
                table: "types_of_publications",
                columns: new[] { "Id", "DateCreate", "DateUpdate", "IsDelete", "name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1035), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1035), false, "DepositedManuscript" },
                    { 2, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1042), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1042), false, "Certificate" },
                    { 3, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1044), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1044), false, "Monograph" },
                    { 4, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1046), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1046), false, "Other" },
                    { 5, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1048), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1048), false, "Patent" },
                    { 6, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1050), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1050), false, "Textbook" },
                    { 7, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1052), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1052), false, "ReportAbstracts" },
                    { 8, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1054), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1054), false, "StudyGuide" },
                    { 9, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1056), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1056), false, "StudyGuideWithStamp" },
                    { 10, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1058), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1058), false, "VstuMagazines" },
                    { 11, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1060), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1060), false, "VstuNews" },
                    { 12, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1062), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1062), false, "EducationalMethodicalComplex" },
                    { 13, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1064), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1064), false, "ForeignCollectionArticle" },
                    { 14, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1066), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1066), false, "ForeignMagazineArticle" },
                    { 15, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1068), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1068), false, "RussianCollectionArticle" },
                    { 16, new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1070), new DateTime(2024, 3, 21, 16, 10, 16, 333, DateTimeKind.Utc).AddTicks(1070), false, "RussianMagazineArticle" }
                });

            migrationBuilder.CreateIndex(
                name: "FK_editor_to_publications",
                table: "publications_to_editors",
                column: "id_Editor");

            migrationBuilder.CreateIndex(
                name: "FK_scientific_collections_to_publications",
                table: "publications_to_scientific_collections",
                column: "id_ScientificCollection");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyPublication");

            migrationBuilder.DropTable(
                name: "EditorPublication");

            migrationBuilder.DropTable(
                name: "publications_to_editors");

            migrationBuilder.DropTable(
                name: "publications_to_scientific_collections");

            migrationBuilder.DropTable(
                name: "PublicationScientificCollection");

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
                name: "country",
                table: "cities");

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
