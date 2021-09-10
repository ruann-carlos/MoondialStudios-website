using System;
using System.ComponentModel.DataAnnotations;

namespace MoondialStudios.Dtos{

    public record UpdateGameDto(){
        [Required]
        public string Name { get; init; }
    }
}
