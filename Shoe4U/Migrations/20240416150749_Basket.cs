using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoe4U.Migrations
{
    /// <inheritdoc />
    public partial class Basket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "db72f550-a1f8-48a4-aa07-d5135bbc2faf", "9ff97080-180e-4e43-8baf-435daeb2037b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3cc47d4-f175-48f3-8ca0-4236177b6583");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db72f550-a1f8-48a4-aa07-d5135bbc2faf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ff97080-180e-4e43-8baf-435daeb2037b");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Basket",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0645b2c8-aaa9-4b7c-8acc-4a99d59f6817", "0645b2c8-aaa9-4b7c-8acc-4a99d59f6817", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Basket", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7b21168e-9a76-41d1-8e5b-49d3c078c0f6", 0, "", "8b5eb433-8f2b-456d-889f-2e72d5a4affb", "user@shoe4u.com", true, false, null, "Петър Георгиев", "USER@SHOE4U.COM", "USER@SHOE4U.COM", "AQAAAAIAAYagAAAAENtM++xREkKPHUdls3mnxd4XQhcYC1+8r60RGWArayMI+hPT1Tzec+dRGck8bcGO6A==", null, false, "b16576c4-1a90-46df-9bd9-5542a96f3d95", false, "user@shoe4u.com" },
                    { "9c66b332-76e4-47cf-9142-4f7e2d19a490", 0, "", "915d7cec-e053-4d87-b438-45545662a133", "admin@shoe4u.com", true, false, null, "Иван Петров", "ADMIN@SHOE4U.COM", "ADMIN@SHOE4U.COM", "AQAAAAIAAYagAAAAEI4FbMbxBvmdyppfbL9ve8WsJKYLpnnkqvaccq1JNotzqZRaq9gzY7GvRH+hpFpzOA==", null, false, "e69580af-825a-4c40-b9c4-8dd609daa31f", false, "admin@shoe4u.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0645b2c8-aaa9-4b7c-8acc-4a99d59f6817", "9c66b332-76e4-47cf-9142-4f7e2d19a490" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0645b2c8-aaa9-4b7c-8acc-4a99d59f6817", "9c66b332-76e4-47cf-9142-4f7e2d19a490" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b21168e-9a76-41d1-8e5b-49d3c078c0f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0645b2c8-aaa9-4b7c-8acc-4a99d59f6817");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c66b332-76e4-47cf-9142-4f7e2d19a490");

            migrationBuilder.DropColumn(
                name: "Basket",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db72f550-a1f8-48a4-aa07-d5135bbc2faf", "db72f550-a1f8-48a4-aa07-d5135bbc2faf", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9ff97080-180e-4e43-8baf-435daeb2037b", 0, null, "8c248c70-0d9e-42fb-9caf-87346e2e7427", "admin@shoe4u.com", true, false, null, "Иван Петров", "ADMIN@SHOE4U.COM", "ADMIN@SHOE4U.COM", "AQAAAAIAAYagAAAAECFSmfhoWjBPeJTdpQ24zo2J2Lo9Eez3uABGPzE0IBnsQYYiWLxAYkriPC37nWGkNg==", null, false, "8d266cf3-e860-46b5-a6d8-db108488c577", false, "admin@shoe4u.com" },
                    { "a3cc47d4-f175-48f3-8ca0-4236177b6583", 0, null, "2cb787dc-952a-47e3-8902-9381b6e7fb41", "user@shoe4u.com", true, false, null, "Петър Георгиев", "USER@SHOE4U.COM", "USER@SHOE4U.COM", "AQAAAAIAAYagAAAAEFs7ioyO++EYu3/vgK19OfTuZeySHnRdf6KpkZ9elqsWsDyHiqRjYvJrOAxFDghd0w==", null, false, "1295d6c7-0590-4a3c-b49c-01fcb6364079", false, "user@shoe4u.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "db72f550-a1f8-48a4-aa07-d5135bbc2faf", "9ff97080-180e-4e43-8baf-435daeb2037b" });
        }
    }
}
