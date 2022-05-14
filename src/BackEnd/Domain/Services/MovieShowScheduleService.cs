using Common.Entities;
using Common.Interfaces;
using System.Diagnostics;

namespace Domain.Services
{
    public class MovieShowScheduleService
    {


        private readonly IAPI_Repository _iAPI_Repository;
        private readonly IServiceRepository _iServiceRepository;

        public MovieShowScheduleService(IAPI_Repository iAPI_Repository, IServiceRepository iServiceRepository)
        {
            _iAPI_Repository = iAPI_Repository;
            _iServiceRepository = iServiceRepository;
        }


        public async Task<string> AddMoveShowAsync(MovieShow movieShow)
        {
            try
            {
                if (!await ViewsLeftForMovie(movieShow)) //No "PurchasedViews" left in a move.
                    return "All PurchasedViews in movie is used";

                if (await MovieShowCauseOverlapp(movieShow)) //Movie schedule overlapp
                    return "Movieshow will overlapp with other movieshows in the schedule";

                if (!await _iAPI_Repository.AddMoveShowAsync(movieShow)) //Should always succed or throw an exception
                    return "Unknown error, should never occur";
                return ""; //If successfull an empty string is returned
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }
        private async Task<bool> ViewsLeftForMovie(MovieShow movieShow)
        {
            try
            {
                Movie movie = await _iServiceRepository.GetMovieByIdAsync(movieShow.MovieId);
                return (movie.UsedViews < movie.PurchasedViews);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }
        private async Task<bool> MovieShowCauseOverlapp(MovieShow movieShow)
        {
            try
            {
                double movieShowMovieLength = (await _iServiceRepository.GetMovieByIdAsync(movieShow.MovieId)).MinutesLength ?? 0;

                List<MovieShow> allMovieShows = await _iAPI_Repository.GetMovieShowsAsync() ?? new List<MovieShow>(); //This list will be filtered to reduce calls to db.

                //Filter 1: Keep only the movieShows that start before the actuall movieShow + the length of actuall movie
                List<MovieShow> filteredMovieShows = allMovieShows.Where(ms => ms.DateTime < movieShow.DateTime.AddMinutes(movieShowMovieLength)).ToList();
                //Filter 2: Keed only the movies, that start 24h before the actual MovieShow. I.e we assume no movie is more than 24h long.
                filteredMovieShows = filteredMovieShows.Where(ms => ms.DateTime > movieShow.DateTime.AddHours(-24)).ToList();

                return filteredMovieShows.Any(ms => MovieShowsOverlappAsync(movieShow, movieShowMovieLength, ms).Result); //Check if there is an overlapp in the filtered list
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }
        private async Task<bool> MovieShowsOverlappAsync(MovieShow movieShow1, double movieShow1LengthMinutes, MovieShow movieShow2)
        {
            Movie MovieShow2Movie = await _iServiceRepository.GetMovieByIdAsync(movieShow2.MovieId);

            DateTime movie1StartTime = movieShow1.DateTime;
            DateTime movie1EndTime = movieShow1.DateTime.AddMinutes(movieShow1LengthMinutes);
            DateTime movie2StartTime = movieShow2.DateTime;
            DateTime movie2EndTime = movieShow2.DateTime.AddMinutes(MovieShow2Movie.MinutesLength ?? 0);

            //movie1StartTime cant be inside movie2
            if (movie1StartTime >= movie2StartTime && movie1StartTime <= movie2EndTime)
                return true;
            //movie1EndTime cant be inside movie2
            if (movie1EndTime >= movie2StartTime && movie1EndTime <= movie2EndTime)
                return true;
            //movie2StartTime cant be inside movie1
            if (movie2StartTime >= movie1StartTime && movie2StartTime <= movie1EndTime)
                return true;
            //movie2EndTime cant be inside movie1
            if (movie2EndTime >= movie1StartTime && movie2EndTime <= movie1EndTime)
                return true;

            return false; //There is no overlapp
        }

    }
}
