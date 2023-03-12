namespace Company.JokeApi.Models;
public record JokeHeaders
{
    public string MyCustomHeader { get; init; } = default!;
}
