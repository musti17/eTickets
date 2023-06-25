using eTickets.Models;
using System.Collections;
using System.Collections.Generic;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        IEnumerable<Actor> GetActors();

        Actor GetActor(int id);

        void Add(Actor actor);

        Actor UpdateActor(int id,Actor newActor);

        void DeleteActor(int id);
    }
}
