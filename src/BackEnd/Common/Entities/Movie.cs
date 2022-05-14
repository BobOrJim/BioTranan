using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class Movie : BaseEntity
    {
        //public Guid Id { get; set; } //EF PK naming convention
        
        [MaxLength(200)]
        public string? Title { get; set; }
        
        [MaxLength(200)]
        public string? Language { get; set; }
        
        [MaxLength(200)]
        public string? Subtitle { get; set; }
        
        [MaxLength(200)]
        public string? Cathegory { get; set; }

        [Range(0, 600, ErrorMessage = "BioTranan does not show movies longer than 600 minutes")]
        public int? MinutesLength { get; set; }

        [Range(0, 200, ErrorMessage = "Max age is 200 years")]
        public int? MinimumAgeLimit { get; set; }
        
        [MaxLength(200)]
        public string? PictureURL { get; set; }
        
        [MaxLength(10000)]
        public string? Description { get; set; }
        
        [MaxLength(200)]
        public string? Director { get; set; }
        
        [MaxLength(200)]
        public string? Actors { get; set; }
        
        public DateTime ReleaseDate { get; set; }

        [Range(0, 10000, ErrorMessage = "BioTranans maximum ticketprice is 10000")]
        public int? PriceSEK { get; set; }

        [Range(0, 1000, ErrorMessage = "BioTranans maximum buy limit is 1000")]
        public int PurchasedViews { get; set; }
        

        public int UsedViews { get; set;
        }
        public void UseView()
        {
            UsedViews++;
        }

        public List<MovieShow>? MovieShows { get; set; } = new(); //EF will map this to the join table
    }
}
