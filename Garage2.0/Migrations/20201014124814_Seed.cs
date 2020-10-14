using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage2._0.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "ParkedVehicle",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "ParkedVehicle",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "ParkedVehicle",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "ParkedVehicle",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);
        }
    }
}
