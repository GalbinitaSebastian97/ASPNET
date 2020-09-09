namespace RecordsDatabaseClassLibrary.RecordsDatabase
{
    public interface IRecordModel
    {
        string Car { get; set; }
        string Client { get; set; }
        string DateOfEntry { get; set; }
        int ID { get; set; }
        string Malfunction { get; set; }
        string Mechanic { get; set; }
        string Price { get; set; }
    }
}