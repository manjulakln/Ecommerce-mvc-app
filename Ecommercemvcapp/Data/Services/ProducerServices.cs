using Ecommercemvcapp.Data.Base;
using Ecommercemvcapp.Models;

namespace Ecommercemvcapp.Data.Services
{
    public class ProducerServices : EntityBaseRepository<Producer>, IProducerServices
    {
        public ProducerServices(AppDbContext context) : base(context)
        {
        }
    }
}
