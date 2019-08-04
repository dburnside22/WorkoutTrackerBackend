using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkoutTrackerApi.Migrations
{
    public partial class CardioAndStrengthSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistanceInFeet",
                table: "Sets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistanceInFeet",
                table: "Sets");
        }
    }
}
