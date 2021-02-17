using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieShop.Infrastructure.Migrations
{
    public partial class PurchaseTableAddForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Purchase_PurchaseId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Review_UserId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Movie_PurchaseId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Movie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                columns: new[] { "UserId", "MovieId" });

            migrationBuilder.CreateTable(
                name: "MoviePurchase",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    PurchasesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePurchase", x => new { x.MoviesId, x.PurchasesId });
                    table.ForeignKey(
                        name: "FK_MoviePurchase_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePurchase_Purchase_PurchasesId",
                        column: x => x.PurchasesId,
                        principalTable: "Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviePurchase_PurchasesId",
                table: "MoviePurchase",
                column: "PurchasesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviePurchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_PurchaseId",
                table: "Movie",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Purchase_PurchaseId",
                table: "Movie",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
