using System;
using System.Collections.Generic;
using MoondialStudios.Entities;
using System.Linq;

namespace MoondialStudios.Repositories
{

    public class InMemGameRepository
    {
        private readonly List<Game> games = new()
        {
            new Game { Id = Guid.NewGuid(), Name = "Mansion", date = DateTimeOffset.UtcNow },
            new Game { Id = Guid.NewGuid(), Name = "Test", date = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Game> GetGames()
        {
            
            return games;
        }

        public Game GetGame(Guid id)
        {
            return games.Where(game => game.Id == id).SingleOrDefault();
        }
    }
}