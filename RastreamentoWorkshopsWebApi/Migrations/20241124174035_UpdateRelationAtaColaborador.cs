using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RastreamentoWorkshopsWebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationAtaColaborador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtaColaborador_Atas_AtaId",
                table: "AtaColaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_AtaColaborador_Colaboradores_ColaboradoresId",
                table: "AtaColaborador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtaColaborador",
                table: "AtaColaborador");

            migrationBuilder.RenameTable(
                name: "AtaColaborador",
                newName: "ColaboradorAtas");

            migrationBuilder.RenameColumn(
                name: "AtaId",
                table: "ColaboradorAtas",
                newName: "AtasId");

            migrationBuilder.RenameIndex(
                name: "IX_AtaColaborador_ColaboradoresId",
                table: "ColaboradorAtas",
                newName: "IX_ColaboradorAtas_ColaboradoresId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColaboradorAtas",
                table: "ColaboradorAtas",
                columns: new[] { "AtasId", "ColaboradoresId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorAtas_Atas_AtasId",
                table: "ColaboradorAtas",
                column: "AtasId",
                principalTable: "Atas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorAtas_Colaboradores_ColaboradoresId",
                table: "ColaboradorAtas",
                column: "ColaboradoresId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorAtas_Atas_AtasId",
                table: "ColaboradorAtas");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorAtas_Colaboradores_ColaboradoresId",
                table: "ColaboradorAtas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColaboradorAtas",
                table: "ColaboradorAtas");

            migrationBuilder.RenameTable(
                name: "ColaboradorAtas",
                newName: "AtaColaborador");

            migrationBuilder.RenameColumn(
                name: "AtasId",
                table: "AtaColaborador",
                newName: "AtaId");

            migrationBuilder.RenameIndex(
                name: "IX_ColaboradorAtas_ColaboradoresId",
                table: "AtaColaborador",
                newName: "IX_AtaColaborador_ColaboradoresId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtaColaborador",
                table: "AtaColaborador",
                columns: new[] { "AtaId", "ColaboradoresId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AtaColaborador_Atas_AtaId",
                table: "AtaColaborador",
                column: "AtaId",
                principalTable: "Atas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtaColaborador_Colaboradores_ColaboradoresId",
                table: "AtaColaborador",
                column: "ColaboradoresId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
