using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordering.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class PostalCodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingAddress_ZipCode",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_ZipCode",
                table: "Orders",
                newName: "ShippingAddress_PostalCode");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_PostalCode",
                table: "Orders",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingAddress_PostalCode",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_PostalCode",
                table: "Orders",
                newName: "ShippingAddress_ZipCode");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_ZipCode",
                table: "Orders",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }
    }
}
