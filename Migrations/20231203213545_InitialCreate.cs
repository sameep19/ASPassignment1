using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace swimming.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Swimming",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PoolName = table.Column<string>(type: "TEXT", nullable: false),
                    PoolLength = table.Column<string>(type: "TEXT", nullable: false),
                    PoolLocation = table.Column<string>(type: "TEXT", nullable: false),
                    PoolCapacity = table.Column<string>(type: "TEXT", nullable: false),
                    PoolTimings = table.Column<string>(type: "TEXT", nullable: false),
                    PoolDays = table.Column<string>(type: "TEXT", nullable: false),
                    PoolSize = table.Column<decimal>(type: "TEXT", nullable: false),
                    EntryDeadline = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Swimming", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Swimming");
        }
    }
}
