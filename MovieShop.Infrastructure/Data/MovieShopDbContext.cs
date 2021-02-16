using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieShop.Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options) //NEW
        {
        }

        // 'vitual' - can be overridden
        // Action<EntityTypeBuilder<TEntity>> buildAction, return null
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<Trailer>(ConfigureTrailer);
            //modelBuilder.Entity<Movie>().HasMany(m => m.Genres).WithMany(g => g.Movies).
            //    UsingEntity<Dictionary<string, object>>("MovieGenre",
            //                           ),;
            //(N : N) Movie : Genre Relationship
            modelBuilder.Entity<Movie>().HasMany(m => m.Genres).WithMany(g => g.Movies)
                .UsingEntity<Dictionary<string, object>>("MovieGenre",
                    m => m.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                    g => g.HasOne<Movie>().WithMany().HasForeignKey("MovieId"));
        }

        private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable("Trailer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TrailerUrl).HasMaxLength(2084);
            builder.Property(t => t.Name).HasMaxLength(2084);

            //In Package Manager Console
            //add-migration TrailerTable
            // missing PK, do something before update-database
            //update-database

        }

        private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
        {
            // Fluent API
            //give rules to our Movie table/entit
            builder.ToTable("Movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(256);
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");

            //In Package Manager Console
            //add-migration MovieTable
            //update-database
        }

        // // Many DbSets, they are represented as properties - "typo? should be 'table'?"
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Trailer> Trailers { get; set; }


    }

    // Default project: MovieShop.Infrastructure
    //add-migration MovieTable   --  see sth. wrong, remove migration before applying
    //Remove-migration -- remove the latest migration
}
