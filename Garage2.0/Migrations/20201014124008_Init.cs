using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage2._0.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkedVehicle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<int>(maxLength: 30, nullable: false),
                    RegNum = table.Column<string>(maxLength: 8, nullable: false),
                    Color = table.Column<string>(nullable: false),
                    Make = table.Column<string>(maxLength: 15, nullable: false),
                    Model = table.Column<string>(maxLength: 15, nullable: false),
                    NumOfWheels = table.Column<int>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkedVehicle", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkedVehicle");
        }
    }
}
