namespace RecordsDatabaseClassLibrary.RecordsDatabase
{
    public interface IRecordsDatabaseConnection
    {
        void CreateLocalDatabase();
        void SetConnectionToLocalDatabase();
    }
}