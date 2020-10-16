using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage2._0.Migrations
{
    public partial class initCreate : Migration
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
                    Color = table.Column<string>(maxLength: 20, nullable: false),
                    Make = table.Column<string>(maxLength: 15, nullable: false),
                    Model = table.Column<string>(maxLength: 20, nullable: false),
                    NumOfWheels = table.Column<int>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkedVehicle", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "ID", "ArrivalTime", "Color", "Make", "Model", "NumOfWheels", "RegNum", "VehicleType" },
                values: new object[] { 1, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black", "Dodge", "Nitro TR 4/4", 4, "FZK678", 3 });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "ID", "ArrivalTime", "Color", "Make", "Model", "NumOfWheels", "RegNum", "VehicleType" },
                values: new object[] { 2, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black", "Camaro", "SS", 4, "FZK677", 3 });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "ID", "ArrivalTime", "Color", "Make", "Model", "NumOfWheels", "RegNum", "VehicleType" },
                values: new object[] { 3, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orange", "Harley Davidson", "NightRod", 2, "MKT677", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkedVehicle");
        }
    }
}
