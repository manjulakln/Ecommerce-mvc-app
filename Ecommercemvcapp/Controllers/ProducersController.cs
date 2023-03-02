using Microsoft.AspNetCore.Mvc;
using Ecommercemvcapp.Data;
using Microsoft.EntityFrameworkCore;
using Ecommercemvcapp.Data.Services;
using Ecommercemvcapp.Models;

namespace Ecommercemvcapp.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerServices _service;

        public ProducersController(IProducerServices service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var producersdata = await _service.GetAllAsync();
            return View(producersdata);
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Producer producer)
            {
            //if(!ModelState.IsValid)
            //{
            //    return View(producer);
            //}
            await _service.AddAsync(producer);
           return RedirectToAction(nameof(Index));
        }
        //Get: /Producers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return View("Notfound");
            }
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
           
            var result = await _service.GetByIdAsync(id);
            if(result == null)
            {
                return View("Notfound");
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Producer producer)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(producer);
            //}
            await _service.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return View("Notfound");
            }
            return View(result);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
