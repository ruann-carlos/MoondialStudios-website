using System;

namespace MoondialStudios.Dtos
{
    public record GameDto {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public DateTimeOffset date { get; init; }
    }
}