using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;


namespace DatabaseClassLibrary.EmployeesDatabase
{
    public class EmployeesDatabaseConnection : IEmployeesDatabaseConnection
    {

        protected System.Data.SQLite.SQLiteConnection connection = null;

        /*
        private EmployeesDatabaseConnection()
        {
        }
        private static EmployeesDatabaseConnection databaseconnection = null;
        public static EmployeesDatabaseConnection DatabaseConnection
        {
            get
            {
                if (databaseconnection == null)
                {
                    databaseconnection = new EmployeesDatabaseConnection();
                }
                return databaseconnection;
            }
        }

        */


        public void SetConnectionToLocalDatabase()
        {
            if (File.Exists(@"Databases/EmployeesDB.db"))
            {
                Console.WriteLine("Found Database ");
            }
            else CreateLocalDatabase();
        }



        public void CreateLocalDatabase()
        {
            try
            {
                System.Data.SQLite.SQLiteConnection.CreateFile(@"Databases/EmployeesDB.db");
                Console.WriteLine("Succesfully Created Local Database");
                Console.WriteLine("Creating tables...");

                string EmployeesTableQuery = @"CREATE TABLE [Employees] (
                                          [ID]    INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	                                      [FullName]  TEXT NOT NULL,
                                          [BirthDay]  TEXT NOT NULL,
	                                      [Qualification] TEXT,
	                                      [FirstDay]  TEXT NOT NULL                            
                                          )";


                using (connection = new System.Data.SQLite.SQLiteConnection(@"data source=Databases/EmployeesDB.db"))
                {
                    System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(connection);
                    connection.Open();
                    command.CommandText = EmployeesTableQuery;
                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }


        protected void ExecuteWrite(string query, Dictionary<string, object> args)
        {

            try
            {
                using (connection = new System.Data.SQLite.SQLiteConnection(@"data source=Databases/EmployeesDB.db"))
                {
                    connection.Open();

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        foreach (var pair in args)
                            cmd.Parameters.AddWithValue(pair.Key, pair.Value);


                        Console.WriteLine("Changes were made in " + cmd.ExecuteNonQuery().ToString() + " places.");
                    }


                    connection.Close();
                }

            }
            catch (Exception e)
            { Console.WriteLine(e); }

        }






    }
}
