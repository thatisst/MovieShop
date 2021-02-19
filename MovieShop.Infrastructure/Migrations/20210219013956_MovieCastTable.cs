using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieShop.Infrastructure.Migrations
{
    public partial class MovieCastTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviePurchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast");

            migrationBuilder.DropIndex(
                name: "IX_MovieCast_MovieId",
                table: "MovieCast");

            migrationBuilder.AddColumn<string>(
                name: "Character",
                table: "MovieCast",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast",
                columns: new[] { "MovieId", "CastId", "Character" });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_MovieId",
                table: "Purchase",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_CastId",
                table: "MovieCast",
                column: "CastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Movie_MovieId",
                table: "Purchase",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Movie_MovieId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_MovieId",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast");

            migrationBuilder.DropIndex(
                name: "IX_MovieCast_CastId",
                table: "MovieCast");

            migrationBuilder.DropColumn(
                name: "Character",
                table: "MovieCast");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast",
                columns: new[] { "CastId", "MovieId" });

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
                name: "IX_MovieCast_MovieId",
                table: "MovieCast",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePurchase_PurchasesId",
                table: "MoviePurchase",
                column: "PurchasesId");
        }
    }
}
