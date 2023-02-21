 using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission6.Models
{
    public class movieContext : DbContext
    {
        //Constructor
        public movieContext(DbContextOptions<movieContext> options) : base(options)
        {

        }

        public DbSet<movieInput> moviesAdded { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Romance" },
                new Category { CategoryId = 3, CategoryName = "Horror" },
                new Category { CategoryId = 4, CategoryName = "Comedy" },
                new Category { CategoryId = 5, CategoryName = "Thriller" },
                new Category { CategoryId = 6, CategoryName = "Documentary" }
            );


            mb.Entity<movieInput>().HasData(
                new movieInput
                {
                    MovieId = 1,
                    Title = "Star Wars III",
                    CategoryId = 1,
                    Year = 2001,
                    Director = "George Lucas",
                    Rating = "PG-13",
                    Edited = false,
                },
                new movieInput
                {
                    MovieId = 2,
                    Title = "Star Wars II",
                    CategoryId = 1,
                    Year = 1999,
                    Director = "George Lucas",
                    Rating = "PG",
                    Edited = false,
                },
                new movieInput
                {
                    MovieId = 3,
                    Title = "Star Wars I",
                    CategoryId = 1,
                    Year = 1998,
                    Director = "George Lucas",
                    Rating = "PG",
                    Edited = false,
                }

            );
        }
    }
}
