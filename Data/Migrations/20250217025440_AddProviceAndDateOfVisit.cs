using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Egovernance.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProviceAndDateOfVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "selectedOfficeVisit",
                table: "LicenseProfiles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "selectedProvince",
                table: "LicenseProfiles",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "selectedOfficeVisit",
                table: "LicenseProfiles");

            migrationBuilder.DropColumn(
                name: "selectedProvince",
                table: "LicenseProfiles");
        }
    }
}
