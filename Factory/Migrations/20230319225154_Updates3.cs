using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Factory.Migrations
{
    public partial class Updates3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MacDetails",
                table: "Machines",
                newName: "MachineDetails");

            migrationBuilder.RenameColumn(
                name: "EnginDetails",
                table: "Engineers",
                newName: "EnginieerDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MachineDetails",
                table: "Machines",
                newName: "MacDetails");

            migrationBuilder.RenameColumn(
                name: "EnginieerDetails",
                table: "Engineers",
                newName: "EnginDetails");
        }
    }
}
