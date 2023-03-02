using System.ComponentModel.DataAnnotations;

namespace Ecommercemvcapp.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Cinema Logo")]
        public string? Logo { get; set; }
        [Display(Name ="Cinema Name")]
        public string? Name { get; set; }
        [Required]

        public string? Discription { get; set; }
        //Relations
        public List<Movie> Movies { get; set; }
    }
}
