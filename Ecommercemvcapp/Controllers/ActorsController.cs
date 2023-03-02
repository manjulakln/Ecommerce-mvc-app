using Microsoft.AspNetCore.Mvc;
using Ecommercemvcapp.Data;
using Ecommercemvcapp.Data.Services;
using Ecommercemvcapp.Models;

namespace Ecommercemvcapp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorservices _services;

        public ActorsController(IActorservices service)
        {
            _services = service;
        }
        public async  Task<IActionResult> Index()
        {
            var data = await _services.GetAllAsync();
            return View(data);
        }
        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                
                return View(actor);
            }
            

            await _services.AddAsync(actor);
            return RedirectToAction(nameof(Index));
          
        }
        //get : Actors/Details
        public async Task<IActionResult> Details(int id)
        {
          var details = await _services.GetByIdAsync(id);
            if(details == null)
                return View("Notfound");
            else
            return View(details);
        }
        //Get: Actors/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var details = await _services.GetByIdAsync(id);
            if (details == null)
                return View("Notfound");
            else
                return View(details);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Actor actor)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(actor);
            //}
            await _services.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));

        }
        //Get: Actors/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var details = await _services.GetByIdAsync(id);
            if (details == null)
                return View("Notfound");
            else
                return View(details);
        }
        [HttpPost, ActionName("Delete")]    
        public async Task<IActionResult> Deleteconfimed(int id)
        {
            //var details = await _services.GetByIdAsync(id);
            //if (details == null)
            //    return View("Notfound");

            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index)); 
        }
    }
}
