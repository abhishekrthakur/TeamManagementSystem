using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamManagement.Migrations
{
    public partial class newmember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           // migrationBuilder.DropTable(
             //   name: "AddMember");

            migrationBuilder.CreateTable(
                name: "NewMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewMembers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewMembers");

            //migrationBuilder.CreateTable(
            //    name: "AddMember",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MemberId = table.Column<int>(type: "int", nullable: false),
            //        RoleId = table.Column<int>(type: "int", nullable: false),
            //        TeamId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AddMember", x => x.Id);
            //    });
        }
    }
}
