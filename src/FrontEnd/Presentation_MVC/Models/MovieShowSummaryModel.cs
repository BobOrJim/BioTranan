namespace Presentation_MVC.Models
{
    public class MovieShowSummaryModel
    {
        public Guid Id { get; set; } 
        public string PictureURL { get; set; } = ""; 
        public string Date { get; set; } = ""; 
        public string Time { get; set; } = ""; 
        public string Title { get; set; } = ""; 
        public string Language { get; set; } = ""; 
        public string Subtitle { get; set; } = ""; 
        public string Cathegory { get; set; } = ""; 
        public int MinutesLength { get; set; } = 0; 
        public int MinimumAgeLimit { get; set; } = 0; 
        public int ReservedSeats { get; set; } = 0;
        public int TotalSeats { get; set; } = 0; 
    }
}
