using Common.Entities;
using Common.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repository
{
    public class API_Repository : IAPI_Repository
    {
        private readonly TrananDbContext _trananDbContext;

        public API_Repository(TrananDbContext trananDbContext) => _trananDbContext = trananDbContext;

        
        public async Task<bool> AddMovieAsync(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            try
            {
                await _trananDbContext.Movies.AddAsync(movie);
                return (await _trananDbContext.SaveChangesAsync() > 0);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw; //I want to bubble this error to the controller (or other)
            }
        }
        public async Task<Movie?> DeleteMovieAsync(Guid id) //Default of cascading delete is used
        {
            try
            {
                Movie? movie = await _trananDbContext.Movies.FindAsync(id);
                if (movie == null)
                {
                    return null;
                }
                _trananDbContext.Movies.Remove(movie);
                await _trananDbContext.SaveChangesAsync();
                return movie;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<bool> AddSalonAsync(Salon salon)
        {
            if (salon == null)
            {
                throw new ArgumentNullException(nameof(salon));
            }
            try
            {
                await _trananDbContext.Salons.AddAsync(salon);
                return (await _trananDbContext.SaveChangesAsync() > 0);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw; //I want to bubble this error to the controller (or other)
            }
        }
        public async Task<bool> AddMoveShowAsync(MovieShow movieShow)
        {
            if (movieShow == null)
            {
                throw new ArgumentNullException(nameof(movieShow));
            }
            try
            {
                await _trananDbContext.MovieShows.AddAsync(movieShow);

                //When a movieshow is added, we also add usedViews in the movie
                Movie? movie = await _trananDbContext.Movies.FindAsync(movieShow.MovieId);
                if (movie != null)
                {
                    movie.UseView();
                    _trananDbContext.Movies.Update(movie);
                }

                return (await _trananDbContext.SaveChangesAsync() > 0);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw; //I want to bubble this error to the controller (or other)
            }
        }
        public async Task<List<MovieShow>?> GetMovieShowsAsync()
        {
            try
            {
                return await _trananDbContext.MovieShows.ToListAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new List<MovieShow>();
            }
        }
        public async Task<List<Reservation>?> GetReservationsAsync()
        {
            try
            {
                return await _trananDbContext.Reservations.ToListAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new List<Reservation>();
            }
        }
        public async Task<List<Reservation>?> GetReservationsForMovieShowAsync(Guid id)
        {
            try
            {
                return await _trananDbContext.Reservations.Where(r => r.MovieShowId == id).ToListAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new List<Reservation>();
            }
        }
        public async Task<bool> AddReservationAsync(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }
            try
            {
                MovieShow? loadMovieShow = _trananDbContext.MovieShows.Where(m => m.Id == reservation.MovieShowId).FirstOrDefault();
                if (loadMovieShow == null)
                {
                    return false;
                }
                else
                {
                    loadMovieShow.Reservations.Add(reservation);
                    _trananDbContext.MovieShows.Update(loadMovieShow);
                    return (await _trananDbContext.SaveChangesAsync() > 0);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw; //I want to bubble this error to the controller (or other)
            }
        }
        public async Task<MovieShow?> ChangePandemicSeatReductionAsync(Guid id, int PandemicSeatReduction)
        {
            try
            {
                MovieShow? movieShow = await _trananDbContext.MovieShows.FindAsync(id);
                if (movieShow == null)
                {
                    return null;
                }
                movieShow.PandemicSeatReduction = PandemicSeatReduction;
                await _trananDbContext.SaveChangesAsync();
                return movieShow;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

    }
}
