﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSale
{
    public class Program
    {
        public static Connect conn  = new Connect();
        public static List<Car> cars = new List<Car>();

        public static void feladat1()
        {
            
            string sql = "SELECT * FROM cars";
            conn.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            do
            {
                Car car = new Car();

                car.Id = dr.GetInt32(0);
                car.Brand = dr.GetString(1);
                car.Type = dr.GetString(2);
                car.License = dr.GetString(3);
                car.Date = dr.GetInt32(4);

                cars.Add(car);
            } while (dr.Read());

            

            conn.Connection.Close();
        }

        static void feladat2()
        {
            string marka, tipus, azon;
            int ev;
            Console.WriteLine("Kérem az autó márkáját: ");
            marka = Console.ReadLine();

            Console.WriteLine("Kérem az autó típusát: ");
            tipus = Console.ReadLine();

            Console.WriteLine("Kérem az autó azonosítóját: ");
            azon = Console.ReadLine();

            Console.WriteLine("Kérem az autó évjáratát: ");
            ev = int.Parse( Console.ReadLine());
            string sql = $"INSERT INTO `cars`(`Brand`, `Type`, `License`, `Date`) VALUES ('{marka}','{tipus}','{azon}',' {ev}')";
            conn.Connection.Open();

            MySqlCommand cmd = new MySqlCommand(sql,conn.Connection);
            cmd.ExecuteNonQuery();

            conn.Connection.Close();
        }

        public static void feladat3()
        {
            int id, ev;
            Console.WriteLine("Kérem az autó id-ját: ");
            id = int.Parse( Console.ReadLine());

            Console.WriteLine("Kérem az autó évjáratát: ");
            ev = int.Parse(Console.ReadLine());

            string sql = $"UPDATE `cars` SET`Date`='{ev}' WHERE `Id` = {id}";

            conn.Connection.Open();
            MySqlCommand cmd = new MySqlCommand( sql,conn.Connection);
            cmd.ExecuteNonQuery();
            conn.Connection.Close();
        }

        static void Main(string[] args)
        {
            /*feladat1();
            foreach (var item in cars)
            {
                Console.WriteLine($"Márka: {item.Brand}, Azonosító: {item.License}");
            }


            feladat2 ();*/

            feladat3();

            Console.ReadLine();
        }

        
    }
}
