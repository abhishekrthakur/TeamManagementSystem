using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamManagement.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfMember",
                table: "Team");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoOfMember",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
