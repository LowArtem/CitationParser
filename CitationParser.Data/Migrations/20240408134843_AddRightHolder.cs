using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitationParser.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRightHolder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "rightHolder",
                table: "publications",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1962), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1962) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1969), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1969) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1971), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1971) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1973), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1973) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1974), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1974) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1976), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1976) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1977), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1977) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1979), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1979) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1980), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1980) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1981), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1981) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1983), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1983) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1984), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1984) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1986), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1986) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1987), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1987) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1989), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1989) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1990), new DateTime(2024, 4, 8, 13, 48, 43, 155, DateTimeKind.Utc).AddTicks(1990) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rightHolder",
                table: "publications");

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8016), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8016) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8026), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8026) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8029), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8029) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8031), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8031) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8033), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8033) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8035), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8035) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8037), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8037) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8039), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8039) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8041), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8041) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8043), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8043) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8044), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8044) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8047), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8047) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8048), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8048) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8050), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8050) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8052), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8052) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8054), new DateTime(2024, 3, 28, 14, 41, 40, 258, DateTimeKind.Utc).AddTicks(8054) });
        }
    }
}
