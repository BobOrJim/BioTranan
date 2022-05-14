
using System.ComponentModel.DataAnnotations;

namespace Presentation_MVC.Dtos.V01
{
    public class ReservationDto //input from UI-head
    {
        public Guid Id { get; set; } //Match agains MovieShow.Id

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Range(0, 10, ErrorMessage = "Kan inte boka mer än 10 biljetter, för fler biljetter vänligen ring oss")]
        public int NumberOfTickets { get; set; } = 0;
    }
}


