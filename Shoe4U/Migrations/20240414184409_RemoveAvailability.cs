using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoe4U.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAvailability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d59449ef-61c3-44ce-9909-9b53521df9a1", "33a8cbb6-368b-4ec8-a89f-1ec00bc894b1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f4358e67-7572-489d-9ed9-3e7aebf3a132");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d59449ef-61c3-44ce-9909-9b53521df9a1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33a8cbb6-368b-4ec8-a89f-1ec00bc894b1");

            migrationBuilder.DropColumn(
                name: "Availability",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Availability",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d59449ef-61c3-44ce-9909-9b53521df9a1", "d59449ef-61c3-44ce-9909-9b53521df9a1", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "33a8cbb6-368b-4ec8-a89f-1ec00bc894b1", 0, null, "570fdbae-7685-4046-9113-83bf783c1e35", "admin@shoe4u.com", true, false, null, "Иван Петров", "ADMIN@SHOE4U.COM", "ADMIN@SHOE4U.COM", "AQAAAAIAAYagAAAAEOzQLHPKc8vGJ/qOR0KLWJSBwefQrl3LU7I2PlddmorCMLnt4IO/zv4ZIwwwK5qPxQ==", null, false, "cd8c604b-58cb-4a7d-a8f4-b0d9138e1553", false, "admin@shoe4u.com" },
                    { "f4358e67-7572-489d-9ed9-3e7aebf3a132", 0, null, "02870c21-5433-49e5-b2f3-c00da26fe1d6", "user@shoe4u.com", true, false, null, "Петър Георгиев", "USER@SHOE4U.COM", "USER@SHOE4U.COM", "AQAAAAIAAYagAAAAEESmT9Laez4aG7jx0d7B2BXBHm0loBkDZh/YqT8cyaHKYkxkATK3Jz4BfU39S2rlqQ==", null, false, "6f9eb76a-04d9-4a47-a5c9-fdcbee8444a8", false, "user@shoe4u.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d59449ef-61c3-44ce-9909-9b53521df9a1", "33a8cbb6-368b-4ec8-a89f-1ec00bc894b1" });
        }
    }
}
