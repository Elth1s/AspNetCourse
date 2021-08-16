using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.Migrations
{
    public partial class SeedUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96ab4491-183e-4135-908a-9c6458f1445f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5292a946-bcf4-45c0-90d6-e341a4674912");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49ef1516-c4a0-48e4-bdcf-7129168fd742", "7b1cda04-4b96-42fb-af95-8d7e77aaa7dd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f5d8d23e-5e82-45e1-80d1-7b0379d6827b", 0, "1d4c230e-65b6-446a-b811-ee0ea54bd309", "dg646726@gmail.com", false, false, null, "DG646726@GMAIL.COM", "DG646726@GMAIL.COM", "AQAAAAEAACcQAAAAEGzUEbebHpUZpIWko1xKd65/QOl5QcL+W9pJDRvN1TWnRm15EZBsXYwdrJcj46rFjQ==", null, false, "4cd29a33-d4c6-4937-9985-e5b95dde497b", false, "dg646726@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "f5d8d23e-5e82-45e1-80d1-7b0379d6827b", "49ef1516-c4a0-48e4-bdcf-7129168fd742" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "f5d8d23e-5e82-45e1-80d1-7b0379d6827b", "49ef1516-c4a0-48e4-bdcf-7129168fd742" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49ef1516-c4a0-48e4-bdcf-7129168fd742");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d8d23e-5e82-45e1-80d1-7b0379d6827b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "96ab4491-183e-4135-908a-9c6458f1445f", "8f797dce-0dc1-44bf-b07a-d3a4261e99b1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5292a946-bcf4-45c0-90d6-e341a4674912", 0, "4a1e9167-cc9d-486b-af34-79632394bc66", "dg646726@gmail.com", false, false, null, "DG646726@GMAIL.COM", "DG646726@GMAIL.COM", "AQAAAAEAACcQAAAAEGzUEbebHpUZpIWko1xKd65/QOl5QcL+W9pJDRvN1TWnRm15EZBsXYwdrJcj46rFjQ==", null, false, "f026aec8-c874-4cb4-868f-171a6e03dc9a", false, "dg646726@gmail.com" });
        }
    }
}
