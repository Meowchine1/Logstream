using Microsoft.EntityFrameworkCore;

namespace Task1VoroninaVar5
{
    internal class CityContext : DbContext
    {
        public DbSet<House> Houses { get; set; }
        public DbSet<Street> Streets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WIN-QGN772BFJ6Q\MYSQL;Database=City1;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>().HasData(
                new House[]
                {
                    new House { Id="3-a", flatNum=2000, year=2000, streetId=11},
                    new House { Id="4-б", flatNum=36, year=1976, streetId=11},
                    new House { Id="75-с", flatNum=355, year=2010, streetId=11},
                    new House { Id="14",flatNum=90, year=1955, streetId=541 },
                    new House { Id="43",flatNum=50, year=1910, streetId=541 },
                    new House { Id="55",flatNum=66, year=1999, streetId=541 },
                    new House { Id="17-б",flatNum=466, year=1980, streetId=55},
                    new House { Id="100-л",flatNum=800, year=2022, streetId=55},
                    new House { Id="1789-у",flatNum=10, year=1988, streetId=55},

                }
                );
            modelBuilder.Entity<Street>().HasData(
                new Street[]
                {
                    new Street { Id=11, Name="Michurina" },
                    new Street { Id=541, Name="Rakhova" },
                    new Street { Id=55, Name="Veselaya"  }
                }
                );

        }

        public void CreateIfNotExist()
        {
            Database.EnsureCreated();

        }

    }
}