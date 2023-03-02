using System.ComponentModel.DataAnnotations;

namespace Ecommercemvcapp.Models
{
    public class Order
    {
       [Key]
       public int Id { get; set; }

        public string Emailaddress { get; set; }
        public string UserId { get; set; }

        public List<OrderItems> orderItems { get; set; }
    }
}
