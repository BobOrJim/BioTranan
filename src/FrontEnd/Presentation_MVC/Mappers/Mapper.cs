using Presentation_MVC.Dtos.V01;
using Presentation_MVC.Models;
using Presentation_MVC.ViewModel;

namespace Presentation_MVC.Mappers
{
    public class Mapper
    {
        public static MovieShowDetailsViewModel Map(MovieShowDetailsDto movieShowDetailsDto)
        {
            return new MovieShowDetailsViewModel()
            {
                Id = movieShowDetailsDto.Id,
                PictureURL = movieShowDetailsDto.PictureURL,
                Title = movieShowDetailsDto.Title,
                Language = movieShowDetailsDto.Language,
                Subtitle = movieShowDetailsDto.Subtitle,
                Cathegory = movieShowDetailsDto.Cathegory,
                MinutesLength = movieShowDetailsDto.MinutesLength,
                MinimumAgeLimit = movieShowDetailsDto.MinimumAgeLimit,
                Salon = movieShowDetailsDto.Salon,
                Date = movieShowDetailsDto.Date,
                Time = movieShowDetailsDto.Time,
                Reservations = movieShowDetailsDto.Reservations,
                TotalSeats = movieShowDetailsDto.TotalSeats,
                PriceSEK = movieShowDetailsDto.PriceSEK,
                Description = movieShowDetailsDto.Description,
                Director = movieShowDetailsDto.Director,
                Actors = movieShowDetailsDto.Actors,
                ReleaseYear = movieShowDetailsDto.ReleaseYear,
            };
        }

        public static MovieShowSummaryModel Map(MovieShowSummaryDto movieShowSummaryDto)
        {
            return new MovieShowSummaryModel()
            {
                Id = movieShowSummaryDto.Id,
                PictureURL = movieShowSummaryDto.PictureURL,
                Date = movieShowSummaryDto.Date,
                Time = movieShowSummaryDto.Time,
                Title = movieShowSummaryDto.Title,
                Language = movieShowSummaryDto.Language,
                Subtitle = movieShowSummaryDto.Subtitle,
                Cathegory = movieShowSummaryDto.Cathegory,
                MinutesLength = movieShowSummaryDto.MinutesLength,
                MinimumAgeLimit = movieShowSummaryDto.MinimumAgeLimit,
                ReservedSeats = movieShowSummaryDto.ReservedSeats,
                TotalSeats = movieShowSummaryDto.TotalSeats,
            };
        }
    }
}
