using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class newFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Universities_University_id",
                table: "Educations");

            migrationBuilder.RenameColumn(
                name: "University_id",
                table: "Educations",
                newName: "University_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_University_id",
                table: "Educations",
                newName: "IX_Educations_University_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Universities_University_Id",
                table: "Educations",
                column: "University_Id",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Universities_University_Id",
                table: "Educations");

            migrationBuilder.RenameColumn(
                name: "University_Id",
                table: "Educations",
                newName: "University_id");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_University_Id",
                table: "Educations",
                newName: "IX_Educations_University_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Universities_University_id",
                table: "Educations",
                column: "University_id",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
