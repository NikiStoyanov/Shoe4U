using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoe4U.Migrations
{
    /// <inheritdoc />
    public partial class Quantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2ed75298-25ca-404e-ac72-648e073ebe51", "d920091d-fbed-41c5-8af8-602ca27d02d4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2551cb3-5448-4f31-8eda-3dacbf978e2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ed75298-25ca-404e-ac72-648e073ebe51");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d920091d-fbed-41c5-8af8-602ca27d02d4");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d8139e5-03f1-4ae0-b4fb-fb30229e8245", "7d8139e5-03f1-4ae0-b4fb-fb30229e8245", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2ffd05e2-5f87-4ab8-aca5-446b79b83401", 0, null, "90bc551b-f21b-4a5d-9c31-59967ec275f8", "admin@shoe4u.com", true, false, null, "Иван Петров", "ADMIN@SHOE4U.COM", "ADMIN@SHOE4U.COM", "AQAAAAIAAYagAAAAEA+zl/cZzfart3I/mjb/xsblnGZKZBVybWx4qAljZGwOWSptR+9oShVVbxD6DWvj+A==", null, false, "4e0fa4a0-d66b-43d5-9684-37f383dce666", false, "admin@shoe4u.com" },
                    { "c604aef8-f85a-436a-b17a-2f61bfce85af", 0, null, "1b413926-36f0-4df0-856a-e7b3a402b3dd", "user@shoe4u.com", true, false, null, "Петър Георгиев", "USER@SHOE4U.COM", "USER@SHOE4U.COM", "AQAAAAIAAYagAAAAEBtHV1QfaYWYVufuBDFOPP34cHtxXhbqCPDmJTrPuKlGh2pTKcK3LCZYFwF4p+kLCQ==", null, false, "517dbf08-da39-4e97-b910-9194827cddf4", false, "user@shoe4u.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7d8139e5-03f1-4ae0-b4fb-fb30229e8245", "2ffd05e2-5f87-4ab8-aca5-446b79b83401" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7d8139e5-03f1-4ae0-b4fb-fb30229e8245", "2ffd05e2-5f87-4ab8-aca5-446b79b83401" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c604aef8-f85a-436a-b17a-2f61bfce85af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d8139e5-03f1-4ae0-b4fb-fb30229e8245");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ffd05e2-5f87-4ab8-aca5-446b79b83401");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ed75298-25ca-404e-ac72-648e073ebe51", "2ed75298-25ca-404e-ac72-648e073ebe51", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b2551cb3-5448-4f31-8eda-3dacbf978e2d", 0, null, "a36ca41c-7320-4629-a97b-086e497afa8b", "user@shoe4u.com", true, false, null, "Петър Георгиев", "USER@SHOE4U.COM", "USER@SHOE4U.COM", "AQAAAAIAAYagAAAAEMHvl4KLsFl9dVDO95dqUiqi8VxLBGVixWLSwfX3J3NypNWWlvTrA4OvIDxzFzWW/Q==", null, false, "616b457f-30e2-4d2d-a97a-74057e35ab5c", false, "user@shoe4u.com" },
                    { "d920091d-fbed-41c5-8af8-602ca27d02d4", 0, null, "ad4e4732-e06b-4d35-b6a8-3b25d54f8d59", "admin@shoe4u.com", true, false, null, "Иван Петров", "ADMIN@SHOE4U.COM", "ADMIN@SHOE4U.COM", "AQAAAAIAAYagAAAAEK2XtqDjfI0x86iucmi6QbFmmHx1pNK7lebXj3EcW4g5dm1dn0c9HKiYvzwMdyYmVg==", null, false, "ea3c3d95-c6db-49b5-8b1e-de56baee998e", false, "admin@shoe4u.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2ed75298-25ca-404e-ac72-648e073ebe51", "d920091d-fbed-41c5-8af8-602ca27d02d4" });
        }
    }
}
