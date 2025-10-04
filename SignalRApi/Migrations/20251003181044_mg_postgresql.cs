using System;
using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

namespace SignalRApi.Migrations
{
    /// <inheritdoc />
    public partial class mg_postgresql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    //VisitorID = table.Column<int>(type: "integer", nullable: false)
                    //    .Annotation("Npgsql:ValueGenerationStrategy", /*NpgsqlValueGenerationStrategy.IdentityByDefaultColumn*/
                    //City = table.Column<int>(type: "integer", nullable: false),
                    //CityVisitCount = table.Column<int>(type: "integer", nullable: false),
                    //VisitDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    //table.PrimaryKey("PK_Visitors", x => x.VisitorID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visitors");
        }
    }
}
