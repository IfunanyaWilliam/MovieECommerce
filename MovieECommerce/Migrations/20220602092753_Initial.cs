using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieECommerce.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullNname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BioInformation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    CinemaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.CinemaId);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    ProducerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullNname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BioInformation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.ProducerId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    CinemaId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: false),
                    ProducerId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Cinemas_CinemaId1",
                        column: x => x.CinemaId1,
                        principalTable: "Cinemas",
                        principalColumn: "CinemaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Producers_ProducerId1",
                        column: x => x.ProducerId1,
                        principalTable: "Producers",
                        principalColumn: "ProducerId");
                });

            migrationBuilder.CreateTable(
                name: "Movie_Actors",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    ActorId1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_Actors", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movie_Actors_Actors_ActorId1",
                        column: x => x.ActorId1,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Actors_Movies_MovieId1",
                        column: x => x.MovieId1,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Actors_ActorId1",
                table: "Movie_Actors",
                column: "ActorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Actors_MovieId1",
                table: "Movie_Actors",
                column: "MovieId1");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CinemaId1",
                table: "Movies",
                column: "CinemaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ProducerId1",
                table: "Movies",
                column: "ProducerId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie_Actors");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Producers");
        }
    }
}
