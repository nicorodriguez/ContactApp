using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactApp.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Contacts",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2020, 7, 8, 2, 7, 45, 978, DateTimeKind.Local).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(2020, 7, 6, 2, 7, 45, 979, DateTimeKind.Local).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "Birthdate",
                value: new DateTime(2020, 7, 3, 2, 7, 45, 979, DateTimeKind.Local).AddTicks(4799));

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "Birthdate", "City", "Company", "Email", "Image", "Name", "PersonalNumber", "ProfileId", "State", "WorkNumber" },
                values: new object[,]
                {
                    { 4, "Avenida Siempre Viva 1234", new DateTime(1965, 7, 8, 2, 7, 45, 979, DateTimeKind.Local).AddTicks(4804), "Ciudad Grito", "Planta Nuclear", "homero.simpson@lossimpsons.com", "image4", "Homero Simpson", "344456984", 1, "springfield", "344456987" },
                    { 5, "9th Street", new DateTime(1970, 7, 8, 2, 7, 45, 979, DateTimeKind.Local).AddTicks(4876), "NY", "Stark Industries", "tony.stark@starkindustries.com", "image5", "Tony Stark", "5411526328", 3, "NY", "5411526358" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2020, 7, 6, 3, 7, 32, 254, DateTimeKind.Local).AddTicks(9291));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(2020, 7, 4, 3, 7, 32, 255, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "Birthdate",
                value: new DateTime(2020, 7, 1, 3, 7, 32, 255, DateTimeKind.Local).AddTicks(9538));
        }
    }
}
