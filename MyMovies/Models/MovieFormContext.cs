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
        public DbSet<Category>Categories { get; set; }
        
        //Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryID = 2, CategoryName = "Comedy"}
            );

            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    ApplicationId = 1,
                    CategoryID = 1,
                    title = "Avengers, The",
                    year = 2012,
                    director = "Tom",
                    rating = "PG-13"
                },
                new ApplicationResponse
                {
                    ApplicationId = 2,
                    CategoryID = 1,
                    title = "Batman",
                    year = 1989,
                    director = "Zach",
                    rating = "PG-13"
                },
                new ApplicationResponse
                {
                    ApplicationId = 3,
                    CategoryID = 1,
                    title = "Batman & Robin",
                    year = 1989,
                    director = "Jake",
                    rating = "PG-13"
                }
            );
        }
    }
}
