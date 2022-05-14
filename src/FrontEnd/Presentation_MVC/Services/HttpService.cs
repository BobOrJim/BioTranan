using Presentation_MVC.Dtos.V01;
using Presentation_MVC.Mappers;
using Presentation_MVC.Models;
using Presentation_MVC.ViewModel;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Presentation_MVC.Services
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            
        }
        
        private async Task<HttpResponseMessage> SendAsyncWithCancellationTokenAsync(HttpRequestMessage httpRequestMessage, int ms)
        {
            var httpClient = _httpClientFactory.CreateClient();
            using (var cts = new CancellationTokenSource(ms))
            {
                try
                {
                    return await httpClient.SendAsync(httpRequestMessage, cts.Token);
                }
                catch (OperationCanceledException oc) //handle timeout
                {
                    throw new TimeoutException("API timeout, backend my be down", oc);
                }
                catch (Exception e)
                {
                    throw new HttpRequestException(e.Message);
                }
            }
        }
        private async Task<T?> ReadHttpResponseMessageContentAsync<T>(HttpResponseMessage httpResponseMessage)
        {
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<T>(content, options);
            }
            throw new HttpRequestException($"{httpResponseMessage.StatusCode} {httpResponseMessage.ReasonPhrase}");
        }
        public async Task<List<MovieShowSummaryModel>> GetMovieShowSummariesAsync()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, URI.API+"v01/UIHead/MovieShowSummarys");
            try
            {
                httpRequestMessage.Headers.Add("Accept", "*/*");
                var httpResponseMessage = await SendAsyncWithCancellationTokenAsync(httpRequestMessage, 30000);
                List<MovieShowSummaryDto> result = await ReadHttpResponseMessageContentAsync<List<MovieShowSummaryDto>>(httpResponseMessage) ?? new List<MovieShowSummaryDto>();
                return result.Select(m => Mapper.Map(m)).ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new List<MovieShowSummaryModel>();
            }    
        }
        public async Task<MovieShowDetailsViewModel> GetMovieShowDetailsAsync(Guid id)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, URI.API + $"v01/UIHead/MovieShowDetail/{id}");
            try
            {
                httpRequestMessage.Headers.Add("Accept", "*/*");
                var httpResponseMessage = await SendAsyncWithCancellationTokenAsync(httpRequestMessage, 30000);
                MovieShowDetailsDto result = await ReadHttpResponseMessageContentAsync<MovieShowDetailsDto>(httpResponseMessage) ?? new MovieShowDetailsDto();
                return Mapper.Map(result);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new MovieShowDetailsViewModel();
            }
        }
        public async Task<string> PostReservationDtoAsync(ReservationDto reservationDto)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, URI.API + "v01/UIHead/MakeReservation");
            try
            {
                httpRequestMessage.Content = new StringContent(JsonSerializer.Serialize(reservationDto), Encoding.UTF8, "application/json");
                var httpResponseMessage = await SendAsyncWithCancellationTokenAsync(httpRequestMessage, 30000);

                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await httpResponseMessage.Content.ReadAsStringAsync();
                }
                throw new HttpRequestException($"{httpResponseMessage.StatusCode} {httpResponseMessage.ReasonPhrase}");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return "";
            }
        }
        public async Task<string> CancelReservation(int reservationCode)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, URI.API + $"v01/UIHead/CancelReservation/{reservationCode}");
            try
            {
                httpRequestMessage.Headers.Add("Accept", "*/*");
                var httpResponseMessage = await SendAsyncWithCancellationTokenAsync(httpRequestMessage, 30000);

                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await httpResponseMessage.Content.ReadAsStringAsync();
                }
                throw new HttpRequestException($"{httpResponseMessage.StatusCode} {httpResponseMessage.ReasonPhrase}");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return "";
            }
        }
        public async Task<string> MakeReview(ReviewDto reviewDto)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, URI.API + $"v01/UIHead/MakeReview");
            try
            {
                httpRequestMessage.Content = new StringContent(JsonSerializer.Serialize(reviewDto), Encoding.UTF8, "application/json");
                var httpResponseMessage = await SendAsyncWithCancellationTokenAsync(httpRequestMessage, 30000);

                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await httpResponseMessage.Content.ReadAsStringAsync();
                }
                throw new HttpRequestException($"{httpResponseMessage.StatusCode} {httpResponseMessage.ReasonPhrase}");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return "";
            }
        }
        public async Task<string> GetRandomJokeAsync()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, @"https://v2.jokeapi.dev/joke/Any");
            try
            {
                httpRequestMessage.Headers.Add("Accept", "*/*");
                var httpResponseMessage = await SendAsyncWithCancellationTokenAsync(httpRequestMessage, 30000);
                var json = await httpResponseMessage.Content.ReadAsStringAsync();

                JsonDocument? jsonDocument = System.Text.Json.JsonDocument.Parse(json);
                string setup = jsonDocument.RootElement.GetProperty("setup").GetString() ?? "";
                string delivery = jsonDocument.RootElement.GetProperty("delivery").GetString() ?? "";

                return $"{setup} : {delivery}";
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return "";
            }
        }

        
    }
}


