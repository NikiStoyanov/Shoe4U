using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoe4U.Migrations
{
    /// <inheritdoc />
    public partial class ProductIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IsDeleted",
                table: "Products");

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
    }
}
