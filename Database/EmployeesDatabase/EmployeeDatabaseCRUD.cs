using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace DatabaseClassLibrary.EmployeesDatabase
{
    public class EmployeeDatabaseCRUD : EmployeesDatabaseConnection, IEmployeeDatabaseCRUD
    {




        /*
                public int GettingLastIncrementedId()
                {
                    try
                    {
                        string query = "select seq from sqlite_sequence where name= Employees";
                        int LastOne;

                        using (connection = new System.Data.SQLite.SQLiteConnection(@"data source=Databases/EmployeesDB.db"))
                        {
                            connection.Open();

                            using (var cmd = new SQLiteCommand(query, connection))
                            {
                                LastOne = Convert.ToInt32(cmd.ExecuteScalar());
                                Console.WriteLine("Getting last Id : " + LastOne.ToString());

                            }

                            connection.Close();
                            return LastOne;
                        }

                    }
                    catch (Exception e)
                    { Console.WriteLine(e); return 0; }



                }
        */


        public void AddNewEmployeeToDatabase(IEmployeeModel person)
        {
            try
            {
                string query = "INSERT INTO Employees(FullName,BirthDay,Qualification,FirstDay) VALUES(@fullName,@birthDay,@qualification,@firstDay)";

                var args = new Dictionary<string, object>
            {
                {"@fullName",person.FullName },
                {"@birthDay",person.BirthDay },
                {"@qualification",person.Qualification },
                {"@firstDay",person.FirstDay}

            };

                base.ExecuteWrite(query, args);
                Console.WriteLine(person.FullName + " added.");

            }
            catch (Exception ex)
            { Console.WriteLine(ex); }
        }

        public void UpdateEmployeeInDatabase(IEmployeeModel person)
        {

            Console.WriteLine(person.ID.ToString() + "  " + person.FullName);
            string query = "UPDATE [Employees] SET FullName=" + person.FullName + ", BirthDay=" + person.BirthDay + ", Qualification=" + person.Qualification + " , FirstDay=" + person.FirstDay + " WHERE ID =" + person.ID.ToString();

            try
            {
                using (connection = new System.Data.SQLite.SQLiteConnection(@"data source=Databases/EmployeesDB.db"))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.CommandText ="update Employees set FullName = :fullname, BirthDay = :birthDay,Qualification= :qualification,FirstDay= :firstDay where ID=:id";
                        command.Parameters.Add("fullname", DbType.String).Value=person.FullName;
                        command.Parameters.Add("birthDay", DbType.String).Value = person.BirthDay;
                        command.Parameters.Add("qualification", DbType.String).Value = person.Qualification;
                        command.Parameters.Add("firstDay", DbType.String).Value = person.FirstDay;
                        command.Parameters.Add("id", DbType.Int64).Value = person.ID;
                        
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
            string query = "Delete from Employees WHERE Id = @id";

            var args = new Dictionary<string, object>
             {
                {"@id", id}
             };

            ExecuteWrite(query, args);
            Console.WriteLine("Deleted " + id.ToString());
        }



        public List<IEmployeeModel> GetEmployeesFromDatabase()
        {
            List<IEmployeeModel> FinalList = new List<IEmployeeModel>();

            string query = "SELECT * FROM  Employees";

            try
            {

                using (connection = new System.Data.SQLite.SQLiteConnection(@"data source=Databases/EmployeesDB.db"))
                {
                    connection.Open();

                    using (var cmd = new SQLiteCommand(query, connection))
                    {

                        SQLiteDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                          


                            FinalList.Add(new EmployeeModel(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4)));

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
