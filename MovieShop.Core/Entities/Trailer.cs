using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieShop.Core.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
        
        //[ForeignKey("MovieId")] // Don't have to specify. Automatically indentify FK
        public int MovieId { get; set; }
        public string TrailerUrl { get; set; }
        public string Name { get; set; }
        // Navigation properties
        public Movie Movie { get; set; }
    }
}
