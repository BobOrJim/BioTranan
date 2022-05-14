using System.ComponentModel.DataAnnotations;

namespace Presentation_MVC.ViewModel
{
    public class WriteReviewViewModel
  {

        [Required(ErrorMessage = "Please enter you number")]
        [Range(100000, 999999, ErrorMessage = "Ange ett nummer mellan 100000 och 999999")]
        public int ReservationCode { get; set; } = 100000;

        [Range(1, 5, ErrorMessage = "Betyg måste vara mellan 1 och 5")]
        public int Rating { get; set; } = 0;

        [MaxLength(200)]
        public string Comment { get; set; } = "";
        public string reviewStatusReply { get; set; } = "";
    }
}
