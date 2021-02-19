using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Views.Shared.NewFolder1.NewFolder
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly IGenreService _genreService;
        public GenresViewComponent(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public IViewComponentResult Invoke()
        {
            var genres = _genreService.GetAllGenres();
            //
            return View(genres);
        }
    }
}
