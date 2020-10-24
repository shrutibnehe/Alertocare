using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace AlertToCareAPI.Database.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BedsInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IcuId = table.Column<string>(nullable: true),
                    IsOccupied = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedsInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IcusInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BedCount = table.Column<int>(nullable: false),
                    LayoutId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcusInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientsInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PatientName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    IcuId = table.Column<string>(nullable: true),
                    BedId = table.Column<string>(nullable: true),
                    ContantNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VitalsInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Bpm = table.Column<double>(nullable: false),
                    Spo2 = table.Column<double>(nullable: false),
                    RespRate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalsInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BedsInfo");

            migrationBuilder.DropTable(
                name: "IcusInfo");

            migrationBuilder.DropTable(
                name: "PatientsInfo");

            migrationBuilder.DropTable(
                name: "VitalsInfo");
        }
    }
}
