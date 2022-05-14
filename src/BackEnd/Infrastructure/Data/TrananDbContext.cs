using Common.Entities;
using Microsoft.EntityFrameworkCore;

//Set startup project to only Presentation_API
//add-migration "v01"
//Add-Migration V01 -context TrananDbContext
//update-database
//update-database -context TrananDbContext

namespace Infrastructure.Data
{
    public class TrananDbContext : DbContext
    {
        public TrananDbContext(DbContextOptions<TrananDbContext> options) : base(options) { }

        
        public DbSet<MovieShow> MovieShows { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TrananDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed 2 Salons
            Guid StoraSalenGuid = new Guid("A0000000-0000-0000-0000-000000000001");
            Guid LillaSalenGuid = new Guid("A0000000-0000-0000-0000-000000000002"); //Under construction
            modelBuilder.Entity<Salon>().HasData(new Salon() { Id = StoraSalenGuid, Name = "Stora salen", TotalSeats = 45 });
            modelBuilder.Entity<Salon>().HasData(new Salon() { Id = LillaSalenGuid, Name = "Lilla salen", TotalSeats = 20 });

            //seed 6 movies, where number 2 is out of views
            Guid Movie1Guid = new Guid("B0000000-0000-0000-0000-000000000001");
            Guid Movie2Guid = new Guid("B0000000-0000-0000-0000-000000000002"); //Out of views
            Guid Movie3Guid = new Guid("B0000000-0000-0000-0000-000000000003");
            Guid Movie4Guid = new Guid("B0000000-0000-0000-0000-000000000004");
            Guid Movie5Guid = new Guid("B0000000-0000-0000-0000-000000000005");
            Guid Movie6Guid = new Guid("B0000000-0000-0000-0000-000000000006");
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = Movie1Guid,
                Title = "Disaster Movie",
                Language = "Eng tal",
                Subtitle = "Swe text",
                Cathegory = "Drama",
                MinutesLength = 87,
                MinimumAgeLimit = 11,
                PictureURL = @"https://m.media-amazon.com/images/M/MV5BMTIzMDQyNDgwNl5BMl5BanBnXkFtZTcwMDA0MTc3MQ@@._V1_FMjpg_UX405_.jpg",
                Description = @"En grupp av misslyckade äventyrare i 20-årsåldern hotas av så gott som alla kända katastrofer ? asteroider, orkanstormar och jordbävningar och kämpar för sina liv för att sätta sig i säkerhet.",
                Director = @"Jason Friedberg, Aaron Seltzer",
                Actors = @"Carmen Electra, Nicole Parker, Valerie Wildman",
                ReleaseDate = new DateTime(2017, 1, 1),
            PriceSEK = 90,
                PurchasedViews = 20,
                UsedViews = 10
            });
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = Movie2Guid,
                Title = "Disaster Movie - ALL VIEWS ARE USED TEST",
                Language = "Eng tal",
                Subtitle = "Swe text",
                Cathegory = "Drama",
                MinutesLength = 87,
                MinimumAgeLimit = 11,
                PictureURL = @"https://m.media-amazon.com/images/M/MV5BMTIzMDQyNDgwNl5BMl5BanBnXkFtZTcwMDA0MTc3MQ@@._V1_FMjpg_UX405_.jpg",
                Description = @"En grupp av misslyckade äventyrare i 20-årsåldern hotas av så gott som alla kända katastrofer ? asteroider, orkanstormar och jordbävningar och kämpar för sina liv för att sätta sig i säkerhet.",
                Director = @"Jason Friedberg, Aaron Seltzer",
                Actors = @"Carmen Electra, Nicole Parker, Valerie Wildman",
                ReleaseDate = new DateTime(2017, 1, 1),
                PriceSEK = 90,
                PurchasedViews = 20,
                UsedViews = 20
            });
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = Movie3Guid,
                Title = "Manos, the Hands of Fate",
                Language = "Eng tal",
                Subtitle = "Swe text",
                Cathegory = "Skräck",
                MinutesLength = 88,
                MinimumAgeLimit = 15,
                PictureURL = @"https://m.media-amazon.com/images/M/MV5BYjIxOWMyMzUtNTMzZC00MThjLTljYjQtZjhlOGQzZTkxOTFkXkEyXkFqcGdeQXVyNjMwMjk0MTQ@._V1_.jpg",
                Description = @"En familj åker vilse på landsbygden och hamnar vid en liten stuga. Där möts de av Torgo som säger att han sköter om stället åt The Master. Det visar sig under natten att The Master, hans många fruar och Torgo ingår i en kult som dyrkar den ondskefulle guden Manos",
                Director = @"Hal Warren",
                Actors = @"Tom Neyman, John Reynolds (I), Diane Mahree",
                ReleaseDate = new DateTime(1966, 1, 1),
                PriceSEK = 90,
                PurchasedViews = 60,
                UsedViews = 11
            });
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = Movie4Guid,
                Title = "SuperBabies: Baby Geniuses 2",
                Language = "Sve tal",
                Subtitle = "Sve text",
                Cathegory = "Komedi",
                MinutesLength = 88,
                MinimumAgeLimit = 0,
                PictureURL = @"https://m.media-amazon.com/images/M/MV5BNjY4NjM3MjQ2OF5BMl5BanBnXkFtZTcwOTc3NzYyMQ@@._V1_FMjpg_UX485_.jpg",
                Description = @"Om en superbebis med mystiska krafter som här hjälper en ny kull småstjärnor.",
                Director = @"Bob Clark",
                Actors = @"Jon Voight, Scott Baio, Vanessa Angel, Peter Wingfield",
                ReleaseDate = new DateTime(2004, 1, 1),
                PriceSEK = 90,
                PurchasedViews = 40,
                UsedViews = 3
            });
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = Movie5Guid,
                Title = "Disaster Movie 2",
                Language = "Eng tal",
                Subtitle = "Swe text",
                Cathegory = "Drama",
                MinutesLength = 87,
                MinimumAgeLimit = 11,
                PictureURL = @"https://m.media-amazon.com/images/M/MV5BMTIzMDQyNDgwNl5BMl5BanBnXkFtZTcwMDA0MTc3MQ@@._V1_FMjpg_UX405_.jpg",
                Description = @"En grupp av misslyckade äventyrare i 20-årsåldern hotas av så gott som alla kända katastrofer ? asteroider, orkanstormar och jordbävningar och kämpar för sina liv för att sätta sig i säkerhet.",
                Director = @"Jason Friedberg, Aaron Seltzer",
                Actors = @"Carmen Electra, Nicole Parker, Valerie Wildman",
                ReleaseDate = new DateTime(2017, 1, 1),
                PriceSEK = 90,
                PurchasedViews = 20,
                UsedViews = 10
            });
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = Movie6Guid,
                Title = "Disaster Movie 3",
                Language = "Eng tal",
                Subtitle = "Swe text",
                Cathegory = "Drama",
                MinutesLength = 87,
                MinimumAgeLimit = 11,
                PictureURL = @"https://m.media-amazon.com/images/M/MV5BMTIzMDQyNDgwNl5BMl5BanBnXkFtZTcwMDA0MTc3MQ@@._V1_FMjpg_UX405_.jpg",
                Description = @"En grupp av misslyckade äventyrare i 20-årsåldern hotas av så gott som alla kända katastrofer ? asteroider, orkanstormar och jordbävningar och kämpar för sina liv för att sätta sig i säkerhet.",
                Director = @"Jason Friedberg, Aaron Seltzer",
                Actors = @"Carmen Electra, Nicole Parker, Valerie Wildman",
                ReleaseDate = new DateTime(2017, 1, 1),
                PriceSEK = 90,
                PurchasedViews = 20,
                UsedViews = 10
            });

            //Seed 5 MovieShows
            Guid MovieShow1Guid = new Guid("C0000000-0000-0000-0000-000000000001");
            Guid MovieShow2Guid = new Guid("C0000000-0000-0000-0000-000000000002");
            Guid MovieShow3Guid = new Guid("C0000000-0000-0000-0000-000000000003");
            Guid MovieShow4Guid = new Guid("C0000000-0000-0000-0000-000000000004");
            Guid MovieShow5Guid = new Guid("C0000000-0000-0000-0000-000000000005");
            modelBuilder.Entity<MovieShow>().HasData(new MovieShow() { Id = MovieShow1Guid, SalonId = StoraSalenGuid, MovieId = Movie1Guid, DateTime = new DateTime(2022, 4, 2, 19, 0, 0), PandemicSeatReduction = 0, });
            modelBuilder.Entity<MovieShow>().HasData(new MovieShow() { Id = MovieShow2Guid, SalonId = StoraSalenGuid, MovieId = Movie3Guid, DateTime = new DateTime(2022, 4, 12, 19, 0, 0), PandemicSeatReduction = 0, });
            modelBuilder.Entity<MovieShow>().HasData(new MovieShow() { Id = MovieShow3Guid, SalonId = StoraSalenGuid, MovieId = Movie4Guid, DateTime = new DateTime(2022, 4, 22, 19, 0, 0), PandemicSeatReduction = 0, });
            modelBuilder.Entity<MovieShow>().HasData(new MovieShow() { Id = MovieShow4Guid, SalonId = StoraSalenGuid, MovieId = Movie5Guid, DateTime = new DateTime(2022, 5, 2, 19, 0, 0), PandemicSeatReduction = 0, });
            modelBuilder.Entity<MovieShow>().HasData(new MovieShow() { Id = MovieShow5Guid, SalonId = StoraSalenGuid, MovieId = Movie6Guid, DateTime = new DateTime(2022, 6, 13, 19, 0, 0), PandemicSeatReduction = 0, });

            //Seed 6 reservations for MovieShow1Guid
            Guid Reservation1Guid = new Guid("D0000000-0000-0000-0000-000000000001");
            Guid Reservation2Guid = new Guid("D0000000-0000-0000-0000-000000000002");
            Guid Reservation3Guid = new Guid("D0000000-0000-0000-0000-000000000003");
            Guid Reservation4Guid = new Guid("D0000000-0000-0000-0000-000000000004");
            Guid Reservation5Guid = new Guid("D0000000-0000-0000-0000-000000000005");
            Guid Reservation6Guid = new Guid("D0000000-0000-0000-0000-000000000006");
            modelBuilder.Entity<Reservation>().HasData(new Reservation() { Id = Reservation1Guid, MovieShowId = MovieShow1Guid, ReservationCode = 100001, ReservationCodeUsed = false, Email = "pers1@gmail.com", NumberOfTickets = 10 });
            modelBuilder.Entity<Reservation>().HasData(new Reservation() { Id = Reservation2Guid, MovieShowId = MovieShow1Guid, ReservationCode = 100002, ReservationCodeUsed = false, Email = "pers2@gmail.com", NumberOfTickets = 10 });
            modelBuilder.Entity<Reservation>().HasData(new Reservation() { Id = Reservation3Guid, MovieShowId = MovieShow1Guid, ReservationCode = 100003, ReservationCodeUsed = false, Email = "pers3@gmail.com", NumberOfTickets = 10 });
            modelBuilder.Entity<Reservation>().HasData(new Reservation() { Id = Reservation4Guid, MovieShowId = MovieShow1Guid, ReservationCode = 100004, ReservationCodeUsed = false, Email = "pers4@gmail.com", NumberOfTickets = 10 });
            modelBuilder.Entity<Reservation>().HasData(new Reservation() { Id = Reservation5Guid, MovieShowId = MovieShow1Guid, ReservationCode = 100005, ReservationCodeUsed = false, Email = "pers5@gmail.com", NumberOfTickets = 1 });
            modelBuilder.Entity<Reservation>().HasData(new Reservation() { Id = Reservation6Guid, MovieShowId = MovieShow1Guid, ReservationCode = 100006, ReservationCodeUsed = false, Email = "pers6@gmail.com", NumberOfTickets = 1 });
            //Seed 1 big reservation for the other 3 MovieShows. Note that there is no reservation for the alst movieShow
            Guid Reservation7Guid = new Guid("D0000000-0000-0000-0000-000000000007");
            Guid Reservation8Guid = new Guid("D0000000-0000-0000-0000-000000000008");
            Guid Reservation9Guid = new Guid("D0000000-0000-0000-0000-000000000009");
            modelBuilder.Entity<Reservation>().HasData(new Reservation() { Id = Reservation7Guid, MovieShowId = MovieShow2Guid, ReservationCode = 100007, ReservationCodeUsed = false, Email = "pers7@gmail.com", NumberOfTickets = 26 });
            modelBuilder.Entity<Reservation>().HasData(new Reservation() { Id = Reservation8Guid, MovieShowId = MovieShow3Guid, ReservationCode = 100008, ReservationCodeUsed = false, Email = "pers8@gmail.com", NumberOfTickets = 2 });
            modelBuilder.Entity<Reservation>().HasData(new Reservation() { Id = Reservation9Guid, MovieShowId = MovieShow4Guid, ReservationCode = 100009, ReservationCodeUsed = false, Email = "pers9@gmail.com", NumberOfTickets = 45 });

            //Seed 3 Reviews för Movie1Guid
            Guid Review1Guid = new Guid("E0000000-0000-0000-0000-000000000001");
            Guid Review2Guid = new Guid("E0000000-0000-0000-0000-000000000002");
            Guid Review3Guid = new Guid("E0000000-0000-0000-0000-000000000003");
            modelBuilder.Entity<Review>().HasData(new Review() { Id = Review1Guid, MovieShowId = MovieShow1Guid, Rating = 3, Comment = "För mycket snack o för lite action" });
            modelBuilder.Entity<Review>().HasData(new Review() { Id = Review2Guid, MovieShowId = MovieShow1Guid, Rating = 4, Comment = "Gillade CGI effekterna, en stark fyra!" });
            modelBuilder.Entity<Review>().HasData(new Review() { Id = Review3Guid, MovieShowId = MovieShow1Guid, Rating = 1, Comment = "Skitfilm" });

        }
    }
}
