using Ecommercemvcapp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Ecommercemvcapp.Models
{
    public class Actor:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Actors Image")]
        
        public string? ProfileImageUrl { get; set; }
        [Required]
        [Display(Name ="Fullname")]
       
        public string? FullName { get; set; }
        [Required]
       
        public string? Biografy { get; set; }
        //relation

        public List<Actor_Movie> Actors_Movies { get; set; }    
    }
}
