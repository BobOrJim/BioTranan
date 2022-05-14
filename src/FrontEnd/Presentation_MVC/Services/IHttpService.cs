using Presentation_MVC.Dtos.V01;
using Presentation_MVC.Models;
using Presentation_MVC.ViewModel;

namespace Presentation_MVC.Services
{
    public interface IHttpService
    {
        Task<List<MovieShowSummaryModel>> GetMovieShowSummariesAsync();
        Task<MovieShowDetailsViewModel> GetMovieShowDetailsAsync(Guid id);
        Task<string> PostReservationDtoAsync(ReservationDto reservationDto);
        Task<string> CancelReservation(int reservationCode);
        Task<string> MakeReview(ReviewDto reviewDto);

        Task<string> GetRandomJokeAsync();

    }
}