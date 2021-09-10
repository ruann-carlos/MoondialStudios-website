using MoondialStudios.Dtos;
using MoondialStudios.Entities;

namespace MoondialStudios
{
    public static class Extensions {
        public static GameDto AsDto (this Game game){
            
            return new GameDto{
                Id = game.Id,
                Name = game.Name,
                date = game.date
            };
        }
    }
}