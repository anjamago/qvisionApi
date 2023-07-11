using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sede = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutoresHasLibrosautorId = table.Column<int>(type: "int", nullable: true),
                    AutoresHasLibroslibro_ISBN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutoresHasLibros",
                columns: table => new
                {
                    autorId = table.Column<int>(type: "int", nullable: false),
                    libro_ISBN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresHasLibros", x => new { x.autorId, x.libro_ISBN });
                    table.ForeignKey(
                        name: "FK_AutoresHasLibros_Autores_autorId",
                        column: x => x.autorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    ISBN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditorialId = table.Column<int>(type: "int", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sinopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    n_paginas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutoresHasLibrosautorId = table.Column<int>(type: "int", nullable: true),
                    AutoresHasLibroslibro_ISBN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Libros_AutoresHasLibros_AutoresHasLibrosautorId_AutoresHasLibroslibro_ISBN",
                        columns: x => new { x.AutoresHasLibrosautorId, x.AutoresHasLibroslibro_ISBN },
                        principalTable: "AutoresHasLibros",
                        principalColumns: new[] { "autorId", "libro_ISBN" });
                    table.ForeignKey(
                        name: "FK_Libros_Editoriales_EditorialId",
                        column: x => x.EditorialId,
                        principalTable: "Editoriales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autores_AutoresHasLibrosautorId_AutoresHasLibroslibro_ISBN",
                table: "Autores",
                columns: new[] { "AutoresHasLibrosautorId", "AutoresHasLibroslibro_ISBN" });

            migrationBuilder.CreateIndex(
                name: "IX_AutoresHasLibros_libro_ISBN",
                table: "AutoresHasLibros",
                column: "libro_ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_AutoresHasLibrosautorId_AutoresHasLibroslibro_ISBN",
                table: "Libros",
                columns: new[] { "AutoresHasLibrosautorId", "AutoresHasLibroslibro_ISBN" });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_EditorialId",
                table: "Libros",
                column: "EditorialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_AutoresHasLibros_AutoresHasLibrosautorId_AutoresHasLibroslibro_ISBN",
                table: "Autores",
                columns: new[] { "AutoresHasLibrosautorId", "AutoresHasLibroslibro_ISBN" },
                principalTable: "AutoresHasLibros",
                principalColumns: new[] { "autorId", "libro_ISBN" });

            migrationBuilder.AddForeignKey(
                name: "FK_AutoresHasLibros_Libros_libro_ISBN",
                table: "AutoresHasLibros",
                column: "libro_ISBN",
                principalTable: "Libros",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autores_AutoresHasLibros_AutoresHasLibrosautorId_AutoresHasLibroslibro_ISBN",
                table: "Autores");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_AutoresHasLibros_AutoresHasLibrosautorId_AutoresHasLibroslibro_ISBN",
                table: "Libros");

            migrationBuilder.DropTable(
                name: "AutoresHasLibros");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Editoriales");
        }
    }
}
