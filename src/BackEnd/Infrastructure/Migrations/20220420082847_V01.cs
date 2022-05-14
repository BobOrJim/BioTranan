using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class V01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Language = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Subtitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cathegory = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MinutesLength = table.Column<int>(type: "int", nullable: true),
                    MinimumAgeLimit = table.Column<int>(type: "int", nullable: true),
                    PictureURL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    Director = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Actors = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceSEK = table.Column<int>(type: "int", nullable: true),
                    PurchasedViews = table.Column<int>(type: "int", nullable: false),
                    UsedViews = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieShows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PandemicSeatReduction = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieShows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieShows_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieShows_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieShowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationCode = table.Column<int>(type: "int", nullable: false),
                    ReservationCodeUsed = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfTickets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_MovieShows_MovieShowId",
                        column: x => x.MovieShowId,
                        principalTable: "MovieShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieShowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_MovieShows_MovieShowId",
                        column: x => x.MovieShowId,
                        principalTable: "MovieShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Actors", "Cathegory", "Description", "Director", "Language", "MinimumAgeLimit", "MinutesLength", "PictureURL", "PriceSEK", "PurchasedViews", "ReleaseDate", "Subtitle", "Title", "UsedViews" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000001"), "Carmen Electra, Nicole Parker, Valerie Wildman", "Drama", "En grupp av misslyckade äventyrare i 20-årsåldern hotas av så gott som alla kända katastrofer ? asteroider, orkanstormar och jordbävningar och kämpar för sina liv för att sätta sig i säkerhet.", "Jason Friedberg, Aaron Seltzer", "Eng tal", 11, 87, "https://m.media-amazon.com/images/M/MV5BMTIzMDQyNDgwNl5BMl5BanBnXkFtZTcwMDA0MTc3MQ@@._V1_FMjpg_UX405_.jpg", 90, 20, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swe text", "Disaster Movie", 10 },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), "Carmen Electra, Nicole Parker, Valerie Wildman", "Drama", "En grupp av misslyckade äventyrare i 20-årsåldern hotas av så gott som alla kända katastrofer ? asteroider, orkanstormar och jordbävningar och kämpar för sina liv för att sätta sig i säkerhet.", "Jason Friedberg, Aaron Seltzer", "Eng tal", 11, 87, "https://m.media-amazon.com/images/M/MV5BMTIzMDQyNDgwNl5BMl5BanBnXkFtZTcwMDA0MTc3MQ@@._V1_FMjpg_UX405_.jpg", 90, 20, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swe text", "Disaster Movie - ALL VIEWS ARE USED TEST", 20 },
                    { new Guid("b0000000-0000-0000-0000-000000000003"), "Tom Neyman, John Reynolds (I), Diane Mahree", "Skräck", "En familj åker vilse på landsbygden och hamnar vid en liten stuga. Där möts de av Torgo som säger att han sköter om stället åt The Master. Det visar sig under natten att The Master, hans många fruar och Torgo ingår i en kult som dyrkar den ondskefulle guden Manos", "Hal Warren", "Eng tal", 15, 88, "https://m.media-amazon.com/images/M/MV5BYjIxOWMyMzUtNTMzZC00MThjLTljYjQtZjhlOGQzZTkxOTFkXkEyXkFqcGdeQXVyNjMwMjk0MTQ@._V1_.jpg", 90, 60, new DateTime(1966, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swe text", "Manos, the Hands of Fate", 11 },
                    { new Guid("b0000000-0000-0000-0000-000000000004"), "Jon Voight, Scott Baio, Vanessa Angel, Peter Wingfield", "Komedi", "Om en superbebis med mystiska krafter som här hjälper en ny kull småstjärnor.", "Bob Clark", "Sve tal", 0, 88, "https://m.media-amazon.com/images/M/MV5BNjY4NjM3MjQ2OF5BMl5BanBnXkFtZTcwOTc3NzYyMQ@@._V1_FMjpg_UX485_.jpg", 90, 40, new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sve text", "SuperBabies: Baby Geniuses 2", 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000005"), "Carmen Electra, Nicole Parker, Valerie Wildman", "Drama", "En grupp av misslyckade äventyrare i 20-årsåldern hotas av så gott som alla kända katastrofer ? asteroider, orkanstormar och jordbävningar och kämpar för sina liv för att sätta sig i säkerhet.", "Jason Friedberg, Aaron Seltzer", "Eng tal", 11, 87, "https://m.media-amazon.com/images/M/MV5BMTIzMDQyNDgwNl5BMl5BanBnXkFtZTcwMDA0MTc3MQ@@._V1_FMjpg_UX405_.jpg", 90, 20, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swe text", "Disaster Movie 2", 10 },
                    { new Guid("b0000000-0000-0000-0000-000000000006"), "Carmen Electra, Nicole Parker, Valerie Wildman", "Drama", "En grupp av misslyckade äventyrare i 20-årsåldern hotas av så gott som alla kända katastrofer ? asteroider, orkanstormar och jordbävningar och kämpar för sina liv för att sätta sig i säkerhet.", "Jason Friedberg, Aaron Seltzer", "Eng tal", 11, 87, "https://m.media-amazon.com/images/M/MV5BMTIzMDQyNDgwNl5BMl5BanBnXkFtZTcwMDA0MTc3MQ@@._V1_FMjpg_UX405_.jpg", 90, 20, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swe text", "Disaster Movie 3", 10 }
                });

            migrationBuilder.InsertData(
                table: "Salons",
                columns: new[] { "Id", "Name", "TotalSeats" },
                values: new object[,]
                {
                    { new Guid("a0000000-0000-0000-0000-000000000001"), "Stora salen", 45 },
                    { new Guid("a0000000-0000-0000-0000-000000000002"), "Lilla salen", 20 }
                });

            migrationBuilder.InsertData(
                table: "MovieShows",
                columns: new[] { "Id", "DateTime", "MovieId", "PandemicSeatReduction", "SalonId" },
                values: new object[,]
                {
                    { new Guid("c0000000-0000-0000-0000-000000000001"), new DateTime(2022, 4, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b0000000-0000-0000-0000-000000000001"), 0, new Guid("a0000000-0000-0000-0000-000000000001") },
                    { new Guid("c0000000-0000-0000-0000-000000000002"), new DateTime(2022, 4, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b0000000-0000-0000-0000-000000000003"), 0, new Guid("a0000000-0000-0000-0000-000000000001") },
                    { new Guid("c0000000-0000-0000-0000-000000000003"), new DateTime(2022, 4, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b0000000-0000-0000-0000-000000000004"), 0, new Guid("a0000000-0000-0000-0000-000000000001") },
                    { new Guid("c0000000-0000-0000-0000-000000000004"), new DateTime(2022, 5, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b0000000-0000-0000-0000-000000000005"), 0, new Guid("a0000000-0000-0000-0000-000000000001") },
                    { new Guid("c0000000-0000-0000-0000-000000000005"), new DateTime(2022, 6, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b0000000-0000-0000-0000-000000000006"), 0, new Guid("a0000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Email", "MovieShowId", "NumberOfTickets", "ReservationCode", "ReservationCodeUsed" },
                values: new object[,]
                {
                    { new Guid("d0000000-0000-0000-0000-000000000001"), "pers1@gmail.com", new Guid("c0000000-0000-0000-0000-000000000001"), 10, 100001, false },
                    { new Guid("d0000000-0000-0000-0000-000000000002"), "pers2@gmail.com", new Guid("c0000000-0000-0000-0000-000000000001"), 10, 100002, false },
                    { new Guid("d0000000-0000-0000-0000-000000000003"), "pers3@gmail.com", new Guid("c0000000-0000-0000-0000-000000000001"), 10, 100003, false },
                    { new Guid("d0000000-0000-0000-0000-000000000004"), "pers4@gmail.com", new Guid("c0000000-0000-0000-0000-000000000001"), 10, 100004, false },
                    { new Guid("d0000000-0000-0000-0000-000000000005"), "pers5@gmail.com", new Guid("c0000000-0000-0000-0000-000000000001"), 1, 100005, false },
                    { new Guid("d0000000-0000-0000-0000-000000000006"), "pers6@gmail.com", new Guid("c0000000-0000-0000-0000-000000000001"), 1, 100006, false },
                    { new Guid("d0000000-0000-0000-0000-000000000007"), "pers7@gmail.com", new Guid("c0000000-0000-0000-0000-000000000002"), 26, 100007, false },
                    { new Guid("d0000000-0000-0000-0000-000000000008"), "pers8@gmail.com", new Guid("c0000000-0000-0000-0000-000000000003"), 2, 100008, false },
                    { new Guid("d0000000-0000-0000-0000-000000000009"), "pers9@gmail.com", new Guid("c0000000-0000-0000-0000-000000000004"), 45, 100009, false }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "MovieShowId", "Rating" },
                values: new object[,]
                {
                    { new Guid("e0000000-0000-0000-0000-000000000001"), "För mycket snack o för lite action", new Guid("c0000000-0000-0000-0000-000000000001"), 3 },
                    { new Guid("e0000000-0000-0000-0000-000000000002"), "Gillade CGI effekterna, en stark fyra!", new Guid("c0000000-0000-0000-0000-000000000001"), 4 },
                    { new Guid("e0000000-0000-0000-0000-000000000003"), "Skitfilm", new Guid("c0000000-0000-0000-0000-000000000001"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieShows_MovieId",
                table: "MovieShows",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieShows_SalonId",
                table: "MovieShows",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MovieShowId",
                table: "Reservations",
                column: "MovieShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MovieShowId",
                table: "Reviews",
                column: "MovieShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "MovieShows");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Salons");
        }
    }
}
