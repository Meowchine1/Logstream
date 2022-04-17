using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1VoroninaVar5
{
    internal class EF
    {


      public  static void PrintOrderbyHouses()
        {
            using (CityContext db = new CityContext())
            {
                var houses = db.Houses.OrderBy(x => x.year)
                .Join(db.Streets, x => x.streetId, t => t.Id,
                (x, t) => new
                {
                    Number = x.Id,
                    Year = x.year,
                    Street = t.Name
                });

                foreach (var x in houses)
                {
                    Console.WriteLine($" [{x.Year}] House Number: {x.Number}  Street: {x.Street}");
                }
            }

             

        }

        public static void PrintOrderbyHousesByRebildNeed()
        {
            using (CityContext db = new CityContext())
            {
                var houses = db.Houses.OrderByDescending(x => x.year * x.flatNum)
                .Join(db.Streets, x => x.streetId, t => t.Id,
                (x, t) => new
                {
                    Number = x.Id,
                    Important = x.flatNum * x.year,
                    Street = t.Name
                });

                foreach (var x in houses)
                {
                    Console.WriteLine($" [{x.Important} ] House Number: {x.Number}  Street: {x.Street}");
                }
            }

        }

        public static void PrintOrderbyHousesLessThanMeanRebuilding()
        {
            using (CityContext db = new CityContext())
            {

                double mean = db.Houses.Average(x => x.year);
               
                Console.WriteLine($"Mean is {mean}");
                var houses = db.Houses.Where(x => x.year > mean);
                foreach (var elem in houses)
                {
                    Console.WriteLine($" Home num: {elem.Id}  year:{elem.year}");
                }
            }

        }

        public static void PrintOrderbyHousesOlderThan5yearsAgoRebuilding()
        {
           
            using (CityContext db = new CityContext())
            {
                var houses = from h in db.Houses
                             .Where(x => x.year < DateTime.Now.Year)
                             join s in db.Streets on h.streetId equals s.Id
                             group s by s.Id into grp
                             select new
                             {
                                 
                                 Name = grp.Key,
                                 Count = grp.Count()
                             };
                foreach (var elem in houses)
                {
                    Console.WriteLine($"{elem.Name}  {elem.Count}");
                }

            }

        }
        public static void MakeRebuildingOldestHome()
        {
            using (CityContext db = new CityContext())
            {
                //int minYear = db.Houses.Min(x => x.year);
                var oldObj = db.Houses.OrderBy(x => x.year)
                    .First();
                Console.WriteLine($"Oldest {oldObj.year}");
                oldObj.year = DateTime.Now.Year;
                Console.WriteLine($"Changing {oldObj.year}");

            }

        }

        public  static void DeleteSmallHouses()
        {
            using (CityContext db = new CityContext())
            {


                int min = db.Houses.Min(x => x.flatNum);
                var smallObj = db.Houses.Where(x => x.flatNum == min);

                foreach (var elem in smallObj) {
                    db.Houses.Remove(elem);
                    
                        }
                db.SaveChanges();
            }

        }

        public static void IncreaseSmallStreet()
        {
            Random random = new Random();
            int length = 6;
            char letter;
            StringBuilder str_build = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }

            using (CityContext db = new CityContext())
            {

                var houses = from h in db.Houses
                             group h by h.streetId into grp
                             select new
                             {
                                 streetId = grp.Key,
                                 Count = grp.Count(),
                                 SUM = grp.Sum( s => s.flatNum)
                             };

                var streetId = houses.OrderBy(x => x.SUM).Select(x => x.streetId).First();

                var newHouse = new House {
                    flatNum = 45,
                    streetId = streetId,
                    year = DateTime.Now.Year,
                    Id = str_build.ToString()

                };

                db.Houses.Add(newHouse);

                db.SaveChanges();
            }

        }


    }
}
