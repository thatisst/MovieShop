using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using MovieShop.Core.Entities;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        public readonly IAsyncRepository<Genre> _genreRepository;
        private static readonly TimeSpan DefaultCacheDuration = TimeSpan.FromDays(30);
        private static readonly string _genresKey = "genres";
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;

        public GenreService(IAsyncRepository<Genre> genreRepository
            , IMemoryCache cache, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _cache = cache;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            var genres = await _cache.GetOrCreateAsync(_genresKey, Factory);
            return genres.OrderBy(g => g.Name);

            //var genres = await _genreRepository.ListAllAsync();
            //return genres;
        }

        private async Task<IEnumerable<Genre>> Factory(ICacheEntry entry)
        {
            entry.SlidingExpiration = DefaultCacheDuration;
            var dbGenres = await _genreRepository.ListAllAsync();
            return dbGenres;
            //return _mapper.Map<IEnumerable<Genre>>(dbGenres);
        }
    }
}
