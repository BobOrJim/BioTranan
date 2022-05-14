using System.ComponentModel.DataAnnotations;

namespace Presentation_MVC.ViewModel
{
  public class MovieShowDetailsViewModel
  {
        public Guid Id { get; set; }
        public string PictureURL { get; set; } = "";
        public string Title { get; set; } = "";
        public string Language { get; set; } = "";
        public string Subtitle { get; set; } = "";
        public string Cathegory { get; set; } = "";
        public int MinutesLength { get; set; } = 0;
        public int MinimumAgeLimit { get; set; } = 12;
        public string Salon { get; set; } = "";
        public string Date { get; set; } = "";
        public string Time { get; set; } = "";
        public int Reservations { get; set; } = 0;
        public int TotalSeats { get; set; } = 0;
        public int PriceSEK { get; set; } = 0;
        public string Description { get; set; } = "";
        public string Director { get; set; } = "";
        public string Actors { get; set; } = "";
        public string ReleaseYear { get; set; } = "";


        //Below is data from (form) in View to Controller
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Vänligen ange antal biljetter")]
        [Range(1, 10, ErrorMessage = "Endast mellan 1 och 10 biljetter kan bokas. För fler biljetter välkommen till tranan och köp på plats")]
        public int NumberOfTickets { get; set; } = 0;
    }
}
