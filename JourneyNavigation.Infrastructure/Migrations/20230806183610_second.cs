using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JourneyNavigation.Infrastructure.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistanceInMeters",
                table: "Journeys");

            migrationBuilder.AddColumn<decimal>(
                name: "DistanceInKm",
                table: "Journeys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistanceInKm",
                table: "Journeys");

            migrationBuilder.AddColumn<int>(
                name: "DistanceInMeters",
                table: "Journeys",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
