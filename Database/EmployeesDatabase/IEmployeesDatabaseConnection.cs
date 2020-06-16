namespace DatabaseClassLibrary.EmployeesDatabase
{
    public interface IEmployeesDatabaseConnection
    {
        void CreateLocalDatabase();
        void SetConnectionToLocalDatabase();
    }
}