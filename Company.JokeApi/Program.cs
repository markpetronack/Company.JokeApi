using Company.JokeApi.DelegatingHandlers;
using Company.JokeApi.Extensions;
using Company.JokeApi.Interfaces;
using Company.JokeApi.Models;
using Refit;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddConfigOptions<JokeHeaders>("JokeHeaders");
builder.Services.AddTransient<JokeDelegatingHandler>();
builder.Services.AddRefitClient<IJokeApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://official-joke-api.appspot.com"))
                .AddHttpMessageHandler<JokeDelegatingHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapGet("/joke", async (IJokeApi jokeApi) => await jokeApi.GetJoke());
app.Run();
