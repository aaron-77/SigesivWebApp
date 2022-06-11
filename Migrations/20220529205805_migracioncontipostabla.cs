using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SigesivServer.Migrations
{
    public partial class migracioncontipostabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asegurado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: true),
                    fkUsuario = table.Column<int>(type: "int", nullable: true),
                    nombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaDeNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    numeroDeLicencia = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "casosdecobertura",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreDelCaso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    condiciones = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_casosdecobertura", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "estadospolizas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadospolizas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "estadosreporte",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadosreporte", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "estadosvehiculosasegurados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadosvehiculosasegurados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "marcas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marcas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    fkAsegurado = table.Column<int>(type: "int", nullable: false),
                    numDeTarjeta = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "poliza",
                columns: table => new
                {
                    idAsegurado = table.Column<int>(type: "int", nullable: false),
                    fechaDeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroDeLicencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idPoliza = table.Column<int>(type: "int", nullable: false),
                    numeroDePoliza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaDeInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaDeExpiracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipoDeCobertura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lapsoDeCobertura = table.Column<int>(type: "int", nullable: false),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroDePlacas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    año = table.Column<int>(type: "int", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Poliza",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroDePoliza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fkVehiculoAsegurado = table.Column<int>(type: "int", nullable: false),
                    fkAsegurado = table.Column<int>(type: "int", nullable: false),
                    fkTipoDeCobertura = table.Column<int>(type: "int", nullable: false),
                    fkPago = table.Column<int>(type: "int", nullable: false),
                    fechaDeInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaDeExpiracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    costoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fkEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliza", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sp_obtenerCoberturaDePoliza",
                columns: table => new
                {
                    nombreDelCaso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    condiciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tiposdecobertura",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoDeCobertura = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lapsoDeCobertura = table.Column<int>(type: "int", nullable: false),
                    costo = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiposdecobertura", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    fkRol = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "VehiculoAsegurado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: true),
                    numeroDeSerie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fkMarca = table.Column<int>(type: "int", nullable: false),
                    fkModelo = table.Column<int>(type: "int", nullable: false),
                    año = table.Column<int>(type: "int", nullable: false),
                    color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    numeroDePlacas = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fkEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "modelos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkMarca = table.Column<int>(type: "int", nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Modelos_marcas",
                        column: x => x.fkMarca,
                        principalTable: "marcas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkRol = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_roles",
                        column: x => x.fkRol,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tiposdecobertura_casosdecobertura",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkTipoDeCobertura = table.Column<int>(type: "int", nullable: false),
                    fkCasoDeCobertura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiposdecobertura_casosdecobertura", x => x.id);
                    table.ForeignKey(
                        name: "FK_tiposDeCobertura_casosDeCobertura_casosdecobertura",
                        column: x => x.fkCasoDeCobertura,
                        principalTable: "casosdecobertura",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tiposDeCobertura_casosDeCobertura_tiposDeCobertura",
                        column: x => x.fkTipoDeCobertura,
                        principalTable: "tiposdecobertura",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vehiculosasegurados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroDeSerie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fkMarca = table.Column<int>(type: "int", nullable: false),
                    fkModelo = table.Column<int>(type: "int", nullable: false),
                    año = table.Column<int>(type: "int", nullable: false),
                    color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    numeroDePlacas = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fkEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculosasegurados", x => x.id);
                    table.ForeignKey(
                        name: "FK_VehiculosAsegurados_estadosVehiculosAsegurados",
                        column: x => x.fkEstado,
                        principalTable: "estadosvehiculosasegurados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehiculosAsegurados_marcas",
                        column: x => x.fkMarca,
                        principalTable: "marcas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehiculosAsegurados_Modelos",
                        column: x => x.fkModelo,
                        principalTable: "modelos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "asegurados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkUsuario = table.Column<int>(type: "int", nullable: false),
                    nombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaDeNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    numeroDeLicencia = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asegurados", x => x.id);
                    table.ForeignKey(
                        name: "FK_Asegurados_usuarios",
                        column: x => x.fkUsuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkUsuario = table.Column<int>(type: "int", nullable: false),
                    fkRol = table.Column<int>(type: "int", nullable: false),
                    nombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaDeIngreso = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal", x => x.id);
                    table.ForeignKey(
                        name: "FK_personal_roles",
                        column: x => x.fkRol,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personal_usuarios",
                        column: x => x.fkUsuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pagos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkAsegurado = table.Column<int>(type: "int", nullable: false),
                    numDeTarjeta = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pagos_Asegurados",
                        column: x => x.fkAsegurado,
                        principalTable: "asegurados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reportesdeincidente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkAsegurado = table.Column<int>(type: "int", nullable: false),
                    fkVehiculoAsegurado = table.Column<int>(type: "int", nullable: false),
                    fkPersonal = table.Column<int>(type: "int", nullable: false),
                    latitud = table.Column<decimal>(type: "decimal(8,6)", nullable: false),
                    longitud = table.Column<decimal>(type: "decimal(8,6)", nullable: false),
                    urlImagen1 = table.Column<string>(type: "text", nullable: false),
                    urlImagen2 = table.Column<string>(type: "text", nullable: false),
                    urlImagen3 = table.Column<string>(type: "text", nullable: false),
                    urlImagen4 = table.Column<string>(type: "text", nullable: false),
                    urlImagen5 = table.Column<string>(type: "text", nullable: true),
                    urlImagen6 = table.Column<string>(type: "text", nullable: true),
                    urlImagen7 = table.Column<string>(type: "text", nullable: true),
                    urlImagen8 = table.Column<string>(type: "text", nullable: true),
                    fkEstado = table.Column<int>(type: "int", nullable: false),
                    fechaDelReporte = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reportesdeincidente", x => x.id);
                    table.ForeignKey(
                        name: "FK_reportesDeSiniestro_asegurados1",
                        column: x => x.fkAsegurado,
                        principalTable: "asegurados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reportesDeSiniestro_estadosReporte",
                        column: x => x.fkEstado,
                        principalTable: "estadosreporte",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reportesDeSiniestro_personal",
                        column: x => x.fkPersonal,
                        principalTable: "personal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reportesDeSiniestro_VehiculosAsegurados",
                        column: x => x.fkVehiculoAsegurado,
                        principalTable: "vehiculosasegurados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "polizasdeseguro",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroDePoliza = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fkVehiculoAsegurado = table.Column<int>(type: "int", nullable: false),
                    fkAsegurado = table.Column<int>(type: "int", nullable: false),
                    fkTipoDeCobertura = table.Column<int>(type: "int", nullable: false),
                    fkPago = table.Column<int>(type: "int", nullable: false),
                    fechaDeInicio = table.Column<DateTime>(type: "date", nullable: false),
                    fechaDeExpiracion = table.Column<DateTime>(type: "date", nullable: false),
                    costoTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    fkEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_polizasdeseguro", x => x.id);
                    table.ForeignKey(
                        name: "FK_polizasDeSeguro_Asegurados",
                        column: x => x.fkAsegurado,
                        principalTable: "asegurados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_polizasDeSeguro_estadosPolizas",
                        column: x => x.fkEstado,
                        principalTable: "estadospolizas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_polizasDeSeguro_Pagos",
                        column: x => x.fkPago,
                        principalTable: "pagos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_polizasDeSeguro_tiposDeCobertura",
                        column: x => x.fkTipoDeCobertura,
                        principalTable: "tiposdecobertura",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_polizasDeSeguro_VehiculosAsegurados",
                        column: x => x.fkVehiculoAsegurado,
                        principalTable: "vehiculosasegurados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "otrosinvolucrados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkReporte = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_otrosinvolucrados", x => x.id);
                    table.ForeignKey(
                        name: "FK_otrosInvolucrados_reportesDeSiniestro",
                        column: x => x.fkReporte,
                        principalTable: "reportesdeincidente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "otrosvehiculosinvolucrados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkOtroInvolucrado = table.Column<int>(type: "int", nullable: true),
                    fkmarca = table.Column<int>(type: "int", nullable: true),
                    fkmodelo = table.Column<int>(type: "int", nullable: true),
                    color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    numeroDePlaca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    fkReporte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_otrosvehiculosinvolucrados", x => x.id);
                    table.ForeignKey(
                        name: "FK_otrosVehiculosInvolucrados_otrosInvolucrados",
                        column: x => x.fkOtroInvolucrado,
                        principalTable: "otrosinvolucrados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_otrosVehiculosInvolucrados_reportesDeSiniestro",
                        column: x => x.fkReporte,
                        principalTable: "reportesdeincidente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_asegurados_fkUsuario",
                table: "asegurados",
                column: "fkUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_modelos_fkMarca",
                table: "modelos",
                column: "fkMarca");

            migrationBuilder.CreateIndex(
                name: "IX_otrosinvolucrados_fkReporte",
                table: "otrosinvolucrados",
                column: "fkReporte");

            migrationBuilder.CreateIndex(
                name: "IX_otrosvehiculosinvolucrados_fkOtroInvolucrado",
                table: "otrosvehiculosinvolucrados",
                column: "fkOtroInvolucrado");

            migrationBuilder.CreateIndex(
                name: "IX_otrosvehiculosinvolucrados_fkReporte",
                table: "otrosvehiculosinvolucrados",
                column: "fkReporte");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_fkAsegurado",
                table: "pagos",
                column: "fkAsegurado");

            migrationBuilder.CreateIndex(
                name: "IX_personal_fkRol",
                table: "personal",
                column: "fkRol");

            migrationBuilder.CreateIndex(
                name: "IX_personal_fkUsuario",
                table: "personal",
                column: "fkUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_polizasdeseguro_fkAsegurado",
                table: "polizasdeseguro",
                column: "fkAsegurado");

            migrationBuilder.CreateIndex(
                name: "IX_polizasdeseguro_fkEstado",
                table: "polizasdeseguro",
                column: "fkEstado");

            migrationBuilder.CreateIndex(
                name: "IX_polizasdeseguro_fkPago",
                table: "polizasdeseguro",
                column: "fkPago");

            migrationBuilder.CreateIndex(
                name: "IX_polizasdeseguro_fkTipoDeCobertura",
                table: "polizasdeseguro",
                column: "fkTipoDeCobertura");

            migrationBuilder.CreateIndex(
                name: "IX_polizasdeseguro_fkVehiculoAsegurado",
                table: "polizasdeseguro",
                column: "fkVehiculoAsegurado");

            migrationBuilder.CreateIndex(
                name: "IX_reportesdeincidente_fkAsegurado",
                table: "reportesdeincidente",
                column: "fkAsegurado");

            migrationBuilder.CreateIndex(
                name: "IX_reportesdeincidente_fkEstado",
                table: "reportesdeincidente",
                column: "fkEstado");

            migrationBuilder.CreateIndex(
                name: "IX_reportesdeincidente_fkPersonal",
                table: "reportesdeincidente",
                column: "fkPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_reportesdeincidente_fkVehiculoAsegurado",
                table: "reportesdeincidente",
                column: "fkVehiculoAsegurado");

            migrationBuilder.CreateIndex(
                name: "IX_tiposdecobertura_casosdecobertura_fkCasoDeCobertura",
                table: "tiposdecobertura_casosdecobertura",
                column: "fkCasoDeCobertura");

            migrationBuilder.CreateIndex(
                name: "IX_tiposdecobertura_casosdecobertura_fkTipoDeCobertura",
                table: "tiposdecobertura_casosdecobertura",
                column: "fkTipoDeCobertura");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_fkRol",
                table: "usuarios",
                column: "fkRol");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculosasegurados_fkEstado",
                table: "vehiculosasegurados",
                column: "fkEstado");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculosasegurados_fkMarca",
                table: "vehiculosasegurados",
                column: "fkMarca");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculosasegurados_fkModelo",
                table: "vehiculosasegurados",
                column: "fkModelo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asegurado");

            migrationBuilder.DropTable(
                name: "otrosvehiculosinvolucrados");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "poliza");

            migrationBuilder.DropTable(
                name: "Poliza");

            migrationBuilder.DropTable(
                name: "polizasdeseguro");

            migrationBuilder.DropTable(
                name: "sp_obtenerCoberturaDePoliza");

            migrationBuilder.DropTable(
                name: "tiposdecobertura_casosdecobertura");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "VehiculoAsegurado");

            migrationBuilder.DropTable(
                name: "otrosinvolucrados");

            migrationBuilder.DropTable(
                name: "estadospolizas");

            migrationBuilder.DropTable(
                name: "pagos");

            migrationBuilder.DropTable(
                name: "casosdecobertura");

            migrationBuilder.DropTable(
                name: "tiposdecobertura");

            migrationBuilder.DropTable(
                name: "reportesdeincidente");

            migrationBuilder.DropTable(
                name: "asegurados");

            migrationBuilder.DropTable(
                name: "estadosreporte");

            migrationBuilder.DropTable(
                name: "personal");

            migrationBuilder.DropTable(
                name: "vehiculosasegurados");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "estadosvehiculosasegurados");

            migrationBuilder.DropTable(
                name: "modelos");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "marcas");
        }
    }
}
