using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;

        public ActorsController(AppDbContext context)
        {
           _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Actors.ToList();//synchronous method to get list of actors
            return View();
        }
    }
}
