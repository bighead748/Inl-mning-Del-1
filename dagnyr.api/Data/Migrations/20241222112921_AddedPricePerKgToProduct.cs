using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dagnyr.api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPricePerKgToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PricePerKg",
                table: "Products",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerKg",
                table: "Products");
        }
    }
}
