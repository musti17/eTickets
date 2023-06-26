using eTickets.Models;
using System.Collections.Generic;
using System.Linq;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddActor(Actor actor)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteActor(int id)
        {
            throw new System.NotImplementedException();
        }

        public Actor GetActor(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Actor> GetActors()
        {
            var result = _context.Actors.ToList();
            return result;
        }

        public Actor UpdateActor(int id, Actor newActor)
        {
            throw new System.NotImplementedException();
        }
    }
}
