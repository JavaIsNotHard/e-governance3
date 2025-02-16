using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Egovernance.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProfileTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstname = table.Column<string>(type: "TEXT", nullable: false),
                    lastname = table.Column<string>(type: "TEXT", nullable: false),
                    province = table.Column<string>(type: "TEXT", nullable: false),
                    district = table.Column<string>(type: "TEXT", nullable: false),
                    dateofbirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    citizenshipNo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
