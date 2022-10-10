using HotelListing.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void  OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Nigeria",
                    ShortName = "NG"
                },
                new Country
                {
                    Id = 2,
                    Name = "Ghana",
                    ShortName = "GH"
                },
                new Country
                {
                    Id = 3,
                    Name = "Benin",
                    ShortName = "BJ"
                },
                new Country
                {
                    Id = 4,
                    Name = "Cameroon",
                    ShortName = "CM"
                });

            builder.Entity<Hotel>().HasData(
               new Hotel
               {
                   Id = 1,
                   Name = "Radisson Bleu Anchorage Hotel",
                   Address = "Lagos",
                   Ratings = 4,
                   CountryId = 1
               },
               new Hotel
               {
                   Id = 2,
                   Name = "Alisa Hotel North Ridge",
                   Address = "Accra",
                   Ratings= 4.5,
                   CountryId = 2


               },
               new Hotel
               {
                   Id = 3,
                   Name = "White Horse Hotel Port0-Novo",
                   Address = "Porto-Novo",
                   Ratings = 4.7,
                   CountryId = 3
               },
               new Hotel
               {
                   Id = 4,
                   Name = "K Hotel",
                   Address = "Douala",
                   Ratings = 4.9,
                   CountryId = 4
               }); ;

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set;}

    }
}
