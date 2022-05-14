﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(TrananDbContext))]
    partial class TrananDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Common.Entities.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Actors")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Cathegory")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Description")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Language")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("MinimumAgeLimit")
                        .HasColumnType("int");

                    b.Property<int?>("MinutesLength")
                        .HasColumnType("int");

                    b.Property<string>("PictureURL")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("PriceSEK")
                        .HasColumnType("int");

                    b.Property<int>("PurchasedViews")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subtitle")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UsedViews")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b0000000-0000-0000-0000-000000000001"),
                            Actors = "Carmen Electra, Nicole Parker, Valerie Wildman",
                            Cathegory = "Drama",
                            Description = "En grupp av misslyckade äventyrare i 20-årsåldern hotas av så gott som alla kända katastrofer ? asteroider, orkanstormar och jordbävningar och kämpar för sina liv för att sätta sig i säkerhet.",
                            Director = "Jason Friedberg, Aaron Seltzer",
                            Language = "Eng tal",
                            MinimumAgeLimit = 11,
                            MinutesLength = 87,
                            PictureURL = "https://m.media-amazon.com/images/M/MV5BMTIzMDQyNDgwNl5BMl5BanBnXkFtZTcwMDA0MTc3MQ@@._V1_FMjpg_UX405_.jpg",
                            PriceSEK = 90,
                            PurchasedViews = 20,
                            ReleaseDate = new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subtitle = "Swe text",
                            Title = "Disaster Movie",
                            UsedViews = 10
                        },
                        new
                        {
                            Id = new Guid("b0000000-0000-0000-0000-000000000002"),
                            Actors = "Carmen Electra, Nicole Parker, Valerie Wildman",
                            Cathegory = "Drama",
                            Description = "En grupp av misslyckade äventyrare i 20-årsåldern hotas av så gott som alla kända katastrofer ? asteroider, orkanstormar och jordbävningar och kämpar för sina liv för att sätta sig i säkerhet.",
                            Director = "Jason Friedberg, Aaron Seltzer",
                            Language = "Eng tal",
                            MinimumAgeLimit = 11,
                            MinutesLength = 87,
                            PictureURL = "https://m.media-amazon.com/images/M/MV5BMTIzMDQyNDgwNl5BMl5BanBnXkFtZTcwMDA0MTc3MQ@@._V1_FMjpg_UX405_.jpg",
                            PriceSEK = 90,
                            PurchasedViews = 20,
                            ReleaseDate = new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subtitle = "Swe text",
                            Title = "Disaster Movie - ALL VIEWS ARE USED TEST",
                            UsedViews = 20
                        },
                        new
                        {
                            Id = new Guid("b0000000-0000-0000-0000-000000000003"),
                            Actors = "Tom Neyman, John Reynolds (I), Diane Mahree",
                            Cathegory = "Skräck",
                            Description = "En familj åker vilse på landsbygden och hamnar vid en liten stuga. Där möts de av Torgo som säger att han sköter om stället åt The Master. Det visar sig under natten att The Master, hans många fruar och Torgo ingår i en kult som dyrkar den ondskefulle guden Manos",
                            Director = "Hal Warren",
                            Language = "Eng tal",
                            MinimumAgeLimit = 15,
                            MinutesLength = 88,
                            PictureURL = "https://m.media-amazon.com/images/M/MV5BYjIxOWMyMzUtNTMzZC00MThjLTljYjQtZjhlOGQzZTkxOTFkXkEyXkFqcGdeQXVyNjMwMjk0MTQ@._V1_.jpg",
                            PriceSEK = 90,
                            PurchasedViews = 60,
                            ReleaseDate = new DateTime(1966, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subtitle = "Swe text",
                            Title = "Manos, the Hands of Fate",
                            UsedViews = 11
                        },
                        new
                        {
                            Id = new Guid("b0000000-0000-0000-0000-000000000004"),
                            Actors = "Jon Voight, Scott Baio, Vanessa Angel, Peter Wingfield",
                            Cathegory = "Komedi",
                            Description = "Om en superbebis med mystiska krafter som här hjälper en ny kull småstjärnor.",
                            Director = "Bob Clark",
                            Language = "Sve tal",
                            MinimumAgeLimit = 0,
                            MinutesLength = 88,
                            PictureURL = "https://m.media-amazon.com/images/M/MV5BNjY4NjM3MjQ2OF5BMl5BanBnXkFtZTcwOTc3NzYyMQ@@._V1_FMjpg_UX485_.jpg",
                            PriceSEK = 90,
                            PurchasedViews = 40,
                            ReleaseDate = new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subtitle = "Sve text",
                            Title = "SuperBabies: Baby Geniuses 2",
                            UsedViews = 3
                        },
                        new
                        {
                            Id = new Guid("b0000000-0000-0000-0000-000000000005"),
                            Actors = "Carmen Electra, Nicole Parker, Valerie Wildman",
                            Cathegory = "Drama",
                            Description = "En grupp av misslyckade äventyrare i 20-årsåldern hotas av så gott som alla kända katastrofer ? asteroider, orkanstormar och jordbävningar och kämpar för sina liv för att sätta sig i säkerhet.",
                            Director = "Jason Friedberg, Aaron Seltzer",
                            Language = "Eng tal",
                            MinimumAgeLimit = 11,
                            MinutesLength = 87,
                            PictureURL = "https://m.media-amazon.com/images/M/MV5BMTIzMDQyNDgwNl5BMl5BanBnXkFtZTcwMDA0MTc3MQ@@._V1_FMjpg_UX405_.jpg",
                            PriceSEK = 90,
                            PurchasedViews = 20,
                            ReleaseDate = new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subtitle = "Swe text",
                            Title = "Disaster Movie 2",
                            UsedViews = 10
                        },
                        new
                        {
                            Id = new Guid("b0000000-0000-0000-0000-000000000006"),
                            Actors = "Carmen Electra, Nicole Parker, Valerie Wildman",
                            Cathegory = "Drama",
                            Description = "En grupp av misslyckade äventyrare i 20-årsåldern hotas av så gott som alla kända katastrofer ? asteroider, orkanstormar och jordbävningar och kämpar för sina liv för att sätta sig i säkerhet.",
                            Director = "Jason Friedberg, Aaron Seltzer",
                            Language = "Eng tal",
                            MinimumAgeLimit = 11,
                            MinutesLength = 87,
                            PictureURL = "https://m.media-amazon.com/images/M/MV5BMTIzMDQyNDgwNl5BMl5BanBnXkFtZTcwMDA0MTc3MQ@@._V1_FMjpg_UX405_.jpg",
                            PriceSEK = 90,
                            PurchasedViews = 20,
                            ReleaseDate = new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subtitle = "Swe text",
                            Title = "Disaster Movie 3",
                            UsedViews = 10
                        });
                });

            modelBuilder.Entity("Common.Entities.MovieShow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("PandemicSeatReduction")
                        .HasColumnType("int");

                    b.Property<Guid>("SalonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("SalonId");

                    b.ToTable("MovieShows");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c0000000-0000-0000-0000-000000000001"),
                            DateTime = new DateTime(2022, 4, 2, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = new Guid("b0000000-0000-0000-0000-000000000001"),
                            PandemicSeatReduction = 0,
                            SalonId = new Guid("a0000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("c0000000-0000-0000-0000-000000000002"),
                            DateTime = new DateTime(2022, 4, 12, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = new Guid("b0000000-0000-0000-0000-000000000003"),
                            PandemicSeatReduction = 0,
                            SalonId = new Guid("a0000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("c0000000-0000-0000-0000-000000000003"),
                            DateTime = new DateTime(2022, 4, 22, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = new Guid("b0000000-0000-0000-0000-000000000004"),
                            PandemicSeatReduction = 0,
                            SalonId = new Guid("a0000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("c0000000-0000-0000-0000-000000000004"),
                            DateTime = new DateTime(2022, 5, 2, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = new Guid("b0000000-0000-0000-0000-000000000005"),
                            PandemicSeatReduction = 0,
                            SalonId = new Guid("a0000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("c0000000-0000-0000-0000-000000000005"),
                            DateTime = new DateTime(2022, 6, 13, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = new Guid("b0000000-0000-0000-0000-000000000006"),
                            PandemicSeatReduction = 0,
                            SalonId = new Guid("a0000000-0000-0000-0000-000000000001")
                        });
                });

            modelBuilder.Entity("Common.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MovieShowId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfTickets")
                        .HasColumnType("int");

                    b.Property<int>("ReservationCode")
                        .HasColumnType("int");

                    b.Property<bool>("ReservationCodeUsed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MovieShowId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d0000000-0000-0000-0000-000000000001"),
                            Email = "pers1@gmail.com",
                            MovieShowId = new Guid("c0000000-0000-0000-0000-000000000001"),
                            NumberOfTickets = 10,
                            ReservationCode = 100001,
                            ReservationCodeUsed = false
                        },
                        new
                        {
                            Id = new Guid("d0000000-0000-0000-0000-000000000002"),
                            Email = "pers2@gmail.com",
                            MovieShowId = new Guid("c0000000-0000-0000-0000-000000000001"),
                            NumberOfTickets = 10,
                            ReservationCode = 100002,
                            ReservationCodeUsed = false
                        },
                        new
                        {
                            Id = new Guid("d0000000-0000-0000-0000-000000000003"),
                            Email = "pers3@gmail.com",
                            MovieShowId = new Guid("c0000000-0000-0000-0000-000000000001"),
                            NumberOfTickets = 10,
                            ReservationCode = 100003,
                            ReservationCodeUsed = false
                        },
                        new
                        {
                            Id = new Guid("d0000000-0000-0000-0000-000000000004"),
                            Email = "pers4@gmail.com",
                            MovieShowId = new Guid("c0000000-0000-0000-0000-000000000001"),
                            NumberOfTickets = 10,
                            ReservationCode = 100004,
                            ReservationCodeUsed = false
                        },
                        new
                        {
                            Id = new Guid("d0000000-0000-0000-0000-000000000005"),
                            Email = "pers5@gmail.com",
                            MovieShowId = new Guid("c0000000-0000-0000-0000-000000000001"),
                            NumberOfTickets = 1,
                            ReservationCode = 100005,
                            ReservationCodeUsed = false
                        },
                        new
                        {
                            Id = new Guid("d0000000-0000-0000-0000-000000000006"),
                            Email = "pers6@gmail.com",
                            MovieShowId = new Guid("c0000000-0000-0000-0000-000000000001"),
                            NumberOfTickets = 1,
                            ReservationCode = 100006,
                            ReservationCodeUsed = false
                        },
                        new
                        {
                            Id = new Guid("d0000000-0000-0000-0000-000000000007"),
                            Email = "pers7@gmail.com",
                            MovieShowId = new Guid("c0000000-0000-0000-0000-000000000002"),
                            NumberOfTickets = 26,
                            ReservationCode = 100007,
                            ReservationCodeUsed = false
                        },
                        new
                        {
                            Id = new Guid("d0000000-0000-0000-0000-000000000008"),
                            Email = "pers8@gmail.com",
                            MovieShowId = new Guid("c0000000-0000-0000-0000-000000000003"),
                            NumberOfTickets = 2,
                            ReservationCode = 100008,
                            ReservationCodeUsed = false
                        },
                        new
                        {
                            Id = new Guid("d0000000-0000-0000-0000-000000000009"),
                            Email = "pers9@gmail.com",
                            MovieShowId = new Guid("c0000000-0000-0000-0000-000000000004"),
                            NumberOfTickets = 45,
                            ReservationCode = 100009,
                            ReservationCodeUsed = false
                        });
                });

            modelBuilder.Entity("Common.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MovieShowId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieShowId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e0000000-0000-0000-0000-000000000001"),
                            Comment = "För mycket snack o för lite action",
                            MovieShowId = new Guid("c0000000-0000-0000-0000-000000000001"),
                            Rating = 3
                        },
                        new
                        {
                            Id = new Guid("e0000000-0000-0000-0000-000000000002"),
                            Comment = "Gillade CGI effekterna, en stark fyra!",
                            MovieShowId = new Guid("c0000000-0000-0000-0000-000000000001"),
                            Rating = 4
                        },
                        new
                        {
                            Id = new Guid("e0000000-0000-0000-0000-000000000003"),
                            Comment = "Skitfilm",
                            MovieShowId = new Guid("c0000000-0000-0000-0000-000000000001"),
                            Rating = 1
                        });
                });

            modelBuilder.Entity("Common.Entities.Salon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Salons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a0000000-0000-0000-0000-000000000001"),
                            Name = "Stora salen",
                            TotalSeats = 45
                        },
                        new
                        {
                            Id = new Guid("a0000000-0000-0000-0000-000000000002"),
                            Name = "Lilla salen",
                            TotalSeats = 20
                        });
                });

            modelBuilder.Entity("Common.Entities.MovieShow", b =>
                {
                    b.HasOne("Common.Entities.Movie", null)
                        .WithMany("MovieShows")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Entities.Salon", null)
                        .WithMany("MovieShows")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Common.Entities.Reservation", b =>
                {
                    b.HasOne("Common.Entities.MovieShow", null)
                        .WithMany("Reservations")
                        .HasForeignKey("MovieShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Common.Entities.Review", b =>
                {
                    b.HasOne("Common.Entities.MovieShow", null)
                        .WithMany("Reviews")
                        .HasForeignKey("MovieShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Common.Entities.Movie", b =>
                {
                    b.Navigation("MovieShows");
                });

            modelBuilder.Entity("Common.Entities.MovieShow", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Common.Entities.Salon", b =>
                {
                    b.Navigation("MovieShows");
                });
#pragma warning restore 612, 618
        }
    }
}
