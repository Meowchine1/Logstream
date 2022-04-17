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
            command.CommandText = "Select h.Id, s.Name from Houses h inner join Streets s  on h.streetId = s.Id order by year ";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($" House number {reader.GetString(reader.GetOrdinal("Id"))}  Street name {reader.GetString(reader.GetOrdinal("Name"))}");
            }

            connection.Close();
        }

        public static void PrintOrderbyHousesByRebildNeed() {

            using var connection = new SqlConnection(@"Server=WIN-QGN772BFJ6Q\MYSQL;Database=City1;Trusted_Connection=True;");
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "Select h.year, h.flatNum, h.Id, s.Name from Houses h inner join Streets s  on h.streetId = s.Id order by year * flatNum desc ";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine( $"House number {reader.GetString(reader.GetOrdinal("Id"))}  Street name {reader.GetString(reader.GetOrdinal("Name"))} " +
                    $" flatNum {reader.GetInt32(reader.GetOrdinal("flatNum"))}  year {reader.GetInt32(reader.GetOrdinal("year"))}");
            }

            connection.Close();
        }
        public static void PrintOrderbyHousesLessThanMeanRebuilding() {

            using var connection = new SqlConnection(@"Server=WIN-QGN772BFJ6Q\MYSQL;Database=City1;Trusted_Connection=True;");
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "Select * from Houses h WHERE year >  (SELECT AVG(year) AS D FROM Houses)";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($" House number {reader.GetString(reader.GetOrdinal("Id"))}  Street name {reader.GetInt32(reader.GetOrdinal("year"))}");
            }

            connection.Close();
        }
        public static void AdoPrintOrderbyHousesOlderThan5yearsAgoRebuilding() {

            using var connection = new SqlConnection(@"Server=WIN-QGN772BFJ6Q\MYSQL;Database=City1;Trusted_Connection=True;");
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT h.Id, s.streetName from Houses h join Streets s on h.streetId = s.streetId ";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($" House number {reader.GetString(reader.GetOrdinal("Id"))}  Street name {reader.GetString(reader.GetOrdinal("streetName"))}");
            }

            connection.Close();
        }
        public static void AdoMakeRebuildingOldestHome() {

            using var connection = new SqlConnection(@"Server=WIN-QGN772BFJ6Q\MYSQL;Database=City1;Trusted_Connection=True;");
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT h.Id, s.streetName from Houses h join Streets s on h.streetId = s.streetId ";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($" House number {reader.GetString(reader.GetOrdinal("Id"))}  Street name {reader.GetString(reader.GetOrdinal("streetName"))}");
            }

            connection.Close();
        }
        public static void AdoDeleteSmallHouses() {

            using var connection = new SqlConnection(@"Server=WIN-QGN772BFJ6Q\MYSQL;Database=City1;Trusted_Connection=True;");
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT h.Id, s.streetName from Houses h join Streets s on h.streetId = s.streetId ";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($" House number {reader.GetString(reader.GetOrdinal("Id"))}  Street name {reader.GetString(reader.GetOrdinal("streetName"))}");
            }

            connection.Close();
        }
        public static void AdoIncreaseSmallStreet() {

            using var connection = new SqlConnection(@"Server=WIN-QGN772BFJ6Q\MYSQL;Database=City1;Trusted_Connection=True;");
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT h.Id, s.streetName from Houses h join Streets s on h.streetId = s.streetId ";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($" House number {reader.GetString(reader.GetOrdinal("Id"))}  Street name {reader.GetString(reader.GetOrdinal("streetName"))}");
            }

            connection.Close();
        }


    }
}
