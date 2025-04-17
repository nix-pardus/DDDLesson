using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDLesson.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackagingTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    PricePerSquareMeter = table.Column<double>(type: "REAL", nullable: false),
                    PricePerSquareMeterOnWeekend = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsWeekend = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WorkerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PackagingTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Area = table.Column<double>(type: "REAL", nullable: false),
                    WorkDayId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkUnits_PackagingTypes_PackagingTypeId",
                        column: x => x.PackagingTypeId,
                        principalTable: "PackagingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkUnits_WorkDays_WorkDayId",
                        column: x => x.WorkDayId,
                        principalTable: "WorkDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkUnits_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkUnits_PackagingTypeId",
                table: "WorkUnits",
                column: "PackagingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkUnits_WorkDayId",
                table: "WorkUnits",
                column: "WorkDayId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkUnits_WorkerId",
                table: "WorkUnits",
                column: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkUnits");

            migrationBuilder.DropTable(
                name: "PackagingTypes");

            migrationBuilder.DropTable(
                name: "WorkDays");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
