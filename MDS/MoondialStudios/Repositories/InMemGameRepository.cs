using System;
using System.Collections.Generic;
using MoondialStudios.Entities;
using System.Linq;

namespace MoondialStudios.Repositories
{
    
    public class InMemGameRepository : IInMemGameRepository
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

        public string GetGameName(Guid id)
        {
            return games.Where(game => game.Id == id).SingleOrDefault().Name;
        }

        public void CreateGame(Game game)
        {
            games.Add(game);
        }

        public void UpdateGame(Game game)
        {
            var index = games.FindIndex(existingGame => existingGame.Id == game.Id);
            games[index] = game;
        }

        public void DeleteGame(Guid id)
        {
            var index = games.FindIndex(existingGame => existingGame.Id == id);
            games.RemoveAt(index);
        }
    }
}