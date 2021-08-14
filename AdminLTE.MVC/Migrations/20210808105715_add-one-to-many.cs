using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.Migrations
{
    public partial class addonetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalCommunityId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CategoryId",
                table: "Employees",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_LocalCommunities_CategoryId",
                table: "Employees",
                column: "CategoryId",
                principalTable: "LocalCommunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_LocalCommunities_CategoryId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CategoryId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LocalCommunityId",
                table: "Employees");
        }
    }
}
