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

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n=>n.ActorId == id);
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
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

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }
    }
}
