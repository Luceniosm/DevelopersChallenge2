using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplicacao.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "DataBank",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<string>(type: "varchar(300)", nullable: false),
                    CodeBank = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataBank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDataBank = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", nullable: false),
                    Account = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DateTrasaction = table.Column<DateTime>(type: "dateTime", nullable: false),
                    CodeBank = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_DataBank_IdDataBank",
                        column: x => x.IdDataBank,
                        principalSchema: "dbo",
                        principalTable: "DataBank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_IdDataBank",
                schema: "dbo",
                table: "Transaction",
                column: "IdDataBank");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DataBank",
                schema: "dbo");
        }
    }
}
