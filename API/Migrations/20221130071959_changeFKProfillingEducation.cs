using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class changeFKProfillingEducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profillings_Educations_Education_id",
                table: "Profillings");

            migrationBuilder.RenameColumn(
                name: "Education_id",
                table: "Profillings",
                newName: "Education_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Profillings_Education_id",
                table: "Profillings",
                newName: "IX_Profillings_Education_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profillings_Educations_Education_Id",
                table: "Profillings",
                column: "Education_Id",
                principalTable: "Educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profillings_Educations_Education_Id",
                table: "Profillings");

            migrationBuilder.RenameColumn(
                name: "Education_Id",
                table: "Profillings",
                newName: "Education_id");

            migrationBuilder.RenameIndex(
                name: "IX_Profillings_Education_Id",
                table: "Profillings",
                newName: "IX_Profillings_Education_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profillings_Educations_Education_id",
                table: "Profillings",
                column: "Education_id",
                principalTable: "Educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
