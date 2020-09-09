using RecordsDatabaseClassLibrary.RecordsDatabase;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordsDatabaseClassLibrary
{
  
        public static class RecordsAbstractizationFactory
        {

          

            public static IRecordModel CreateRecordInstance(string Client, string Car, string DateOfEntry, string Malfunction, string Mechanic, string Price)
            {
                return new RecordsDatabaseClassLibrary.RecordsDatabase.RecordModel(Client,Car,DateOfEntry,Malfunction,Mechanic,Price);
            }

            public static IRecordModel CreateRecordInstance(int ID, string Client, string Car, string DateOfEntry, string Malfunction, string Mechanic, string Price)
            {
                return new RecordsDatabaseClassLibrary.RecordsDatabase.RecordModel(ID, Client, Car, DateOfEntry, Malfunction, Mechanic, Price);
            }

            public static IRecordsDatabaseCRUD CreateInstanceForCRUDOperations()
            {
            return new RecordsDatabaseClassLibrary.RecordsDatabase.RecordsDatabaseCRUD();
            }

            public static IRecordsDatabaseConnection CreateRecordsDatabaseConnection()
            {
            return new RecordsDatabaseClassLibrary.RecordsDatabase.RecordsDatabaseConnection();
            }


            public static List<IRecordModel> ReturningRecordsList()
            {
            return new RecordsDatabaseClassLibrary.RecordsDatabase.RecordsDatabaseCRUD().GetRecordsFromDatabase();
            }

          



        
    }
}
