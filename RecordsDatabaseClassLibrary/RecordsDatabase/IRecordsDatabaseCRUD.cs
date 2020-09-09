using System.Collections.Generic;

namespace RecordsDatabaseClassLibrary.RecordsDatabase
{
    public interface IRecordsDatabaseCRUD
    {
        void AddNewRecordToDatabase(IRecordModel model);
        void DeleteUser(int id);
        List<IRecordModel> GetRecordsFromDatabase();
        void UpdateRecordInDatabase(IRecordModel model);
    }
}