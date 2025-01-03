using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eVillaBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameInVillaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vill_Number",
                table: "VillaNumbers",
                newName: "Villa_Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Villa_Number",
                table: "VillaNumbers",
                newName: "Vill_Number");
        }
    }
}
