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
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<Trailer>(ConfigureTrailer);

            modelBuilder.Entity<Movie>().HasMany(m => m.Genres).WithMany(g => g.Movies)
                .UsingEntity<Dictionary<string, object>>("MovieGenre",
                    m => m.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                    g => g.HasOne<Movie>().WithMany().HasForeignKey("MovieId"));

            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany(g => g.Users)
                .UsingEntity<Dictionary<string, object>>("UserRole",
                u => u.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                r => r.HasOne<User>().WithMany().HasForeignKey("UserId"));

            modelBuilder.Entity<Movie>().HasMany(m => m.MovieCasts).WithOne(c => c.Movie);

            modelBuilder.Entity<Movie>().HasMany(m => m.Reviews).WithOne(r => r.Movie)
                .HasForeignKey(r => r.MovieId);

            modelBuilder.Entity<Review>().HasKey(r => new { r.UserId, r.MovieId });
            //modelBuilder.Entity<Review>().HasNoKey();

            modelBuilder.Entity<Cast>(ConfigureCast);

            modelBuilder.Entity<MovieCast>().HasKey(mc => new { mc.MovieId, mc.CastId, mc.Character });
        }


        private void ConfigureCast(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Cast");
            builder.Property(c => c.Name).HasMaxLength(128);
            builder.Property(c => c.ProfilePath).HasMaxLength(2084);
        }

        private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable("Trailer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TrailerUrl).HasMaxLength(2084);
            builder.Property(t => t.Name).HasMaxLength(2084);
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
        }

        // // Many DbSets, they are represented as properties - "typo? should be 'table'?"
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Review> Reviews { get; set; }


    }

    // Default project: MovieShop.Infrastructure
    //add-migration MovieTable   --  see sth. wrong, remove migration before applying
    //Remove-migration -- remove the latest migration
}
