using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomicSeller.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "int", nullable: false),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DailyStartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    DailyEndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    LastExecutionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobPeriod = table.Column<TimeSpan>(type: "time", nullable: true),
                    Repeat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantID = table.Column<int>(type: "int", nullable: true),
                    WebserviceKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebserviceStoreKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebserviceCarrierServiceKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebserviceWMSKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebserviceReportingKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebServiceOutput = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jobs");
        }
    }
}
