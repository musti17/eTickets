using eTickets.Data;
using eTickets.Data.Services;
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
    }
}
