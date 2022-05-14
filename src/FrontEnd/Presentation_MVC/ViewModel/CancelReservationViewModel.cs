using System.ComponentModel.DataAnnotations;

namespace Presentation_MVC.ViewModel
{

    public class CancelReservationViewModel
    {

        [Required(ErrorMessage = "Please enter you number")]
        [Range(100000, 999999, ErrorMessage = "Ange ett nummer mellan 100000 och 999999")]
        public int reservationsId { get; set; } = 0;
        public string cancelStatusReply { get; set; } = "";
    }
}
