using Common.Entities;

namespace Common.Interfaces
{
    public interface IAPI_Repository
    {

        Task<bool> AddMovieAsync(Movie movie);
        Task<Movie?> DeleteMovieAsync(Guid id);
        Task<bool> AddSalonAsync(Salon salon);
        Task<bool> AddMoveShowAsync(MovieShow movieShow);
        Task<List<MovieShow>?> GetMovieShowsAsync();
        Task<List<Reservation>?> GetReservationsAsync();
        Task<List<Reservation>?> GetReservationsForMovieShowAsync(Guid id);
        Task<bool> AddReservationAsync(Reservation reservation);
        Task<MovieShow?> ChangePandemicSeatReductionAsync(Guid id, int PandemicSeatReduction);
        
    }
}