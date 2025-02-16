using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Egovernance.Data.Migrations
{
    /// <inheritdoc />
    public partial class ShowRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "LicenseProfiles");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "LicenseProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "LicenseProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LicenseProfiles",
                table: "LicenseProfiles",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseProfiles_UserId",
                table: "LicenseProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseProfiles_AspNetUsers_UserId",
                table: "LicenseProfiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenseProfiles_AspNetUsers_UserId",
                table: "LicenseProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LicenseProfiles",
                table: "LicenseProfiles");

            migrationBuilder.DropIndex(
                name: "IX_LicenseProfiles_UserId",
                table: "LicenseProfiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LicenseProfiles");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "LicenseProfiles");

            migrationBuilder.RenameTable(
                name: "LicenseProfiles",
                newName: "Profiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "id");
        }
    }
}
