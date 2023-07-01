using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REACTBIGBANG.Migrations
{
    /// <inheritdoc />
    public partial class Begin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "doctors");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "doctors");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
