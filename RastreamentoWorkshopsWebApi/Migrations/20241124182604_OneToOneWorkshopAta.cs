using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RastreamentoWorkshopsWebApi.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneWorkshopAta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Atas_WorkshopId",
                table: "Atas");

            migrationBuilder.CreateIndex(
                name: "IX_Atas_WorkshopId",
                table: "Atas",
                column: "WorkshopId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Atas_WorkshopId",
                table: "Atas");

            migrationBuilder.CreateIndex(
                name: "IX_Atas_WorkshopId",
                table: "Atas",
                column: "WorkshopId");
        }
    }
}
