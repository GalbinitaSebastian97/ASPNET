using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace RecordsDatabaseClassLibrary.RecordsDatabase
{
    public class RecordsDatabaseCRUD : RecordsDatabaseConnection, IRecordsDatabaseCRUD
    {


        public void AddNewRecordToDatabase(IRecordModel model)
        {
            try
            {
                string query = "INSERT INTO Records(Client,Car,DateOfEntry,Malfunction,Mechanic,Price) VALUES(@client,@car,@dateOfEntry,@malfunction,@mechanic,@price)";

                var args = new Dictionary<string, object>
            {

                  {"@client",              model.Client },
                  {"@car",                 model.Car },
                  {"@dateOfEntry",         model.DateOfEntry },
                  {"@malfunction",         model.Malfunction },
                  {"@mechanic",            model.Mechanic },
                  {"@price"     ,          model.Price },

            };

                base.ExecuteWrite(query, args);


            }
            catch (Exception ex)
            { Console.WriteLine(ex); }
        }

        public void UpdateRecordInDatabase(IRecordModel model)
        {


            string query = "UPDATE [Records] SET Client=" + model.Client + ", Car=" + model.Car + ", DateOfEntry=" + model.DateOfEntry + " , Malfunction=" + model.Malfunction + " , Mechanic=" + model.Mechanic + " Price=" + model.Price + " WHERE ID =" + model.ID.ToString();

            try
            {
                using (connection = new System.Data.SQLite.SQLiteConnection(@"data source=Databases/RecordsDB.db"))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.CommandText = "update Records set Client = :client, Car = :car,DateOfEntry= :dateOfEntry,Malfunction= :malfunction,Mechanic= :mechanic,Price= :price where ID=:id";
                        command.Parameters.Add("client", DbType.String).Value = model.Client;
                        command.Parameters.Add("car", DbType.String).Value = model.Car;
                        command.Parameters.Add("dateOfEntry", DbType.String).Value = model.DateOfEntry;
                        command.Parameters.Add("malfunction", DbType.String).Value = model.Malfunction;
                        command.Parameters.Add("mechanic", DbType.String).Value = model.Mechanic;
                        command.Parameters.Add("price", DbType.String).Value = model.Price;
                        command.Parameters.Add("id", DbType.Int64).Value = model.ID;

                        Console.WriteLine(command.ExecuteNonQuery());

                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex); }

        }


        public void DeleteUser(int id)
        {
            string query = "Delete from Records WHERE Id = @id";

            var args = new Dictionary<string, object>
             {
                {"@id", id}
             };

            ExecuteWrite(query, args);
            Console.WriteLine("Deleted " + id.ToString());
        }



        public List<IRecordModel> GetRecordsFromDatabase()
        {
            List<IRecordModel> FinalList = new List<IRecordModel>();

            string query = "SELECT * FROM  Records";

            try
            {

                using (connection = new System.Data.SQLite.SQLiteConnection(@"data source=Databases/RecordsDB.db"))
                {
                    connection.Open();

                    using (var cmd = new SQLiteCommand(query, connection))
                    {

                        SQLiteDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {



                            FinalList.Add(new RecordModel(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6)));

                        };

                    }

                    connection.Close();
                    return FinalList;

                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex); return null; }


        }







    }
}



