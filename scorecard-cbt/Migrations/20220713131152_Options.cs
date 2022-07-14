using Microsoft.EntityFrameworkCore.Migrations;

namespace scorecard_cbt.Migrations
{
    public partial class Options : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "option",
                table: "Options",
                newName: "Tag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tag",
                table: "Options",
                newName: "option");
        }
    }
}
