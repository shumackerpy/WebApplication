using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacion.Migrations
{
    public partial class dev01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_completo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    cedula = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    departamento = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    tipo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    titulo_obtenido = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    horario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    fecha_inicio = table.Column<DateTime>(type: "date", nullable: true),
                    fecha_termino = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tabla",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabla", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Clave = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Restablecer = table.Column<bool>(type: "bit", nullable: true),
                    Confirmado = table.Column<bool>(type: "bit", nullable: true),
                    Token = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__USUARIO__5B65BF97A4D0431C", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Asistencia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_alumno = table.Column<int>(type: "int", nullable: true),
                    id_curso = table.Column<int>(type: "int", nullable: true),
                    fecha = table.Column<DateTime>(type: "date", nullable: true),
                    estado = table.Column<bool>(type: "bit", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencia", x => x.id);
                    table.ForeignKey(
                        name: "FK__Asistenci__id_al__5165187F",
                        column: x => x.id_alumno,
                        principalTable: "Alumnos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Asistenci__id_cu__52593CB8",
                        column: x => x.id_curso,
                        principalTable: "Cursos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Historico_Cursos_Alumnos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_alumno = table.Column<int>(type: "int", nullable: true),
                    id_curso = table.Column<int>(type: "int", nullable: true),
                    fecha_registro = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico_Cursos_Alumnos", x => x.id);
                    table.ForeignKey(
                        name: "FK__Historico__id_al__5535A963",
                        column: x => x.id_alumno,
                        principalTable: "Alumnos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Historico__id_cu__5629CD9C",
                        column: x => x.id_curso,
                        principalTable: "Cursos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_id_alumno",
                table: "Asistencia",
                column: "id_alumno");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_id_curso",
                table: "Asistencia",
                column: "id_curso");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_Cursos_Alumnos_id_alumno",
                table: "Historico_Cursos_Alumnos",
                column: "id_alumno");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_Cursos_Alumnos_id_curso",
                table: "Historico_Cursos_Alumnos",
                column: "id_curso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencia");

            migrationBuilder.DropTable(
                name: "Historico_Cursos_Alumnos");

            migrationBuilder.DropTable(
                name: "tabla");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
