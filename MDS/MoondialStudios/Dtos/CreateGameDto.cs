using System;
using System.ComponentModel.DataAnnotations;

namespace MoondialStudios.Dtos{

    public record CreateGameDto(){
        [Required]
        public string Name { get; init; }
    }
}
