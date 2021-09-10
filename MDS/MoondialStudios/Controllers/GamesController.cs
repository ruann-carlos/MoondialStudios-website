using Microsoft.AspNetCore.Mvc;
using MoondialStudios.Repositories;
using MoondialStudios.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using MoondialStudios.Dtos;

namespace MoondialStudios.Controllers
{
    
    [ApiController]
    [Route("games")]
    public class GamesController : ControllerBase
    {
        private readonly IInMemGameRepository repository;

        public GamesController(IInMemGameRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<GameDto> GetGames()
        {
            var games = repository.GetGames().Select(game => game.AsDto());
            return games;
        }

        [HttpGet("{id}")]
        public ActionResult<GameDto> GetGame(Guid id){
            var game = repository.GetGame(id);

            if(game is null){
                return NotFound();
            }
            return game.AsDto();
        }

        [HttpGet("name/{id}")]
        public ActionResult<string> GetGameName(Guid id){
            var game = repository.GetGameName(id);

            if(game is null){
                return NotFound();
            }

            return game;
        }

        //post /items
        [HttpPost]
        public ActionResult<GameDto> CreateItem(CreateGameDto gameDto){
            Game game = new(){
                Id = Guid.NewGuid(),
                Name = gameDto.Name,
                date = DateTimeOffset.UtcNow
            };

            repository.CreateGame(game);

            return CreatedAtAction(nameof(GetGame), new {id = game.Id}, game.AsDto());
        }
        
        //Put /games/
        [HttpPut("{id}")]
        public ActionResult UpdateGame(Guid id, UpdateGameDto gameDto){
            var existingGame = repository.GetGame(id);
            if(existingGame is null){
                return NotFound();
            }

            Game updateGame = existingGame with{
                Name = gameDto.Name
            };

            repository.UpdateGame(updateGame);
            return NoContent();
        }

        //delete /game
        [HttpDelete("{id}")]
        public ActionResult DeleteGame (Guid id){
            var existingGame = repository.GetGame(id);
            if(existingGame is null){
                return NotFound();
            }

            repository.DeleteGame(id);

            return NoContent();
        }
    }
}