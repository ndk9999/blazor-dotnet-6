using BlazorFullStackCrud.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigator;

        public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public SuperHeroService(HttpClient httpClient, NavigationManager navigator)
        {
            _httpClient = httpClient;
            _navigator = navigator;
        }

        public async Task GetComicsAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Comic>>("api/superhero/comics");

            if (result != null)
            {
                Comics = result;
            }
        }

        public async Task<SuperHero> GetHeroAsync(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");

            if (result == null) throw new Exception("Hero not found!");

            return result;
        }

        public async Task GetHeroesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SuperHero>>("api/superhero");

            if (result != null)
            {
                Heroes = result;
            }
        }

        public async Task CreateHero(SuperHero hero)
        {
            var response = await _httpClient.PostAsJsonAsync("api/superhero", hero);
            await SetHeroes(response);
        }

        public async Task UpdateHero(SuperHero hero)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/superhero/{hero.Id}", hero);
            await SetHeroes(response);
        }

        public async Task DeleteHero(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/superhero/{id}");
            await SetHeroes(response);
        }

        private async Task SetHeroes(HttpResponseMessage response)
        {
            var result = await response.Content.ReadFromJsonAsync<List<SuperHero>>();

            if (result != null)
            {
                Heroes = result;
            }

            _navigator.NavigateTo("superheroes");
        }
    }
}
