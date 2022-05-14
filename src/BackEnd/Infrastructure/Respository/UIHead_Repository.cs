using Common.Interfaces;
using Common.Dtos.V01;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repository
{
    public class UIHead_Repository : IUIHead_Repository
    {
        private readonly TrananDbContext _trananDbContext;

        public UIHead_Repository(TrananDbContext trananDbContext) => _trananDbContext = trananDbContext;
        
        public async Task<List<MovieShowSummaryDto>?> GetMovieShowSummarysAsync()
        {
            try
            {
                List<MovieShowSummaryDto> result = await (from m1 in _trananDbContext.MovieShows
                                                          join m2 in _trananDbContext.Salons on m1.SalonId equals m2.Id
                                                          join m3 in _trananDbContext.Movies on m1.MovieId equals m3.Id
                                                          select new MovieShowSummaryDto
                                                          {
                                                              Id = m1.Id, //From MovieShow
                                                              PictureURL = m3.PictureURL ?? "", //From Movie
                                                              Date = m1.DateTime.ToString("MM-dd"), //From MovieShow
                                                              Time = m1.DateTime.ToString("HH:mm"), //From MovieShow
                                                              Title = m3.Title ?? "Unknown", //From Movie
                                                              Language = m3.Language ?? "Unknown", //From Movie
                                                              Subtitle = m3.Subtitle ?? "Unknown", //From Movie
                                                              Cathegory = m3.Cathegory ?? "Unknown", //From Movie
                                                              MinutesLength = m3.MinutesLength ?? 0, //From Movie
                                                              MinimumAgeLimit = m3.MinimumAgeLimit ?? 0, //From Movie
                                                              ReservedSeats = -1, //
                                                              TotalSeats = m2.TotalSeats, //From Salon
                                                          }).ToListAsync();

                result.ForEach(t => t.ReservedSeats = _trananDbContext.Reservations.Where(r => r.MovieShowId == t.Id).ToList().Sum(r => r.NumberOfTickets));
                return result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new List<MovieShowSummaryDto>();
            }
        }

        public async Task<MovieShowDetailsDto?> GetMovieShowDetailsAsync(Guid id)
        {
            try
            {
                int totalReservations = _trananDbContext.Reservations.Where(r => r.MovieShowId == id).ToList().Sum(r => r.NumberOfTickets);
                MovieShowDetailsDto? result = await (from m1 in _trananDbContext.MovieShows
                                                    join m2 in _trananDbContext.Salons on m1.SalonId equals m2.Id
                                                    join m3 in _trananDbContext.Movies on m1.MovieId equals m3.Id
                                                    where m1.Id == id
                                                    select new MovieShowDetailsDto
                                                    {
                                                        Id = m1.Id, //From MovieShow
                                                        PictureURL = m3.PictureURL ?? "", //From Movie
                                                        Title = m3.Title ?? "Unknown", //From Movie
                                                        Language = m3.Language ?? "Unknown", //From Movie
                                                        Subtitle = m3.Subtitle ?? "Unknown", //From Movie
                                                        Cathegory = m3.Cathegory ?? "Unknown", //From Movie
                                                        MinutesLength = m3.MinutesLength ?? 0, //From Movie
                                                        MinimumAgeLimit = m3.MinimumAgeLimit ?? 0, //From Movie
                                                        Salon = m2.Name ?? "Unknown", //From Salon
                                                        Date = m1.DateTime.ToString("MM-dd"), //From MovieShow
                                                        Time = m1.DateTime.ToString("HH:mm"), //From MovieShow
                                                        Reservations = totalReservations, // Must be separate query
                                                        TotalSeats = m2.TotalSeats, //From Salon
                                                        PriceSEK = m3.PriceSEK ?? 0, //From Movie
                                                        Description = m3.Description ?? "", //From Movie
                                                        Director = m3.Director ?? "", //From Movie
                                                        Actors = m3.Actors ?? "", //From Movie
                                                        ReleaseYear = m3.ReleaseDate.ToString("yyyy"), //From Movie
                                                    }).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new MovieShowDetailsDto();
            }
        }


        
        
        
        //Load Post with related comments
        //Post? loadPostWithComments = _gradesDbContext.Posts.Include(p => p.Comments).FirstOrDefault();


    }
}
