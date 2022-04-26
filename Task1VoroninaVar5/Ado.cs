using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1VoroninaVar5
{
    internal class Ado
    {
       public static void PrintOrderbyHouses()
        {

            using var connection = new SqlConnection(@"Server=WIN-QGN772BFJ6Q\MYSQL;Database=City1;Trusted_Connection=True;");
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "Select h.year, h.Id, s.Name " +
                "from Houses h inner join Streets s  on h.streetId = s.Id order by year ";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($" [{reader.GetInt32(reader.GetOrdinal("year"))}]  House number {reader.GetString(reader.GetOrdinal("Id"))}" +
                    $"  Street name {reader.GetString(reader.GetOrdinal("Name"))}");
            }

            connection.Close();
        }

        public static void PrintOrderbyHousesByRebildNeed() {

            using var connection = new SqlConnection(@"Server=WIN-QGN772BFJ6Q\MYSQL;Database=City1;Trusted_Connection=True;");
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "Select h.year, h.flatNum, h.Id, s.Name " +
                "from Houses h inner join Streets s  on h.streetId = s.Id order by year * flatNum desc ";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine( $"House number {reader.GetString(reader.GetOrdinal("Id"))}  " +
                    $"Street name {reader.GetString(reader.GetOrdinal("Name"))} " +
                    $" flatNum {reader.GetInt32(reader.GetOrdinal("flatNum"))}  year {reader.GetInt32(reader.GetOrdinal("year"))}");
            }

            connection.Close();
        }
        public static void PrintOrderbyHousesLessThanMeanRebuilding() {

            using var connection = new SqlConnection(@"Server=WIN-QGN772BFJ6Q\MYSQL;Database=City1;Trusted_Connection=True;");
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "Select * " +
                "from Houses h " +
                "WHERE year >  (SELECT AVG(year) AS D FROM Houses)";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($" House number {reader.GetString(reader.GetOrdinal("Id"))}  " +
                    $"Street name {reader.GetInt32(reader.GetOrdinal("year"))}");
            }

            connection.Close();
        }
        public static void PrintOrderbyHousesOlderThan5yearsAgoRebuilding() {

            using var connection = new SqlConnection(@"Server=WIN-QGN772BFJ6Q\MYSQL;Database=City1;Trusted_Connection=True;");
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "Select (select  s.Name   from Streets s where s.Id = streetId   ) as StreetName, count(streetId) as k " +
                "from Houses h inner join Streets s on h.streetId = s.Id " +
                "where h.year > (SELECT YEAR(getdate())) - 5  group by streetId";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($" Street {reader.GetString(reader.GetOrdinal("StreetName"))}  " +
                    $"house num {reader.GetInt32(reader.GetOrdinal("k"))}");
            }

            connection.Close();
        }
        public static void  MakeRebuildingOldestHome() {

            using var connection = new SqlConnection(@"Server=WIN-QGN772BFJ6Q\MYSQL;Database=City1;Trusted_Connection=True;");
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "select min(year) as minYear, (SELECT YEAR(getdate())) as curYear from Houses" +
                " update top (1) Houses " +
                "set Houses.year = (SELECT YEAR(getdate())) " +
                "FROM Houses h " +
                "WHERE h.year = (SELECT  MIN(year) FROM Houses)";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($" Min year {reader.GetInt32(reader.GetOrdinal("minYear"))}. Update to {reader.GetInt32(reader.GetOrdinal("curYear"))}");
            }
            connection.Close();
        }
        public static void DeleteSmallHouses() {

            using var connection = new SqlConnection(@"Server=WIN-QGN772BFJ6Q\MYSQL;Database=City1;Trusted_Connection=True;");
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "select min(flatNum) as minFlatnum   from Houses   " +
                "select Id as minId from Houses where flatNum = (select min(flatNum) from Houses) " +
                "delete from Houses where flatNum = (select min(flatNum) from Houses)";
            using var reader = command.ExecuteReader();
           

            connection.Close();
        }
        public static void  IncreaseSmallStreet() {

            using var connection = new SqlConnection(@"Server=WIN-QGN772BFJ6Q\MYSQL;Database=City1;Trusted_Connection=True;");
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "declare @AlLChars varchar(100) = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789'  " +
                "declare @name varchar = (SELECT RIGHT(LEFT(@AlLChars, ABS(BINARY_CHECKSUM(NEWID()) % 35) + 1), 1)  " +
                "+ RIGHT(LEFT(@AlLChars, ABS(BINARY_CHECKSUM(NEWID()) % 35) + 1), 1) + RIGHT(LEFT(@AlLChars, ABS(BINARY_CHECKSUM(NEWID()) % 35) + 1), 1) " +
                "+ RIGHT(LEFT(@AlLChars, ABS(BINARY_CHECKSUM(NEWID()) % 35) + 1), 1) + RIGHT(LEFT(@AlLChars, ABS(BINARY_CHECKSUM(NEWID()) % 35) + 1), 1)) " +
                "declare @year int = (select year(getdate())) " +
                "declare @idStreet int = (select top 1 streetId from Houses group by streetId order by sum(flatNum) )   " +
                "select Name from Streets where Id = @idStreet " +
                "insert into Houses values (@name, 44, @year, @idStreet)" +
                "  ";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($" Name {reader.GetString(reader.GetOrdinal("Name"))} ");
            }
            connection.Close();
        }


    }
}
