using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommercemvcapp.Data.ViewModels
{
    public class NewMovieVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Movie Name is required")]
        [Display(Name ="Movie Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Movie Description")]
        public string Description { get; set; }
        [Required, Display(Name ="Price in $")]
        public string Price { get; set; }
        [Required,Display(Name ="Movie Poster Url")]
        public string ImageUrl { get; set; }
        [Required,DisplayFormat(DataFormatString="DD/MM/YYYY")]
        public DateTime StartDate { get; set; }
        [Required, DisplayFormat(DataFormatString = "DD/MM/YYYY")]
        public DateTime EndDate { get; set; }
        [Required,Display(Name="Select Movie Catagory")]
        public MovieCategory MovieCategory { get; set; }
        [Required,Display(Name="Select Actor(s)")]

        public List<int> ActorIds { get; set; }
        [Required,Display(Name="Select Producer")]
        public int ProducerId { get; set; }
        [Required, Display(Name = "Select Cinema")]
        public int CinemaId { get; set; }   
    }
}
