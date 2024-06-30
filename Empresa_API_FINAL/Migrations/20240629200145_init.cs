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
                name: "deducciones",
                columns: table => new
                {
                    deduccionesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empleadoId = table.Column<int>(type: "int", nullable: false),
                    nombreDeEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoDeEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrestamoBancario = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrestamoEmpresario = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PensionAlimenticia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeduccionPorDaños = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    despreciacionVehiculo = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deducciones", x => x.deduccionesId);
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    primerNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    segundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primerApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    segundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numCedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numInss = table.Column<long>(type: "bigint", nullable: false),
                    numRuc = table.Column<long>(type: "bigint", nullable: false),
                    sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<long>(type: "bigint", nullable: true),
                    celular = table.Column<long>(type: "bigint", nullable: true),
                    fechaDeNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    fechaDeContratacion = table.Column<DateOnly>(type: "date", nullable: false),
                    fechaDeCierreDeContrato = table.Column<DateOnly>(type: "date", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.EmpleadoId);
                });

            migrationBuilder.CreateTable(
                name: "ingresos",
                columns: table => new
                {
                    IngresosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    nombreDeEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoDeEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalarioBase = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Comisiones = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HorasExtra = table.Column<int>(type: "int", nullable: true),
                    Bonificaciones = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepreciacionVehiculo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ViaticoCombustible = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ViaticoAlimenticio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ViaticoPorHospedaje = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RiesgoLaboral = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtrosIngresos = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingresos", x => x.IngresosId);
                });

            migrationBuilder.CreateTable(
                name: "nominas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    NombreDeEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidoDeEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inns = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ir = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SalarioFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deducciones");

            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "ingresos");

            migrationBuilder.DropTable(
                name: "nominas");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
