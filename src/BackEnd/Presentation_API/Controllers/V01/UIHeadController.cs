using Common.Interfaces;
using Domain.Services;
using Common.Dtos.V01;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Presentation_API.Controllers.V01
{
    [ApiController]
    [Route("/api/v01/[controller]")]
    public class UIHeadController : ControllerBase
    {
        private readonly IUIHead_Repository _iUIHead_Repository;
        private readonly ReservationService _reservationService;
        private readonly ReviewService _reviewService;

        public UIHeadController(IUIHead_Repository iUIHead_Repository, ReservationService reservationService, ReviewService reviewService)
        {
            _iUIHead_Repository = iUIHead_Repository;
            _reservationService = reservationService;
            _reviewService = reviewService;
        }

        [HttpGet]
        [Route("MovieShowSummarys", Name = "MovieShowSummarysAsync")]
        public async Task<IActionResult> MovieShowSummarysAsync()
        {
            var movieShowSummarys = await _iUIHead_Repository.GetMovieShowSummarysAsync();
            if (movieShowSummarys == null || movieShowSummarys.Count == 0)
            {
                return NoContent();
            }
            return Ok(movieShowSummarys);
        }

        [HttpGet]
        [Route("MovieShowDetail/{id:Guid}", Name = "MovieShowDetailAsync")]
        public async Task<IActionResult> MovieShowDetailAsync(Guid id)
        {
            var movieShowDetail = await _iUIHead_Repository.GetMovieShowDetailsAsync(id);
            if (movieShowDetail == null)
            {
                return NotFound();
            }
            return Ok(movieShowDetail);
        }

        [HttpPost]
        [Route("MakeReservation", Name = "MakeReservationAsync")]
        public async Task<IActionResult> MakeReservationAsync([FromBody] ReservationDto reservationDto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try //Bubblar upp error
            {
                string reservation = await _reservationService.MakeReservationAsync(reservationDto);
                return Ok(reservation); //If fully booked, string is "Full", otherwise its a reservationCode.
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("CancelReservation/{reservationCode:int}", Name = "CancelReservationAsync")]
        public async Task<IActionResult> CancelReservationAsync(int reservationCode)
        {
            try //Bubblar upp error
            {
                var result = await _reservationService.CancelReservationAsync(reservationCode);
                if (result)
                {
                    return Ok($"{reservationCode} deleted");
                }
                else
                {
                    return Ok($"{reservationCode} not found");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("MakeReview", Name = "MakeReviewAsync")]
        public async Task<IActionResult> MakeReviewAsync([FromBody] ReviewDto reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try //Bubblar upp error
            {
                var response = await _reviewService.MakeReviewAsync(reviewDto);
                if (response == "MovieNotFinished" || response == "ReservationCodeIsUsed" || response == "ReservationCodeNotFound")
                    return Ok(response);
                return StatusCode(201); //Cant use CreatedAt, there is getReviewByIdEndpoint, customer want it like this.
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return StatusCode(500);
            }
        }
    }
}
