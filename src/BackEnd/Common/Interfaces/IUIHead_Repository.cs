using Common.Dtos.V01;

namespace Common.Interfaces
{
    public interface IUIHead_Repository
    {
        Task<List<MovieShowSummaryDto>?> GetMovieShowSummarysAsync();
        Task<MovieShowDetailsDto?> GetMovieShowDetailsAsync(Guid id);
    }
}