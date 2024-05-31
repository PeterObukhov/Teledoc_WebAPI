using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teledoc_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class clientId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Founders_Clients_CompanyId",
                table: "Founders");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Founders",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Founders_CompanyId",
                table: "Founders",
                newName: "IX_Founders_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Founders_Clients_ClientId",
                table: "Founders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Founders_Clients_ClientId",
                table: "Founders");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Founders",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Founders_ClientId",
                table: "Founders",
                newName: "IX_Founders_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Founders_Clients_CompanyId",
                table: "Founders",
                column: "CompanyId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
