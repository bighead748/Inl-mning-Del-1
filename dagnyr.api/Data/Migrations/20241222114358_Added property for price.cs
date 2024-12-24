using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dagnyr.api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addedpropertyforprice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePerKg",
                table: "Products",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "PricePerKg");
        }
    }
}
