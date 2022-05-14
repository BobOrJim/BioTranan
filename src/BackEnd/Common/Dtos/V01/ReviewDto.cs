
using System.ComponentModel.DataAnnotations;

namespace Common.Dtos.V01
{
    public class ReviewDto //input from UI-head
    {
        [Range(100000, 999999, ErrorMessage = "Valid reservations numbers are between 100000 and 999999")]
        public int ReservationCode { get; set; } = 100000;

        [Range(1, 5, ErrorMessage = "Valid reservations numbers are between 1 and 5")]
        public int Rating { get; set; } = 0;

        [MaxLength(2000, ErrorMessage = "Review must be less than 2000 characters")]
        public string Comment { get; set; } = "";
    }
}
