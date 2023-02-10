using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHistorywithSQL
{
    internal class Program
    {
        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database no found");
            }
            return sqlite_conn;
        }

        public static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand cmd;
            string strCosts = "CREATE TABLE if not exists Costs(id INTEGER PRIMARY KEY AUTOINCREMENT, cost double, place_id INT)";
            string strPlaces = "CREATE TABLE if not exists Places(id INTEGER PRIMARY KEY AUTOINCREMENT, place VARCHAR(20), date VARCHAR(20))";
            cmd= conn.CreateCommand();

            cmd.CommandText = strCosts;
            cmd.ExecuteNonQuery();

            cmd.CommandText= strPlaces;
            cmd.ExecuteNonQuery();
        }
        static void InsertData(SQLiteConnection conn)
        {
            try
            {
                conn.Open();

            }
            catch (Exception)
            {

            }

            Console.Write("Enter the place: ");
            string place = Console.ReadLine();
            Console.Write("Enter the date: ");
            string date1 = Console.ReadLine();
            Console.Write("Enter the cost: ");
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            double cost = Convert.ToDouble(Console.ReadLine(), provider);
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Places(place, date) VALUES('" + place + "','" + date1 + "' ); ";
            //Console.WriteLine(sqlite_cmd.CommandText);
            sqlite_cmd.ExecuteNonQuery();
            //------------------------
            SQLiteDataReader sqlite_datareader;
            //SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Places ";
            int place_id = 0;
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                place_id = (int)sqlite_datareader.GetInt64(0);
            }
            //------------------------
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Costs(cost, place_id) VALUES(" + cost + "," + place_id + " ); ";
            Console.WriteLine(sqlite_cmd.CommandText);
            sqlite_cmd.ExecuteNonQuery();
            conn.Close();
        }
        static void ReadData(SQLiteConnection conn)
        {
            try
            {
                conn.Open();

            }
            catch (Exception)
            {

            }
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT places.id, places.place, places.date, costs.cost FROM Places, Costs WHERE places.id = costs.place_id";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            double average=0;
            int time = 0;
            while (sqlite_datareader.Read())
            {
                int col0 = (int)sqlite_datareader.GetInt64(0);
                string col1 = sqlite_datareader.GetString(1);
                string col2 = sqlite_datareader.GetString(2);
                double col3= sqlite_datareader.GetFloat(3);
                Console.WriteLine("{0} {1} {2} {3}EUR", col0,col1,col2,col3);
                average += col3;
                time++;
            }
            Console.WriteLine("Average spending is {0} EUROS", (int)(average/time));
            conn.Close();
        }
        static void ReadDataPlaces(SQLiteConnection conn, string place)
        {
            try
            {
                conn.Open();
            }
            catch (Exception)
            {

                
            }
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT places.place, places.date, costs.cost FROM Places, Costs WHERE places.id = costs.place_id and " + "'" + place + "' = places.place;";
            //Console.WriteLine(sqlite_cmd.CommandText);
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                //int col0 = (int)sqlite_datareader.GetInt64(0);
                string col1 = sqlite_datareader.GetString(0);
                string col2 = sqlite_datareader.GetString(1);
                double col3 = sqlite_datareader.GetFloat(2);
                Console.WriteLine("{0} {1} {2}", col1, col2,col3);
            }
            conn.Close();
        }

        static void DeletePlaces(SQLiteConnection conn, int id)
        {
            try
            {
                conn.Open();
            }
            catch (Exception)
            {

            }
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            SQLiteCommand sqlite_cmd_2;
            sqlite_cmd_2 = conn.CreateCommand();
            sqlite_cmd.CommandText = "Delete FROM Places WHERE places.id = " + id + " ;";
            sqlite_cmd_2.CommandText = "Delete FROM Costs WHERE costs.place_id = " + id + " ;";
            //Console.WriteLine(sqlite_cmd.CommandText);
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd_2.ExecuteNonQuery();
            conn.Close();
        }
        static void Main(string[] args)
        {
            SQLiteConnection conn;
            conn = CreateConnection();
            int item = 1;
            Console.WriteLine("1: Display all data: ");
            Console.WriteLine("2: Travels to given places: ");
            Console.WriteLine("3: Insert Data: ");
            Console.WriteLine("4: Delete Data: ");
            Console.WriteLine("0: Exit");

            while (true)
            {
                item = Convert.ToInt32(Console.ReadLine());
                if (item == 0)
                {
                    Environment.Exit(0);
                }
                if (item == 1)
                {

                    ReadData(conn);
                }
                if (item == 2)
                {
                    Console.WriteLine("Show all the trips to: ");
                    string place = Console.ReadLine();
                    ReadDataPlaces(conn, place);
                }
                if (item == 3)
                {
                    Console.WriteLine("Insert Data");
                    CreateTable(conn);
                    InsertData(conn);

                }
                if (item == 4)
                {
                    Console.WriteLine("Delete data");
                    Console.Write("Enter the id of the place that you would want to delete:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    DeletePlaces(conn, id);
                }
            }
            
            Console.ReadLine();
        }
    }
}
