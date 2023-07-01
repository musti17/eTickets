using eTickets.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetActors();

        Task<Actor> GetActor(int id);

        Task AddActor(Actor actor);

        Task<Actor> UpdateAsync(int id,Actor newActor);

        Task DeleteAsync(int id);
    }
}
