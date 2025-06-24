using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarApi.Migrations
{
    /// <inheritdoc />
    public partial class foregnkeyOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Persons_OwnerPersonId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "OwnerPersonId",
                table: "Cars",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_OwnerPersonId",
                table: "Cars",
                newName: "IX_Cars_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Persons_PersonId",
                table: "Cars",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Persons_PersonId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Cars",
                newName: "OwnerPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_PersonId",
                table: "Cars",
                newName: "IX_Cars_OwnerPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Persons_OwnerPersonId",
                table: "Cars",
                column: "OwnerPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
