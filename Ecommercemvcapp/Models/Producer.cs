using System.ComponentModel.DataAnnotations;
using Ecommercemvcapp.Data.Base;

namespace Ecommercemvcapp.Models
{
    public class Producer:IEntityBase
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Profile picture")]
        public string? ProfileImageUrl { get; set; }
        [Required]
        [StringLength(50)]
        public string? FullName { get; set; }
        [Required]
        [StringLength (maximumLength:500)]
        public string? Biografy { get; set; }
        
        //Relations
        public List<Movie> Movies { get; set; }
    }
}
