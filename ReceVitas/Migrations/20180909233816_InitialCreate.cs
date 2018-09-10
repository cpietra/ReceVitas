using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ReceVitas.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medicamentos",
                columns: table => new
                {
                    id_medicamento = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    atc = table.Column<string>(nullable: true),
                    generico = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true),
                    presentacion = table.Column<string>(nullable: true),
                    pvp = table.Column<double>(nullable: false),
                    acargoos = table.Column<double>(nullable: false),
                    acargoafil = table.Column<double>(nullable: false),
                    laboratorio = table.Column<string>(nullable: true),
                    registro = table.Column<double>(nullable: false),
                    pr = table.Column<double>(nullable: false),
                    grupoter = table.Column<double>(nullable: false),
                    obser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamentos", x => x.id_medicamento);
                });

            migrationBuilder.CreateTable(
                name: "medicos",
                columns: table => new
                {
                    id_medico = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    apellido = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true),
                    dni = table.Column<string>(nullable: true),
                    direccion = table.Column<string>(nullable: true),
                    localidad = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    movil = table.Column<string>(nullable: true),
                    compania_m = table.Column<string>(nullable: true),
                    m_n = table.Column<string>(nullable: true),
                    m_p = table.Column<string>(nullable: true),
                    plan = table.Column<string>(nullable: true),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicos", x => x.id_medico);
                });

            migrationBuilder.CreateTable(
                name: "padron",
                columns: table => new
                {
                    id_Padron = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    plan = table.Column<string>(nullable: true),
                    categoria = table.Column<string>(nullable: true),
                    numero = table.Column<int>(nullable: false),
                    orden = table.Column<int>(nullable: false),
                    tipo_doc = table.Column<string>(nullable: true),
                    num_doc = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true),
                    sexo = table.Column<string>(nullable: true),
                    ecivil = table.Column<string>(nullable: true),
                    f_nacimiento = table.Column<DateTime>(nullable: false),
                    nacionalidad = table.Column<string>(nullable: true),
                    parentesco = table.Column<string>(nullable: true),
                    vive_calle = table.Column<string>(nullable: true),
                    vive_numero = table.Column<string>(nullable: true),
                    vive_piso = table.Column<string>(nullable: true),
                    vive_depto = table.Column<string>(nullable: true),
                    vive_cod_postal = table.Column<string>(nullable: true),
                    vive_localidad_texto = table.Column<string>(nullable: true),
                    vive_localidad = table.Column<string>(nullable: true),
                    vive_partido = table.Column<string>(nullable: true),
                    vive_provincia = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    movil = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    f_ingreso = table.Column<DateTime>(nullable: false),
                    prepaga_anterior = table.Column<string>(nullable: true),
                    f_egreso = table.Column<DateTime>(nullable: false),
                    prepaga_proxima = table.Column<string>(nullable: true),
                    volveria = table.Column<string>(nullable: true),
                    motivo_baja_miembro = table.Column<string>(nullable: true),
                    motivo_baja_miembro_agrupado = table.Column<string>(nullable: true),
                    cobrador = table.Column<string>(nullable: true),
                    zona = table.Column<string>(nullable: true),
                    f_alta_grupo = table.Column<DateTime>(nullable: false),
                    f_antiguedad1 = table.Column<DateTime>(nullable: false),
                    promotor = table.Column<string>(nullable: true),
                    tipo_grupo = table.Column<string>(nullable: true),
                    presento = table.Column<string>(nullable: true),
                    f_baja = table.Column<DateTime>(nullable: false),
                    motivo_baja_grupo = table.Column<string>(nullable: true),
                    motivo_baja_agrupado_grupo = table.Column<string>(nullable: true),
                    paciente_cronico = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_padron", x => x.id_Padron);
                });

            migrationBuilder.CreateTable(
                name: "patologias",
                columns: table => new
                {
                    id_pat = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    codigo = table.Column<string>(nullable: true),
                    descripcion = table.Column<string>(nullable: true),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patologias", x => x.id_pat);
                });

            migrationBuilder.CreateTable(
                name: "recetas_registros",
                columns: table => new
                {
                    id_receta = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    numero_afiliado = table.Column<int>(nullable: false),
                    id_medicamento = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    id_medico = table.Column<int>(nullable: false),
                    id_pat = table.Column<int>(nullable: false),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recetas_registros", x => x.id_receta);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicamentos");

            migrationBuilder.DropTable(
                name: "medicos");

            migrationBuilder.DropTable(
                name: "padron");

            migrationBuilder.DropTable(
                name: "patologias");

            migrationBuilder.DropTable(
                name: "recetas_registros");
        }
    }
}
