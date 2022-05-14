using Common.Entities;
using Common.Interfaces;
using Common.Dtos.V01;
using System.Diagnostics;

namespace Domain.Services
{
    public class ReservationService
    {
        private readonly IAPI_Repository _iAPI_Repository;
        private readonly IServiceRepository _iServiceRepository;

        public ReservationService(IAPI_Repository iAPI_Repository, IServiceRepository iServiceRepository)
        {
            _iAPI_Repository = iAPI_Repository;
            _iServiceRepository = iServiceRepository;
        }
        
        public async Task<string> MakeReservationAsync(ReservationDto reservationDto)
        {
            try
            {
                int seatsLeft = await _iServiceRepository.GetAvailableSeatsForMovieShowAsync(reservationDto.Id);

                if (seatsLeft >= reservationDto.NumberOfTickets)
                {
                    Reservation reservation = new Reservation
                    {
                        MovieShowId = reservationDto.Id,
                        ReservationCode = new Random().Next(100000, 999999),
                        ReservationCodeUsed = false,
                        Email = reservationDto.Email,
                        NumberOfTickets = reservationDto.NumberOfTickets,
                    };
                    await _iAPI_Repository.AddReservationAsync(reservation);
                    return reservation.ReservationCode.ToString();
                }
                return "Full";
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<bool> CancelReservationAsync(int reservationCode)
        {
            try
            {
                Reservation? reservation = await _iServiceRepository.GetReservationByCodeAsync(reservationCode);
                if (reservation == null)
                    return false;
                return await _iServiceRepository.DeleteReservationAsync(reservation.Id);
             }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }
         
    }
}
