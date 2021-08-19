using Microsoft.AspNetCore.Mvc;
using MoondialStudios.Repositories;
using MoondialStudios.Entities;
using System;
using System.Collections.Generic;

namespace MoondialStudios.Controllers
{
    
    [ApiController]
    [Route("games")]
    public class GamesController : ControllerBase
    {
        private readonly InMemGameRepository repository;

        public GamesController()
        {
            repository = new InMemGameRepository();
        }

        [HttpGet]
        public IEnumerable<Game> GetGames()
        {
            var games = repository.GetGames();
            return games;
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetGame(Guid id){
            var game = repository.GetGame(id);

            if(game is null){
                return NotFound();
            }
            return game;
        }
    }
}