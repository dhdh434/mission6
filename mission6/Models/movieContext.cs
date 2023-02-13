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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<movieInput>().HasData(
                new movieInput
                {
                    MovieId = 1,
                    Title = "Star Wars III",
                    Category = "Action/Adventure",
                    Year = 2001,
                    Director = "George Lucas",
                    Rating = "PG-13",
                    Edited = false,
                },
                new movieInput
                {
                    MovieId = 2,
                    Title = "Star Wars II",
                    Category = "Action/Adventure",
                    Year = 1999,
                    Director = "George Lucas",
                    Rating = "PG",
                    Edited = false,
                },
                new movieInput
                {
                    MovieId = 3,
                    Title = "Star Wars I",
                    Category = "Action/Adventure",
                    Year = 1998,
                    Director = "George Lucas",
                    Rating = "PG",
                    Edited = false,
                }

            );
        }
    }
}
