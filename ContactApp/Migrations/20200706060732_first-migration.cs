using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactApp.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Company = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    WorkNumber = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    PersonalNumber = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(maxLength: 255, nullable: false),
                    State = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_contact_profile",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "Name" },
                values: new object[] { 1, "User" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "Name" },
                values: new object[] { 2, "Manager" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "Name" },
                values: new object[] { 3, "Admin" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "Birthdate", "City", "Company", "Email", "Image", "Name", "PersonalNumber", "ProfileId", "State", "WorkNumber" },
                values: new object[] { 1, "Calle 1 123", new DateTime(2020, 7, 6, 3, 7, 32, 254, DateTimeKind.Local).AddTicks(9291), "Mar del Plata", "Santander Rio", "juan.gonzales@gmail.com", "image1", "Juan Gonzales", "5411527714", 1, "Buenos Aires", "5411527754" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "Birthdate", "City", "Company", "Email", "Image", "Name", "PersonalNumber", "ProfileId", "State", "WorkNumber" },
                values: new object[] { 2, "Belgrano 550", new DateTime(2020, 7, 4, 3, 7, 32, 255, DateTimeKind.Local).AddTicks(9425), "Mendoza", "Galeno", "guillermo.garcia@gmail.com", "image2", "Guillermo Garcia", "5411635449", 2, "Mendoza", "5411635489" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "Birthdate", "City", "Company", "Email", "Image", "Name", "PersonalNumber", "ProfileId", "State", "WorkNumber" },
                values: new object[] { 3, "Av Libertador 1700", new DateTime(2020, 7, 1, 3, 7, 32, 255, DateTimeKind.Local).AddTicks(9538), "Capital Federal", "Arcor", "martin.mendoza@gmail.com", "image3", "Martin Mendoza", "5411526328", 3, "Buenos Aires", "5411526358" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ProfileId",
                table: "Contacts",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
