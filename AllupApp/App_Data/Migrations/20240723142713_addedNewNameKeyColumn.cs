using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllupApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedNewNameKeyColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Keyi",
                table: "Settings",
                newName: "Key");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Settings",
                newName: "Keyi");
        }
    }
}
