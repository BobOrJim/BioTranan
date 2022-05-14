
using System.ComponentModel.DataAnnotations;

namespace Presentation_MVC.Dtos.V01
{
    public class MovieShowSummaryDto //Output to UI-head
    {
        public Guid Id { get; set; } // From MovieShow

        [MaxLength(200)]
        public string PictureURL { get; set; } = ""; //PictureURL from Movie

        [MaxLength(200)]
        public string Date { get; set; } = ""; //DateTime from MovieShow

        [MaxLength(200)]        
        public string Time { get; set; } = ""; //DateTime from MovieShow

        [MaxLength(200)]
        public string Title { get; set; } = ""; //Title from Movie

        [MaxLength(200)]
        public string Language { get; set; } = ""; //Language from Movie

        [MaxLength(200)]
        public string Subtitle { get; set; } = ""; //Subtitle from Movie

        [MaxLength(200)]
        public string Cathegory { get; set; } = ""; //Cathegory from Movie

        [Range(0, 600, ErrorMessage = "BioTranan does not show movies longer than 600 minutes")]
        public int MinutesLength { get; set; } = 0; //MinutesLength from Movie

        [Range(7, 18, ErrorMessage = "Valid range is 7 - 18")]
        public int MinimumAgeLimit { get; set; } = 0; //MinimumAgeLimit from Movie

        [Range(0, 10, ErrorMessage = "Kan inte boka mer än 10 biljetter, för fler biljetter vänligen ring oss")]
        public int ReservedSeats { get; set; } = 0; //ReservedSeats from Movieshow

        [Range(0, 1000, ErrorMessage = "Alowed seaats is 0 - 1000")]
        public int TotalSeats { get; set; } = 0; //TotalSeats from Salon
    }
}
