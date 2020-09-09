using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace RecordsDatabaseClassLibrary.RecordsDatabase
{
    public class RecordsDatabaseConnection : IRecordsDatabaseConnection
    {
        protected System.Data.SQLite.SQLiteConnection connection = null;

        public void SetConnectionToLocalDatabase()
        {
            if (File.Exists(@"Databases/RecordsDB.db"))
            {
                Console.WriteLine("Found Database ");
            }
            else CreateLocalDatabase();
        }



        public void CreateLocalDatabase()
        {
            try
            {
                System.Data.SQLite.SQLiteConnection.CreateFile(@"Databases/RecordsDB.db");
                Console.WriteLine("Succesfully Created Local Database");
                Console.WriteLine("Creating tables...");

                string RecordsTableQuery = @"CREATE TABLE [Records] (
                                          [ID]    INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	                                      [Client]  TEXT NOT NULL,
                                          [Car]  TEXT NOT NULL,
	                                      [DateOfEntry] TEXT NOT NULL,
	                                      [Malfunction]  TEXT ,                         
	                                      [Mechanic]  TEXT NOT NULL ,                        
	                                      [Price]  TEXT NOT NULL                       
                                          )";


                using (connection = new System.Data.SQLite.SQLiteConnection(@"data source=Databases/RecordsDB.db"))
                {
                    System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(connection);
                    connection.Open();
                    command.CommandText =RecordsTableQuery;
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
                using (connection = new System.Data.SQLite.SQLiteConnection(@"data source=Databases/RecordsDB.db"))
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
