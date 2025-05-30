﻿using BlazorFullStackCrud.Shared;

namespace BlazorFullStackCrud.Client.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> Heroes { get; set; }

        List<Comic> Comics { get; set; }

        Task GetHeroesAsync();

        Task GetComicsAsync();

        Task<SuperHero> GetHeroAsync(int id);

        Task CreateHero(SuperHero hero);

        Task UpdateHero(SuperHero hero);

        Task DeleteHero(int id);
    }
}
