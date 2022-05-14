using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class MovieShow : BaseEntity
    {
        //public Guid Id { get; set; } //EF PK convention
        public Guid SalonId { get; set; } //When inserting a moveShow, a salon with this id must exist
        public Guid MovieId { get; set; } //When inserting a moveShow, a movie with this id must exist

        public DateTime DateTime { get; set; }


        [Range(0, 600, ErrorMessage = "Maximum reduction is 600")]
        public int? PandemicSeatReduction { get; set; }

        public List<Reservation>? Reservations { get; set; } = new(); //EF automatic navigation property
        public List<Review>? Reviews { get; set; } = new(); //EF automatic navigation property

    }
}

    