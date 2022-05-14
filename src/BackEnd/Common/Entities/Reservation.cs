using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class Reservation : BaseEntity
    {
        //public Guid Id { get; set; }
        public Guid MovieShowId { get; set; } //EF will map this to MovieShow.Id

        [Range(100000, 999999, ErrorMessage = "Valid reservation code is between 100000 and 999999")]
        public int ReservationCode { get; set; } = 100000;
        public bool ReservationCodeUsed { get; set; } = false;
        

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = "";
        

        [Range(0, 100, ErrorMessage = "You can not buy more than 100 tickets")]
        public int NumberOfTickets { get; set; }
    }
}
