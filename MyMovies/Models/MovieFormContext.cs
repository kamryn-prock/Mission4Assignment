using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Models
{
    public class MovieFormContext : DbContext
    {
        // Constructor
        public MovieFormContext (DbContextOptions <MovieFormContext> options): base(options) 
        {
            //Leave Blank for now
        }

        public DbSet<ApplicationResponse> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder nb)
        {
            nb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    ApplicationId = 1,
                    category = "Action/Adventure",
                    title = "Avengers, The",
                    year = 2012,
                    director = "Tom",
                    rating = "PG-13"
                },
                new ApplicationResponse
                {
                    ApplicationId = 2,
                    category = "Action/Adventure",
                    title = "Batman",
                    year = 1989,
                    director = "Zach",
                    rating = "PG-13"
                },
                new ApplicationResponse
                {
                    ApplicationId = 3,
                    category = "Action/Adventure",
                    title = "Batman & Robin",
                    year = 1989,
                    director = "Jake",
                    rating = "PG-13"
                }
            );
        }
    }
}
