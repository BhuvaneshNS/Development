using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalShopManagementSystem.Migrations
{
    public partial class userTablemod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MedicalShops_MedicalShopId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalShopId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MedicalShops_MedicalShopId",
                table: "Users",
                column: "MedicalShopId",
                principalTable: "MedicalShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MedicalShops_MedicalShopId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalShopId",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MedicalShops_MedicalShopId",
                table: "Users",
                column: "MedicalShopId",
                principalTable: "MedicalShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
