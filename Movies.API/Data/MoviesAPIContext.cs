﻿using Microsoft.EntityFrameworkCore;
using Movies.API.Model;

namespace Movies.API.Data
{
    public class MoviesAPIContext : DbContext
    {
        public MoviesAPIContext (DbContextOptions<MoviesAPIContext> options): base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
    }
}
