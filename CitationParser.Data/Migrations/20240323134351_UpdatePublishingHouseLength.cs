using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitationParser.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePublishingHouseLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "publishingHouse",
                table: "publications",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "publishingHouse",
                table: "publications",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9040), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9040) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9047), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9047) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9049), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9049) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9051), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9051) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9053), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9053) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9055), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9055) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9057), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9057) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9059), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9059) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9061), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9061) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9063), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9063) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9065), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9065) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9067), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9067) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9069), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9069) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9071), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9071) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9073), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9073) });

            migrationBuilder.UpdateData(
                table: "types_of_publications",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9074), new DateTime(2024, 3, 22, 15, 51, 38, 277, DateTimeKind.Utc).AddTicks(9074) });
        }
    }
}
