using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ChangaTableRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Profillings_NIK",
                table: "Accounts");

            migrationBuilder.AddForeignKey(
                name: "FK_Profillings_Accounts_NIK",
                table: "Profillings",
                column: "NIK",
                principalTable: "Accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profillings_Accounts_NIK",
                table: "Profillings");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Profillings_NIK",
                table: "Accounts",
                column: "NIK",
                principalTable: "Profillings",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
