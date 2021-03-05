using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Models.Response
{
    public class GenreModel
    {
        public int Id { get; set; }

        //[MaxLength(24)] // no need here
        public string Name { get; set; }
    }
}
