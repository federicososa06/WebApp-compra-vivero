using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorios.Migrations
{
    public partial class INICIAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    CostoSinImpuestos = table.Column<decimal>(nullable: false),
                    CostoTotal = table.Column<decimal>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    AmericaDelSur = table.Column<bool>(nullable: true),
                    MedidasSanitarias = table.Column<string>(nullable: true),
                    TasaImportacion = table.Column<decimal>(nullable: true),
                    TasaArancelesAmerica = table.Column<decimal>(nullable: true),
                    CostoFlete = table.Column<decimal>(nullable: true),
                    TasaIva = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoIluminacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIluminacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPlanta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPlanta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Contrasenia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plantas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoId = table.Column<int>(nullable: true),
                    NombreCientifico = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    AlturaMax = table.Column<int>(nullable: false),
                    UrlFoto = table.Column<string>(nullable: true),
                    Ambiente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plantas_TiposPlanta_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TiposPlanta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FichaCuidados",
                columns: table => new
                {
                    PlantaId = table.Column<int>(nullable: false),
                    FrecuenciaRiegoUnidadTiempo = table.Column<string>(nullable: true),
                    FrecuenciaRiegoCantidad = table.Column<int>(nullable: false),
                    Temperatura = table.Column<decimal>(nullable: false),
                    IluminacionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaCuidados", x => x.PlantaId);
                    table.ForeignKey(
                        name: "FK_FichaCuidados_TipoIluminacion_IluminacionId",
                        column: x => x.IluminacionId,
                        principalTable: "TipoIluminacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichaCuidados_Plantas_PlantaId",
                        column: x => x.PlantaId,
                        principalTable: "Plantas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    CompraId = table.Column<int>(nullable: false),
                    PlantaId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(nullable: false),
                    PrecioUnitario = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => new { x.CompraId, x.PlantaId });
                    table.ForeignKey(
                        name: "FK_Items_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Plantas_PlantaId",
                        column: x => x.PlantaId,
                        principalTable: "Plantas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NombreVulgar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    PlantaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NombreVulgar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NombreVulgar_Plantas_PlantaId",
                        column: x => x.PlantaId,
                        principalTable: "Plantas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FichaCuidados_IluminacionId",
                table: "FichaCuidados",
                column: "IluminacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PlantaId",
                table: "Items",
                column: "PlantaId");

            migrationBuilder.CreateIndex(
                name: "IX_NombreVulgar_PlantaId",
                table: "NombreVulgar",
                column: "PlantaId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_TipoId",
                table: "Plantas",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FichaCuidados");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "NombreVulgar");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoIluminacion");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Plantas");

            migrationBuilder.DropTable(
                name: "TiposPlanta");
        }
    }
}
