using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService actorsService)
        {
           _actorsService = actorsService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _actorsService.GetActors();//synchronous method to get list of actors
            return View(data);
        }

        //Get:  Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);//will return the same view with the Model State Errors
            }
            await _actorsService.AddActor(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _actorsService.GetActor(id);

            if(actorDetails == null) return View("Empty");
            return View(actorDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _actorsService.GetActor(id);

            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);//will return the same view with the Model State Errors
            }

            await _actorsService.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _actorsService.GetActor(id);

            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var actorDetails = await _actorsService.GetActor(id);
            if (actorDetails == null) return View("Not Found");

            await _actorsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
