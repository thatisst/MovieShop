using AutoMapper;
using MovieShop.Core.Entities;
using MovieShop.Core.Exceptions;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;
        private readonly IMapper _mapper;

        public CastService(ICastRepository castRepository
            , IMapper mapper) 
        {
            _castRepository = castRepository;
            _mapper = mapper;
        }

        public async Task<CastDetailsResponseModel> GetCastDetailsWithMovies(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);
            if (cast == null)
                throw new NotFoundException("Cast " + id + " Not Found");
            var response = _mapper.Map<CastDetailsResponseModel>(cast);
            return response;
        }
    }
}
