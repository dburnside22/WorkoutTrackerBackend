using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkoutTrackerApi.Migrations
{
    public partial class UserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEM1tKYwnVagw1a1hzyiL+oKE8WaNQiiH779QXwtusa+w63GaUEHmaFanqJao4BCuKQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEM1tKYwnVagw1a1hzyiL+oKE8WaNQiiH779QXwtusa+w63GaUEHmaFanqJao4BCuKQ==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");
        }
    }
}
