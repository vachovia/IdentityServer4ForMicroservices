using Movies.API.Model;

namespace Movies.API.Data.SeedData
{
    public static class MoviesContextSeed
    {
        // var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()
        // var context = serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>()
        // builder.Services.BuildServiceProvider().GetRequiredService
        // IHost = builder.Build()
        //public static void SeedDatatabse(IHost host)
        //{
        //    using var scope = host.Services.CreateScope();

        //    var services = scope.ServiceProvider;

        //    var moviesContext = services.GetRequiredService<MoviesAPIContext>();

        //    SeedData(moviesContext);
        //}

        public static void AddSeedData(this IApplicationBuilder app)
        {
            try
            {
                using var scope = app.ApplicationServices.CreateScope();
                var moviesContext = scope.ServiceProvider.GetRequiredService<MoviesAPIContext>();
                SeedData(moviesContext);
            }
            catch
            {
                throw;
            }
        }

        public static void SeedData(MoviesAPIContext moviesContext)
        {
            if (!moviesContext.Movie.Any())
            {
                var movies = new List<Movie>
                {
                    new Movie
                    {
                        Genre = "Drama",
                        Title = "The Shawshank Redemption",
                        Rating = "9.3",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1994, 5, 5),
                        Owner = "alice"
                    },
                    new Movie
                    {
                        Genre = "Crime",
                        Title = "The Godfather",
                        Rating = "9.2",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1972, 5, 5),
                        Owner = "alice"
                    },
                    new Movie
                    {
                        Genre = "Action",
                        Title = "The Dark Knight",
                        Rating = "9.1",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(2008, 5, 5),
                        Owner = "bob"
                    },
                    new Movie
                    {
                        Genre = "Crime",
                        Title = "12 Angry Men",
                        Rating = "8.9",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1957, 5, 5),
                        Owner = "bob"
                    },
                    new Movie
                    {
                        Genre = "Biography",
                        Title = "Schindler's List",
                        Rating = "8.9",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1993, 5, 5),
                        Owner = "alice"
                    },
                    new Movie
                    {
                        Genre = "Drama",
                        Title = "Pulp Fiction",
                        Rating = "8.9",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1994, 5, 5),
                        Owner = "alice"
                    },
                    new Movie
                    {
                        Genre = "Drama",
                        Title = "Fight Club",
                        Rating = "8.8",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1999, 5, 5),
                        Owner = "bob"
                    },
                    new Movie
                    {
                        Genre = "Romance",
                        Title = "Forrest Gump",
                        Rating = "8.8",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1994, 5, 5),
                        Owner = "bob"
                    }
                };
                moviesContext.Movie.AddRange(movies);
                moviesContext.SaveChanges();
            }
        }
    }
}
