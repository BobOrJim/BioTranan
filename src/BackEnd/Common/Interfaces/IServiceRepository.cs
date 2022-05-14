using Common.Entities;

namespace Common.Interfaces
{
    public interface IServiceRepository
    {
        Task<int> GetAvailableSeatsForMovieShowAsync(Guid id);
        Task<Reservation?> GetReservationByCodeAsync(int reservationCode);
        Task<bool> DeleteReservationAsync(Guid id);

        
        Task<bool> MovieFinishedAsync(int ReservationCode);
        Task<bool> ReservationCodeIsUsedAsync(int ReservationCode);
        Task<bool> ReservationCodeNotFoundAsync(int ReservationCode);
        Task<Guid> GetMovieShowGuidFromReservationCodeAsync(int ReservationCode);
        Task<bool> AddReviewAsync(Review review);
        Task<bool> SetReservationCodeAsUsedAsync(int ReservationCode);
        Task<Movie> GetMovieByIdAsync(Guid id);
    }
}