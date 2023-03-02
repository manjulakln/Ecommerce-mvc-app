using Ecommercemvcapp.Data.Base;
using Ecommercemvcapp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ecommercemvcapp.Data.Services
{
    public class ActorServices : EntityBaseRepository<Actor>, IActorservices
    {
        public ActorServices(AppDbContext context) : base(context) { }
    }
}
