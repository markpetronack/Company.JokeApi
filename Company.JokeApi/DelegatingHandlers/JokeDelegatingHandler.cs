using Company.JokeApi.Models;
namespace Company.JokeApi.DelegatingHandlers;
public class JokeDelegatingHandler : DelegatingHandler
{
    private readonly JokeHeaders jokeHeaders;

    public JokeDelegatingHandler(JokeHeaders jokeHeaders)
    {
        this.jokeHeaders = jokeHeaders;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("MyCustomHeader", this.jokeHeaders.MyCustomHeader);
        return await base.SendAsync(request, cancellationToken);
    }
}
