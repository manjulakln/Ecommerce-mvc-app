using Microsoft.AspNetCore.Mvc;
using Ecommercemvcapp.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommercemvcapp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var moviesdata = await _context.Movies.Include(n => n.Cinema).ToListAsync();
            return View(moviesdata);
        }
    }
}
