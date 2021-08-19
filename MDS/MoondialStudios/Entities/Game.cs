using System;
using System.Collections.Generic;

namespace MoondialStudios.Entities
{
   public record Game
   {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public DateTimeOffset date { get; init; }
    }
    
}