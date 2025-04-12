using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Techan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class bugFixesForBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desciption",
                table: "BrandDetails",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "BrandDetails",
                newName: "Desciption");
        }
    }
}
