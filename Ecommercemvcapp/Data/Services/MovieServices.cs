using Ecommercemvcapp.Data.Base;
using Ecommercemvcapp.Models;

namespace Ecommercemvcapp.Data.Services
{
    public class MovieServices : EntityBaseRepository<Movie>,IMoviesServices
    {
        public MovieServices(AppDbContext context) : base(context)
        {
        }
    }
}
