using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dagnyr.api.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedsupplierIdtoSupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Suppliers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Suppliers");
        }
    }
}
