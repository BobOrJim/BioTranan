using Common.Entities;
using Common.Interfaces;
using Common.Dtos.V01;


namespace Domain.Services
{
    public class ReviewService
    {

        private readonly IServiceRepository _iServiceRepository;

        public ReviewService(IServiceRepository iServiceRepository) => _iServiceRepository = iServiceRepository;

        
        public async Task<string> MakeReviewAsync(ReviewDto reviewDto)
        {
            if (await _iServiceRepository.ReservationCodeNotFoundAsync(reviewDto.ReservationCode))
                return "ReservationCodeNotFound";
            if (await _iServiceRepository.ReservationCodeIsUsedAsync(reviewDto.ReservationCode))
                return "ReservationCodeIsUsed";
            if (! await _iServiceRepository.MovieFinishedAsync(reviewDto.ReservationCode))
                return "MovieNotFinished";

            Guid MovieShowId = await _iServiceRepository.GetMovieShowGuidFromReservationCodeAsync(reviewDto.ReservationCode);
            var review = new Review { MovieShowId = MovieShowId, Rating = reviewDto.Rating, Comment = reviewDto.Comment};
            await _iServiceRepository.AddReviewAsync(review);
            await _iServiceRepository.SetReservationCodeAsUsedAsync(reviewDto.ReservationCode);

            return "";
        }
        

    }
}
