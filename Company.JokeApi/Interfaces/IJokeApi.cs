using Company.JokeApi.Models;
using Refit;

namespace Company.JokeApi.Interfaces;

    public interface IJokeApi
    {
        [Get("/random_joke")]
        Task<Joke> GetJoke();
    }

