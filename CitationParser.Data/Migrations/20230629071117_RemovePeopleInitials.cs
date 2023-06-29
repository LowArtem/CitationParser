using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitationParser.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovePeopleInitials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "name",
                table: "authors",
                type: "varchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "",
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "editors");

            migrationBuilder.DropColumn(
                name: "name",
                table: "authors");

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
        }
    }
}
