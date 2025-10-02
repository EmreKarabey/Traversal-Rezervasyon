using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mg_update_Guide_Destination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1) Destinations tablosuna nullable GuideID kolonu ekle
            migrationBuilder.AddColumn<int>(
                name: "GuideID",
                table: "Destinations",
                type: "int",
                nullable: true);

            // 2) GuideID için index
            migrationBuilder.CreateIndex(
                name: "IX_Destinations_GuideID",
                table: "Destinations",
                column: "GuideID");

            // 3) FK: Destinations(GuideID) -> Guides(GuideID)
            // OnDelete davranışını modelde SetNull yaptınsa alttaki satırı
            // onDelete: ReferentialAction.SetNull olarak kullanabilirsin.
            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Guides_GuideID",
                table: "Destinations",
                column: "GuideID",
                principalTable: "Guides",
                principalColumn: "GuideID"
            // , onDelete: ReferentialAction.SetNull
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Ters işlemler
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Guides_GuideID",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_GuideID",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "GuideID",
                table: "Destinations");
        }
    }
}
