using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Oprema_za_mob_telefone.Data.Migrations
{
    public partial class DodajCenuUProizvod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cena",
                table: "Proizvodi",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);//m decimalan
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Proizvodi");
        }
    }
}
