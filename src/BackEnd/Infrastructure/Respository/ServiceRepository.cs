using Common.Entities;
using Common.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private TrananDbContext _trananDbContext;

        public ServiceRepository(TrananDbContext trananDbContext) => _trananDbContext = trananDbContext;

        public async Task<int> GetAvailableSeatsForMovieShowAsync(Guid id)
        {
            try
            {
                var movieShow = await _trananDbContext.MovieShows.FirstOrDefaultAsync(ms => ms.Id == id);
                if (movieShow == null)
                    throw new Exception("MovieShow not found");

                int reservedSeats = (await _trananDbContext.Reservations.Where(r => r.MovieShowId == id).ToListAsync()).Sum(r => r.NumberOfTickets);
                int totalSeats = _trananDbContext.Salons.Where(s => s.Id == movieShow.SalonId).Select(s => s.TotalSeats).FirstOrDefault();
                return totalSeats - reservedSeats;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }
        
        public async Task<Reservation?> GetReservationByCodeAsync(int reservationCode)
        {
            try
            {
                var result = await _trananDbContext.Reservations.FirstOrDefaultAsync(r => r.ReservationCode == reservationCode);
                if (result == null)
                    return null;
                return result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<bool> DeleteReservationAsync(Guid id)
        {
            try
            {
                Reservation? reservation = await _trananDbContext.Reservations.Where(r => r.Id == id).FirstOrDefaultAsync();
                if (reservation == null)
                    return false;
                _trananDbContext.Reservations.Remove(reservation);
                await _trananDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        
        //Used to see if a review can be posted
        public async Task<bool> MovieFinishedAsync(int ReservationCode = 0)
        {
            try
            {
                Guid movieGuid = await GetMovieShowGuidFromReservationCodeAsync(ReservationCode);
                MovieShow? loadedMovieShow = _trananDbContext.MovieShows.Where(m => m.Id == movieGuid).FirstOrDefault();
                if (loadedMovieShow == null)
                    return false;

                var loadedMovie = await _trananDbContext.Movies.FirstOrDefaultAsync(m => m.Id == loadedMovieShow.MovieId);
                if (loadedMovie == null)
                    return false;

                return (DateTime.Now > loadedMovieShow.DateTime.AddMinutes((double)loadedMovie.MinutesLength));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw; //I want to bubble this error to the controller (or other)
            }
        }

        public async Task<bool> ReservationCodeIsUsedAsync(int ReservationCode)
        {
            try
            {
                var result = await _trananDbContext.Reservations.FirstOrDefaultAsync(r => r.ReservationCode == ReservationCode);
                if (result == null)
                    return false;
                return result.ReservationCodeUsed;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<bool> ReservationCodeNotFoundAsync(int ReservationCode)
        {
            try
            {
                Reservation? result = await _trananDbContext.Reservations.FirstOrDefaultAsync(r => r.ReservationCode == ReservationCode);
                if (result == null)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Guid> GetMovieShowGuidFromReservationCodeAsync(int ReservationCode = 0)
        {
            try
            {
                Reservation? reservation = await _trananDbContext.Reservations.Where(r => r.ReservationCode == ReservationCode).FirstOrDefaultAsync();
                if (reservation == null)
                    return Guid.Empty;

                return reservation.MovieShowId;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw; //I want to bubble this error to the controller (or other)
            }
        }

        public async Task<bool> AddReviewAsync(Review review)
        { 
            if (review == null)
                throw new ArgumentNullException(nameof(review));

            try
            {
                MovieShow? loadedMovieShow = _trananDbContext.MovieShows.Where(m => m.Id == review.MovieShowId).FirstOrDefault();
                if (loadedMovieShow == null)
                    return false;

                loadedMovieShow.Reviews.Add(review);
                _trananDbContext.MovieShows.Update(loadedMovieShow);
                return (await _trananDbContext.SaveChangesAsync() > 0);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw; //I want to bubble this error to the controller (or other)
            }
        }

        public async Task<bool> SetReservationCodeAsUsedAsync(int ReservationCode)
        {
            try
            {
                Reservation? reservation = await _trananDbContext.Reservations.Where(r => r.ReservationCode == ReservationCode).FirstOrDefaultAsync();
                if (reservation == null)
                    return false;

                reservation.ReservationCodeUsed = true;
                _trananDbContext.Reservations.Update(reservation);
                return (await _trananDbContext.SaveChangesAsync() > 0);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw; //I want to bubble this error to the controller (or other)
            }
        }


        public async Task<Movie> GetMovieByIdAsync(Guid id)
        {
            try
            {
                var result = await _trananDbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
                if (result == null)
                    throw new Exception("Movie not found");
                return result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }


    }
}
