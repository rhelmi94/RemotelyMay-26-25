﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace RaefTech.Server.Migrations.Sqlite;

public partial class DisplayName : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "DisplayName",
            table: "RaefTechUsers",
            maxLength: 100,
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "DisplayName",
            table: "RaefTechUsers");
    }
}
