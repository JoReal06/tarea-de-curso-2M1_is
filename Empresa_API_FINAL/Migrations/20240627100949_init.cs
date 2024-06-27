using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empresa_API_FINAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numEmpleado = table.Column<int>(type: "int", nullable: false),
                    numCedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numInss = table.Column<int>(type: "int", nullable: false),
                    numRuc = table.Column<int>(type: "int", nullable: false),
                    primerNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    segundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primerApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    segundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaDeNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: true),
                    celular = table.Column<int>(type: "int", nullable: true),
                    fechaDeContratacion = table.Column<DateOnly>(type: "date", nullable: false),
                    fechaDeCierreDeContrato = table.Column<DateOnly>(type: "date", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ingresos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    SalarioBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comisiones = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HorasExtra = table.Column<int>(type: "int", nullable: false),
                    Bonificaciones = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepreciacionVehiculo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ViaticoCombustible = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ViaticoAlimenticio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiesgoLaboral = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtrosIngresos = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingresos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nominas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    horasExtras = table.Column<int>(type: "int", nullable: false),
                    salarioBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    comisiones = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    bonificaciones = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    depreciacionVehiculo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    viaticoCobustible = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    inns = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ir = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    viaticoAlimenticioFijo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    viaticoAlimenticio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    riesgoLaboral = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    otrosIngresos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    prestamoBancario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    prestamoEmpresario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pensionAlimenticia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    deduccionPorDaños = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    viaticoPorHospedaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nominas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreDeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "deducciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empleadoId = table.Column<int>(type: "int", nullable: false),
                    Inns = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ir = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrestamoBancario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrestamoEmpresario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PensionAlimenticia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeduccionPorDaños = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deducciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_deducciones_empleados_empleadoId",
                        column: x => x.empleadoId,
                        principalTable: "empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_deducciones_empleadoId",
                table: "deducciones",
                column: "empleadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deducciones");

            migrationBuilder.DropTable(
                name: "ingresos");

            migrationBuilder.DropTable(
                name: "nominas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "empleados");
        }
    }
}
