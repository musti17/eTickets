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
        public IActionResult Index()
        {
            var data = _actorsService.GetActors();//synchronous method to get list of actors
            return View(data);
        }

        //Get:  Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);//will return the same view with the Model State Errors
            }
            _actorsService.AddActor(actor);
            return RedirectToAction(nameof(Index));

        }
    }
}
