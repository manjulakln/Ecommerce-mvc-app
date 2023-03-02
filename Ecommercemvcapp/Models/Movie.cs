using Ecommercemvcapp.Data;
using Ecommercemvcapp.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommercemvcapp.Models
{
    public class Movie :IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Imageurl { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        //relations

        public List<Actor_Movie> Actors_Movies { get; set; }
        //cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
