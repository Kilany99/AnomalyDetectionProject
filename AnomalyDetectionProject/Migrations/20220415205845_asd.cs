using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnomalyDetectionProject.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ad_Password = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Camera",
                schema: "dbo",
                columns: table => new
                {
                    CameraZoneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZonePriority = table.Column<int>(type: "int", nullable: false),
                    ZoneDescription = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camera", x => x.CameraZoneID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "dbo",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Password = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    DeviceToken = table.Column<string>(type: "varchar(40)", nullable: true),
                    CameraZoneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client_Camera_CameraZoneID",
                        column: x => x.CameraZoneID,
                        principalSchema: "dbo",
                        principalTable: "Camera",
                        principalColumn: "CameraZoneID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostedData",
                schema: "dbo",
                columns: table => new
                {
                    PostedDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrimeScreenshot = table.Column<string>(type: "varchar(300)", nullable: false),
                    AnomalyDateTime = table.Column<string>(type: "varchar(150)", nullable: false),
                    ActionType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ActionPriority = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    CameraZoneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostedData", x => x.PostedDataId);
                    table.ForeignKey(
                        name: "FK_PostedData_Camera_CameraZoneID",
                        column: x => x.CameraZoneID,
                        principalSchema: "dbo",
                        principalTable: "Camera",
                        principalColumn: "CameraZoneID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Action",
                schema: "dbo",
                columns: table => new
                {
                    ActionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    MCUID = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    ActionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.ActionID);
                    table.ForeignKey(
                        name: "FK_Action_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "dbo",
                        principalTable: "Client",
                        principalColumn: "ClientId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Action_ClientId",
                schema: "dbo",
                table: "Action",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CameraZoneID",
                schema: "dbo",
                table: "Client",
                column: "CameraZoneID");

            migrationBuilder.CreateIndex(
                name: "IX_PostedData_CameraZoneID",
                schema: "dbo",
                table: "PostedData",
                column: "CameraZoneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Action",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "PostedData",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Camera",
                schema: "dbo");
        }
    }
}
