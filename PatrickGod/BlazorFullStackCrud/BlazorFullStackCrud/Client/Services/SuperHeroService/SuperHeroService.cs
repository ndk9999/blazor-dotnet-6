using BlazorFullStackCrud.Shared;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _httpClient;

        public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public SuperHeroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task GetComicsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SuperHero> GetHeroAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetHeroesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SuperHero>>("api/superhero");

            if (result != null)
            {
                Heroes = result;
            }
        }
    }
}
