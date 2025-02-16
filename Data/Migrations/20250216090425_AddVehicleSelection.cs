using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Egovernance.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleSelection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "selectedVehicle",
                table: "LicenseProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "selectedVehicle",
                table: "LicenseProfiles");
        }
    }
}
