using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafeLinkApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_REGIAO",
                columns: table => new
                {
                    ID_REGIAO = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_CIDADE = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    SG_ESTADO = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    VL_LATITUDE = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    VL_LONGITUDE = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    NM_REGIAO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_REGIAO", x => x.ID_REGIAO);
                });

            migrationBuilder.CreateTable(
                name: "TB_USER",
                columns: table => new
                {
                    ID_USER = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_EMAIL = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    DS_SENHA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    TP_ROLE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER", x => x.ID_USER);
                });

            migrationBuilder.CreateTable(
                name: "TB_ALERTA",
                columns: table => new
                {
                    ID_ALERTA = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DT_CRIACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DT_EMITIDO_EM = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DS_MENSAGEM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    DS_NIVEL_RISCO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ID_REGIAO = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALERTA", x => x.ID_ALERTA);
                    table.ForeignKey(
                        name: "FK_TB_ALERTA_TB_REGIAO_ID_REGIAO",
                        column: x => x.ID_REGIAO,
                        principalTable: "TB_REGIAO",
                        principalColumn: "ID_REGIAO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_EVENTO_NATURAL",
                columns: table => new
                {
                    ID_EVENTO_NATURAL = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DT_CRIACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DT_OCORRENCIA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DS_DESCRICAO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    DS_TIPO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ID_REGIAO = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EVENTO_NATURAL", x => x.ID_EVENTO_NATURAL);
                    table.ForeignKey(
                        name: "FK_TB_EVENTO_NATURAL_TB_REGIAO_ID_REGIAO",
                        column: x => x.ID_REGIAO,
                        principalTable: "TB_REGIAO",
                        principalColumn: "ID_REGIAO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PREVISAO_RISCO",
                columns: table => new
                {
                    ID_PREVISAO_RISCO = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DT_CRIACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DT_GERADO_EM = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DS_FONTE = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    DS_NIVEL_PREVISTO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ID_REGIAO = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PREVISAO_RISCO", x => x.ID_PREVISAO_RISCO);
                    table.ForeignKey(
                        name: "FK_TB_PREVISAO_RISCO_TB_REGIAO_ID_REGIAO",
                        column: x => x.ID_REGIAO,
                        principalTable: "TB_REGIAO",
                        principalColumn: "ID_REGIAO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_RELATO_USUARIO",
                columns: table => new
                {
                    ID_RELATO_USUARIO = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DT_CRIACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DT_RELATO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DS_MENSAGEM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    ID_USUARIO = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ID_REGIAO = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RELATO_USUARIO", x => x.ID_RELATO_USUARIO);
                    table.ForeignKey(
                        name: "FK_TB_RELATO_USUARIO_TB_REGIAO_ID_REGIAO",
                        column: x => x.ID_REGIAO,
                        principalTable: "TB_REGIAO",
                        principalColumn: "ID_REGIAO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_RELATO_USUARIO_TB_USER_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "TB_USER",
                        principalColumn: "ID_USER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALERTA_ID_REGIAO",
                table: "TB_ALERTA",
                column: "ID_REGIAO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_EVENTO_NATURAL_ID_REGIAO",
                table: "TB_EVENTO_NATURAL",
                column: "ID_REGIAO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PREVISAO_RISCO_ID_REGIAO",
                table: "TB_PREVISAO_RISCO",
                column: "ID_REGIAO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RELATO_USUARIO_ID_REGIAO",
                table: "TB_RELATO_USUARIO",
                column: "ID_REGIAO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RELATO_USUARIO_ID_USUARIO",
                table: "TB_RELATO_USUARIO",
                column: "ID_USUARIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ALERTA");

            migrationBuilder.DropTable(
                name: "TB_EVENTO_NATURAL");

            migrationBuilder.DropTable(
                name: "TB_PREVISAO_RISCO");

            migrationBuilder.DropTable(
                name: "TB_RELATO_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_REGIAO");

            migrationBuilder.DropTable(
                name: "TB_USER");
        }
    }
}
