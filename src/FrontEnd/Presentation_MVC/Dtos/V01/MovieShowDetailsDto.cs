
using System.ComponentModel.DataAnnotations;

namespace Presentation_MVC.Dtos.V01
{
    public class MovieShowDetailsDto //Output to UI-head
    {
        public Guid Id { get; set; } // From MovieShow
        
        [MaxLength(200)]
        public string PictureURL { get; set; } = ""; //From Movie

        [MaxLength(200)]
        public string Title { get; set; } = ""; //From Movie

        [MaxLength(200)]
        public string Language { get; set; } = ""; //From Movie

        [MaxLength(200)]
        public string Subtitle { get; set; } = ""; //From Movie

        [MaxLength(200)]
        public string Cathegory { get; set; } = ""; //From Movie

        [Range(0, 600, ErrorMessage = "BioTranan does not show movies longer than 600 minutes")]
        public int MinutesLength { get; set; } = 0; //From Movie

        [Range(7, 18, ErrorMessage = "Valid range is 7 - 18")]
        public int MinimumAgeLimit { get; set; } = 12; //From Movie

        [MaxLength(200)]
        public string Salon { get; set; } = ""; //From Salon

        [MaxLength(200)]
        public string Date { get; set; } = ""; //From MovieShow

        [MaxLength(200)]
        public string Time { get; set; } = ""; //From MovieShow

        [Range(0, 10, ErrorMessage = "Kan inte boka mer än 10 biljetter, för fler biljetter vänligen ring oss")]
        public int Reservations { get; set; } = 0; //From MovieShow

        [Range(0, 1000, ErrorMessage = "Alowed seaats is 0 - 1000")]
        public int TotalSeats { get; set; } = 0; //From Salon

        [Range(0, 1000, ErrorMessage = "Inga negativa värden tilllåtna")]
        public int PriceSEK { get; set; } = 0; //From Movie

        [MaxLength(200)]
        public string Description { get; set; } = ""; //From Movie

        [MaxLength(200)]
        public string Director { get; set; } = ""; //From Movie

        [MaxLength(200)]
        public string Actors { get; set; } = ""; //From Movie

        [MaxLength(200)]
        public string ReleaseYear { get; set; } = ""; //From Movie
    }
}
