using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDLesson.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsInOurShift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInOurShift",
                table: "Workers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInOurShift",
                table: "Workers");
        }
    }
}
