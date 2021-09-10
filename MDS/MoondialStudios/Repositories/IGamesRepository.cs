using System;
using System.Collections.Generic;
using MoondialStudios.Entities;

namespace MoondialStudios.Repositories
{
    public interface IInMemGameRepository
    {
        Game GetGame(Guid id);
        string GetGameName(Guid id);
        IEnumerable<Game> GetGames();
        void CreateGame(Game game);
        void UpdateGame(Game game);

        void DeleteGame(Guid id);
    }
}