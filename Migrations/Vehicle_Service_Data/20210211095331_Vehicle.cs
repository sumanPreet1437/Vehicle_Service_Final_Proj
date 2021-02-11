using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;
namespace Vehicle_Service_Final_Proj.Migrations.Vehicle_Service_Data
{
    public partial class Vehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleOwner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceBookingRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    VehicleOwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBookingRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceBookingRecord_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceBookingRecord_VehicleOwner_VehicleOwnerId",
                        column: x => x.VehicleOwnerId,
                        principalTable: "VehicleOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBookingRecord_ServiceId",
                table: "ServiceBookingRecord",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBookingRecord_VehicleOwnerId",
                table: "ServiceBookingRecord",
                column: "VehicleOwnerId");
            var sqlFile = Path.Combine(".\\DatabaseScripts", @"data.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceBookingRecord");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "VehicleOwner");
        }
    }
}
