using System.ComponentModel.DataAnnotations;
namespace Ecommercemvcapp.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public string ShoppingCartId { get; set; }
        public int Amount{ get; set; }
        public Movie Movie { get; set; }    

    }
}
