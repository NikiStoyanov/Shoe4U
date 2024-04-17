using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoe4U.Migrations
{
    /// <inheritdoc />
    public partial class ProductCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b48665c3-6568-46ed-b204-1b18eac9ec9d", "dc42ed99-3cd6-4f9d-ad00-e1d5561e36e2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7a58d5b-0d4d-4711-bae3-9a37b471b673");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b48665c3-6568-46ed-b204-1b18eac9ec9d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc42ed99-3cd6-4f9d-ad00-e1d5561e36e2");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b48665c3-6568-46ed-b204-1b18eac9ec9d", "b48665c3-6568-46ed-b204-1b18eac9ec9d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d7a58d5b-0d4d-4711-bae3-9a37b471b673", 0, null, "04a5bc73-08b9-4436-b49e-e35553a1dfa5", "user@shoe4u.com", true, false, null, "Петър Георгиев", "USER@SHOE4U.COM", "USER@SHOE4U.COM", "AQAAAAIAAYagAAAAEKfeA306IZ+wI4C1lTYA2qf+sceVxM9XErJ0OStQGudxZx6ynas5HCKC3dL/hVfFlA==", null, false, "96fe4754-db6f-4840-97a4-a0837bcd5c4f", false, "user@shoe4u.com" },
                    { "dc42ed99-3cd6-4f9d-ad00-e1d5561e36e2", 0, null, "9e32cd53-6ea2-4c3e-aaa4-07639a42474a", "admin@shoe4u.com", true, false, null, "Иван Петров", "ADMIN@SHOE4U.COM", "ADMIN@SHOE4U.COM", "AQAAAAIAAYagAAAAEKKnBzJJFI3lH21UAeolEaVA/O3eC7Fv6vqcPh2wLi/Rp1+2OVWs/Bv/r4GWFEXjqQ==", null, false, "e4f70f83-c068-42f2-8b55-47e9a1145052", false, "admin@shoe4u.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b48665c3-6568-46ed-b204-1b18eac9ec9d", "dc42ed99-3cd6-4f9d-ad00-e1d5561e36e2" });
        }
    }
}
