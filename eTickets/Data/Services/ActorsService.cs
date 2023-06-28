using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddActor(Actor actor)
        {
           await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync(); 
        }

        public void DeleteActor(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Actor> GetActor(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.ActorId == id);
            return result;
        }


        public async Task<IEnumerable<Actor>> GetActors()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public Actor UpdateActor(int id, Actor newActor)
        {
            throw new System.NotImplementedException();
        }
    }
}
