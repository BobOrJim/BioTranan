using Presentation_MVC.Dtos.V01;
using Microsoft.AspNetCore.Mvc;
using Presentation_MVC.Models;
using Presentation_MVC.Services;
using Presentation_MVC.ViewModel;
using System.Diagnostics;

namespace Presentation_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpService _httpRequestBackendService;

        public HomeController(IHttpService httpRequestBackendService) => _httpRequestBackendService = httpRequestBackendService;

        
        private string ChangeDateFormat(string date)
        {
            string[] dateSplit = date.Split('-');
            string month = dateSplit[0];
            string day = dateSplit[1];
            if (day.Substring(0, 1) == "0")
                day = day.Substring(1);
            switch (month)
            {
                case "01":
                    month = "Jan";
                    break;
                case "02":
                    month = "Feb";
                    break;
                case "03":
                    month = "Mar";
                    break;
                case "04":
                    month = "Apr";
                    break;
                case "05":
                    month = "May";
                    break;
                case "06":
                    month = "Jun";
                    break;
                case "07":
                    month = "Jul";
                    break;
                case "08":
                    month = "Aug";
                    break;
                case "09":
                    month = "Sep";
                    break;
                case "10":
                    month = "Oct";
                    break;
                case "11":
                    month = "Nov";
                    break;
                case "12":
                    month = "Dec";
                    break;
            }
            return $"{day} {month}";
        }

        public async Task<IActionResult> Index() => View("Index", await _httpRequestBackendService.GetRandomJokeAsync());

        public async Task<IActionResult> Schedule()
        {
            MovieShowSummaryViewModel movieShowSummaryViewModel = new MovieShowSummaryViewModel();
            movieShowSummaryViewModel.movieShowSummaryModels = await _httpRequestBackendService.GetMovieShowSummariesAsync();
            movieShowSummaryViewModel.movieShowSummaryModels.ForEach(x => x.Date = ChangeDateFormat(x.Date));
            return View("Schedule", movieShowSummaryViewModel);
        }
    
        public async Task<IActionResult> MovieDetails(Guid Id)
        {
            var viewModel = await _httpRequestBackendService.GetMovieShowDetailsAsync(Id);
            viewModel.Date = ChangeDateFormat(viewModel.Date);
            viewModel.Reservations = viewModel.TotalSeats - viewModel.Reservations;
            return View("MovieDetails", viewModel);
        } 


        [ValidateAntiForgeryToken()]
        [HttpPost]
        public async Task<IActionResult> ReservationConfirmation(MovieShowDetailsViewModel movieShowDetailsViewModel)
        {
            if (!ModelState.IsValid)
                return View("MovieDetails", await _httpRequestBackendService.GetMovieShowDetailsAsync(movieShowDetailsViewModel.Id));
            
            ReservationDto reservationDto = new ReservationDto {
                Email = movieShowDetailsViewModel.Email,
                NumberOfTickets = movieShowDetailsViewModel.NumberOfTickets,
                Id = movieShowDetailsViewModel.Id
            };
            return View("ReservationConfirmation", await _httpRequestBackendService.PostReservationDtoAsync(reservationDto));
        }

        public IActionResult ReservationConfirmation() => View(); //To handle F5

        [HttpGet]
        public IActionResult CancelReservation() => View(new CancelReservationViewModel());

        [ValidateAntiForgeryToken()]
        [HttpPost]
        public async Task<IActionResult> CancelReservation(CancelReservationViewModel cancelReservationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(new CancelReservationViewModel() { cancelStatusReply = "Ogiltligt reservationsid"});
            }
            
            CancelReservationViewModel newCancelReservationViewModel = new();
            newCancelReservationViewModel.cancelStatusReply = await _httpRequestBackendService.CancelReservation(cancelReservationViewModel.reservationsId);
            return View(newCancelReservationViewModel);
        }

        [HttpGet]
        public IActionResult WriteReview() => View(new WriteReviewViewModel());

        
        [ValidateAntiForgeryToken()]
        [HttpPost]
        public async Task<IActionResult> WriteReview(WriteReviewViewModel writeReviewViewModel)
        {
            if (!ModelState.IsValid)
                return View(new WriteReviewViewModel());

            ReviewDto reviewDto = new ReviewDto
            {
                ReservationCode = writeReviewViewModel.ReservationCode,
                Rating = writeReviewViewModel.Rating,
                Comment = writeReviewViewModel.Comment
            };
            return View("WriteReview", new WriteReviewViewModel() { reviewStatusReply = await _httpRequestBackendService.MakeReview(reviewDto) });
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}