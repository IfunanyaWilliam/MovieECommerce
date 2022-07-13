using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieECommerce.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Actors_Actors_ActorId1",
                table: "Movie_Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Actors_Movies_MovieId1",
                table: "Movie_Actors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie_Actors",
                table: "Movie_Actors");

            migrationBuilder.DropIndex(
                name: "IX_Movie_Actors_ActorId1",
                table: "Movie_Actors");

            migrationBuilder.DropIndex(
                name: "IX_Movie_Actors_MovieId1",
                table: "Movie_Actors");

            migrationBuilder.DropColumn(
                name: "ActorId1",
                table: "Movie_Actors");

            migrationBuilder.DropColumn(
                name: "MovieId1",
                table: "Movie_Actors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie_Actors",
                table: "Movie_Actors",
                columns: new[] { "MovieId", "ActorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Actors_Actors_MovieId",
                table: "Movie_Actors",
                column: "MovieId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Actors_Movies_MovieId",
                table: "Movie_Actors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Actors_Actors_MovieId",
                table: "Movie_Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Actors_Movies_MovieId",
                table: "Movie_Actors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie_Actors",
                table: "Movie_Actors");

            migrationBuilder.AddColumn<string>(
                name: "ActorId1",
                table: "Movie_Actors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MovieId1",
                table: "Movie_Actors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie_Actors",
                table: "Movie_Actors",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Actors_ActorId1",
                table: "Movie_Actors",
                column: "ActorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Actors_MovieId1",
                table: "Movie_Actors",
                column: "MovieId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Actors_Actors_ActorId1",
                table: "Movie_Actors",
                column: "ActorId1",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Actors_Movies_MovieId1",
                table: "Movie_Actors",
                column: "MovieId1",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
