using Common.Entities;
using Common.Interfaces;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation_API.Middleware;
using System.Diagnostics;

namespace Presentation_API.V01.Controllers
{
    [ApiController]
    [Route("/api/v01/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAPI_Repository _iAPI_Repository;
        private readonly MovieShowScheduleService _movieShowScheduleService;

        public AdminController(IAPI_Repository iAPI_Repository, MovieShowScheduleService movieShowScheduleService)
        {
            _iAPI_Repository = iAPI_Repository;
            _movieShowScheduleService = movieShowScheduleService;
        }

        [ApiKeyMiddleware]
        [HttpPost]
        [Route("Movie", Name = "AddMovieAsync")]
        public async Task<IActionResult> AddMovieAsync([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _iAPI_Repository.AddMovieAsync(movie);
                return StatusCode(201); //Cant return "CreatedAtRoute(...)" becouse "GetSalon(Guid id)" is not implentented. Customer simply want it like this.
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("Movie/{id:Guid}", Name = "DeleteMovieAsync")]
        public async Task<IActionResult> DeleteMovieAsync(Guid id)
        {
            var deletedMovie = await _iAPI_Repository.DeleteMovieAsync(id);
            if (deletedMovie == null)
            {
                return NotFound();
            }
            return Ok(new { Message = $"{deletedMovie.Id} with title {deletedMovie.Title} was deleted" });
        }

        [HttpPost]
        [Route("Salon", Name = "AddSalonAsync")]
        public async Task<IActionResult> AddSalonAsync([FromBody] Salon salon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _iAPI_Repository.AddSalonAsync(salon);
                return StatusCode(201); //Cant return "CreatedAtRoute(...)" becouse "GetSalon(Guid id)" is not implentented. Customer simply want it like this.
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("MovieShow", Name = "AddMovieShowAsync")]
        public async Task<IActionResult> AddMovieShowAsync([FromBody] MovieShow movieShow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string result = await _movieShowScheduleService.AddMoveShowAsync(movieShow);
                //I could make result and object, with a bool status, and a string message. Perhaps this is a case of SOLID vs KISS, and in this case used KISS.
                if (result == "All PurchasedViews in movie is used" || result == "Movieshow will overlapp with other movieshows in the schedule" || result == "Unknown error, should never occur")
                    return Ok(result);
                return StatusCode(201); //Cant return "CreatedAtRoute(...)" becouse "GetSalon(Guid id)" is not implentented. Customer simply want it like this.
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("MovieShows", Name = "GetMovieShowsAsync")]
        public async Task<IActionResult> GetMovieShowsAsync()
        {
            var movieShows = await _iAPI_Repository.GetMovieShowsAsync();
            if (movieShows == null)
            {
                return NoContent();
            }
            return Ok(movieShows);
        }

        [HttpGet]
        [Route("Reservations", Name = "GetReservationsAsync")]
        public async Task<IActionResult> GetReservationsAsync()
        {
            var reservations = await _iAPI_Repository.GetReservationsAsync();
            if (reservations == null)
            {
                return NoContent();
            }
            return Ok(reservations);
        }

        [HttpGet]
        [Route("ReservationsForMovieShow/{id:Guid}", Name = "GetReservationsForMovieShowAsync")]
        public async Task<IActionResult> GetReservationsForMovieShowAsync(Guid id)
        {
            var reservations = await _iAPI_Repository.GetReservationsForMovieShowAsync(id);
            if (reservations?.Count == 0 || reservations == null)
            {
                return NoContent();
            }
            return Ok(reservations);
        }

        [HttpPost]
        [Route("Reservation", Name = "AddReservationAsync")]
        public async Task<IActionResult> AddReservationAsync([FromBody] Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (await _iAPI_Repository.AddReservationAsync(reservation)) 
                {
                    return StatusCode(201); //Cant return "CreatedAtRoute(...)" becouse "GetSalon(Guid id)" is not implentented. Customer simply want it like this.
                }
                else
                {
                    return StatusCode(422); //422 = Unprocessable Entity
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpPatch] //Its a partial change to an existing entity, i.e i use patch. PATCH always have a body.
        [Route("MovieShowPandemic/{id:Guid}", Name = "ChangeMovieShowPandemicAsync")]
        public async Task<IActionResult> ChangeMovieShowPandemicAsync(Guid id, [FromBody] int PandemicSeatReduction)
        {
            if (!ModelState.IsValid) //Invalid jsonformat in request body
            {
                return BadRequest(ModelState);
            }
            try
            {
                MovieShow? editedMovieShow = await _iAPI_Repository.ChangePandemicSeatReductionAsync(id, PandemicSeatReduction);
                if (editedMovieShow == null)
                {
                    return NotFound();
                }
                return Ok(editedMovieShow);
            }
            catch (Exception e) //exeption thrown from repository
            {
                Debug.WriteLine(e.Message);
                return StatusCode(500);
            }
        }


        [ApiKeyMiddleware]
        [HttpGet]
        [Route("Secret", Name = "GetSecret")]
        public IActionResult GetSecret()
        {
            return Ok("This is a secret");
        }

        
    }
}