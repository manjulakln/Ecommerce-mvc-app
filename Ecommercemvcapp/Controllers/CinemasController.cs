using Microsoft.AspNetCore.Mvc;
using Ecommercemvcapp.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommercemvcapp.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _context;

        public CinemasController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var cinemassdata = await _context.Cinemas.ToListAsync();
            return View(cinemassdata);
        }
    }
}
