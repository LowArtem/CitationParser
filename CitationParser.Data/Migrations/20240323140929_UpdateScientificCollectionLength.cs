using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitationParser.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScientificCollectionLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "scientific_collections",
                type: "varchar(350)",
                maxLength: 350,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6206), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6206) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6210), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6212), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6212) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6214), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6214) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6216), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6216) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6218), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6218) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6220), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6222), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6222) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6224), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6224) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6226), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6226) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6228), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6228) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6230), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6231), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6231) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6233), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6233) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6235), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6235) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6237), new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6237) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "scientific_collections",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(350)",
                oldMaxLength: 350,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7115), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7115) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7121), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7121) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7123), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7123) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7125), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7125) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7128), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7128) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7130), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7130) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7132), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7132) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7134), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7134) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7136), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7136) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7138), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7138) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7140), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7140) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7142), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7142) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7143), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7143) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7145), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7145) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7147), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7147) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7149), new DateTime(2024, 3, 23, 13, 43, 51, 171, DateTimeKind.Utc).AddTicks(7149) });
        }
    }
}
