using Microsoft.EntityFrameworkCore.Migrations;

namespace M1092242.Migrations
{
    public partial class PersonModelModifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "People",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Password",
                table: "People",
                type: "real",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
